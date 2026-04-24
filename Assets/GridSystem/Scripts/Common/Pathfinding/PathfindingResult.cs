using System.Collections.Generic;

namespace GridSystem.Pathfinding
{
	public class PathfindingResult<T> where T : IGridCell
    {
		public bool Success { get; private set; }

		public IReadOnlyList<T> Path { get; private set; }

		public float TotalCost { get; private set; }

		public int NodesExplored { get; private set; }

        public PathfindingResult(bool success, List<T> path, float totalCost, int nodesExplored)
        {
            Success = success;
            Path = path?.AsReadOnly();
            TotalCost = totalCost;
            NodesExplored = nodesExplored;
        }

        public static PathfindingResult<T> Failure(int nodesExplored)
        {
            return new PathfindingResult<T>(false, new List<T>(), 0f, nodesExplored);
        }
    }
}