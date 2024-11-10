using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    [Serializable]
	public struct GridPosition2D : IEquatable<GridPosition2D>
	{
        public int X;
        public int Z;

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
        /// <summary>
        /// Get a specific direct neighbour from this GridPosition2D
        /// </summary>
        /// <param name="idx">The direct neighbour index</param>
        /// <returns>The neighbour at the idx position</returns>
        public GridPosition2D GetDirectNeighbour(int idx) => DirectNeighbours[(4 + (idx % 4)) % 4];

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
        /// <summary>
        /// Get a specific neighbour from this GridPosition2D
        /// </summary>
        /// <param name="idx">The neighbour index</param>
        /// <returns>The neighbour at the idx position</returns>
        public GridPosition2D GetNeighbour(int idx) => Neighbours[(8 + (idx % 8)) % 8];

        public GridPosition2D(int x, int z) : this()
        {
            this.X = x;
            this.Z = z;
        }

        /// <summary>
        /// Calculates the Manhattan distance between this and a different GridPosition2D
        /// </summary>
        /// <param name="other">The GridPosition2D to calculate the distance from</param>
        /// <returns>The distance between the two positions</returns>
        public int DistanceFrom(GridPosition2D other)
        {
            return ManhattanDistance(this, other);
        }

        /// <summary>
        /// Get all the grid positions within a range
        /// </summary>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <returns>Set containing all the positions within the range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromADistanceRange(int range)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
                    if (Mathf.Abs(x) + Mathf.Abs(z) > range)
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
        /// <returns>Set containing all the positions within the square range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromASquareRange(int range)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
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
        /// <returns>Set containing all the positions within the circular range</returns>
        public HashSet<GridPosition2D> GetGridPositionsFromACircularRange(float range)
        {
            HashSet<GridPosition2D> rangeList = new HashSet<GridPosition2D>();

            foreach (GridPosition2D gridPosition in GetGridPositionsFromASquareRange(Mathf.CeilToInt(range)))
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
            return "(" + X + ", " + Z + ")";
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
            return new GridPosition2D(a.X / b.X, a.Z / b.Z);
        }

        public static GridPosition2D operator %(GridPosition2D a, GridPosition2D b)
        {
            return new GridPosition2D(a.X % b.X, a.Z % b.Z);
        }

        public static GridPosition2D operator !(GridPosition2D a)
        {
            return new GridPosition2D(-a.X, -a.Z);
        }

        private void InitializeDirectNeighboursList()
        {
            directNeighbours = new List<GridPosition2D>
            {
                this + new GridPosition2D(1, 0),
                this + new GridPosition2D(0, -1),
                this + new GridPosition2D(-1, 0),
                this + new GridPosition2D(0, 1)
            };
        }

        private void InitializeNeighboursList()
        {
            neighbours = new List<GridPosition2D>
            {
                this + new GridPosition2D(1, 0),
                this + new GridPosition2D(1, -1),
                this + new GridPosition2D(0, -1),
                this + new GridPosition2D(-1, -1),
                this + new GridPosition2D(-1, 0),
                this + new GridPosition2D(-1, 1),
                this + new GridPosition2D(0, 1),
                this + new GridPosition2D(1, 1)
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
            return Mathf.Abs(a.X - b.X) + Mathf.Abs(a.Z - b.Z);
        }
    }
}