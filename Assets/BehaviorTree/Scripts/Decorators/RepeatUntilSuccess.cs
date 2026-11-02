namespace BehaviorTree
{
    /// <summary>Re-runs the child on every failure; returns Success as soon as the child succeeds</summary>
    [NodeInfo("Repeat Until Success", "Decorators", "Re-runs the child on every failure, returns Success as soon as the child succeeds.")]
    public class RepeatUntilSuccess : Decorator
    {
        /// <summary>Creates a node that retries the given child until it succeeds</summary>
        /// <param name="child">The node to retry</param>
        public RepeatUntilSuccess(Node child) : base(child) { }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            NodeStatus status = Child.Tick(context);
            return status == NodeStatus.Success ? NodeStatus.Success : NodeStatus.Running;
        }
    }
}