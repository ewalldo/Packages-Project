using UnityEditor;
using UnityEngine;

namespace ScriptGeneratorTools
{
    public class ScriptsGeneratorSettings : ScriptableObject
	{
		public TextAsset CSClassTemplate;
		public TextAsset CSMonoBehaviourTemplate;
		public TextAsset CSScriptableObjectTemplate;
		public TextAsset CSCustomEditorTemplate;
		public TextAsset CSCustomPropertyDrawerTemplate;
		public TextAsset CSCustomPropertyAttributeTemplate;
		public TextAsset CSInterfaceTemplate;
		public TextAsset CSStructTemplate;
		public TextAsset CSEnumTemplate;

		public static ScriptsGeneratorSettings FindSettings()
        {
			string[] guids = AssetDatabase.FindAssets("t:ScriptsGeneratorSettings");

			if (guids.Length == 0)
				return null;

			string path = AssetDatabase.GUIDToAssetPath(guids[0]);
			return AssetDatabase.LoadAssetAtPath<ScriptsGeneratorSettings>(path);
		}

		internal static ScriptsGeneratorSettings GetOrCreateSettings()
        {
			ScriptsGeneratorSettings settings = FindSettings();
			
			if (settings == null)
            {
				settings = CreateInstance<ScriptsGeneratorSettings>();
				AssetDatabase.CreateAsset(settings, "Assets");
				AssetDatabase.SaveAssets();
			}

			return settings;
		}
	}
}