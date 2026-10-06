using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// Contains the context for a single behavior tree instance running on a single agent.
    /// This includes the agent's GameObject, its Transform, the shared Blackboard, and any attached debuggers.
    /// </summary>
    public class BehaviorTreeContext
    {
        /// <summary>The agent this context belongs to</summary>
        public GameObject GameObject { get; }

        /// <summary>The agent GameObject's transform</summary>
        public Transform Transform { get; }

        /// <summary>The blackboard shared by every node in this tree instance</summary>
        public Blackboard Blackboard { get; }

        /// <summary>The BehaviorTree instance that owns this context</summary>
        public BehaviorTree Tree { get; internal set; }

        /// <summary>The elapsed time for the current tick</summary>
        public float DeltaTime { get; internal set; }

        /// <summary>
        /// A list of debuggers that will be notified of node enter/exit events. This can be used to visualize the tree's execution in real time
        /// </summary>
        private readonly List<IBehaviorTreeDebugger> debuggers = new List<IBehaviorTreeDebugger>();

        /// <summary>Creates a context for the given agent, sharing the given blackboard</summary>
        /// <param name="owner">The agent this context belongs to</param>
        /// <param name="blackboard">The blackboard every node in the tree will share</param>
        public BehaviorTreeContext(GameObject owner, Blackboard blackboard)
        {
            GameObject = owner ?? throw new ArgumentNullException(nameof(owner));
            Transform = owner.transform;
            Blackboard = blackboard;
        }

        /// <summary>Attaches a debugger so it starts receiving node enter/exit events</summary>
        /// <param name="debugger">The debugger to attach</param>
        public void AddDebugger(IBehaviorTreeDebugger debugger)
        {
            if (!debuggers.Contains(debugger))
                debuggers.Add(debugger);
        }

        /// <summary>Detaches a debugger</summary>
        /// <param name="debugger">The debugger to detach</param>
        public void RemoveDebugger(IBehaviorTreeDebugger debugger) => debuggers.Remove(debugger);

        /// <summary>Notifies every attached debugger when a node has just entered its execution</summary>
        internal void NotifyDebuggersEnter(Node node)
        {
            foreach (IBehaviorTreeDebugger debugger in debuggers)
                debugger.OnNodeEnter(node);
        }

        /// <summary>Notifies every attached debugger a node has just exited with the given status</summary>
        internal void NotifyDebuggersExit(Node node, NodeStatus status)
        {
            foreach (IBehaviorTreeDebugger debugger in debuggers)
                debugger.OnNodeExit(node, status);
        }
    }
}