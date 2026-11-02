using System;
using UnityEngine;

namespace GridSystem
{
	public class RectangleHexGrid<T> : HexGrid<T>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHexGrid{T}"/> class.
        /// </summary>
        /// <param name="hexType">The type of hex this grid is composed of</param>
        /// <param name="centerHexRowColumnAlignment">The alignment of the center row (PointTop) or column (FlatTop) of the grid</param>
        /// <param name="leftOffset">Number of hex cells to the left of the center hex</param>
        /// <param name="rightOffset">Number of hex cells to the right of the center hex</param>
        /// <param name="topOffset">Number of hex cells above the center hex</param>
        /// <param name="bottomOffset">Number of hex cells below the center hex</param>
        /// <param name="edgeLength">The edge length of a hex cell</param>
        /// <param name="gridOriginPosition">The origin position of the hex grid</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<RectangleHexGrid<T>, AxialCoord, T> where RectangleHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object)</param>
        public RectangleHexGrid(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Vector3 gridOriginPosition, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null)
            : base(hexType, edgeLength, gridOriginPosition)
        {
            if (leftOffset < 0)
                throw new ArgumentException($"{nameof(leftOffset)} cannot be negative.");
            if (rightOffset < 0)
                throw new ArgumentException($"{nameof(rightOffset)} cannot be negative.");
            if (topOffset < 0)
                throw new ArgumentException($"{nameof(topOffset)} cannot be negative.");
            if (bottomOffset < 0)
                throw new ArgumentException($"{nameof(bottomOffset)} cannot be negative.");

            ValidateAlignment(hexType, centerHexRowColumnAlignment);

            leftOffset *= -1;
            bottomOffset *= -1;

            if (hexType == HexType.FlatTop)
            {
                for (int q = leftOffset; q <= rightOffset; q++)
                {
                    int qOffset = GetOffset(centerHexRowColumnAlignment, q);
                    for (int r = bottomOffset - qOffset; r <= topOffset - qOffset; r++)
                    {
                        InitializeAxialCoord(q, r, gridObjectInitializer);
                    }
                }
            }
            else if (hexType == HexType.PointTop)
            {
                for (int r = bottomOffset; r <= topOffset; r++)
                {
                    int rOffset = GetOffset(centerHexRowColumnAlignment, r);
                    for (int q = leftOffset - rOffset; q <= rightOffset - rOffset; q++)
                    {
                        InitializeAxialCoord(q, r, gridObjectInitializer);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHexGrid{T}"/> class.
        /// </summary>
        /// <param name="hexType">The type of hex this grid is composed of</param>
        /// <param name="centerHexRowColumnAlignment">The alignment of the center row (PointTop) or column (FlatTop) of the grid</param>
        /// <param name="leftOffset">Number of hex cells to the left of the center hex</param>
        /// <param name="rightOffset">Number of hex cells to the right of the center hex</param>
        /// <param name="topOffset">Number of hex cells above the center hex</param>
        /// <param name="bottomOffset">Number of hex cells below the center hex</param>
        /// <param name="edgeLength">The edge length of a hex cell</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<RectangleHexGrid<T>, AxialCoord, T> where RectangleHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object)</param>
        public RectangleHexGrid(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null)
            : this(hexType, centerHexRowColumnAlignment, leftOffset, rightOffset, topOffset, bottomOffset, edgeLength, Vector3.zero, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHexGrid{T}"/> class.
        /// </summary>
        /// <param name="gridData">The grid data in a serialized format</param>
        public RectangleHexGrid(SerializableHexGrid<T> gridData)
            : base((HexType)gridData.HexType, gridData.EdgeLength, new Vector3(gridData.OriginX, gridData.OriginY, gridData.OriginZ))
        {
            foreach (SerializableHexGrid<T>.HexGridData data in gridData.Data)
            {
                hexGrid[new AxialCoord(data.Q, data.R)] = data.Value;
            }
        }

        private void InitializeAxialCoord(int q, int r, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer)
        {
            AxialCoord axialCoord = new AxialCoord(q, r);

            if (gridObjectInitializer != null)
                hexGrid[axialCoord] = gridObjectInitializer(this, axialCoord);
            else
                hexGrid[axialCoord] = default(T);
        }

        private int GetOffset(HexAlignment hexAlignment, int axisIndex)
        {
            return hexAlignment switch
            {
                HexAlignment.FlatTopDown or HexAlignment.PointTopLeft => (int)Math.Floor(axisIndex / 2f),
                HexAlignment.FlatTopUp or HexAlignment.PointTopRight => (int)Math.Floor((axisIndex + 1) / 2.0f),
                _ => throw new ArgumentOutOfRangeException(nameof(hexAlignment), hexAlignment, null),
            };
        }

        private void ValidateAlignment(HexType hexType, HexAlignment alignment)
        {
            bool valid = hexType switch
            {
                HexType.FlatTop => alignment is HexAlignment.FlatTopDown or HexAlignment.FlatTopUp,
                HexType.PointTop => alignment is HexAlignment.PointTopLeft or HexAlignment.PointTopRight,
                _ => false
            };

            if (!valid)
                throw new ArgumentException($"HexAlignment {alignment} is not compatible with HexType {hexType}");
        }
    }
}