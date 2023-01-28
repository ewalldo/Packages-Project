using System.IO;
using UnityEditor;

namespace ScriptGeneratorTools
{
    internal class ScriptsGenerator
    {
        private const string basePath = "Assets/Create/C# Scripts Templates/";
        private const string classPath = basePath + "C# Class";
        private const string monobehaviourPath = basePath + "C# MonoBehaviour";
        private const string scriptableObjectPath = basePath + "C# ScriptableObject";
        private const string customEditorPath = basePath + "C# Custom Editor";
        private const string customPropertyPath = basePath + "C# Custom Property Drawer";
        private const string interfacePath = basePath + "C# Interface";
        private const string structPath = basePath + "C# Struct";
        private const string enumPath = basePath + "C# Enum";

        [MenuItem(classPath, false, 61)]
        private static void CreateScript() => CheckAndCreate(ScriptType.CSClass);
        [MenuItem(monobehaviourPath, false, 62)]
        private static void CreateScriptMonoBehaviour() => CheckAndCreate(ScriptType.CSMonoBehaviour);
        [MenuItem(scriptableObjectPath, false, 63)]
        private static void CreateScriptScriptableObject() => CheckAndCreate(ScriptType.CSScriptableObject);
        [MenuItem(customEditorPath, false, 64)]
        private static void CreateScriptEditorCustomEditor() => CheckAndCreate(ScriptType.CSCustomEditor);
        [MenuItem(customPropertyPath, false, 65)]
        private static void CreateScriptEditorPropertyDrawer() => CheckAndCreate(ScriptType.CSCustomPropertyDrawer);
        [MenuItem(interfacePath, false, 66)]
        private static void CreateScriptInterface() => CheckAndCreate(ScriptType.CSInterface);
        [MenuItem(structPath, false, 67)]
        private static void CreateScriptStruct() => CheckAndCreate(ScriptType.CSStruct);
        [MenuItem(enumPath, false, 68)]
        private static void CreateScriptEnum() => CheckAndCreate(ScriptType.CSEnum);

        private static void CheckAndCreate(ScriptType scriptType)
        {
            string currentPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string filepath = EditorUtility.SaveFilePanel("Save Script", currentPath, "NewScript", "cs");

            if (!AssetDatabase.IsValidFolder(currentPath))
                return;

            if (string.IsNullOrEmpty(filepath))
                return;

            string scriptContents = "";
            string filename = Path.GetFileNameWithoutExtension(filepath);

            switch (scriptType)
            {
                case ScriptType.CSClass:
                    scriptContents += "using UnityEngine;\n\nnamespace GenericNamespace\n{\n\tpublic class " + filename + "\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSMonoBehaviour:
                    scriptContents += "using UnityEngine;\n\nnamespace GenericNamespace\n{\n\tpublic class " + filename + " : MonoBehaviour\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSScriptableObject:
                    scriptContents += "using UnityEngine;\n\nnamespace GenericNamespace\n{\n\t//[CreateAssetMenu(fileName = \"ScriptableObject\", menuName = \"ScriptableObject/New Scriptable Object\")]\n\tpublic class " + filename + " : ScriptableObject\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSCustomEditor:
                    scriptContents += "using UnityEngine;\nusing UnityEditor;\n\nnamespace GenericNamespace\n{\n\t//[CustomEditor(typeof(ClassName))]\n\tpublic class " + filename + " : Editor\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSCustomPropertyDrawer:
                    scriptContents += "using UnityEngine;\nusing UnityEditor;\n\nnamespace GenericNamespace\n{\n\t//[CustomPropertyDrawer(typeof(ClassName))]\n\tpublic class " + filename + " : PropertyDrawer\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSInterface:
                    scriptContents += "namespace GenericNamespace\n{\n\tpublic interface " + filename + "\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSStruct:
                    scriptContents += "namespace GenericNamespace\n{\n\tpublic struct " + filename + "\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                case ScriptType.CSEnum:
                    scriptContents += "namespace GenericNamespace\n{\n\tpublic enum " + filename + "\n\t{\n\t\t// Add your code here\n\t}\n}";
                    break;
                default:
                    break;
            }

            File.WriteAllText(filepath, scriptContents);
            AssetDatabase.Refresh();
        }

        private enum ScriptType
        {
            CSClass,
            CSMonoBehaviour,
            CSScriptableObject,
            CSCustomEditor,
            CSCustomPropertyDrawer,
            CSInterface,
            CSStruct,
            CSEnum,
        }
    }
}
