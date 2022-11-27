using System;
using System.Collections.Generic;
using UnityEngine;

namespace RadarChart
{
    public class RadarChart : MonoBehaviour
    {
        [SerializeField] private CanvasRenderer radarMeshCanvasRenderer;
        [SerializeField] private Material radarMeshMaterial;
        [SerializeField] private Texture2D radarMeshTexture;

        private IStats stats;

        public void SetStats(IStats stats)
        {
            this.stats = stats;

            stats.OnStatsChanged += Stats_OnStatsChanged;

            UpdateStatsVisual();
        }

        private void Stats_OnStatsChanged(object sender, EventArgs e)
        {
            UpdateStatsVisual();
        }

        private void UpdateStatsVisual()
        {
            List<float> statsNormalized = stats.StatsToList();
            int numStats = statsNormalized.Count;

            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[numStats + 1];
            Vector2[] uv = new Vector2[numStats + 1];
            int[] triangles = new int[3 * numStats];

            float angleIncrement = 360f / numStats;
            float radarChartSize = 280f;

            vertices[0] = Vector3.zero;
            for (int i = 0; i < numStats; i++)
            {
                Vector3 vertexValue = Quaternion.Euler(0f, 0f, -angleIncrement * i) * Vector3.up * radarChartSize * statsNormalized[i];
                vertices[i + 1] = vertexValue;
            }

            uv[0] = Vector2.zero;
            for (int i = 0; i < numStats; i++)
            {
                uv[i + 1] = Vector2.one;
            }

            for (int i = 0; i < numStats - 1; i++)
            {
                triangles[(i * 3) + 0] = 0;
                triangles[(i * 3) + 1] = i + 1;
                triangles[(i * 3) + 2] = i + 2;
            }
            triangles[(numStats * 3) - 3] = 0;
            triangles[(numStats * 3) - 2] = numStats;
            triangles[(numStats * 3) - 1] = 1;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            radarMeshCanvasRenderer.SetMesh(mesh);
            radarMeshCanvasRenderer.SetMaterial(radarMeshMaterial, radarMeshTexture);
        }
    }
}
