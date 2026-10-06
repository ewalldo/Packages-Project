namespace BehaviorTree
{
    /// <summary>Re-runs the child on every success, returns Failure as soon as the child fails</summary>
    [NodeInfo("Repeat Until Failure", "Decorators", "Re-runs the child on every success, returns Failure as soon as the child fails.")]
    public class RepeatUntilFailure : Decorator
    {
        /// <summary>Creates a node that retries the given child until it fails</summary>
        /// <param name="child">The node to retry</param>
        public RepeatUntilFailure(Node child) : base(child) { }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            NodeStatus status = Child.Tick(context);
            return status == NodeStatus.Failure ? NodeStatus.Failure : NodeStatus.Running;
        }
    }
}