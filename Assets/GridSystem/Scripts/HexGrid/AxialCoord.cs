using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	[Serializable]
	public struct AxialCoord : IEquatable<AxialCoord>, IGridCell
	{
        [SerializeField] private int q;
        [SerializeField] private int r;

        public int Q => q;
        public int R => r;
        public int S => -Q - R;

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

        public AxialCoord(int q, int r) : this()
        {
            this.q = q;
            this.r = r;
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
        /// <param name="includeSelf">Whether to include the current position in the returned set</param>
        /// <returns>Set containing all the positions within the range</returns>
        public HashSet<AxialCoord> GetAxialCoordsWithinRange(int range, bool includeSelf = true)
        {
            HashSet<AxialCoord> withinRange = new HashSet<AxialCoord>();

            for (int q = -range; q <= range; q++)
            {
                for (int r = Mathf.Max(-range, -q - range); r <= Mathf.Min(range, -q + range); r++)
                {
                    if (!includeSelf && q == 0 && r == 0)
                        continue;

                    withinRange.Add(this + new AxialCoord(q, r));
                }
            }

            return withinRange;
        }

        /// <summary>
        /// Reflects this coordinate across the Q axis (keeping Q constant, swapping R and S)
        /// </summary>
        public AxialCoord ReflectQ => new AxialCoord(Q, S);
        /// <summary>
        /// Reflects this coordinate across the R axis (keeping R constant, swapping Q and S)
        /// </summary>
        public AxialCoord ReflectR => new AxialCoord(S, R);
        /// <summary>
        /// Reflects this coordinate across the S axis (keeping S constant, swapping Q and R)
        /// </summary>
        public AxialCoord ReflectS => new AxialCoord(R, Q);

        /// <summary>
        /// Rotates this coordinate 60Åã clockwise around the origin
        /// </summary>
        public AxialCoord RotateClockwise => new AxialCoord(-R, -S);

        /// <summary>
        /// Rotates this coordinate 60Åã counter-clockwise around the origin
        /// </summary>
        public AxialCoord RotateCounterClockwise => new AxialCoord(-S, -Q);

        /// <summary>
        /// Rotates this coordinate around a center point
        /// </summary>
        /// <param name="center">The center point to rotate around</param>
        /// <param name="steps">The number of 60Åã steps to rotate</param>
        /// <returns>The rotated AxialCoord</returns>
        public AxialCoord RotateClockwiseAround(AxialCoord center, int steps = 1)
        {
            AxialCoord offset = this - center;
            for (int i = 0; i < ((steps % 6) + 6) % 6; i++)
                offset = offset.RotateClockwise;
            return center + offset;
        }

        public override bool Equals(object obj)
        {
            return obj is AxialCoord axialCoord && Q == axialCoord.Q && R == axialCoord.R;
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
            return a.Q == b.Q && a.R == b.R;
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
            return (Mathf.Abs(a.Q) + Mathf.Abs(a.R) + Mathf.Abs(a.S)) / 2;
        }

        public static readonly AxialCoord Zero = new AxialCoord(0, 0);

    }
}