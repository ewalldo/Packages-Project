namespace BehaviorTree
{
    /// <summary>
    /// Repeats the child a fixed number of times, or forever if unlimited, optionally breaking early on the first failure.
    /// </summary>
    [NodeInfo("Repeater", "Decorators", "Repeats the child a fixed number of times (or forever), optionally breaking on failure.")]
    public class Repeater : Decorator
    {
        private readonly int repeatCount;
        private readonly bool breakOnFailure;

        private int completedCount;

        /// <summary>Creates a repeater wrapping the given child</summary>
        /// <param name="child">The node to repeat</param>
        /// <param name="repeatCount">How many times to repeat, or a negative number to repeat forever</param>
        /// <param name="breakOnFailure">If true, a single child failure ends the repeater with instead of continuing</param>
        public Repeater(Node child, int repeatCount = -1, bool breakOnFailure = true) : base(child)
        {
            this.repeatCount = repeatCount;
            this.breakOnFailure = breakOnFailure;
        }

        protected override void OnEnter(BehaviorTreeContext context)
        {
            completedCount = 0;
        }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            NodeStatus status = Child.Tick(context);

            if (status == NodeStatus.Running)
                return NodeStatus.Running;

            if (status == NodeStatus.Failure && breakOnFailure)
                return NodeStatus.Failure;

            completedCount++;

            if (repeatCount >= 0 && completedCount >= repeatCount)
                return NodeStatus.Success;

            return NodeStatus.Running;
        }
    }
}