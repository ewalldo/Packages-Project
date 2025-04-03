using System.IO;
using UnityEditor;
using UnityEngine;

namespace ScriptGeneratorTools
{
    internal class ScriptsGenerator
    {
        private const string basePath = "Assets/Create/C# Scripts Templates/";
        private const string classPath = basePath + "C# Class";
        private const string monobehaviourPath = basePath + "C# MonoBehaviour";
        private const string scriptableObjectPath = basePath + "C# ScriptableObject";
        private const string customEditorPath = basePath + "C# Custom Editor";
        private const string customPropertyDrawerPath = basePath + "C# Custom Property Drawer";
        private const string customPropertyAttributePath = basePath + "C# Custom Property Attribute";
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

        [MenuItem(customPropertyDrawerPath, false, 65)]
        private static void CreateScriptEditorPropertyDrawer() => CheckAndCreate(ScriptType.CSCustomPropertyDrawer);

        [MenuItem(customPropertyAttributePath, false, 66)]
        private static void CreateScriptEditorPropertyAttribute() => CheckAndCreate(ScriptType.CSCustomPropertyAttribute);

        [MenuItem(interfacePath, false, 67)]
        private static void CreateScriptInterface() => CheckAndCreate(ScriptType.CSInterface);

        [MenuItem(structPath, false, 68)]
        private static void CreateScriptStruct() => CheckAndCreate(ScriptType.CSStruct);

        [MenuItem(enumPath, false, 69)]
        private static void CreateScriptEnum() => CheckAndCreate(ScriptType.CSEnum);

        private static void CheckAndCreate(ScriptType scriptType)
        {
            ScriptsGeneratorSettings settings = ScriptsGeneratorSettings.GetOrCreateSettings();
            string fileName = "NewScript.cs";

            string templatePath;
            switch (scriptType)
            {
                case ScriptType.CSClass:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSClassTemplate);
                    break;
                case ScriptType.CSMonoBehaviour:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSMonoBehaviourTemplate);
                    break;
                case ScriptType.CSScriptableObject:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSScriptableObjectTemplate);
                    break;
                case ScriptType.CSCustomEditor:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSCustomEditorTemplate);
                    break;
                case ScriptType.CSCustomPropertyDrawer:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSCustomPropertyDrawerTemplate);
                    break;
                case ScriptType.CSCustomPropertyAttribute:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSCustomPropertyAttributeTemplate);
                    break;
                case ScriptType.CSInterface:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSInterfaceTemplate);
                    break;
                case ScriptType.CSStruct:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSStructTemplate);
                    break;
                case ScriptType.CSEnum:
                    templatePath = AssetDatabase.GetAssetPath(settings.CSEnumTemplate);
                    break;
                default:
                    return;
            }

            if (templatePath == string.Empty || templatePath == default)
            {
                Debug.LogError($"Could not find template for {scriptType} in the settings file.");
                return;
            }

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, fileName);
        }

        private enum ScriptType
        {
            CSClass,
            CSMonoBehaviour,
            CSScriptableObject,
            CSCustomEditor,
            CSCustomPropertyDrawer,
            CSCustomPropertyAttribute,
            CSInterface,
            CSStruct,
            CSEnum,
        }
    }
}
