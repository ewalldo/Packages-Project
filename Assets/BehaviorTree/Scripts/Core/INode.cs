namespace BehaviorTree
{
    /// <summary>
    /// Defines The contract for any behavior tree node.
    /// </summary>
    public interface INode
    {
        /// <summary>The result of the most recent Tick call</summary>
        NodeStatus Status { get; }

        /// <summary>
        /// Advances the node by one tick.
        /// Returns <see cref="NodeStatus.Running"/> if the node is still in progress, or
        /// returns <see cref="NodeStatus.Success"/> if the node has completed successfully, or
        /// returns <see cref="NodeStatus.Failure"/> if the node has failed.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>The result of this tick</returns>
        NodeStatus Tick(BehaviorTreeContext context);

        /// <summary>
        /// Interrupts the node if it is currently running, forcing it to <see cref="NodeStatus.Failure"/> and running its exit/cleanup logic.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        void Abort(BehaviorTreeContext context);

        /// <summary>
        /// Aborts the node if it is currently running, then fully clears its state so it behaves as if it had never run
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        void Reset(BehaviorTreeContext context);
    }
}