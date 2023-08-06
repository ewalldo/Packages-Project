using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute to convert a string field into a scene selection field (string only)
	/// </summary>
	public class SceneFieldAttribute : PropertyAttribute
	{
        public int SelectedSceneIndex { get; private set; }

        public SceneFieldAttribute()
        {
            SelectedSceneIndex = 0;
        }

        public void SetSceneIndex(int sceneIndex)
        {
            SelectedSceneIndex = sceneIndex;
        }
    }
}