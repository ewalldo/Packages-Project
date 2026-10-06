using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// The single, unambiguous entry point of a tree. Ticks its one child and passes the result through unchanged
    /// </summary>
    [NodeInfo("Root", "Core", "The single entry point of a tree; ticks its one child and passes the result through unchanged.")]
    public class Root : Node
    {
        /// <summary>The root's node child</summary>
        public Node Child { get; }

        /// <summary>Wraps the child as the tree's entry point.</summary>
        /// <param name="child">The node to run as the tree's actual root</param>
        public Root(Node child)
        {
            Child = child;
        }

        public override void Reset(BehaviorTreeContext context)
        {
            base.Reset(context);
            Child.Reset(context);
        }

        public override IReadOnlyList<Node> GetChildren() => new Node[] { Child };

        /// <summary>Ticks its child and returns its result unchanged</summary>
        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            return Child.Tick(context);
        }

        protected override void OnAbort(BehaviorTreeContext context)
        {
            Child.Abort(context);
        }
    }
}