using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    [Serializable]
	public struct GridPosition2D : IEquatable<GridPosition2D>
	{
        [SerializeField] private int x;
        [SerializeField] private int z;

        public int X => x;
        public int Z => z;

        [NonSerialized] private List<GridPosition2D> directNeighbours;
        /// <summary>
        /// Get all the direct (sides) neighbours from this GridPosition2D
        /// </summary>
        public List<GridPosition2D> DirectNeighbours
        {
            get
            {
                if (directNeighbours == null)
                    InitializeDirectNeighboursList();

                return directNeighbours;
            }
        }

        [NonSerialized] private List<GridPosition2D> neighbours;
        /// <summary>
        /// Get all the neighbour positions (side and diagonals) from this GridPosition2D
        /// </summary>
        public List<GridPosition2D> Neighbours
        {
            get
            {
                if (neighbours == null)
                    InitializeNeighboursList();

                return neighbours;
            }
        }

        public GridPosition2D(int x, int z) : this()
        {
            this.x = x;
            this.z = z;
        }

        /// <summary>
        /// Calculates the Manhattan distance between this and a different GridPosition2D
        /// </summary>
        /// <param name="other">The GridPosition2D to calculate the distance from</param>
        /// <returns>The distance between the two positions</returns>
        public int ManhattanDistanceFrom(GridPosition2D other)
        {
            return ManhattanDistance(this, other);
        }

        /// <summary>
        /// Calculates the Chebyshev distance between this and a different GridPosition2D
        /// </summary>
        /// <param name="other">The GridPosition2D to calculate the distance from</param>
        /// <returns>The distance between the two positions</returns>
        public int ChebyshevDistanceFrom(GridPosition2D other)
        {
            return ChebyshevDistance(this, other);
        }

        /// <summary>
        /// Get all the grid positions within a range
        /// </summary>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeSelf">Whether to include the current position in the returned set</param>
        /// <returns>Set containing all the positions within the range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromADistanceRange(int range, bool includeSelf = true)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
                    if (Math.Abs(x) + Math.Abs(z) > range)
                        continue;

                    if (!includeSelf && x == 0 && z == 0)
                        continue;

                    GridPosition2D gridPosition = this + (new GridPosition2D(x, z));
                    rangeList.Add(gridPosition);
                }
            }

            return rangeList;
        }

        /// <summary>
        /// Get all the grid position within a square range
        /// </summary>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeSelf">Whether to include the current position in the returned set</param>
        /// <returns>Set containing all the positions within the square range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromASquareRange(int range, bool includeSelf = true)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
                    if (!includeSelf && x == 0 && z == 0)
                        continue;

                    GridPosition2D gridPosition = this + (new GridPosition2D(x, z));
                    rangeList.Add(gridPosition);
                }
            }

            return rangeList;
        }

        /// <summary>
        /// Get all grid positions within a circular range from this position
        /// </summary>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeSelf">Whether to include the current position in the returned set</param>
        /// <returns>Set containing all the positions within the circular range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromACircularRange(float range, bool includeSelf = true)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            foreach (GridPosition2D gridPosition in GetGridPositionsFromASquareRange(Mathf.CeilToInt(range), includeSelf))
            {
                GridPosition2D distance = this - gridPosition;
                distance *= distance;

                if ((distance.X + distance.Z) <= range * range)
                    rangeList.Add(gridPosition);
            }

            return rangeList;
        }

        public override bool Equals(object obj)
        {
            return obj is GridPosition2D position && X == position.X && Z == position.Z;
        }

        public bool Equals(GridPosition2D other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Z);
        }

        public override string ToString()
        {
            return $"({X}, {Z})";
        }

        public static bool operator ==(GridPosition2D a, GridPosition2D b)
        {
            return a.X == b.X && a.Z == b.Z;
        }

        public static bool operator !=(GridPosition2D a, GridPosition2D b)
        {
            return !(a == b);
        }

        public static GridPosition2D operator +(GridPosition2D a, GridPosition2D b)
        {
            return new GridPosition2D(a.X + b.X, a.Z + b.Z);
        }

        public static GridPosition2D operator -(GridPosition2D a, GridPosition2D b)
        {
            return new GridPosition2D(a.X - b.X, a.Z - b.Z);
        }

        public static GridPosition2D operator *(GridPosition2D a, GridPosition2D b)
        {
            return new GridPosition2D(a.X * b.X, a.Z * b.Z);
        }

        public static GridPosition2D operator *(GridPosition2D a, int k)
        {
            return new GridPosition2D(a.X * k, a.Z * k);
        }

        public static GridPosition2D operator /(GridPosition2D a, GridPosition2D b)
        {
            if (b.X == 0 || b.Z == 0)
                throw new DivideByZeroException("GridPosition2D division by zero");

            return new GridPosition2D(a.X / b.X, a.Z / b.Z);
        }

        public static GridPosition2D operator %(GridPosition2D a, GridPosition2D b)
        {
            if (b.X == 0 || b.Z == 0)
                throw new DivideByZeroException("GridPosition2D modulo by zero");

            return new GridPosition2D(a.X % b.X, a.Z % b.Z);
        }

        public static GridPosition2D operator -(GridPosition2D a)
        {
            return new GridPosition2D(-a.X, -a.Z);
        }

        private void InitializeDirectNeighboursList()
        {
            directNeighbours = new List<GridPosition2D>
            {
                this + Right,
                this + Down,
                this + Left,
                this + Up
            };
        }

        private void InitializeNeighboursList()
        {
            neighbours = new List<GridPosition2D>
            {
                this + Right,
                this + DownRight,
                this + Down,
                this + DownLeft,
                this + Left,
                this + UpLeft,
                this + Up,
                this + UpRight
            };
        }

        /// <summary>
        /// Calculates the Manhattan distance between two GridPosition2D
        /// </summary>
        /// <param name="a">The first GridPosition2D</param>
        /// <param name="b">The second GridPosition2D</param>
        /// <returns>The distance between the two positions</returns>
        public static int ManhattanDistance(GridPosition2D a, GridPosition2D b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Z - b.Z);
        }

        /// <summary>
        /// Calculates the Chebyshev distance between two GridPosition2D
        /// </summary>
        /// <param name="a">The first GridPosition2D</param>
        /// <param name="b">The second GridPosition2D</param>
        /// <returns>The distance between the two positions</returns>
        public static int ChebyshevDistance(GridPosition2D a, GridPosition2D b)
        {
            return Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Z - b.Z));
        }

        public static readonly GridPosition2D Zero = new GridPosition2D(0, 0);
        public static readonly GridPosition2D One = new GridPosition2D(1, 1);
        public static readonly GridPosition2D Right = new GridPosition2D(1, 0);
        public static readonly GridPosition2D Left = new GridPosition2D(-1, 0);
        public static readonly GridPosition2D Up = new GridPosition2D(0, 1);
        public static readonly GridPosition2D Down = new GridPosition2D(0, -1);

        public static readonly GridPosition2D UpRight = new GridPosition2D(1, 1);
        public static readonly GridPosition2D UpLeft = new GridPosition2D(-1, 1);
        public static readonly GridPosition2D DownRight = new GridPosition2D(1, -1);
        public static readonly GridPosition2D DownLeft = new GridPosition2D(-1, -1);
    }
}