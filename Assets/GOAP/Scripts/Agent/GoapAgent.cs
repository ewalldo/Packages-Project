using System;
using System.Collections.Generic;
using GOAP.Actions;
using GOAP.Execution;
using GOAP.Goals;
using GOAP.Planning;
using GOAP.Sensing;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Agent
{
    /// <summary>
    /// Top-level MonoBehaviour that owns and orchestrates the full GOAP loop.
    ///
    /// Responsibilities (in order each frame):
    ///   1. Tick SensorContext timing
    ///   2. Tick all ISensors  → writes to WorldState and Blackboard
    ///   3. Evaluate goals     → GoalSelector picks the best IGoal
    ///   4. Request replan     → if goal changed, plan failed, or interval elapsed
    ///   5. Run planner        → GoapPlanner produces a GoapPlan
    ///   6. Tick executor      → PlanExecutor steps through actions
    ///   7. React to terminal  → handle plan success, failure, or no-goal
    ///
    /// Setup:
    ///   - Attach GoapAgent to a GameObject
    ///   - Attach GoapSensor subclasses as sibling components or attach them to a dedicated Sensors parent object
    ///   - Attach GoapGoal subclasses as sibling components or attach them to a dedicated Goals parent object
    ///   - Attach GoapAction subclasses as sibling components or attach them to a dedicated Actions parent object
    ///   - Assign a GoapAgentConfig asset in the Inspector
    /// </summary>
    [DisallowMultipleComponent]
    public class GoapAgent : MonoBehaviour
    {
        // - Inspector -

        [Header("Configuration")]
        [Tooltip("Agent configuration asset. A default config is used if left empty.")]
        [SerializeField] private GoapAgentConfig config;

        [Tooltip("The main gameObject to pass as context to Actions and Sensors. If not set, will use the gameObject which this component is attached to")]
        [SerializeField] private GameObject agentObject;

        [Tooltip("The object which the goals are attached to it. If not set, will use the gameObject which this component is attached to")]
        [SerializeField] private GameObject goalsParent;

        [Tooltip("The object which the actions are attached to it. If not set, will use the gameObject which this component is attached to")]
        [SerializeField] private GameObject actionsParent;

        [Tooltip("The object which the sensors are attached to it. If not set, will use the gameObject which this component is attached to")]
        [SerializeField] private GameObject sensorsParent;

        // - Subsystems -

        private WorldState worldState;
        private Blackboard blackboard;
        private SensorContext sensorContext;
        private ActionContext actionContext;

        private GoalSelector goalSelector;
        private IPlanner planner;
        private PlanExecutor executor;

        private GoapAction[] actions;
        private GoapSensor[] sensors;

        // - Custom IAgentComponents -

        private readonly List<IAgentComponent> agentComponents = new List<IAgentComponent>();

        // - State -

        private AgentState agentState = AgentState.Uninitialized;
        private ReplanRequest pendingReplan;
        private int consecutivePlanFailures;

        // - Timers -

        private float timeSinceLastGoalEval;
        private float timeSinceLastReplan;
        private float totalTime;

        // - Public API -

        /// <summary>The agent's current live world state. Read-only from outside.</summary>
        public WorldState WorldState => worldState;

        /// <summary>The shared blackboard for sensor/action data exchange.</summary>
        public Blackboard Blackboard => blackboard;

        /// <summary>The agent's current high-level state.</summary>
        public AgentState State => agentState;

        /// <summary>The goal currently being pursued. Null if none.</summary>
        public IGoal ActiveGoal => goalSelector?.CurrentGoal;

        /// <summary>The plan currently being executed. Null if none.</summary>
        public GoapPlan ActivePlan => executor?.CurrentPlan;

        /// <summary>The action currently executing. Null if none.</summary>
        public IAction ActiveAction => executor?.CurrentAction;

        /// <summary>
        /// Exposes the PlanExecutor's events for external subscription.
        /// </summary>
        public ExecutionEvents ExecutionEvents => executor?.Events;

        /// <summary>
        /// The object which the goals are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.</summary>
        public GameObject GoalsParent => goalsParent ?? gameObject;

        /// <summary>
        /// The object which the actions are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.</summary>
        public GameObject ActionsParent => actionsParent ?? gameObject;

        /// <summary>
        /// The object which the sensors are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.</summary>
        public GameObject SensorsParent => sensorsParent ?? gameObject;

        /// <summary>
        /// Event raised whenever the agent transitions to a new AgentState.
        /// </summary>
        public event Action<AgentState, AgentState> OnAgentStateChanged;

        // - Unity Lifecycle -

        private void Awake()
        {
            config ??= GoapAgentConfig.CreateDefault();
            InitializeSubsystems();
        }

        private void Start()
        {
            InitializeSensors();
            TransitionToState(AgentState.Active);
            RequestReplan(ReplanRequest.Reselect(ReplanReason.NoPlanExists));
        }

        private void Update()
        {
            if (config.TickMode == AgentTickMode.Update)
                Tick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (config.TickMode == AgentTickMode.FixedUpdate)
                Tick(Time.fixedDeltaTime);
        }

        private void OnDestroy() => Shutdown();

        private void OnDisable()
        {
            if (agentState != AgentState.Disabled)
                TransitionToState(AgentState.Disabled);
        }

        private void OnEnable()
        {
            if (agentState == AgentState.Disabled)
                TransitionToState(AgentState.Active);
        }

        // - Public Control API -

        /// <summary>
        /// Manually drives the agent by one tick.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (agentState == AgentState.Uninitialized || agentState == AgentState.Disabled)
                return;

            totalTime += deltaTime;

            TickSensors(deltaTime);
            TickGoalEvaluation(deltaTime);
            TickPlanning(deltaTime);
            TickExecution(deltaTime);
            TickAgentComponents(deltaTime);
        }

        /// <summary>
        /// Forces an immediate replan for the currently active goal. Can be called from external systems (e.g. when a major world event occurs).
        /// </summary>
        public void ForceReplan()
        {
            RequestReplan(ReplanRequest.ForGoal(ActiveGoal, ReplanReason.ForcedByExternal));
        }

        /// <summary>
        /// Sets the agent's state directly. Use to pause, disable, or resume the agent from external systems.
        /// </summary>
        public void SetState(AgentState newState) => TransitionToState(newState);

        // - IAgentComponent Registration -

        /// <summary>
        /// Registers a custom IAgentComponent to be driven by this agent's lifecycle.
        /// </summary>
        public void RegisterComponent(IAgentComponent component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            if (agentComponents.Contains(component))
                return;

            agentComponents.Add(component);

            // If the agent is already initialized, initialize the late-registered component
            if (agentState != AgentState.Uninitialized)
                component.Initialize(this);
        }

        /// <summary>Unregisters and shuts down a previously registered component.</summary>
        public void UnregisterComponent(IAgentComponent component)
        {
            if (component == null)
                return;
            if (agentComponents.Remove(component))
                component.Shutdown();
        }

        // - Initialization -

        private void InitializeSubsystems()
        {
            // - Shared data -
            worldState = new WorldState();
            blackboard = new Blackboard();

            // - Contexts -
            sensorContext = new SensorContext(agentObject != null ? agentObject : gameObject, worldState, blackboard);
            actionContext = new ActionContext(agentObject != null ? agentObject : gameObject, worldState, blackboard);

            // - Goal selector -
            goalSelector = new GoalSelector();

            GoapGoal[] goals = goalsParent != null ? goalsParent.GetComponents<GoapGoal>() : GetComponents<GoapGoal>();
            foreach (GoapGoal goal in goals)
                goalSelector.RegisterGoal(goal);

            // - Planner -
            planner = new GoapPlanner(config.PlannerSettings);

            // - Executor -
            executor = new PlanExecutor(actionContext, config.DebugLog);
            SubscribeToExecutorEvents();

            // - Cache action and sensor arrays -
            actions = actionsParent != null ? actionsParent.GetComponents<GoapAction>() : GetComponents<GoapAction>();
            sensors = sensorsParent != null ? sensorsParent.GetComponents<GoapSensor>() : GetComponents<GoapSensor>();

            // - Initialize registered IAgentComponents -
            foreach (IAgentComponent component in agentComponents)
                component.Initialize(this);

            if (config.DebugLog)
                Debug.Log($"[GoapAgent] Initialized: {name} | " +
                    $"Goals: {goals.Length} | " +
                    $"Actions: {actions.Length} | " +
                    $"Sensors: {sensors.Length}", this);
        }

        private void InitializeSensors()
        {
            foreach (GoapSensor sensor in sensors)
                sensor.Initialize(sensorContext);
        }

        // - GOAP Loop Steps -

        /// <summary>Step 1: Tick all sensors to update WorldState and Blackboard.</summary>
        private void TickSensors(float deltaTime)
        {
            bool shouldTickSensors =
                agentState == AgentState.Active     ||
                agentState == AgentState.Planning   ||
                agentState == AgentState.SensingOnly ||
                (agentState == AgentState.Idle && config.TickSensorsWhileIdle);

            if (!shouldTickSensors)
                return;

            sensorContext.Tick(deltaTime, totalTime);

            foreach (GoapSensor sensor in sensors)
                sensor.UpdateSensor(sensorContext);
        }

        /// <summary>Step 2: Evaluate goals and detect goal changes.</summary>
        private void TickGoalEvaluation(float deltaTime)
        {
            if (agentState == AgentState.SensingOnly || agentState == AgentState.Disabled)
                return;

            timeSinceLastGoalEval += deltaTime;
            if (timeSinceLastGoalEval < config.GoalEvaluationInterval)
                return;
            timeSinceLastGoalEval = 0f;

            IGoal previousGoal = goalSelector.CurrentGoal;
            GoalSelectionResult result = goalSelector.SelectBestGoal(worldState, blackboard);

            switch (result.Status)
            {
                case GoalSelectionStatus.NoneValid:
                case GoalSelectionStatus.AllSatisfied:
                    HandleNoValidGoal();
                    return;

                case GoalSelectionStatus.Found:
                    // Goal changed mid-execution: request a replan
                    if (result.SelectedGoal != previousGoal)
                    {
                        //if (config.DebugLog)
                        //    Debug.Log($"[GoapAgent] Goal changed: {previousGoal?.Name ?? "None"} → {result.SelectedGoal.Name}", this);

                        //if (executor.IsRunning && config.AllowMidPlanInterruption)
                        //    executor.InterruptPlan(PlanInterruptReason.GoalChanged);

                        //RequestReplan(ReplanRequest.ForGoal(result.SelectedGoal, ReplanReason.GoalChanged));

                        if ((executor.IsRunning && config.AllowMidPlanInterruption) || previousGoal == null)
                        {
                            if (config.DebugLog)
                                Debug.Log($"[GoapAgent] Goal changed: {previousGoal?.Name ?? "None"} → {result.SelectedGoal.Name}", this);

                            executor.InterruptPlan(PlanInterruptReason.GoalChanged);
                            RequestReplan(ReplanRequest.ForGoal(result.SelectedGoal, ReplanReason.GoalChanged));
                        }
                    }
                    break;
            }
        }

        /// <summary>Step 3: Process any pending replan requests.</summary>
        private void TickPlanning(float deltaTime)
        {
            if (agentState == AgentState.SensingOnly || agentState == AgentState.Disabled)
                return;

            // - Periodic replan timer -
            if (config.ReplanInterval > 0f && agentState == AgentState.Active)
            {
                timeSinceLastReplan += deltaTime;
                if (timeSinceLastReplan >= config.ReplanInterval)
                {
                    timeSinceLastReplan = 0f;

                    if (!executor.IsRunning)
                        RequestReplan(ReplanRequest.ForGoal(goalSelector.CurrentGoal, ReplanReason.PeriodicReplan));
                }
            }

            // - Process pending replan -
            if (!pendingReplan.IsPending)
                return;

            IGoal goalToPlanFor = pendingReplan.TargetGoal ?? goalSelector.CurrentGoal;

            if (goalToPlanFor == null)
            {
                HandleNoValidGoal();
                pendingReplan = ReplanRequest.None;
                return;
            }

            TransitionToState(AgentState.Planning);

            if (config.DebugLog)
                Debug.Log($"[GoapAgent] Planning for goal: '{goalToPlanFor.Name}' | Reason: {pendingReplan.Reason}", this);

            GoapPlan plan = planner.CreatePlan(worldState, goalToPlanFor, actions);
            pendingReplan = ReplanRequest.None;

            if (plan != null)
            {
                consecutivePlanFailures = 0;

                if (config.DebugLogPlans)
                    Debug.Log($"[GoapAgent] Plan formed:\n{plan}", this);

                executor.StartPlan(plan);
                TransitionToState(AgentState.Active);
            }
            else
            {
                HandlePlanningFailure(goalToPlanFor);
            }
        }

        /// <summary>Step 4: Tick the plan executor.</summary>
        private void TickExecution(float deltaTime)
        {
            if (agentState != AgentState.Active)
                return;
            if (!executor.IsRunning)
                return;

            executor.Tick();
        }

        /// <summary>Step 5: Tick all registered IAgentComponents.</summary>
        private void TickAgentComponents(float deltaTime)
        {
            foreach (IAgentComponent component in agentComponents)
                component.Tick(deltaTime);
        }

        // - Executor Event Handlers -

        private void SubscribeToExecutorEvents()
        {
            executor.Events.OnPlanSucceeded += HandlePlanSucceeded;
            executor.Events.OnPlanFailed += HandlePlanExecutionFailed;
        }

        private void HandlePlanSucceeded(GoapPlan plan)
        {
            if (config.DebugLog)
                Debug.Log($"[GoapAgent] Plan succeeded for goal: '{ActiveGoal?.Name}'", this);

            executor.Reset();
            consecutivePlanFailures = 0;
            timeSinceLastReplan = 0f;
            goalSelector.ClearCurrentGoal(GoalDeactivationReason.Completed);

            // Re-evaluate goals now that the world state has changed
            RequestReplan(ReplanRequest.Reselect(ReplanReason.NoPlanExists));
        }

        private void HandlePlanExecutionFailed(GoapPlan plan, IAction failedAction)
        {
            if (config.DebugLog)
                Debug.LogWarning($"[GoapAgent] Plan execution failed. Action: '{failedAction.Name}' | Goal: '{ActiveGoal?.Name}'", this);

            executor.Reset();
            HandlePlanningFailure(ActiveGoal);
            goalSelector.ClearCurrentGoal(GoalDeactivationReason.PlanFailed);
        }

        // - State Transition Helpers -

        private void HandleNoValidGoal()
        {
            if (agentState == AgentState.Idle)
                return;

            if (config.DebugLog)
                Debug.Log("[GoapAgent] No valid goal found. Entering Idle.", this);

            if (executor.IsRunning)
                executor.InterruptPlan(PlanInterruptReason.GoalChanged);

            executor.Reset();
            TransitionToState(AgentState.Idle);
            goalSelector.ClearCurrentGoal(GoalDeactivationReason.Invalidated);
        }

        private void HandlePlanningFailure(IGoal goal)
        {
            consecutivePlanFailures++;

            int maxFailures = config.MaxConsecutivePlanFail;
            bool limitReached = maxFailures >= 0 && consecutivePlanFailures >= maxFailures;

            if (limitReached)
            {
                if (config.DebugLog)
                    Debug.LogWarning($"[GoapAgent] Planning failed {consecutivePlanFailures} consecutive time(s) for goal '{goal?.Name}'. " +
                        $"Entering PlanningFailed state.", this);

                TransitionToState(AgentState.PlanningFailed);
            }
            else
            {
                if (config.DebugLog)
                    Debug.LogWarning($"[GoapAgent] No plan found for goal '{goal?.Name}'. Retry {consecutivePlanFailures}/{maxFailures}.", this);

                // Schedule a retry on next planning tick
                RequestReplan(ReplanRequest.ForGoal(goal, ReplanReason.PlanFailed));
            }
        }

        private void RequestReplan(ReplanRequest request)
        {
            pendingReplan = request;
        }

        private void TransitionToState(AgentState newState)
        {
            if (agentState == newState)
                return;

            AgentState previous = agentState;
            agentState = newState;

            if (config.DebugLog)
                Debug.Log($"[GoapAgent] State: {previous} → {newState}", this);

            // Notify all registered components
            foreach (IAgentComponent component in agentComponents)
                component.OnAgentStateChanged(previous, newState);

            // Notify external listeners
            OnAgentStateChanged?.Invoke(previous, newState);

            // Handle Disabled state — stop everything
            if (newState == AgentState.Disabled)
            {
                if (executor.IsRunning)
                    executor.InterruptPlan(PlanInterruptReason.AgentStopped);

                executor.Reset();
                goalSelector.ClearCurrentGoal(GoalDeactivationReason.Invalidated);
            }
        }

        // - Shutdown -

        private void Shutdown()
        {
            TransitionToState(AgentState.Disabled);

            foreach (GoapSensor sensor in sensors)
                sensor.Teardown();

            foreach (IAgentComponent component in agentComponents)
                component.Shutdown();

            agentComponents.Clear();

            if (config.DebugLog)
                Debug.Log($"[GoapAgent] Shut down: {name}", this);
        }
    }
}