using System;
using UnityEngine;

namespace GridSystem
{
	public class HexagonHexGrid<T> : HexGrid<T>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="HexagonHexGrid{T}"/> class.
        /// </summary>
        /// <param name="hexType">The type of hex this grid is composed of</param>
        /// <param name="rangeFromCenter">The number of hex cells on each direction from the center</param>
        /// <param name="edgeLength">The edge length of a hex cell</param>
        /// <param name="gridOriginPosition">The origin position of the hex grid</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<HexagonHexGrid<T>, AxialCoord, T> where HexagonHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object)</param>
        public HexagonHexGrid(HexType hexType, int rangeFromCenter, float edgeLength, Vector3 gridOriginPosition, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null)
            : base(hexType, edgeLength, gridOriginPosition)
        {
            if (rangeFromCenter < 0)
                throw new ArgumentException($"{nameof(rangeFromCenter)} cannot be negative.");

            for (int q = -rangeFromCenter; q <= rangeFromCenter; q++)
            {
                int r1 = Mathf.Max(-rangeFromCenter, -q - rangeFromCenter);
                int r2 = Mathf.Min(rangeFromCenter, -q + rangeFromCenter);
                for (int r = r1; r <= r2; r++)
                {
                    AxialCoord axialCoord = new AxialCoord(q, r);

                    if (gridObjectInitializer != null)
                        hexGrid[axialCoord] = gridObjectInitializer(this, axialCoord);
                    else
                        hexGrid[axialCoord] = default(T);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexagonHexGrid{T}"/> class.
        /// </summary>
        /// <param name="hexType">The type of hex this grid is composed of</param>
        /// <param name="rangeFromCenter">The number of hex cells on each direction from the center</param>
        /// <param name="edgeLength">The edge length of a hex cell</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<HexagonHexGrid<T>, AxialCoord, T> where HexagonHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object)</param>
        public HexagonHexGrid(HexType hexType, int rangeFromCenter, float edgeLength, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null)
            : this(hexType, rangeFromCenter, edgeLength, Vector3.zero, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexagonHexGrid{T}"/> class.
        /// </summary>
        /// <param name="gridData">The grid data in a serialized format</param>
        public HexagonHexGrid(SerializableHexGrid<T> gridData)
            : base((HexType)gridData.HexType, gridData.EdgeLength, new Vector3(gridData.OriginX, gridData.OriginY, gridData.OriginZ))
        {
            foreach (SerializableHexGrid<T>.HexGridData data in gridData.Data)
            {
                hexGrid[new AxialCoord(data.Q, data.R)] = data.Value;
            }
        }
    }
}