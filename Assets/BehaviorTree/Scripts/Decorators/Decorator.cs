using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for nodes that wrap exactly one child, modifying or gating its behavior/result.
    /// </summary>
    public abstract class Decorator : Node
    {
        /// <summary>The single node this decorator wraps</summary>
        protected readonly Node Child;

        /// <summary>Creates a decorator wrapping the given child</summary>
        /// <param name="child">The node to wrap</param>
        protected Decorator(Node child)
        {
            Child = child;
        }

        public override void Reset(BehaviorTreeContext context)
        {
            base.Reset(context);
            Child.Reset(context);
        }

        /// <summary>Returns this node's sole child</summary>
        public override IReadOnlyList<Node> GetChildren() => new Node[] { Child };

        /// <summary>Aborts node's sole child</summary>
        protected override void OnAbort(BehaviorTreeContext context)
        {
            Child.Abort(context);
        }
    }
}