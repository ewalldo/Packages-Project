using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace LootSystem
{
	public class PieChartElement : VisualElement
	{
		public struct Slice
		{
			public string label;
			public float value;
			public Color color;
		}

		private readonly VisualElement pie;
		private readonly VisualElement legend;
		private List<Slice> slices = new List<Slice>();

        public PieChartElement(float diameter = 180f)
        {
            // Stack the pie on top and the legend below, both centered.
            style.flexDirection = FlexDirection.Column;
            style.alignItems = Align.Center;

            // Pie element
            pie = new VisualElement();
            pie.style.width = diameter;
            pie.style.height = diameter;
            pie.style.flexShrink = 0;
            pie.generateVisualContent += OnGeneratePie;
            Add(pie);

            // Legend element
            legend = new VisualElement();
            legend.style.marginTop = 12;
            legend.style.alignItems = Align.FlexStart;
            Add(legend);
        }

        private void OnGeneratePie(MeshGenerationContext context)
        {
            Rect rect = pie.contentRect;
            if (rect.width <= 1f || rect.height <= 1f)
                return;

            float total = 0f;
            foreach (Slice slice in slices)
                total += Mathf.Max(0f, slice.value);

            if (total <= 0f)
                return;

            Vector2 center = rect.center;
            float radius = (Mathf.Min(rect.width, rect.height) * 0.5f) - 1f;

            Painter2D painter = context.painter2D;
            float startDegrees = -90f; // Start at the top of the circle.

            foreach (Slice slice in slices)
            {
                float value = Mathf.Max(0f, slice.value);
                if (value <= 0f)
                    continue;

                float sweep = value / total * 360f;

                painter.fillColor = slice.color;
                painter.BeginPath();

                if (sweep >= 359.999f)
                {
                    // A single item at 100%. Draw the disc as two semicircle arcs along the circumference
                    // so there is no seam running to the center (and no blank full-360 arc).
                    painter.Arc(center, radius, new Angle(0f, AngleUnit.Degree), new Angle(180f, AngleUnit.Degree));
                    painter.Arc(center, radius, new Angle(180f, AngleUnit.Degree), new Angle(360f, AngleUnit.Degree));
                }
                else
                {
                    // Draw each wedge as one path; splitting it would leave an anti-aliased seam mid-wedge.
                    painter.MoveTo(center);
                    painter.Arc(center, radius, new Angle(startDegrees, AngleUnit.Degree), new Angle(startDegrees + sweep, AngleUnit.Degree));
                    painter.LineTo(center);
                }

                painter.ClosePath();
                painter.Fill();

                startDegrees += sweep;
            }
        }

        public void SetSlices(IEnumerable<Slice> newSlices)
        {
            slices = new List<Slice>(newSlices);
            RebuildLegend();
            pie.MarkDirtyRepaint();
        }

        private void RebuildLegend()
        {
            legend.Clear();

            foreach (Slice slice in slices)
            {
                VisualElement row = new VisualElement();
                row.style.flexDirection = FlexDirection.Row;
                row.style.alignItems = Align.Center;
                row.style.marginBottom = 3;

                VisualElement swatch = new VisualElement();
                swatch.style.width = 12;
                swatch.style.height = 12;
                swatch.style.flexShrink = 0;
                swatch.style.backgroundColor = slice.color;
                swatch.style.borderTopLeftRadius = 2;
                swatch.style.borderTopRightRadius = 2;
                swatch.style.borderBottomLeftRadius = 2;
                swatch.style.borderBottomRightRadius = 2;
                row.Add(swatch);

                Label label = new Label(slice.label);
                label.style.marginLeft = 6;
                label.style.whiteSpace = WhiteSpace.Normal;
                label.style.flexShrink = 1;
                row.Add(label);

                legend.Add(row);
            }
        }
    }
}