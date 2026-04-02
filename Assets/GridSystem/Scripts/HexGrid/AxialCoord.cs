using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	[Serializable]
	public struct AxialCoord : IEquatable<AxialCoord>
	{
        public int Q;
        public int R;
        public int S;

        [NonSerialized] private List<AxialCoord> neighbours;
        /// <summary>
        /// Get all the neighbour positions from this AxialCoord
        /// </summary>
        public List<AxialCoord> Neighbours
        {
            get
            {
                if (neighbours == null)
                    InitializeNeighboursList();

                return neighbours;
            }
        }
        /// <summary>
        /// Get a specific neighbour from this AxialCoord
        /// </summary>
        /// <param name="idx">The neighbour index</param>
        /// <returns>The neighbour at the index position</returns>
        public AxialCoord GetNeighbour(int idx) => Neighbours[(6 + (idx % 6)) % 6];

        [NonSerialized] private List<AxialCoord> diagonals;
        /// <summary>
        /// Get all the diagonal positions from this AxialCoord
        /// </summary>
        public List<AxialCoord> Diagonals
        {
            get
            {
                if (diagonals == null)
                    InitializeDiagonalsList();

                return diagonals;
            }
        }
        /// <summary>
        /// Get a specific diagonal from this AxialCoord
        /// </summary>
        /// <param name="idx">The diagonal index</param>
        /// <returns>The diagonal at the index position</returns>
        public AxialCoord GetDiagonal(int idx) => Diagonals[(6 + (idx % 6)) % 6];

        public AxialCoord(int q, int r) : this()
        {
            this.Q = q;
            this.R = r;
            this.S = -q - r;
        }

        /// <summary>
        /// Calculates the distance between this and a different AxialCoord
        /// </summary>
        /// <param name="other">The AxialCoord to calculate the distance from</param>
        /// <returns>The distance between the two positions</returns>
        public int DistanceFrom(AxialCoord other)
        {
            return Distance(this, other);
        }

        /// <summary>
        /// Get all AxialCoord within a range
        /// </summary>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <returns>Set containing all the positions within the range</returns>
        public HashSet<AxialCoord> GetAxialCoordsWithinRange(int range)
        {
            HashSet<AxialCoord> withinRange = new HashSet<AxialCoord>();

            for (int q = -range; q <= range; q++)
            {
                for (int r = Mathf.Max(-range, -q - range); r <= Mathf.Min(range, -q + range); r++)
                {
                    withinRange.Add(this + new AxialCoord(q, r));
                }
            }

            return withinRange;
        }

        /// <summary>
        /// Get the AxialCoord position when reflecting through the Q-axis
        /// </summary>
        public AxialCoord ReflectQ => new AxialCoord(Q, S);
        /// <summary>
        /// Get the AxialCoord position when reflecting through the R-axis
        /// </summary>
        public AxialCoord ReflectR => new AxialCoord(S, R);
        /// <summary>
        /// Get the AxialCoord position when reflecting through the S-axis
        /// </summary>
        public AxialCoord ReflectS => new AxialCoord(R, Q);

        public override bool Equals(object obj)
        {
            return obj is AxialCoord axialCoord && Q == axialCoord.Q && R == axialCoord.R && S == axialCoord.S;
        }

        public bool Equals(AxialCoord other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Q, R, S);
        }
        public override string ToString()
        {
            return $"({Q}, {R}, {S})";
        }

        public static bool operator ==(AxialCoord a, AxialCoord b)
        {
            return a.Q == b.Q && a.R == b.R && a.S == b.S;
        }

        public static bool operator !=(AxialCoord a, AxialCoord b)
        {
            return !(a == b);
        }

        public static AxialCoord operator +(AxialCoord a, AxialCoord b)
        {
            return new AxialCoord(a.Q + b.Q, a.R + b.R);
        }

        public static AxialCoord operator -(AxialCoord a, AxialCoord b)
        {
            return new AxialCoord(a.Q - b.Q, a.R - b.R);
        }

        public static AxialCoord operator *(AxialCoord a, int k)
        {
            return new AxialCoord(a.Q * k, a.R * k);
        }

        private void InitializeNeighboursList()
        {
            neighbours = new List<AxialCoord>
            {
                this + new AxialCoord(1, 0),
                this + new AxialCoord(1, -1),
                this + new AxialCoord(0, -1),
                this + new AxialCoord(-1, 0),
                this + new AxialCoord(-1, 1),
                this + new AxialCoord(0, 1)
            };
        }

        private void InitializeDiagonalsList()
        {
            diagonals = new List<AxialCoord>
            {
                this + new AxialCoord(2, -1),
                this + new AxialCoord(1, -2),
                this + new AxialCoord(-1, -1),
                this + new AxialCoord(-2, 1),
                this + new AxialCoord(-1, 2),
                this + new AxialCoord(1, 1)
            };
        }

        /// <summary>
        /// Calculates the distance between two AxialCoord
        /// </summary>
        /// <param name="a">The first AxialCoord</param>
        /// <param name="b">The second AxialCoord</param>
        /// <returns>The distance between the two positions</returns>
        public static int Distance(AxialCoord a, AxialCoord b)
        {
            AxialCoord diff = a - b;
            return Length(diff);
        }

        /// <summary>
        /// Calculates the length of an AxialCoord
        /// </summary>
        /// <param name="a">The AxialCoord to calculate the length</param>
        /// <returns>The AxialCoord's length</returns>
        public static int Length(AxialCoord a)
        {
            return Mathf.Max(Mathf.Abs(a.Q), Mathf.Abs(a.R), Mathf.Abs(a.S));
        }
    }
}