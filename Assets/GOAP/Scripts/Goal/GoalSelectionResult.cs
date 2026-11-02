namespace GOAP.Goals
{
    /// <summary>
    /// The result of a goal selection evaluation.
    /// Carries both the winning goal (if any) and the reason it was selected or not.
    /// </summary>
    public readonly struct GoalSelectionResult
    {
        /// <summary>The selected goal. Null if no valid goal was found.</summary>
        public readonly IGoal SelectedGoal;

        /// <summary>Whether a valid, unsatisfied goal was found.</summary>
        public readonly bool HasGoal;

        /// <summary>The priority score of the selected goal.</summary>
        public readonly float Priority;

        /// <summary>Describes the outcome of the selection.</summary>
        public readonly GoalSelectionStatus Status;

        private GoalSelectionResult(IGoal goal, float priority, GoalSelectionStatus status)
        {
            SelectedGoal = goal;
            Priority = priority;
            Status = status;
            HasGoal = goal != null;
        }

        // - Factory Methods -

        public static GoalSelectionResult Found(IGoal goal, float priority) => new GoalSelectionResult(goal, priority, GoalSelectionStatus.Found);

        public static GoalSelectionResult NoneValid() => new GoalSelectionResult(null, 0f, GoalSelectionStatus.NoneValid);

        public static GoalSelectionResult AllSatisfied() => new GoalSelectionResult(null, 0f, GoalSelectionStatus.AllSatisfied);

        public override string ToString() => HasGoal
            ? $"GoalSelectionResult: {SelectedGoal.Name} (Priority: {Priority}, Status: {Status})"
            : $"GoalSelectionResult: None (Status: {Status})";
    }

    public enum GoalSelectionStatus
    {
        /// <summary>A valid goal was found and returned.</summary>
        Found,

        /// <summary>Goals exist but none passed IsValid() checks.</summary>
        NoneValid,

        /// <summary>All valid goals are already satisfied.</summary>
        AllSatisfied
    }
}