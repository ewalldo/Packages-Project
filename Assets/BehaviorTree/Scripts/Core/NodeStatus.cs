namespace BehaviorTree
{
    /// <summary>
    /// The outcome of a single Tick call.
    /// </summary>
    public enum NodeStatus
    {
        /// <summary>The node has not finished and it is still running</summary>
        Running,

        /// <summary>The node finished and succeeded.</summary>
        Success,

        /// <summary>The node finished but it has failed</summary>
        Failure
    }
}