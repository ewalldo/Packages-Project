namespace BehaviorTree
{
    /// <summary>
    /// Threshold used by Parallel nodes to decide when enough children have reached a given outcome.
    /// </summary>
    public enum ParallelPolicy
    {
        /// <summary>Met as soon as at least one child reaches the outcome</summary>
        RequireOne,

        /// <summary>Met only once every child has reached the outcome</summary>
        RequireAll
    }
}