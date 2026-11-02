using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace EventBusPattern
{
    [CustomEditor(typeof(EventBus))]
    public class EventBusEditor : Editor
    {
        // Tracks the current search filter string
        private string searchFilter = string.Empty;

        private EventBus eventBus;

        // Styles are initialized lazily since they require the GUI system to be ready.
        private GUIStyle deadListenerStyle;
        private GUIStyle aliveListenerStyle;
        private GUIStyle headerStyle;

        private void OnEnable()
        {
            eventBus = target as EventBus;
        }

        public override void OnInspectorGUI()
        {
            InitializeStyles();

            DrawInspectorHeader();

            EditorGUILayout.Space();

            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox("Registered events and their details will appear here during Play mode.", MessageType.Info);
                return;
            }

            IReadOnlyDictionary<Type, List<Delegate>> registeredEvents = eventBus.GetRegisteredEvents();

            DrawStatisticsPanel(registeredEvents);

            EditorGUILayout.Space();

            DrawSearchBar();

            EditorGUILayout.Space();

            if (registeredEvents.Count == 0)
            {
                EditorGUILayout.HelpBox("No events are currently registered.", MessageType.Info);
            }
            else
            {
                DrawEventList(registeredEvents);
            }

            // Continuously repaint so the display stays up to date.
            Repaint();
        }

        /// <summary>
        /// Draws the top header of the inspector.
        /// </summary>
        private void DrawInspectorHeader()
        {
            EditorGUILayout.LabelField("Event Bus Inspector", headerStyle);
            EditorGUILayout.LabelField(eventBus.name, EditorStyles.centeredGreyMiniLabel);
        }

        /// <summary>
        /// Draws a panel summarizing the overall state of the EventBus.
        /// </summary>
        private void DrawStatisticsPanel(IReadOnlyDictionary<Type, List<Delegate>> registeredEvents)
        {
            int totalListeners = registeredEvents.Values.Sum(list => list.Count);
            int deadListeners = registeredEvents.Values.SelectMany(list => list).Count(d => IsTargetDead(d));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Statistics", EditorStyles.boldLabel);
            EditorGUILayout.Space(2);

            EditorGUILayout.BeginHorizontal();
            DrawStatField("Registered Event Types", registeredEvents.Count.ToString());
            DrawStatField("Total Listeners", totalListeners.ToString());
            DrawStatField("Dead Listeners", deadListeners.ToString(), deadListeners > 0 ? Color.red : Color.green);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Draws a single labelled statistic field.
        /// </summary>
        private void DrawStatField(string label, string value, Color? valueColor = null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField(label, EditorStyles.centeredGreyMiniLabel);

            Color originalColor = GUI.contentColor;
            if (valueColor.HasValue)
                GUI.contentColor = valueColor.Value;
            EditorGUILayout.LabelField(value, EditorStyles.boldLabel);
            GUI.contentColor = originalColor;

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Draws the search bar used to filter events by type name.
        /// </summary>
        private void DrawSearchBar()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            EditorGUILayout.LabelField("Search", GUILayout.Width(50));
            searchFilter = EditorGUILayout.TextField(searchFilter, EditorStyles.toolbarSearchField);

            if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(45)))
                searchFilter = string.Empty;

            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draws the full list of registered events, applying the search filter.
        /// </summary>
        private void DrawEventList(IReadOnlyDictionary<Type, List<Delegate>> registeredEvents)
        {
            var filteredEvents = registeredEvents.Where(kvp => string.IsNullOrEmpty(searchFilter) || kvp.Key.Name.IndexOf(searchFilter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (filteredEvents.Count == 0)
            {
                EditorGUILayout.HelpBox($"No events matching '{searchFilter}'.", MessageType.Info);
                return;
            }

            foreach (var kvp in filteredEvents)
                DrawEventEntry(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// Draws a single event type entry, with a foldout containing listener details.
        /// </summary>
        private void DrawEventEntry(Type eventType, List<Delegate> listeners)
        {
            int deadCount = listeners.Count(IsTargetDead);
            bool hasDeadListeners = deadCount > 0;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            // Header row
            EditorGUILayout.BeginHorizontal();

            // Colored indicator dot
            Color indicatorColor = hasDeadListeners ? Color.red : Color.green;
            Color originalColor = GUI.contentColor;
            GUI.contentColor = indicatorColor;
            EditorGUILayout.LabelField("●", GUILayout.Width(16));
            GUI.contentColor = originalColor;

            // Event type name + namespace
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField(eventType.Name, EditorStyles.boldLabel);
            if (!string.IsNullOrEmpty(eventType.Namespace))
                EditorGUILayout.LabelField(eventType.Namespace, EditorStyles.miniLabel);
            EditorGUILayout.EndVertical();

            GUILayout.FlexibleSpace();

            // Listener count badge
            DrawListenerCountBadge(listeners.Count, deadCount);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(4);

            foreach (Delegate listener in listeners)
                DrawListenerEntry(listener);

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(2);
        }

        /// <summary>
        /// Draws a badge showing the total and dead listener counts for an event.
        /// </summary>
        private void DrawListenerCountBadge(int totalCount, int deadCount)
        {
            var badgeColor = deadCount > 0 ? new Color(1f, 0.5f, 0f) : new Color(0.2f, 0.8f, 0.2f);
            var originalColor = GUI.contentColor;
            GUI.contentColor = badgeColor;

            string badgeText = deadCount > 0
                ? $"{totalCount} listeners ({deadCount} dead)"
                : $"{totalCount} listener(s)";

            EditorGUILayout.LabelField(badgeText, EditorStyles.miniLabel, GUILayout.Width(160));
            GUI.contentColor = originalColor;
        }

        /// <summary>
        /// Draws details for a single listener delegate.
        /// </summary>
        private void DrawListenerEntry(Delegate listener)
        {
            bool isDead = IsTargetDead(listener);
            GUIStyle style = isDead ? deadListenerStyle : aliveListenerStyle;

            EditorGUILayout.BeginHorizontal(style);

            // Status icon
            EditorGUILayout.LabelField(isDead ? "✖" : "✔", GUILayout.Width(20));

            EditorGUILayout.BeginVertical();

            // Method info row
            DrawListenerMethodInfo(listener);

            // Target info row
            DrawListenerTargetInfo(listener);

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(2);
        }

        /// <summary>
        /// Draws the method name and declaring type for a listener.
        /// </summary>
        private void DrawListenerMethodInfo(Delegate listener)
        {
            string declaringTypeName = listener.Method.DeclaringType?.Name ?? "Unknown";
            string methodName = listener.Method.Name;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Method", EditorStyles.miniLabel, GUILayout.Width(55));
            EditorGUILayout.LabelField(
                $"{declaringTypeName}.{methodName}()",
                EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draws the target object info for a listener, including a ping button
        /// if the target is a Unity Object.
        /// </summary>
        private void DrawListenerTargetInfo(Delegate listener)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Target", EditorStyles.miniLabel, GUILayout.Width(55));

            if (listener.Target == null)
            {
                // Static method — no target object
                EditorGUILayout.LabelField("Static Method", EditorStyles.miniLabel);
            }
            else if (listener.Target is UnityEngine.Object unityObject)
            {
                if (unityObject == null)
                {
                    // Target was a Unity Object but has since been destroyed
                    EditorGUILayout.LabelField("Destroyed Unity Object", deadListenerStyle);
                }
                else
                {
                    EditorGUILayout.LabelField(unityObject.name, EditorStyles.miniLabel);

                    // Ping button lets you locate the target object in the Editor
                    if (GUILayout.Button("Ping", EditorStyles.miniButton, GUILayout.Width(40)))
                        EditorGUIUtility.PingObject(unityObject);

                    // Select button lets you select the target object in the Editor
                    if (GUILayout.Button("Select", EditorStyles.miniButton, GUILayout.Width(50)))
                        Selection.activeObject = unityObject;
                }
            }
            else
            {
                // Non-Unity C# object target
                EditorGUILayout.LabelField(listener.Target.GetType().Name, EditorStyles.miniLabel);
            }

            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Returns true if the delegate's target is a destroyed Unity Object.
        /// Static methods (null target) and live C# objects are considered alive.
        /// </summary>
        private bool IsTargetDead(Delegate d)
        {
            // Static methods have no target — always alive
            if (d.Target == null) return false;

            // Unity overrides the == null check for destroyed objects
            if (d.Target is UnityEngine.Object unityObject)
                return unityObject == null;

            return false;
        }

        private void InitializeStyles()
        {
            headerStyle ??= new GUIStyle(EditorStyles.largeLabel)
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold,
                fontSize = 14
            };

            deadListenerStyle ??= new GUIStyle(EditorStyles.helpBox)
            {
                normal = { textColor = new Color(1f, 0.4f, 0.4f) }
            };

            aliveListenerStyle ??= new GUIStyle(EditorStyles.helpBox)
            {
                normal = { textColor = new Color(0.4f, 1f, 0.4f) }
            };
        }
    }
}
