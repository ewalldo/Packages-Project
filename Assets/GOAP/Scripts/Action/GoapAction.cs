using System.Collections.Generic;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Actions
{
    /// <summary>
    /// Abstract MonoBehaviour base class for all GOAP actions.
    /// Inherit from this to create concrete actions and attach them
    /// as components on a GoapAgent's GameObject.
    ///
    /// Subclasses must implement:
    ///   - BuildPreconditions()  : define what must be true before this action runs
    ///   - BuildEffects()        : define what becomes true after this action runs
    ///   - OnTick()              : the per-frame execution logic
    ///
    /// Subclasses may optionally override:
    ///   - GetCost()             : return a dynamic cost (default is _baseCost)
    ///   - IsExecutable()        : runtime pre-execution validation (default is true)
    ///   - OnStart()             : called once before the first tick
    ///   - OnStop()              : called once after the last tick
    /// </summary>
    public abstract class GoapAction : MonoBehaviour, IAction
    {
        // - Inspector -

        [Header("Action Settings")]
        [Tooltip("Human-readable name for this action. Defaults to class name if left empty.")]
        [SerializeField] private string actionName;

        [Tooltip("Base planning cost for this action. Lower cost = planner prefers this action.")]
        [SerializeField, Min(0f)] private float baseCost = 1f;

        [Tooltip("If enabled, this action will log lifecycle events to the console.")]
        [SerializeField] private bool debugLog = false;

        // - Internal State -

        private List<WorldStateFact> preconditions;
        private List<WorldStateFact> effects;
        private ActionStatus status = ActionStatus.Idle;
        private bool isInitialized;

        // - IAction: Identity -

        public string Name => string.IsNullOrEmpty(actionName) ? GetType().Name : actionName;

        // - IAction: Planning Data -

        public IReadOnlyList<WorldStateFact> Preconditions
        {
            get
            {
                EnsureInitialized();
                return preconditions;
            }
        }

        public IReadOnlyList<WorldStateFact> Effects
        {
            get
            {
                EnsureInitialized();
                return effects;
            }
        }

        /// <summary>
        /// Returns the base cost by default.
        /// Override to return a dynamic cost based on runtime state.
        /// </summary>
        public virtual float GetCost(WorldState currentState) => baseCost;

        // - IAction: Runtime Validity -

        /// <summary>
        /// Returns true by default.
        /// Override to add runtime guards the planner cannot predict.
        /// </summary>
        public virtual bool IsExecutable(WorldState currentState) => true;

        // - IAction: Execution Lifecycle -

        /// <summary>
        /// Called once before the first OnTick(). Override for setup logic.
        /// Always call base.OnStart() when overriding.
        /// </summary>
        public virtual void OnStart(ActionContext context)
        {
            status = ActionStatus.Running;

            if (debugLog)
                Debug.Log($"[GOAP] Action started: {Name}", this);
        }

        /// <summary>
        /// Called every frame by the PlanExecutor.
        /// Must be implemented: return Continue(), Complete(), or Fail().
        /// </summary>
        public abstract ActionStatus OnTick(ActionContext context);

        /// <summary>
        /// Called once after the action ends. Override for cleanup logic.
        /// Always call base.OnStop() when overriding.
        /// </summary>
        public virtual void OnStop(ActionContext context, ActionStopReason reason)
        {
            status = ActionStatus.Idle;

            if (debugLog)
                Debug.Log($"[GOAP] Action stopped: {Name} | Reason: {reason}", this);
        }

        // - Protected API -

        /// <summary>
        /// Override to define this action's preconditions.
        /// Called once and cached. Use the helper methods below for clarity.
        /// </summary>
        /// <example>
        /// protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        /// {
        ///     preconditions.Add(WorldStateFact.Create(WorldKeys.HasWeapon, true));
        ///     preconditions.Add(WorldStateFact.Create(WorldKeys.IsEnemyVisible, true));
        /// }
        /// </example>
        protected abstract void BuildPreconditions(List<WorldStateFact> preconditions);

        /// <summary>
        /// Override to define this action's effects.
        /// Called once and cached.
        /// </summary>
        /// <example>
        /// protected override void BuildEffects(List<WorldStateFact> effects)
        /// {
        ///     effects.Add(WorldStateFact.Create(WorldKeys.IsEnemyDead, true));
        /// }
        /// </example>
        protected abstract void BuildEffects(List<WorldStateFact> effects);

        /// <summary>
        /// Convenience method for subclasses to signal failure from OnTick.
        /// More readable than: return ActionStatus.Failed
        /// </summary>
        protected ActionStatus Fail()
        {
            if (debugLog)
                Debug.LogWarning($"[GOAP] Action failed: {Name}", this);

            status = ActionStatus.Failed;
            return status;
        }

        /// <summary>Convenience method for subclasses to signal success from OnTick.</summary>
        protected ActionStatus Complete()
        {
              if (debugLog)
                Debug.Log($"[GOAP] Action completed: {Name}", this);

            status = ActionStatus.Completed;
            return status;
        }

        /// <summary>Convenience method for subclasses to signal continuation from OnTick.</summary>
        protected ActionStatus Continue()
        {
            if (debugLog)
                Debug.Log($"[GOAP] Action running: {Name}", this);

            status = ActionStatus.Running;
            return status;
        }

        // - Private Helpers -

        private void EnsureInitialized()
        {
            if (isInitialized)
                return;

            preconditions = new List<WorldStateFact>();
            effects = new List<WorldStateFact>();

            BuildPreconditions(preconditions);
            BuildEffects(effects);

            isInitialized = true;
        }
    }
}