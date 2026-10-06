namespace BehaviorTree
{
    /// <summary>
    /// Ticks children in order, resuming from wherever it left off across Running ticks.
    /// Fails as soon as any child fails or succeeds only once every child has succeeded.
    /// </summary>
    [NodeInfo("Sequence", "Composites", "Ticks children in order; fails as soon as any child fails, succeeds only if all children succeed.")]
    public class Sequence : Composite
    {
        private int currentIndex;

        /// <summary>Creates a sequence over the given children, in the order they should run</summary>
        /// <param name="children">The children to run, in order</param>
        public Sequence(params Node[] children) : base(children) { }

        protected override void OnEnter(BehaviorTreeContext context)
        {
            currentIndex = 0;
        }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            while (currentIndex < Children.Count)
            {
                NodeStatus status = Children[currentIndex].Tick(context);

                if (status == NodeStatus.Running)
                    return NodeStatus.Running;

                if (status == NodeStatus.Failure)
                    return NodeStatus.Failure;

                currentIndex++;
            }

            return NodeStatus.Success;
        }

        /// <summary>Aborts whichever child is currently running</summary>
        protected override void OnAbort(BehaviorTreeContext context)
        {
            if (currentIndex < Children.Count)
                Children[currentIndex].Abort(context);
        }
    }
}
