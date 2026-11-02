using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// One runnable instance of a tree, bound to a single agent's context and blackboard
    /// </summary>
    public class BehaviorTree
    {
        /// <summary>The tree's entry point</summary>
        public Root Root { get; }

        /// <summary>The blackboard shared by every node in this tree instance</summary>
        public Blackboard Blackboard { get; }

        /// <summary>The per-tick context passed to every node</summary>
        public BehaviorTreeContext Context { get; }

        /// <summary>The result of the most recent tick call</summary>
        public NodeStatus LastStatus { get; private set; } = NodeStatus.Failure;

        /// <summary>Attaches a debugger so it starts receiving node enter/exit events for this tree</summary>
        /// <param name="debugger">The debugger to attach</param>
        public void AddDebugger(IBehaviorTreeDebugger debugger) => Context.AddDebugger(debugger);

        /// <summary>Detaches a previously-attached debugger</summary>
        /// <param name="debugger">The debugger to detach</param>
        public void RemoveDebugger(IBehaviorTreeDebugger debugger) => Context.RemoveDebugger(debugger);

        /// <summary>Creates a tree instance for the given agent</summary>
        /// <param name="root">The tree's root logic. Wrapped in a Root node automatically if it isn't already one</param>
        /// <param name="owner">The agent this tree instance runs for</param>
        /// <param name="blackboard">The blackboard to use, if null create a new instance</param>
        public BehaviorTree(Node root, GameObject owner, Blackboard blackboard = null)
        {
            Root = root as Root ?? new Root(root);
            Blackboard = blackboard ?? new Blackboard();
            Context = new BehaviorTreeContext(owner, Blackboard) { Tree = this };
        }

        /// <summary>Ticks the tree once</summary>
        /// <param name="deltaTime">The elapsed time to make available to nodes via BehaviorTreeContext.DeltaTime</param>
        /// <returns>The tree's result for this tick</returns>
        public NodeStatus Tick(float deltaTime)
        {
            Context.DeltaTime = deltaTime;
            LastStatus = Root.Tick(Context);
            return LastStatus;
        }

        /// <summary>Aborts the tree if it is currently running</summary>
        public void Abort()
        {
            Root.Abort(Context);
        }

        /// <summary>Aborts the tree if running, then fully clears its state so the next tick starts fresh</summary>
        public void ResetTree()
        {
            Root.Reset(Context);
        }
    }
}