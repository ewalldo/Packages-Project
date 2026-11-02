using GOAP.Agent;
using UnityEditor;
using UnityEngine;

namespace GOAP.Editor
{
    /// <summary>
    /// Shared GUIStyle definitions for all GOAP editor windows and inspectors.
    /// Initialized lazily on first access to avoid Editor startup cost.
    /// </summary>
    internal static class GoapEditorStyles
    {
        // - Initialization -

        private static bool initialized;

        private static void EnsureInitialized()
        {
            if (initialized)
                return;
            
            initialized = true;
            Initialize();
        }

        private static void Initialize()
        {
            // - Section Header -
            SectionHeader = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize  = 12,
                alignment = TextAnchor.MiddleLeft,
                padding   = new RectOffset(4, 0, 4, 4)
            };

            // - State Badge -
            StateBadge = new GUIStyle(EditorStyles.miniLabel)
            {
                alignment = TextAnchor.MiddleCenter,
                padding   = new RectOffset(6, 6, 2, 2),
                fontStyle = FontStyle.Bold,
                normal    = { background = MakeTex(1, 1, new Color(0.2f, 0.2f, 0.2f)) }
            };

            // - Action Node -
            ActionNodeNormal = new GUIStyle("box")
            {
                alignment = TextAnchor.MiddleLeft,
                fontSize  = 11,
                padding   = new RectOffset(8, 8, 6, 6),
                normal    = { background = MakeTex(1, 1, new Color(0.25f, 0.25f, 0.25f)) },
                stretchWidth = true
            };

            ActionNodeActive = new GUIStyle(ActionNodeNormal)
            {
                normal = { background = MakeTex(1, 1, new Color(0.15f, 0.5f, 0.15f)) }
            };

            ActionNodeFailed = new GUIStyle(ActionNodeNormal)
            {
                normal = { background = MakeTex(1, 1, new Color(0.5f, 0.15f, 0.15f)) }
            };

            ActionNodeCompleted = new GUIStyle(ActionNodeNormal)
            {
                normal = { background = MakeTex(1, 1, new Color(0.15f, 0.35f, 0.55f)) }
            };

            // - Fact Row -
            FactRowEven = new GUIStyle
            {
                normal    = { background = MakeTex(1, 1, new Color(0.18f, 0.18f, 0.18f)) },
                padding   = new RectOffset(4, 4, 2, 2)
            };

            FactRowOdd = new GUIStyle
            {
                normal    = { background = MakeTex(1, 1, new Color(0.22f, 0.22f, 0.22f)) },
                padding   = new RectOffset(4, 4, 2, 2)
            };

            // - Status Colors -
            ColorActive    = new Color(0.4f, 0.9f, 0.4f);
            ColorIdle      = new Color(0.8f, 0.8f, 0.4f);
            ColorFailed    = new Color(0.9f, 0.3f, 0.3f);
            ColorDisabled  = new Color(0.5f, 0.5f, 0.5f);
            ColorPlanning  = new Color(0.4f, 0.6f, 0.9f);
        }

        // - Styles -

        private static GUIStyle sectionHeader;
        public  static GUIStyle SectionHeader
        {
            get
            {
                EnsureInitialized();
                return sectionHeader;
            }
            private set => sectionHeader = value;
        }

        private static GUIStyle stateBadge;
        public static GUIStyle StateBadge
        {
            get
            {
                EnsureInitialized();
                return stateBadge;
            }
            private set => stateBadge = value;
        }

        private static GUIStyle actionNodeNormal;
        public static GUIStyle ActionNodeNormal
        {
            get {
                EnsureInitialized();
                return actionNodeNormal;
            }
            private set => actionNodeNormal = value;
        }

        private static GUIStyle actionNodeActive;
        public static GUIStyle ActionNodeActive
        {
            get
            {
                EnsureInitialized();
                return actionNodeActive;
            }
            private set => actionNodeActive = value;
        }

        private static GUIStyle actionNodeFailed;
        public static GUIStyle ActionNodeFailed
        {
            get
            {
                EnsureInitialized();
                return actionNodeFailed;
            }
            private set => actionNodeFailed = value;
        }

        private static GUIStyle actionNodeCompleted;
        public static GUIStyle ActionNodeCompleted
        {
            get
            {
                EnsureInitialized();
                return actionNodeCompleted;
            }
            private set => actionNodeCompleted = value;
        }

        private static GUIStyle factRowEven;
        public static GUIStyle FactRowEven
        {
            get
            {
                EnsureInitialized();
                return factRowEven;
            }
            private set => factRowEven = value;
        }

        private static GUIStyle factRowOdd;
        public static GUIStyle FactRowOdd
        {
            get
            {
                EnsureInitialized();
                return factRowOdd;
            }
            private set => factRowOdd = value;
        }

        // - Colors -

        public static Color ColorActive;
        public static Color ColorIdle;
        public static Color ColorFailed;
        public static Color ColorDisabled;
        public static Color ColorPlanning;

        // - Helpers -

        public static Color GetStateColor(AgentState state) => state switch
        {
            AgentState.Active => ColorActive,
            AgentState.Idle => ColorIdle,
            AgentState.Planning => ColorPlanning,
            AgentState.PlanningFailed => ColorFailed,
            AgentState.Disabled => ColorDisabled,
            AgentState.SensingOnly => ColorIdle,
            _ => Color.white
        };

        private static Texture2D MakeTex(int width, int height, Color color)
        {
            Texture2D tex = new Texture2D(width, height);
            Color[] pixel = new Color[width * height];
            for (int i = 0; i < pixel.Length; i++)
                pixel[i] = color;
            tex.SetPixels(pixel);
            tex.Apply();
            return tex;
        }
    }
}