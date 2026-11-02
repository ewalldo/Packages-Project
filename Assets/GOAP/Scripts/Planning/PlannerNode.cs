using GOAP.Actions;
using GOAP.WorldStates;

namespace GOAP.Planning
{
    /// <summary>
    /// Represents a single node in the A* search graph used by GoapPlanner.
    /// Each node captures a simulated world state reached by executing one action.
    ///
    /// This is an internal type — it is created, pooled, and recycled
    /// exclusively by GoapPlanner and NodePool.
    /// </summary>
    internal class PlannerNode
    {
        // - Graph Data -

        /// <summary>
        /// The simulated world state at this node.
        /// Produced by applying Action.Effects onto the parent node's state.
        /// </summary>
        public WorldState SimulatedState { get; private set; }

        /// <summary>
        /// The action that was executed to reach this node.
        /// Null for the root node (no action taken yet).
        /// </summary>
        public IAction Action { get; private set; }

        /// <summary>
        /// The parent node in the search tree.
        /// Used to reconstruct the plan by walking back to the root.
        /// </summary>
        public PlannerNode Parent { get; private set; }

        // - A* Cost Data -

        /// <summary>Actual accumulated cost from the start node to this node.</summary>
        public float GCost { get; private set; }

        /// <summary>Estimated remaining cost from this node to the goal (heuristic).</summary>
        public float HCost { get; private set; }

        /// <summary>Total estimated cost: GCost + HCost. Used by the priority queue.</summary>
        public float FCost => GCost + HCost;

        /// <summary>Depth in the search tree. Used to enforce MaxPlanLength.</summary>
        public int Depth { get; private set; }

        // - Setup / Reset (used by NodePool) -

        /// <summary>
        /// Initializes or re-initializes this node with new data.
        /// Called by NodePool.Rent() after retrieving from the pool.
        /// </summary>
        public void Initialize(WorldState simulatedState, IAction action, PlannerNode parent, float gCost, float hCost)
        {
            SimulatedState = simulatedState;
            Action = action;
            Parent = parent;
            GCost = gCost;
            HCost = hCost;
            Depth = parent == null ? 0 : parent.Depth + 1;
        }

        /// <summary>
        /// Clears all references so the node can safely sit in the pool
        /// without keeping objects alive via GC roots.
        /// </summary>
        public void Reset()
        {
            SimulatedState = null;
            Action = null;
            Parent = null;
            GCost = 0f;
            HCost = 0f;
            Depth = 0;
        }
    }
}