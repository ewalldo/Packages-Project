using System;

namespace GridSystem
{
	public struct GridPosition2D : IEquatable<GridPosition2D>
	{
        public int X;
        public int Z;

        public GridPosition2D(int x, int z)
        {
            this.X = x;
            this.Z = z;
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
    }
}