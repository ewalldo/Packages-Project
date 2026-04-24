using System;

namespace GridSystem.Pathfinding
{
	internal class PathNode<T> : IComparable<PathNode<T>> where T : IGridCell
	{
		public T Position { get; private set; }

        /// <summary>
        /// Cost from the start node to this node
        /// </summary>
        public float GCost { get; set; }

        /// <summary>
        /// Cost from this node to the end node (heuristic)
        /// </summary>
		public float HCost { get; set; }

        /// <summary>
        /// Total cost of this node (GCost + HCost)
        /// </summary>
        public float FCost => GCost + HCost;

        public PathNode<T> Parent { get; set; }

        public PathNode(T position)
        {
            Position = position;
        }

        public int CompareTo(PathNode<T> other)
        {
            int compare = FCost.CompareTo(other.FCost);

            if (compare == 0)
                compare = HCost.CompareTo(other.HCost); // Tie-breaker: prefer nodes with lower HCost
            
            return compare;
        }
    }
}