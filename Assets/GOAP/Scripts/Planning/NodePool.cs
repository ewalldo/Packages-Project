using System.Collections.Generic;

namespace GOAP.Planning
{
    /// <summary>
    /// A simple object pool for PlannerNode instances.
    /// Eliminates per-planning-cycle heap allocations for nodes.
    ///
    /// Usage:
    ///   PlannerNode node = _pool.Rent();
    ///   node.Initialize(...);
    ///   // ... use node ...
    ///   _pool.Return(node);
    /// </summary>
    internal class NodePool
    {
        private readonly Stack<PlannerNode> pool;
        private readonly int maxSize;

        public NodePool(int initialCapacity = 64, int maxSize = 512)
        {
            this.maxSize = maxSize;
            pool = new Stack<PlannerNode>(initialCapacity);

            // Pre-warm the pool
            for (int i = 0; i < initialCapacity; i++)
                pool.Push(new PlannerNode());
        }

        /// <summary>
        /// Retrieves a node from the pool or creates a new one if empty.
        /// The caller must call Initialize() on the returned node.
        /// </summary>
        public PlannerNode Rent()
        {
            return pool.Count > 0 ? pool.Pop() : new PlannerNode();
        }

        /// <summary>
        /// Returns a node to the pool after resetting its state.
        /// Nodes beyond maxSize are discarded.
        /// </summary>
        public void Return(PlannerNode node)
        {
            node.Reset();

            if (pool.Count < maxSize)
                pool.Push(node);
        }

        /// <summary>Returns a list of nodes to the pool all at once.</summary>
        public void ReturnAll(List<PlannerNode> nodes)
        {
            foreach (PlannerNode node in nodes)
                Return(node);
        }

        /// <summary>Current number of available nodes in the pool.</summary>
        public int AvailableCount => pool.Count;
    }
}