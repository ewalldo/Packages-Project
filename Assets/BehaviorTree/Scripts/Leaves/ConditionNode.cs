using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for a leaf node that evaluates a condition in the behavior tree. Condition nodes are expected to check some state or property and return Success if the condition holds, or Failure if it does not.
    /// 
    /// Subclasses must implement:
    ///     - Evaluate() : defines the condition's own evaluation logic.
    /// </summary>
    public abstract class ConditionNode : Node
    {
        public override IReadOnlyList<Node> GetChildren() => System.Array.Empty<Node>();

        protected override void OnAbort(BehaviorTreeContext context)
        {
            // Condition nodes don't have children, so there's nothing to abort.
        }

        /// <inheritdoc/>
        protected sealed override NodeStatus OnTick(BehaviorTreeContext context)
        {
            return Evaluate(context) ? NodeStatus.Success : NodeStatus.Failure;
        }

        /// <summary>
        /// Usable outside the normal Tick traversal (e.g. by ConditionGuard/Selector to check a condition without ticking a whole subtree).
        /// Still updates its status and fires debugger events.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>The condition's current result</returns>
        public bool Check(BehaviorTreeContext context)
        {
            HasTicked = true;
            NotifyDebuggerEnter(context);
            bool success = Evaluate(context);
            Status = success ? NodeStatus.Success : NodeStatus.Failure;
            NotifyDebuggerExit(context, Status);
            return success;
        }

        /// <summary>
        /// Evaluates the node's condition
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>True if the condition currently holds, false otherwise</returns>
        protected abstract bool Evaluate(BehaviorTreeContext context);
    }
}