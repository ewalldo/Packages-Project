using GOAP.Goals;

namespace GOAP.Agent
{
    /// <summary>
    /// Describes a pending request to form a new plan.
    /// Created internally by the GoapAgent and consumed at the start
    /// of the next planning cycle.
    /// </summary>
    public readonly struct ReplanRequest
    {
        /// <summary>Whether a replan has been requested.</summary>
        public readonly bool IsPending;

        /// <summary>The reason the replan was triggered.</summary>
        public readonly ReplanReason Reason;

        /// <summary>
        /// The goal to plan for. If null, the agent will re-run
        /// goal selection to pick the best current goal.
        /// </summary>
        public readonly IGoal TargetGoal;

        private ReplanRequest(ReplanReason reason, IGoal targetGoal)
        {
            IsPending = true;
            Reason = reason;
            TargetGoal = targetGoal;
        }

        // - Factory Methods -

        public static ReplanRequest ForGoal(IGoal goal, ReplanReason reason) => new ReplanRequest(reason, goal);

        public static ReplanRequest Reselect(ReplanReason reason) => new ReplanRequest(reason, null);

        public static readonly ReplanRequest None = default;

        public override string ToString() => IsPending ?
            $"ReplanRequest [{Reason}] → {(TargetGoal != null ? TargetGoal.Name : "Reselect goal")}" :
            "ReplanRequest [None]";
    }

    /// <summary>Why a replan was requested.</summary>
    public enum ReplanReason
    {
        /// <summary>No active plan exists yet.</summary>
        NoPlanExists,

        /// <summary>The active goal changed.</summary>
        GoalChanged,

        /// <summary>The active plan failed during execution.</summary>
        PlanFailed,

        /// <summary>The world state changed enough to invalidate the current plan.</summary>
        WorldStateInvalidated,

        /// <summary>The replan interval timer elapsed — periodic re-evaluation.</summary>
        PeriodicReplan,

        /// <summary>A replan was requested explicitly from outside the agent.</summary>
        ForcedByExternal
    }
}