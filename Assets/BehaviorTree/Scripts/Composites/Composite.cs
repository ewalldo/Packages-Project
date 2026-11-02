using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for nodes with multiple children evaluated as a group.
    /// </summary>
    public abstract class Composite : Node
    {
        /// <summary>This node's children, in evaluation order</summary>
        protected readonly List<Node> Children = new List<Node>();

        /// <summary>Creates a composite over the given children, in the order they should be evaluated</summary>
        /// <param name="children">The children to run, in evaluation order</param>
        protected Composite(params Node[] children)
        {
            Children.AddRange(children);
        }

        /// <summary>Resets this node, then every child, including ones that were never reached this run</summary>
        public override void Reset(BehaviorTreeContext context)
        {
            base.Reset(context);

            foreach (Node child in Children)
                child.Reset(context);
        }

        /// <summary>Returns this node's children</summary>
        public override IReadOnlyList<Node> GetChildren() => Children;
    }
}