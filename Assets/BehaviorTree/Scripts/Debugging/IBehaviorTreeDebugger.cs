namespace BehaviorTree
{
    /// <summary>
    /// Contract for a debugger that can be attached to a BehaviorTreeContext to receive notifications when nodes enter and exit.
    /// </summary>
    public interface IBehaviorTreeDebugger
    {
        /// <summary>Called when a node begins running (its first tick after completing, being reset, or being aborted)</summary>
        /// <param name="node">The node that just entered</param>
        void OnNodeEnter(Node node);

        /// <summary>Called when a node stops running, whether it finished normally or was aborted</summary>
        /// <param name="node">The node that just exited</param>
        /// <param name="status">The node's final status for this run</param>
        void OnNodeExit(Node node, NodeStatus status);
    }
}