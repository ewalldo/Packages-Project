using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(PrettyFieldAttribute))]
    public class PrettyFieldDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PrettyFieldAttribute prettyFieldAttribute = attribute as PrettyFieldAttribute;

            string fieldLabel = string.IsNullOrEmpty(prettyFieldAttribute.FieldText) ? label.text : prettyFieldAttribute.FieldText;

            Color ogColor = EditorStyles.label.normal.textColor;
            EditorStyles.label.normal.textColor = prettyFieldAttribute.FieldColor;

            if (!string.IsNullOrEmpty(prettyFieldAttribute.IconName) && TryLoadTexture(prettyFieldAttribute.IconName, out Texture2D iconTexture))
            {
                GUI.DrawTexture(new Rect(position.x, position.y, position.height, position.height), iconTexture);
                EditorGUI.PropertyField(new Rect(position.x + position.height, position.y, position.width - position.height, position.height), property, new GUIContent(fieldLabel));
            }
            else
            {
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, position.height), property, new GUIContent(fieldLabel));
            }

            EditorStyles.label.normal.textColor = ogColor;
        }

        private bool TryLoadTexture(string textureName, out Texture2D tex)
        {
            tex = Resources.Load<Texture2D>(textureName);

            if (tex == null)
            {
                Debug.LogWarning($"PrettyField attribute: Couldn't find texture with the name {textureName} in the Resources folder");
                return false;
            }
            else
                return true;
        }
    }
}