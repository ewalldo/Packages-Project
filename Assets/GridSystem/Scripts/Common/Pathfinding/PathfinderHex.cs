using System;
using System.Collections.Generic;

namespace GridSystem.Pathfinding
{
    public class PathfinderHex<T>
    {
        private readonly HexGrid<T> grid;
        private readonly Func<T, bool> isWalkable;
        private readonly Func<T, int> movementCost;
        private readonly int maxSearchDepth;

        /// <summary>
        /// Initializes a new instance of the Pathfinder class.
        /// </summary>
        /// <param name="grid">The grid to pathfind on</param>
        /// <param name="isWalkable">Predicate that defines if a cell is walkable</param>
        /// <param name="movementCost">Optional per-cell movement cost (defaults to 1)</param>
        /// <param name="maxSearchDepth">Maximum search depth for pathfinding</param>
        public PathfinderHex(HexGrid<T> grid, Func<T, bool> isWalkable, Func<T, int> movementCost = null, int maxSearchDepth = int.MaxValue)
        {
            this.grid = grid ?? throw new ArgumentNullException(nameof(grid));
            this.isWalkable = isWalkable ?? throw new ArgumentNullException(nameof(isWalkable));
            this.movementCost = movementCost ?? (_ => 1); // Default movement cost is 1 for all tiles
            this.maxSearchDepth = maxSearchDepth;
        }

        /// <summary>
        /// Initializes a Pathfinder using a grid of ITraversalProvider objects, which simplifies the setup by using the properties of the object directly.
        /// </summary>
        /// <param name="grid">The grid to pathfind on</param>
        /// <param name="maxSearchDepth">Maximum search depth for pathfinding</param>
        /// <returns>Pathfinder instance</returns>
        public static PathfinderHex<T2> CreateFromTraversalProvider<T2>(HexGrid<T2> grid, int maxSearchDepth = int.MaxValue) where T2 : ITraversalProvider
        {
            return new PathfinderHex<T2>(grid, cell => cell != null && cell.IsWalkable, cell => cell?.MovementCost ?? 1, maxSearchDepth);
        }

        /// <summary>
        /// Finds a path from the start position to the end position
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="end">The target position</param>
        /// <returns>The result of the pathfinding operation, including the found path, cost, and other relevant information</returns>
        public PathfindingResult<AxialCoord> FindPath(AxialCoord start, AxialCoord end)
        {
            if (!grid.IsWithinHexGridBounds(start))
                throw new ArgumentOutOfRangeException(nameof(start), $"Start position {start} is outside grid bounds");

            if (!grid.IsWithinHexGridBounds(end))
                throw new ArgumentOutOfRangeException(nameof(end), $"End position {end} is outside grid bounds");

            if (!isWalkable(grid.GetGridObjectAtAxialCoord(end)))
                return PathfindingResult<AxialCoord>.Failure(0);

            if (start == end)
                return new PathfindingResult<AxialCoord>(true, new List<AxialCoord> { start }, 0f, 0);

            SimplePriorityQueue<PathNode<AxialCoord>> openSet = new SimplePriorityQueue<PathNode<AxialCoord>>();
            HashSet<AxialCoord> closedSet = new HashSet<AxialCoord>();
            Dictionary<AxialCoord, PathNode<AxialCoord>> nodeMap = new Dictionary<AxialCoord, PathNode<AxialCoord>>();

            PathNode<AxialCoord> startNode = new PathNode<AxialCoord>(start)
            {
                GCost = 0,
                HCost = CalculateHeuristic(start, end)
            };
            openSet.Enqueue(startNode);
            nodeMap[start] = startNode;

            int nodesExplored = 0;

            while (openSet.Count > 0)
            {
                PathNode<AxialCoord> currentNode = openSet.Dequeue();

                if (currentNode.Position == end)
                    return RetracePath(nodeMap, start, end, nodesExplored);

                closedSet.Add(currentNode.Position);
                nodesExplored++;

                if (nodesExplored > maxSearchDepth)
                    return PathfindingResult<AxialCoord>.Failure(nodesExplored);

                foreach (AxialCoord neighbourPos in grid.GetAdjacentNeighbours(currentNode.Position, false))
                {
                    if (closedSet.Contains(neighbourPos))
                        continue;

                    T neighbourCell = grid.GetGridObjectAtAxialCoord(neighbourPos);

                    if (!isWalkable(neighbourCell))
                        continue;

                    float tentativeGCost = currentNode.GCost + movementCost(neighbourCell);

                    if (!nodeMap.TryGetValue(neighbourPos, out PathNode<AxialCoord> neighbourNode))
                    {
                        neighbourNode = new PathNode<AxialCoord>(neighbourPos)
                        {
                            GCost = tentativeGCost,
                            HCost = CalculateHeuristic(neighbourPos, end),
                            Parent = currentNode
                        };
                        nodeMap[neighbourPos] = neighbourNode;
                    }

                    if (tentativeGCost < neighbourNode.GCost || !openSet.Contains(neighbourNode))
                    {
                        neighbourNode.GCost = tentativeGCost;
                        neighbourNode.HCost = CalculateHeuristic(neighbourPos, end);
                        neighbourNode.Parent = currentNode;

                        if (!openSet.Contains(neighbourNode))
                            openSet.Enqueue(neighbourNode);
                        else
                            openSet.UpdatePriority(neighbourNode);
                    }
                }
            }

            return PathfindingResult<AxialCoord>.Failure(nodesExplored);
        }

        /// <summary>
        /// Checks if a path exists between the start and end positions.
        /// If it does, the resulting path and related information will be returned in the out parameter.
        /// If not, the result will indicate failure.
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="end">The target position</param>
        /// <param name="pathResult">The result of the pathfinding operation, including the found path, cost, and other relevant information</param>
        /// <returns>True if a path exists, false otherwise</returns>
        public bool IsPathAvailable(AxialCoord start, AxialCoord end, out PathfindingResult<AxialCoord> pathResult)
        {
            pathResult = FindPath(start, end);
            return pathResult.Success;
        }

        private static PathfindingResult<AxialCoord> RetracePath(Dictionary<AxialCoord, PathNode<AxialCoord>> nodeMap, AxialCoord start, AxialCoord end, int nodesExplored)
        {
            List<AxialCoord> path = new List<AxialCoord>();
            AxialCoord current = end;

            while (current != start)
            {
                path.Add(current);
                current = nodeMap[current].Parent.Position;
            }

            path.Add(start);
            path.Reverse();

            return new PathfindingResult<AxialCoord>(true, path, nodeMap[end].GCost, nodesExplored);
        }

        private int CalculateHeuristic(AxialCoord a, AxialCoord b)
        {
            return AxialCoord.Distance(a, b);
        }
    }
}