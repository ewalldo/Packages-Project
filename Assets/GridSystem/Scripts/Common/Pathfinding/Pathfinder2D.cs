using System;
using System.Collections.Generic;
using static GridSystem.Pathfinding.PathfindingOptions2D;

namespace GridSystem.Pathfinding
{
    public class Pathfinder2D<T>
    {
        private readonly Grid2D<T> grid;
        private readonly Func<T, bool> isWalkable;
        private readonly Func<T, int> movementCost;
        private readonly PathfindingOptions2D options;

        private const float DIAGONAL_COST = 1.41421356f; // sqrt(2)

        /// <summary>
        /// Initializes a new instance of the Pathfinder class.
        /// </summary>
        /// <param name="grid">The grid to pathfind on</param>
        /// <param name="isWalkable">Predicate that defines if a cell is walkable</param>
        /// <param name="movementCost">Optional per-cell movement cost (defaults to 1)</param>
        /// <param name="options">Optional configuration</param>
        public Pathfinder2D(Grid2D<T> grid, Func<T, bool> isWalkable, Func<T, int> movementCost = null, PathfindingOptions2D options = null)
        {
            this.grid = grid ?? throw new ArgumentNullException(nameof(grid));
            this.isWalkable = isWalkable ?? throw new ArgumentNullException(nameof(isWalkable));
            this.movementCost = movementCost ?? (_ => 1); // Default movement cost is 1 for all tiles
            this.options = options ?? new PathfindingOptions2D();
        }

        /// <summary>
        /// Initializes a Pathfinder using a grid of ITraversalProvider objects, which simplifies the setup by using the properties of the object directly.
        /// </summary>
        /// <param name="grid">The grid to pathfind on</param>
        /// <param name="options">Optional configuration</param>
        /// <returns>Pathfinder instance</returns>
        public static Pathfinder2D<T2> CreateFromTraversalProvider<T2>(Grid2D<T2> grid, PathfindingOptions2D options = null) where T2 : ITraversalProvider
        {
            return new Pathfinder2D<T2>(grid, cell => cell != null && cell.IsWalkable, cell => cell?.MovementCost ?? 1, options);
        }

        /// <summary>
        /// Finds a path from the start position to the end position
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="end">The target position</param>
        /// <returns>The result of the pathfinding operation, including the found path, cost, and other relevant information</returns>
        public PathfindingResult<GridPosition2D> FindPath(GridPosition2D start, GridPosition2D end)
        {
            if (!grid.IsWithinGrid2DBounds(start))
                throw new ArgumentOutOfRangeException(nameof(start), $"Start position {start} is outside grid bounds");

            if (!grid.IsWithinGrid2DBounds(end))
                throw new ArgumentOutOfRangeException(nameof(end), $"End position {end} is outside grid bounds");

            if (!isWalkable(grid.GetGridObjectAtGridPosition2D(end)))
                return PathfindingResult<GridPosition2D>.Failure(0);

            if (start == end)
                return new PathfindingResult<GridPosition2D>(true, new List<GridPosition2D> { start }, 0f, 0);

            SimplePriorityQueue<PathNode<GridPosition2D>> openSet = new SimplePriorityQueue<PathNode<GridPosition2D>>();
            HashSet<GridPosition2D> closedSet = new HashSet<GridPosition2D>();
            Dictionary<GridPosition2D, PathNode<GridPosition2D>> nodeMap = new Dictionary<GridPosition2D, PathNode<GridPosition2D>>();

            PathNode<GridPosition2D> startNode = new PathNode<GridPosition2D>(start)
            {
                GCost = 0,
                HCost = CalculateHeuristic(start, end)
            };
            openSet.Enqueue(startNode);
            nodeMap[start] = startNode;

            int nodesExplored = 0;

            while (openSet.Count > 0)
            {
                PathNode<GridPosition2D> currentNode = openSet.Dequeue();

                if (currentNode.Position == end)
                    return RetracePath(nodeMap, start, end, nodesExplored);

                closedSet.Add(currentNode.Position);
                nodesExplored++;

                if (nodesExplored > options.MaxSearchDepth)
                    return PathfindingResult<GridPosition2D>.Failure(nodesExplored);

                foreach (GridPosition2D neighbourPos in grid.GetAdjacentNeighbours(currentNode.Position, false, options.AllowDiagonalMovement))
                {
                    if (closedSet.Contains(neighbourPos))
                        continue;

                    T neighbourCell = grid.GetGridObjectAtGridPosition2D(neighbourPos);

                    if (!isWalkable(neighbourCell))
                        continue;

                    if (options.AllowDiagonalMovement && !options.AllowCuttingCorners && IsCuttingCorner(currentNode.Position, neighbourPos))
                        continue;

                    float tentativeGCost = currentNode.GCost + (movementCost(neighbourCell) * GetMovementCostMultiplier(currentNode.Position, neighbourPos));

                    if (!nodeMap.TryGetValue(neighbourPos, out PathNode<GridPosition2D> neighbourNode))
                    {
                        neighbourNode = new PathNode<GridPosition2D>(neighbourPos)
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

            return PathfindingResult<GridPosition2D>.Failure(nodesExplored);
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
        public bool IsPathAvailable(GridPosition2D start, GridPosition2D end, out PathfindingResult<GridPosition2D> pathResult)
        {
            pathResult = FindPath(start, end);
            return pathResult.Success;
        }

        private static PathfindingResult<GridPosition2D> RetracePath(Dictionary<GridPosition2D, PathNode<GridPosition2D>> nodeMap, GridPosition2D start, GridPosition2D end, int nodesExplored)
        {
            List<GridPosition2D> path = new List<GridPosition2D>();
            GridPosition2D current = end;

            while (current != start)
            {
                path.Add(current);
                current = nodeMap[current].Parent.Position;
            }

            path.Add(start);
            path.Reverse();

            return new PathfindingResult<GridPosition2D>(true, path, nodeMap[end].GCost, nodesExplored);
        }

        private int CalculateHeuristic(GridPosition2D a, GridPosition2D b)
        {
            return options.Heuristic switch
            {
                PathfindingHeuristic.Manhattan => GridPosition2D.ManhattanDistance(a, b),
                PathfindingHeuristic.Chebyshev => GridPosition2D.ChebyshevDistance(a, b),
                PathfindingHeuristic.Euclidean => (int)(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Z - b.Z, 2)) * 10),
                _ => GridPosition2D.ManhattanDistance(a, b)
            };
        }

        private bool IsCuttingCorner(GridPosition2D from, GridPosition2D to)
        {
            int dx = to.X - from.X;
            int dz = to.Z - from.Z;

            // If moving diagonally, check if either of the adjacent orthogonal tiles are unwalkable
            if (IsDiagonalMove(from, to))
            {
                GridPosition2D neighbor1 = new GridPosition2D(from.X + dx, from.Z);
                GridPosition2D neighbor2 = new GridPosition2D(from.X, from.Z + dz);

                return !isWalkable(grid.GetGridObjectAtGridPosition2D(neighbor1)) || !isWalkable(grid.GetGridObjectAtGridPosition2D(neighbor2));
            }

            // Not a diagonal move, so not cutting a corner
            return false;
        }

        private float GetMovementCostMultiplier(GridPosition2D from, GridPosition2D to)
        {
            if (!options.ApplyDiagonalCostPenalty || !IsDiagonalMove(from, to))
                return 1;

            // If moving diagonally, apply a cost penalty (e.g. ~1.4 times the normal cost)
            return DIAGONAL_COST;
        }

        private bool IsDiagonalMove(GridPosition2D from, GridPosition2D to)
        {
            int dx = Math.Abs(to.X - from.X);
            int dz = Math.Abs(to.Z - from.Z);

            return dx == 1 && dz == 1;
        }
    }
}