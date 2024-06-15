using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace StateMachinePattern
{
    public class StateMachineGenerator : EditorWindow
    {
        private string stateMachineClassName;
        private List<string> statesNames;
        private ReorderableList reorderableList;
        private string initialStateName;

        private bool createMonoBehaviourVersion;
        private bool createStatesOnly;
        private bool overwriteNamespace;
        private string scriptsNamespace;
        private Vector2 scrollPos;

        private const string DEFAULT_NAMESPACE = "StateMachinePattern";

        [MenuItem("Window/State Machine Generator", false, 211)]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(StateMachineGenerator));
            window.minSize = new Vector2(700, 250);
            window.titleContent = new GUIContent("State Machine Generator");
        }

        private void OnEnable()
        {
            if (statesNames == null)
                statesNames = new List<string>();
            if (reorderableList == null)
                InitializeList();

            stateMachineClassName = "NewStateMachine";
            initialStateName = "";
            createMonoBehaviourVersion = true;
            createStatesOnly = false;
            overwriteNamespace = false;
            scriptsNamespace = DEFAULT_NAMESPACE;
        }

        private void InitializeList()
        {
            reorderableList = new ReorderableList(statesNames, typeof(string), true, true, true, true);
            reorderableList.drawHeaderCallback += DrawHeaderCallback;
            reorderableList.drawElementCallback += DrawElementCallback;
            reorderableList.onAddCallback += OnAddCallback;
            reorderableList.onRemoveCallback += OnRemoveCallback;
        }

        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "States To Create", EditorStyles.boldLabel);
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            EditorGUI.BeginChangeCheck();

            string newName = EditorGUI.TextField(new Rect(rect.x, rect.y, rect.width * 0.7f, rect.height), statesNames[index]).Trim().Replace(" ", "");
            newName = string.Concat(newName[0].ToString().ToUpper(), newName[1..]);
            if (EditorGUI.EndChangeCheck() && newName != statesNames[index] && !string.IsNullOrEmpty(newName))
            {
                statesNames[index] = GenerateUniqueName(newName);
            }

            bool isDefault = EditorGUI.ToggleLeft(new Rect(rect.width * 0.8f, rect.y, rect.width * 0.2f, rect.height), "Initial State", initialStateName == statesNames[index]);
            if (isDefault)
            {
                initialStateName = statesNames[index];
            }
        }

        private void OnAddCallback(ReorderableList list)
        {
            int index = list.count == 0 ? 0 : list.index + 1;
            statesNames.Insert(index, GenerateUniqueName("NewState"));
            list.Select(index);
        }

        private void OnRemoveCallback(ReorderableList list)
        {
            if (initialStateName == statesNames[list.index])
                initialStateName = "";

            statesNames.RemoveAt(list.index);
            if (list.count > 0)
                list.index = list.index - 1 >= 0 ? list.index - 1 : 0;
            else
                list.index = -1;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            stateMachineClassName = EditorGUILayout.TextField(new GUIContent("State Machine Name", "Enter a name for the state machine class"), stateMachineClassName);
            createMonoBehaviourVersion = EditorGUILayout.ToggleLeft(new GUIContent("Create MonoBehaviour version", "If true, create a state machine class that inherits from a MonoBehaviour base class."), createMonoBehaviourVersion, GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            scrollPos = GUILayout.BeginScrollView(scrollPos);
            Rect topRect = EditorGUILayout.GetControlRect(false, reorderableList.GetHeight());
            reorderableList.DoList(topRect);
            GUILayout.EndScrollView();

            GUILayout.Space(10);
            EditorGUILayout.BeginHorizontal();
            overwriteNamespace = EditorGUILayout.ToggleLeft(new GUIContent("Overwrite Namespace", "Overwrite the default namespace (StateMachinePattern) and create the scripts in a different one"), overwriteNamespace, GUILayout.Width(150));
            GUI.enabled = overwriteNamespace;
            if (!overwriteNamespace)
                scriptsNamespace = DEFAULT_NAMESPACE;
            scriptsNamespace = EditorGUILayout.TextField(scriptsNamespace);
            GUI.enabled = true;
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);
            createStatesOnly = EditorGUILayout.ToggleLeft(new GUIContent("Create States only", "Skip generating the state machine class, generate the state classes only"), createStatesOnly);

            if (statesNames.Count <= 0)
                GUI.enabled = false;

            GUILayout.Space(10);
            if (GUILayout.Button("Generate State Machine"))
            {
                Generate();
            }
            GUI.enabled = true;
        }

        private void Generate()
        {
            if (statesNames.Count == 0)
                return;

            string currentProjectPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string copyPath = EditorUtility.SaveFilePanel("Save the state machine scripts", currentProjectPath, stateMachineClassName, "cs");

            if (string.IsNullOrEmpty(copyPath))
                return;

            WriteStateClasses(Path.GetDirectoryName(copyPath));
            if (!createStatesOnly)
                WriteStateMachineClass(copyPath);

            AssetDatabase.Refresh();

            this.Close();
        }

        private void WriteStateClasses(string directoryPath)
        {
            foreach (string state in statesNames)
            {
                string statePath = directoryPath + "\\" + state + ".cs";
                string variableStateMachine = string.Concat(stateMachineClassName[0].ToString().ToLower(), stateMachineClassName[1..]);

                using (StreamWriter outfile = new StreamWriter(statePath))
                {
                    outfile.WriteLine("using UnityEngine;");
                    if (overwriteNamespace)
                        outfile.WriteLine("using " + DEFAULT_NAMESPACE + ";");
                    outfile.WriteLine("");
                    outfile.WriteLine("namespace " + (overwriteNamespace ? scriptsNamespace : DEFAULT_NAMESPACE));
                    outfile.WriteLine("{");
                    outfile.WriteLine("\tpublic class " + state + " : IState");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("\t\tprivate " + stateMachineClassName + " " + variableStateMachine + ";");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\tpublic " + state + "(" + stateMachineClassName + " " + variableStateMachine + ")");
                    outfile.WriteLine("\t\t{");
                    outfile.WriteLine("\t\t\tthis." + variableStateMachine + " = " + variableStateMachine + ";");
                    outfile.WriteLine("\t\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\tpublic void OnEnter()");
                    outfile.WriteLine("\t\t{");
                    outfile.WriteLine("\t\t\t// Add your code here");
                    outfile.WriteLine("\t\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\tpublic void OnExit()");
                    outfile.WriteLine("\t\t{");
                    outfile.WriteLine("\t\t\t// Add your code here");
                    outfile.WriteLine("\t\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\tpublic void OnUpdate()");
                    outfile.WriteLine("\t\t{");
                    outfile.WriteLine("\t\t\t// Add your code here");
                    outfile.WriteLine("\t\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\tpublic void OnFixedUpdate()");
                    outfile.WriteLine("\t\t{");
                    outfile.WriteLine("\t\t\t// Add your code here");
                    outfile.WriteLine("\t\t}");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
        }

        private void WriteStateMachineClass(string path)
        {
            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.WriteLine("using UnityEngine;");
                if (overwriteNamespace)
                    outfile.WriteLine("using " + DEFAULT_NAMESPACE + ";");
                outfile.WriteLine("");
                outfile.WriteLine("namespace " + (overwriteNamespace ? scriptsNamespace : DEFAULT_NAMESPACE));
                outfile.WriteLine("{");
                outfile.WriteLine("\tpublic class " + stateMachineClassName + " : " + (createMonoBehaviourVersion ? "StateMachineMonoBehaviour" : "StateMachine"));
                outfile.WriteLine("\t{");
                foreach (string state in statesNames)
                {
                    outfile.WriteLine("\t\tpublic " + state + " " + state + "State { get; private set; }");
                }
                outfile.WriteLine("");
                if (createMonoBehaviourVersion)
                    outfile.WriteLine("\t\tprivate void Start()");
                else
                    outfile.WriteLine("\t\tpublic " + stateMachineClassName + "()");
                outfile.WriteLine("\t\t{");
                foreach (string state in statesNames)
                {
                    outfile.WriteLine("\t\t\t" + state + "State = new " + state + "(this);");
                }
                if (!string.IsNullOrEmpty(initialStateName))
                {
                    outfile.WriteLine("");
                    outfile.WriteLine("\t\t\tChangeState(" + initialStateName + "State);");
                }
                outfile.WriteLine("\t\t}");
                outfile.WriteLine("\t}");
                outfile.WriteLine("}");
            }
        }

        private string GenerateUniqueName(string newName)
        {
            while (!IsNameUnique(newName))
            {
                newName = "New" + newName;
            }

            return newName;
        }

        private bool IsNameUnique(string newName)
        {
            return !statesNames.Contains(newName);
        }
    }
}