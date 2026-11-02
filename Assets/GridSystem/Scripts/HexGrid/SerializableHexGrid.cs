using System;

namespace GridSystem
{
	[Serializable]
	public class SerializableHexGrid<T>
	{
        public int HexType;
        public float EdgeLength;

        public float OriginX;
        public float OriginY;
        public float OriginZ;

        public HexGridData[] Data;

        public SerializableHexGrid() { }

        public SerializableHexGrid(HexGrid<T> grid)
        {
            HexType = (int)grid.HexGridType;
            EdgeLength = grid.EdgeLength;
            OriginX = grid.GridOriginPosition.x;
            OriginY = grid.GridOriginPosition.y;
            OriginZ = grid.GridOriginPosition.z;

            Data = new HexGridData[grid.Count];
            int index = 0;
            foreach ((AxialCoord coord, T value) in grid.GetGridObjectsWithPositions())
            {
                Data[index++] = new HexGridData(coord.Q, coord.R, value);
            }
        }

        [Serializable]
        public class HexGridData
        {
            public int Q;
            public int R;
            public T Value;
            public HexGridData() { }
            public HexGridData(int q, int r, T value)
            {
                Q = q;
                R = r;
                Value = value;
            }
        }
    }
}
