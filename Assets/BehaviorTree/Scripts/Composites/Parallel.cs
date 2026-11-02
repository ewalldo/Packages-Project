using System;

namespace BehaviorTree
{
    /// <summary>
    /// Ticks every still-running child on every tick, rather than one at a time.
    /// A child that finishes is latched, its result is cached and reused instead of
    /// re-ticking it (and re-triggering its enter/exit side effects). until the whole
    /// Parallel itself restarts. Success/failure thresholds are
    /// independently configurable via ParallelPolicy.
    /// </summary>
    [NodeInfo("Parallel", "Composites", "Ticks running children every tick, a child that finishes is latched (not re-ticked) until the whole Parallel restarts. Success/failure thresholds are configurable via ParallelPolicy.")]
    public class Parallel : Composite
    {
        private readonly ParallelPolicy successPolicy;
        private readonly ParallelPolicy failurePolicy;

        /// <summary>Cached final result per child index, or null if that child hasn't finished yet this run.</summary>
        private readonly NodeStatus?[] latchedStatus;

        /// <summary>Creates a parallel over the given children</summary>
        /// <param name="successPolicy">How many children must succeed for this node to succeed</param>
        /// <param name="failurePolicy">How many children must fail for this node to fail</param>
        /// <param name="children">The children to run simultaneously</param>
        public Parallel(ParallelPolicy successPolicy, ParallelPolicy failurePolicy, params Node[] children)
            : base(children)
        {
            this.successPolicy = successPolicy;
            this.failurePolicy = failurePolicy;
            latchedStatus = new NodeStatus?[Children.Count];
        }

        /// <summary>Clears every child's latched result so the run starts fresh</summary>
        protected override void OnEnter(BehaviorTreeContext context)
        {
            for (int i = 0; i < latchedStatus.Length; i++)
                latchedStatus[i] = null;
        }

        /// <inheritdoc/>
        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            int successCount = 0;
            int failureCount = 0;

            for (int i = 0; i < Children.Count; i++)
            {
                NodeStatus status = latchedStatus[i] ?? Children[i].Tick(context);

                if (status != NodeStatus.Running)
                    latchedStatus[i] = status;

                if (status == NodeStatus.Success)
                    successCount++;
                else if (status == NodeStatus.Failure)
                    failureCount++;
            }

            if (MeetsPolicy(failurePolicy, failureCount, Children.Count))
                return NodeStatus.Failure;

            if (MeetsPolicy(successPolicy, successCount, Children.Count))
                return NodeStatus.Success;

            return NodeStatus.Running;
        }

        /// <summary>Aborts every child</summary>
        protected override void OnAbort(BehaviorTreeContext context)
        {
            foreach (Node child in Children)
                child.Abort(context);
        }

        /// <summary>Checks if the given ParallelPolicy is satisfied</summary>
        private static bool MeetsPolicy(ParallelPolicy policy, int count, int total)
        {
            return policy switch
            {
                ParallelPolicy.RequireOne => count > 0,
                ParallelPolicy.RequireAll => count == total,
                _ => throw new ArgumentOutOfRangeException(nameof(policy))
            };
        }
    }
}