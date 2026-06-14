using GOAP.Actions;
using GOAP.Agent;
using GOAP.Goals;
using GOAP.Planning;
using GOAP.WorldStates;
using GOAP.Sensing;
using UnityEditor;
using UnityEngine;

namespace GOAP.Editor
{
    /// <summary>
    /// Custom Inspector for GoapAgent.
    /// Displays live runtime data when the game is playing and
    /// configuration data when it is not.
    ///
    /// Sections:
    ///   [Configuration]  — config asset, tick mode (edit + play mode)
    ///   [Agent State]    — current AgentState with color coding  (play mode)
    ///   [Controls]       — Force Replan button                    (play mode)
    ///   [Active Goal]    — name, priority, desired state          (play mode)
    ///   [Active Plan]    — action list with progress highlight    (play mode)
    ///   [World State]    — all current facts                      (play mode)
    ///   [Blackboard]     — all current entries                    (play mode)
    ///   [Sensors]        — list of attached sensors + status      (play mode)
    /// </summary>
    [CustomEditor(typeof(GoapAgent))]
    public class GoapAgentEditor : UnityEditor.Editor
    {
        // - Foldout State -

        private bool showGoal = true;
        private bool showPlan = true;
        private bool showWorldState = true;
        private bool showBlackboard = true;
        private bool showSensors = true;

        // - Repaint -

        private void OnEnable()
        {
            // Request repaint every frame during play mode so live data updates
            EditorApplication.update += RepaintIfPlaying;
        }

        private void OnDisable()
        {
            EditorApplication.update -= RepaintIfPlaying;
        }

        private void RepaintIfPlaying()
        {
            if (Application.isPlaying)
                Repaint();
        }

        // - Inspector Draw -

        public override void OnInspectorGUI()
        {
            GoapAgent agent = target as GoapAgent;

            DrawDefaultInspector();

            if (!Application.isPlaying)
            {
                DrawEditModeInfo(agent);
                return;
            }

            EditorGUILayout.Space(8);
            DrawRuntimeSections(agent);
        }

        // - Edit Mode -

        private void DrawEditModeInfo(GoapAgent agent)
        {
            EditorGUILayout.Space(4);
            EditorGUILayout.HelpBox("Enter Play Mode to inspect live GOAP runtime data.", MessageType.Info);

            // Show attached components summary
            EditorGUILayout.Space(4);
            DrawSectionHeader("Agent Components");

            GoapGoal[] goals = agent.GoalsParent == null ? agent.GetComponents<GoapGoal>() : agent.GoalsParent.GetComponents<GoapGoal>();
            GoapAction[] actions = agent.ActionsParent == null ? agent.GetComponents<GoapAction>() : agent.ActionsParent.GetComponents<GoapAction>();
            GoapSensor[] sensors = agent.SensorsParent == null ? agent.GetComponents<GoapSensor>() : agent.SensorsParent.GetComponents<GoapSensor>();

            EditorGUILayout.LabelField($"Goals: {goals.Length}",   EditorStyles.miniLabel);
            EditorGUI.indentLevel++;
            foreach (GoapGoal goal in goals)
            {
                EditorGUILayout.LabelField($"- {goal.Name}", EditorStyles.miniLabel);
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.LabelField($"Actions: {actions.Length}", EditorStyles.miniLabel);
            EditorGUI.indentLevel++;
            foreach (GoapAction action in actions)
            {
                EditorGUILayout.LabelField($"- {action.Name}", EditorStyles.miniLabel);
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.LabelField($"Sensors: {sensors.Length}", EditorStyles.miniLabel);
            EditorGUI.indentLevel++;
            foreach (GoapSensor sensor in sensors)
            {
                EditorGUILayout.LabelField($"- {sensor.Name}", EditorStyles.miniLabel);
            }
            EditorGUI.indentLevel--;
        }

        // - Runtime Sections -

        private void DrawRuntimeSections(GoapAgent agent)
        {
            DrawAgentState(agent);
            DrawControlButtons(agent);

            EditorGUILayout.Space(4);

            showGoal = DrawFoldout(showGoal, "Active Goal", () => DrawGoal(agent));

            EditorGUILayout.Space(4);

            showPlan = DrawFoldout(showPlan, "Active Plan", () => DrawPlan(agent));

            EditorGUILayout.Space(4);

            showWorldState = DrawFoldout(showWorldState, "World State", () => DrawWorldState(agent));

            EditorGUILayout.Space(4);

            showBlackboard = DrawFoldout(showBlackboard, "Blackboard", () => DrawBlackboard(agent));

            EditorGUILayout.Space(4);

            showSensors = DrawFoldout(showSensors, "Sensors", () => DrawSensors(agent));
        }

        // - Agent State -

        private void DrawAgentState(GoapAgent agent)
        {
            DrawSectionHeader("Agent State");

            Color stateColor = GoapEditorStyles.GetStateColor(agent.State);
            string stateLabel = agent.State.ToString();

            Color prevColor = GUI.color;
            GUI.color = stateColor;
            EditorGUILayout.LabelField(stateLabel, EditorStyles.boldLabel);
            GUI.color = prevColor;
        }

        // - Active Goal -

        private void DrawGoal(GoapAgent agent)
        {
            IGoal goal = agent.ActiveGoal;

            if (goal == null)
            {
                EditorGUILayout.LabelField("No active goal", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            EditorGUILayout.LabelField("Name", goal.Name, EditorStyles.miniLabel);
            EditorGUILayout.LabelField("Satisfied", goal.IsSatisfied(agent.WorldState).ToString(), EditorStyles.miniLabel);

            EditorGUILayout.Space(2);
            EditorGUILayout.LabelField("Desired State:", EditorStyles.boldLabel);

            int row = 0;
            foreach (WorldStateFact fact in goal.DesiredState.GetAllFacts())
            {
                GUIStyle style = (row % 2 == 0) ? GoapEditorStyles.FactRowEven : GoapEditorStyles.FactRowOdd;
                using (new EditorGUILayout.HorizontalScope(style))
                {
                    EditorGUILayout.LabelField(fact.Key.Name, GUILayout.Width(160));
                    EditorGUILayout.LabelField(fact.Value?.ToString(), EditorStyles.miniLabel);
                }
                row++;
            }
        }

        // - Active Plan -

        private void DrawPlan(GoapAgent agent)
        {
            GoapPlan plan = agent.ActivePlan;

            if (plan == null)
            {
                EditorGUILayout.LabelField("No active plan", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            EditorGUILayout.LabelField($"Status: {plan.Status}, Remaining: {plan.RemainingCount}/{plan.TotalCount}", EditorStyles.miniLabel);

            EditorGUILayout.Space(4);

            for (int i = 0; i < plan.Actions.Count; i++)
            {
                IAction action = plan.Actions[i];
                bool isActive = action == agent.ActiveAction;
                bool isCompleted = i < plan.TotalCount - plan.RemainingCount && !isActive;

                GUIStyle style = isActive ? GoapEditorStyles.ActionNodeActive : isCompleted
                        ? GoapEditorStyles.ActionNodeCompleted
                        : GoapEditorStyles.ActionNodeNormal;

                string prefix = isActive ? "▶ " : isCompleted ? "✓ " : "○ ";

                EditorGUILayout.LabelField($"{prefix}[{i + 1}] {action.Name}", style);
            }
        }

        // - World State -

        private void DrawWorldState(GoapAgent agent)
        {
            if (agent.WorldState == null)
            {
                EditorGUILayout.LabelField("World state unavailable", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            int row = 0;
            foreach (WorldStateFact fact in agent.WorldState.GetAllFacts())
            {
                GUIStyle style = (row % 2 == 0) ? GoapEditorStyles.FactRowEven : GoapEditorStyles.FactRowOdd;
                using (new EditorGUILayout.HorizontalScope(style))
                {
                    EditorGUILayout.LabelField(fact.Key.Name, GUILayout.Width(160));
                    EditorGUILayout.LabelField(fact.Value?.ToString(), EditorStyles.miniLabel);
                }
                row++;
            }
        }

        // - Blackboard -

        private void DrawBlackboard(GoapAgent agent)
        {
            if (agent.Blackboard == null)
            {
                EditorGUILayout.LabelField("Blackboard unavailable", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            int row = 0;
            foreach (string key in agent.Blackboard.GetKeys())
            {
                agent.Blackboard.TryGet(key, out object value);
                GUIStyle style = (row % 2 == 0) ? GoapEditorStyles.FactRowEven : GoapEditorStyles.FactRowOdd;
                using (new EditorGUILayout.HorizontalScope(style))
                {
                    EditorGUILayout.LabelField(key, GUILayout.Width(160));
                    EditorGUILayout.LabelField(value?.ToString() ?? "null", EditorStyles.miniLabel);
                }
                row++;
            }
        }

        // - Sensors -

        private void DrawSensors(GoapAgent agent)
        {
            GoapSensor[] sensors = agent.SensorsParent == null ? agent.GetComponents<GoapSensor>() : agent.SensorsParent.GetComponents<GoapSensor>();

            if (sensors.Length == 0)
            {
                EditorGUILayout.LabelField("No sensors attached", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            int row = 0;
            foreach (GoapSensor sensor in sensors)
            {
                GUIStyle style = (row % 2 == 0) ? GoapEditorStyles.FactRowEven : GoapEditorStyles.FactRowOdd;

                using (new EditorGUILayout.HorizontalScope(style))
                {
                    EditorGUILayout.LabelField(sensor.Name, GUILayout.Width(160));
                    EditorGUILayout.LabelField(sensor.UpdateMode.ToString(), GUILayout.Width(160));
                    Color prevColor = GUI.color;
                    GUI.color = sensor.IsEnabled ? GoapEditorStyles.ColorActive : GoapEditorStyles.ColorDisabled;
                    EditorGUILayout.LabelField(sensor.IsEnabled ? "Enabled" : "Disabled");
                    GUI.color = prevColor;
                }
                row++;
            }
        }

        // - Control Buttons -

        private void DrawControlButtons(GoapAgent agent)
        {
            EditorGUILayout.Space(4);

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Force Replan", EditorStyles.miniButton))
                    agent.ForceReplan();

                //if (GUILayout.Button("Open Graph Visualizer", EditorStyles.miniButton))
                //    GoapGraphVisualizer.OpenFor(agent);
            }
        }

        // - Shared Helpers -

        private void DrawSectionHeader(string title)
        {
            EditorGUILayout.Space(2);
            EditorGUILayout.LabelField(title, GoapEditorStyles.SectionHeader);
            DrawHorizontalLine();
        }

        private bool DrawFoldout(bool state, string label, System.Action drawContent)
        {
            state = EditorGUILayout.Foldout(state, label, true, EditorStyles.foldoutHeader);
            if (state)
            {
                EditorGUI.indentLevel++;
                drawContent();
                EditorGUI.indentLevel--;
            }
            return state;
        }

        private static void DrawHorizontalLine(float height = 1f)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, height);
            EditorGUI.DrawRect(rect, new Color(0.3f, 0.3f, 0.3f));
        }
    }
}