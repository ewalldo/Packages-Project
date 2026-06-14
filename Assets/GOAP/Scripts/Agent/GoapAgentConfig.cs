using GOAP.Planning;
using UnityEngine;

namespace GOAP.Agent
{
    /// <summary>
    /// ScriptableObject configuration asset for a GoapAgent.
    /// Create via Assets > Create > Scriptable Objects > GOAP > Agent Config
    /// and assign to the GoapAgent component in the Inspector.
    ///
    /// Separating configuration from the MonoBehaviour means multiple
    /// agents of the same type share one config asset, and changing
    /// a value propagates to all agents instantly.
    /// </summary>
    [CreateAssetMenu(fileName = "GoapAgentConfig", menuName = "Scriptable Objects/GOAP/Agent Config")]
    public class GoapAgentConfig : ScriptableObject
    {
        // - Planning -

        [Header("Planning")]
        [Tooltip("Planner configuration asset. Leave empty to use default settings.")]
        [SerializeField] private PlannerSettings plannerSettings;

        [Tooltip("How often (in seconds) the agent re-evaluates its goal and replans even if nothing obviously changed. Set to 0 to disable periodic replanning.")]
        [SerializeField, Min(0f)] private float replanInterval = 2f;

        [Tooltip("How many consecutive planning failures are allowed before the agent enters PlanningFailed state and stops trying. -1 means unlimited retries.")]
        [SerializeField] private int maxConsecutivePlanFailures = 3;

        // - Goal Selection -

        [Header("Goal Selection")]
        [Tooltip("How often (in seconds) goal priority is re-evaluated. Lower values give more responsive goal switching at higher CPU cost.")]
        [SerializeField, Min(0f)] private float goalEvaluationInterval = 0.5f;

        [Tooltip("If enabled, the agent will interrupt the current plan and replan immediately whenever goal selection produces a different goal." +
                 "If disabled, goal re-evaluation only triggers replanning after the current plan naturally ends.")]
        [SerializeField] private bool allowMidPlanGoalInterruption = true;

        // - Sensing -

        [Header("Sensing")]
        [Tooltip("If enabled, sensors tick even while the agent is in Planning or Idle states. " +
                 "Recommended: true. Disabling saves CPU but may cause stale world state.")]
        [SerializeField] private bool tickSensorsWhileIdle = true;

        // - Tick Mode -

        [Header("Update Loop")]
        [Tooltip("Which Unity update loop drives this agent.")]
        [SerializeField] private AgentTickMode tickMode = AgentTickMode.Update;

        // - Debug -

        [Header("Debug")]
        [Tooltip("If enabled, the agent logs every state transition and replan request.")]
        [SerializeField] private bool debugLog = false;

        [Tooltip("If enabled, the agent logs the full plan each time a new one is formed.")]
        [SerializeField] private bool debugLogPlans = false;

        // - Public Accessors -

        public PlannerSettings PlannerSettings => plannerSettings;
        public float ReplanInterval => replanInterval;
        public int MaxConsecutivePlanFail => maxConsecutivePlanFailures;
        public float GoalEvaluationInterval => goalEvaluationInterval;
        public bool AllowMidPlanInterruption => allowMidPlanGoalInterruption;
        public bool TickSensorsWhileIdle => tickSensorsWhileIdle;
        public AgentTickMode TickMode => tickMode;
        public bool DebugLog => debugLog;
        public bool DebugLogPlans => debugLogPlans;

        // - Default Factory -

        /// <summary>
        /// Creates a default config instance at runtime when no asset is assigned.
        /// </summary>
        public static GoapAgentConfig CreateDefault()
        {
            GoapAgentConfig config = CreateInstance<GoapAgentConfig>();
            config.plannerSettings = PlannerSettings.CreateDefault();
            config.replanInterval = 2f;
            config.maxConsecutivePlanFailures = 3;
            config.goalEvaluationInterval = 0.5f;
            config.allowMidPlanGoalInterruption = true;
            config.tickSensorsWhileIdle = true;
            config.tickMode = AgentTickMode.Update;
            config.debugLog = false;
            config.debugLogPlans = false;

            return config;
        }
    }
}