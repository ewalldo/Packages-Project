using GOAP.Sensing;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Goals
{
    /// <summary>
    /// Abstract MonoBehaviour base class for all GOAP goals.
    /// Inherit from this to create concrete goals and attach them
    /// as components on a GoapAgent's GameObject.
    ///
    /// Subclasses must implement:
    ///   - GetPriority()       : return how important this goal is right now
    ///   - IsValid()           : return whether this goal should be considered
    ///   - BuildDesiredState() : define what world state this goal desires
    ///
    /// Subclasses may optionally override:
    ///   - IsSatisfied()       : checks if the current state already satisfies the goal's desired state
    ///   - OnGoalActivated()   : called when this goal becomes the active goal
    ///   - OnGoalDeactivated() : called when this goal is deactivated
    /// </summary>
    public abstract class GoapGoal : MonoBehaviour, IGoal
    {
        // - Inspector -

        [Header("Goal Settings")]
        [Tooltip("Human-readable name for this goal. Defaults to the class name if left empty.")]
        [SerializeField] private string goalName;

        [Tooltip("If enabled, this goal will log lifecycle events to the console.")]
        [SerializeField] private bool debugLog = false;

        // - Internal State -

        private WorldState desiredState;
        private bool isInitialized;

        // - IGoal: Identity -

        public string Name => string.IsNullOrEmpty(goalName) ? GetType().Name : goalName;

        // - IGoal: Planning Data -

        /// <summary>
        /// The desired state is built once on first access and cached.
        /// Override BuildDesiredState() to populate it.
        /// It is rebuilt every time the goal is activated to stay current.
        /// </summary>
        public WorldState DesiredState
        {
            get
            {
                if (!isInitialized)
                    RebuildDesiredState();
                return desiredState;
            }
        }

        /// <inheritdoc/>
        public abstract float GetPriority(WorldState currentState, Blackboard blackboard);

        // - IGoal: Validity -

        /// <inheritdoc/>
        public abstract bool IsValid(WorldState currentState);

        /// <summary>
        /// Default implementation checks if the current state already satisfies
        /// this goal's desired state. Override for custom satisfaction logic.
        /// </summary>
        public virtual bool IsSatisfied(WorldState currentState)
        {
            return currentState.Satisfies(DesiredState);
        }

        // - IGoal: Lifecycle -

        /// <summary>
        /// Called when this goal becomes the active goal.
        /// Rebuilds the desired state so it reflects the latest conditions.
        /// Always call base.OnGoalActivated() when overriding.
        /// </summary>
        public virtual void OnGoalActivated()
        {
            RebuildDesiredState();

            if (debugLog)
                Debug.Log($"[GOAP] Goal activated: {Name}", this);
        }

        /// <summary>
        /// Called when this goal is deactivated.
        /// Always call base.OnGoalDeactivated() when overriding.
        /// </summary>
        public virtual void OnGoalDeactivated(GoalDeactivationReason reason)
        {
            if (debugLog)
                Debug.Log($"[GOAP] Goal deactivated: {Name} | Reason: {reason}", this);
        }

        // - Protected API -

        /// <summary>
        /// Override this to define what world state this goal desires.
        /// Called once on first access, and again each time the goal is activated.
        /// </summary>
        /// <example>
        /// protected override void BuildDesiredState(WorldState desiredState)
        /// {
        ///     desiredState.Set(WorldKeys.IsEnemyDead, true);
        /// }
        /// </example>
        protected abstract void BuildDesiredState(WorldState desiredState);

        // - Private Helpers -

        private void RebuildDesiredState()
        {
            desiredState ??= new WorldState();
            desiredState.Clear();
            BuildDesiredState(desiredState);
            isInitialized = true;
        }
    }
}