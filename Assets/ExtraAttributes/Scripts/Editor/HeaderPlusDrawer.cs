using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(HeaderPlusAttribute))]
    public class HeaderPlusDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position)
        {
            HeaderPlusAttribute headerPlusAttribute = attribute as HeaderPlusAttribute;
            GUIStyle gUIStyle = GetHeaderTextStyle(headerPlusAttribute);

            if (!string.IsNullOrEmpty(headerPlusAttribute.IconName) && TryLoadTexture(headerPlusAttribute.IconName, out Texture2D iconTexture))
            {
                GUI.DrawTexture(new Rect(position.x, position.y, position.height, position.height), iconTexture);
                GUI.Label(new Rect(position.x + position.height, position.y, position.width - position.height, position.height), headerPlusAttribute.HeaderText, gUIStyle);
            }
            else
            {
                GUI.Label(new Rect(position.x, position.y, position.width, position.height), headerPlusAttribute.HeaderText, gUIStyle);
            }
        }

        private GUIStyle GetHeaderTextStyle(HeaderPlusAttribute headerPlusAttribute)
        {
            GUIStyle gUIStyle = new GUIStyle();
            gUIStyle.normal.textColor = headerPlusAttribute.HeaderColor;
            gUIStyle.alignment = headerPlusAttribute.HeaderAlignment;

            return gUIStyle;
        }

        private bool TryLoadTexture(string textureName, out Texture2D tex)
        {
            tex = Resources.Load<Texture2D>(textureName);

            if (tex == null)
            {
                Debug.LogWarning($"HeaderPlus attribute: Couldn't find texture with the name {textureName} in the Resources folder");
                return false;
            }
            else
                return true;
        }
    }
}