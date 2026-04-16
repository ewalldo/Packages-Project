using System;

namespace GridSystem
{
    [Serializable]
    public class SerializableGrid2D<T>
    {
        public int Width;
        public int Height;
        public float CellSizeX;
        public float CellSizeZ;

        public float OriginX;
        public float OriginY;
        public float OriginZ;

        public T[] Data;

        public SerializableGrid2D() { }

        public SerializableGrid2D(Grid2D<T> grid)
        {
            Width = grid.Width;
            Height = grid.Height;
            CellSizeX = grid.CellSizeX;
            CellSizeZ = grid.CellSizeZ;
            OriginX = grid.GridOriginPosition.x;
            OriginY = grid.GridOriginPosition.y;
            OriginZ = grid.GridOriginPosition.z;

            Data = new T[Width * Height];
            int index = 0;
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    Data[index++] = grid[x, z];
                }
            }
        }
    }
}
