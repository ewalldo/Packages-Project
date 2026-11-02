namespace GridSystem.Pathfinding
{
	public class PathfindingOptions2D
	{
        /// <summary>
        /// Whether diagonal movement is allowed
        /// </summary>
        public bool AllowDiagonalMovement { get; set; }

        /// <summary>
        /// Whether diagonal movement can cut through blocked corners.
        /// If true, the unit can move diagonally even if one of the adjacent orthogonal cells is blocked, effectively cutting through the corner of the blocked cell.
        /// If false, the unit would have to move around the corner instead.
        /// Only relevant when AllowDiagonalMovement = true. Controls whether a unit can cut through the corner of a blocked cell when moving diagonally.
        /// </summary>
        public bool AllowCuttingCorners { get; set; }

        /// <summary>
        /// Whether diagonal movement should cost more than cardinal movement.
        /// If true, diagonal movement will cost more than cardinal movement (e.g. 1.4 instead of 1) to reflect the longer distance traveled.
        /// If false, diagonal movement will cost the same as cardinal movement (e.g. 1) for simplicity.
        /// Only relevant when AllowDiagonalMovement = true. Applies an extra movement cost to diagonal steps.
        /// </summary>
        public bool ApplyDiagonalCostPenalty { get; set; }

        /// <summary>
        /// The heuristic function to use for A*.
        /// Manhattan: Uses the Manhattan distance (L1 norm) as the heuristic, which is suitable for grids with only cardinal (4-directional) movement.
        /// Chebyshev: Uses the Chebyshev distance (L�� norm) as the heuristic, which is suitable for grids with 8-directional movement.
        /// Euclidean: Uses the Euclidean distance (L2 norm) as the heuristic, which is suitable for grids with free movement.
        /// </summary>
        public PathfindingHeuristic Heuristic { get; set; }

        public enum PathfindingHeuristic
        {
            Manhattan,
            Chebyshev,
            Euclidean
        }

        /// <summary>
        /// Maximum search depth for pathfinding
        /// </summary>
        public int MaxSearchDepth { get; set; }

        public PathfindingOptions2D(bool allowDiagonalMovement, bool allowCuttingCorners, bool applyDiagonalCostPenalty, PathfindingHeuristic heuristic, int maxSearchDepth = int.MaxValue)
        {
            AllowDiagonalMovement = allowDiagonalMovement;
            AllowCuttingCorners = allowCuttingCorners;
            ApplyDiagonalCostPenalty = applyDiagonalCostPenalty;
            Heuristic = heuristic;
            MaxSearchDepth = maxSearchDepth;
        }

        public PathfindingOptions2D()
            : this(false, false, true, PathfindingHeuristic.Manhattan, int.MaxValue) { }
    }
}