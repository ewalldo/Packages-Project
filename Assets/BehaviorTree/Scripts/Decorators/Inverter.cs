namespace BehaviorTree
{
    /// <summary>Flips a child's Success/Failure result, passes Running through unchanged.</summary>
    [NodeInfo("Inverter", "Decorators", "Flips Success to Failure and vice versa; passes Running through unchanged.")]
    public class Inverter : Decorator
    {
        /// <summary>Creates an inverter wrapping the given child</summary>
        /// <param name="child">The node whose result should be inverted</param>
        public Inverter(Node child) : base(child) { }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            NodeStatus status = Child.Tick(context);

            return status switch
            {
                NodeStatus.Success => NodeStatus.Failure,
                NodeStatus.Failure => NodeStatus.Success,
                _ => NodeStatus.Running
            };
        }
    }
}