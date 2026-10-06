namespace BehaviorTree
{
    /// <summary>
    /// Only runs the child while a <see cref="ConditionNode"/> holds.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><see cref="AbortType.None"/> checks the condition once, on first entry, like a static precondition.</item>
    /// <item><see cref="AbortType.Self"/> re-checks every tick while THIS guard's own child is the active branch, and aborts it if the condition turns false.
    /// It does nothing while some other (lower-priority) sibling is active instead, the guard just isn't being ticked in that case, so there's nothing for Self to re-check.</item>
    /// <item><see cref="AbortType.LowerPriority"/> is what lets a parent Selector reactively notice this guard's condition becoming true again while a lower-priority
    /// sibling is currently running, and jump back to interrupt it. This applies regardless of this
    /// guard's own position/priority in the Selector, what matters is whether something lower-priority than it is currently active.</item>
    /// <item><see cref="AbortType.Both"/> = Self while active + LowerPriority while inactive.
    /// A guard meant to "take over when true, give up when false".</item>
    /// </list>
    /// </remarks>
    [NodeInfo("Condition Guard", "Decorators", "Only runs the child while a condition holds, can abort a running subtree per AbortType.")]
    public class ConditionGuard : Decorator
    {
        /// <summary>The condition gating this guard's child</summary>
        public ConditionNode Condition { get; }

        /// <summary>How reactively this guard responds to the condition changing</summary>
        public AbortType AbortType { get; }

        /// <summary>Creates a guard wrapping the given child</summary>
        /// <param name="condition">The condition that must hold for the child to run</param>
        /// <param name="child">The node to gate</param>
        /// <param name="abortType">How reactively this guard should respond to the condition changing</param>
        public ConditionGuard(ConditionNode condition, Node child, AbortType abortType = AbortType.None)
            : base(child)
        {
            Condition = condition;
            AbortType = abortType;
        }

        /// <summary>
        /// Checks the condition without ticking this guard's own lifecycle.
        /// Used by Selector's reactive-abort scan to peek at a higher-priority guard while a different sibling is currently active.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>True if the child would currently be allowed to run</returns>
        public bool CanEnter(BehaviorTreeContext context) => Condition.Check(context);

        /// <inheritdoc/>
        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            bool recheckEveryTick = AbortType is AbortType.Self or AbortType.Both;

            if (recheckEveryTick)
            {
                if (!Condition.Check(context))
                {
                    Child.Abort(context);
                    return NodeStatus.Failure;
                }
            }
            else if (!IsRunning && !Condition.Check(context))
            {
                return NodeStatus.Failure;
            }

            return Child.Tick(context);
        }
    }
}