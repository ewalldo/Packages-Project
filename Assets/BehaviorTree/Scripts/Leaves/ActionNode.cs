using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for a leaf node that performs an action in the behavior tree. Action nodes are expected to perform some operation and return a status (Success, Failure, or Running) based on the outcome of that operation.
    /// 
    /// Subclasses must implement:
    ///     - OnTick() : defines the action's own tick logic.
    ///     
    /// Subclasses may optionally override:
    ///     - Reset()   : aborts the node if it is currently running, then fully clears its state. Always call base.Reset() when overriding.
    ///     - OnEnter() : called once before the first tick
    ///     - OnExit()  : called once after the last tick or abort
    /// </summary>
    public abstract class ActionNode : Node
    {
        public override IReadOnlyList<Node> GetChildren() => System.Array.Empty<Node>();

        protected override void OnAbort(BehaviorTreeContext context)
        {
            // Action nodes typically don't have children, so there's no need to abort any child nodes.
        }
    }
}