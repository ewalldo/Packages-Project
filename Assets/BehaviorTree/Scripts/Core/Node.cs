using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for every node in a behavior tree.
    /// 
    /// Subclasses must implement:
    ///     - OnTick()      : defines the node's own tick logic.
    ///     - GetChildren() : the node's direct children, in evaluation order
    ///     - OnAbort()     : called once if the node is aborted while running
    ///     
    /// Subclasses may optionally override:
    ///     - Reset()   : aborts the node if it is currently running, then fully clears its state. Always call base.Reset() when overriding.
    ///     - OnEnter() : called once before the first tick
    ///     - OnExit()  : called once after the last tick or abort
    /// </summary>
    public abstract class Node : INode
    {
        /// <summary>The result of the most recent tick, abort, or reset</summary>
        public NodeStatus Status { get; protected set; } = NodeStatus.Failure;

        /// <summary>
        /// True if this node has been ticked at least once since the last reset, false otherwise
        /// </summary>
        public bool HasTicked { get; protected set; }

        /// <summary>True if the last computed status was <see cref="NodeStatus.Running"/></summary>
        protected bool IsRunning => Status == NodeStatus.Running;

        /// <summary>
        /// True from the moment OnEnter fires until the matching OnExit fires - i.e. while a tick/abort cycle is "open".
        /// </summary>
        private bool hasEntered;

        /// <summary>
        /// Advances the node by one tick.
        /// Fires <see cref="OnEnter"/> if this is a fresh entry,
        /// calls <see cref="OnTick"/>,
        /// then fires <see cref="OnExit"/> if the result isn't <see cref="NodeStatus.Running"/>.
        /// Notifies any attached debuggers.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>The result of this tick</returns>
        public NodeStatus Tick(BehaviorTreeContext context)
        {
            HasTicked = true;

            if (!hasEntered)
            {
                hasEntered = true;
                OnEnter(context);
                NotifyDebuggerEnter(context);
            }

            Status = OnTick(context);

            if (Status != NodeStatus.Running)
            {
                hasEntered = false;
                OnExit(context);
                NotifyDebuggerExit(context, Status);
            }

            return Status;
        }

        /// <summary>
        /// Interrupts the node if it is currently running.
        /// Calls <see cref="OnAbort"/>, and forces its status to <see cref="NodeStatus.Failure"/>,
        /// then fires <see cref="OnExit"/> and notifies debuggers exactly as a normal non-Running tick would.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        public void Abort(BehaviorTreeContext context)
        {
            if (!hasEntered)
                return;

            hasEntered = false;
            OnAbort(context);
            Status = NodeStatus.Failure;
            OnExit(context);
            NotifyDebuggerExit(context, Status);
        }

        /// <summary>
        /// Aborts the node if it is currently running, then fully clears its state so it behaves as if it had never run.
        /// Always call base.Reset() when overriding.
        /// </summary>
        /// <param name="context">The tree/agent context to run against.</param>
        public virtual void Reset(BehaviorTreeContext context)
        {
            Abort(context);
            HasTicked = false;
            Status = NodeStatus.Failure;
        }

        /// <summary>
        /// Returns this node's children
        /// </summary>
        /// <returns>This node's direct children, in evaluation order</returns>
        public abstract IReadOnlyList<Node> GetChildren();

        /// <summary>
        /// The node's own tick logic. Called once per <see cref="Tick"/> call
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        /// <returns>The result of this tick</returns>
        protected abstract NodeStatus OnTick(BehaviorTreeContext context);

        /// <summary>
        /// Called by <see cref="Abort"/>, before <see cref="OnExit"/>, only while this node is currently running
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        protected abstract void OnAbort(BehaviorTreeContext context);

        /// <summary>Called once, the first time this node is ticked</summary>
        /// <param name="context">The tree/agent context</param>
        protected virtual void OnEnter(BehaviorTreeContext context) { }

        /// <summary>
        /// Called once when the status has becomes different from <see cref="NodeStatus.Running"/>,
        /// whether that happened via a normal <see cref="OnTick"/> result or via <see cref="Abort"/>.
        /// Use this for any cleanup that must happen no matter how the node finished.
        /// </summary>
        /// <param name="context">The tree/agent context</param>
        protected virtual void OnExit(BehaviorTreeContext context) { }

        /// <summary>
        /// Reports an enter event to every debugger attached to the context.
        /// </summary>
        /// <param name="context">The context whose attached debuggers should be notified</param>
        protected void NotifyDebuggerEnter(BehaviorTreeContext context) => context.NotifyDebuggersEnter(this);

        /// <summary>Reports an exit event, with its final status, to every debugger attached to the context</summary>
        /// <param name="context">The context whose attached debuggers should be notified</param>
        /// <param name="status">The node's final status for this run</param>
        protected void NotifyDebuggerExit(BehaviorTreeContext context, NodeStatus status) => context.NotifyDebuggersExit(this, status);
    }
}