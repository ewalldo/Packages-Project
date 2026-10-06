namespace BehaviorTree
{
    /// <summary>Aborts the child and returns Failure if it runs longer than the configured duration</summary>
    [NodeInfo("Time Limit", "Decorators", "Aborts the child and returns Failure if it runs longer than the configured duration.")]
    public class TimeLimit : Decorator
    {
        private readonly float maxDuration;

        private float elapsed;

        /// <summary>Creates a time limit wrapping the given child</summary>
        /// <param name="child">The node to bound</param>
        /// <param name="maxDuration">The maximum time, in seconds, the child is allowed to keep running</param>
        public TimeLimit(Node child, float maxDuration) : base(child)
        {
            this.maxDuration = maxDuration;
        }

        protected override void OnEnter(BehaviorTreeContext context)
        {
            elapsed = 0f;
        }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            elapsed += context.DeltaTime;

            if (elapsed >= maxDuration)
            {
                Child.Abort(context);
                return NodeStatus.Failure;
            }

            return Child.Tick(context);
        }
    }
}