namespace BehaviorTree
{
    /// <summary>
    /// Ticks children in order, resuming from wherever it left off across Running
    /// ticks. Succeeds as soon as any child succeeds or fails only once every child has failed.
    /// Also reactively re-checks earlier ConditionGuard children while a later one is running,
    /// so a higher-priority branch can interrupt and take over as soon as its guard condition becomes true again.
    /// </summary>
    [NodeInfo("Selector", "Composites", "Ticks children in order, succeeds as soon as any child succeeds, fails only if all children fail.")]
    public class Selector : Composite
    {
        private int currentIndex;

        /// <summary>Creates a selector over the given children, in priority order (highest first)</summary>
        /// <param name="children">The children to try, in priority order</param>
        public Selector(params Node[] children) : base(children) { }

        protected override void OnEnter(BehaviorTreeContext context)
        {
            currentIndex = 0;
        }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            TryReactiveAbort(context);

            while (currentIndex < Children.Count)
            {
                NodeStatus status = Children[currentIndex].Tick(context);

                if (status == NodeStatus.Running)
                    return NodeStatus.Running;

                if (status == NodeStatus.Success)
                    return NodeStatus.Success;

                currentIndex++;
            }

            return NodeStatus.Failure;
        }

        protected override void OnAbort(BehaviorTreeContext context)
        {
            if (currentIndex < Children.Count)
                Children[currentIndex].Abort(context);
        }

        /// <summary>
        /// Reactive interrupts: even while a lower-priority (later) child is running,
        /// re-check earlier ConditionGuard children configured for <see cref="AbortType.LowerPriority"/> or <see cref="AbortType.Both"/>.
        /// If one now passes, abort the running child and resume from that guard.
        /// </summary>
        private void TryReactiveAbort(BehaviorTreeContext context)
        {
            if (currentIndex <= 0)
                return;

            for (int i = 0; i < currentIndex; i++)
            {
                if (Children[i] is ConditionGuard guard &&
                    guard.AbortType is AbortType.LowerPriority or AbortType.Both &&
                    guard.CanEnter(context))
                {
                    Children[currentIndex].Abort(context);
                    currentIndex = i;
                    return;
                }
            }
        }
    }
}