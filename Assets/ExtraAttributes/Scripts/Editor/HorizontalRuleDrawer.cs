using UnityEditor;
using UnityEngine;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(HorizontalRuleAttribute))]
    public class HorizontalRuleDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            HorizontalRuleAttribute horizontalRuleAttribute = attribute as HorizontalRuleAttribute;
            return EditorGUIUtility.singleLineHeight * 2 + horizontalRuleAttribute.HRHeight;
        }

        public override void OnGUI(Rect position)
        {
            HorizontalRuleAttribute horizontalRuleAttribute = attribute as HorizontalRuleAttribute;
            EditorGUI.DrawRect(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, position.height - (EditorGUIUtility.singleLineHeight * 2)), horizontalRuleAttribute.HRColor);
        }
    }
}
