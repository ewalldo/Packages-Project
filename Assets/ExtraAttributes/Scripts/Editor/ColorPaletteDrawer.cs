using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(ColorPaletteAttribute))]
    public class ColorPaletteDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Color)
            {
                string errorMessage = "ColorPalette attribute: Must be used with color property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            ColorPaletteAttribute colorPaletteAttribute = attribute as ColorPaletteAttribute;
            Color selectedColor = property.colorValue;

            EditorGUI.BeginChangeCheck();

            int index = 0;
            string[] colorNames = new string[colorPaletteAttribute.Colors.Length];
            for (int i = 0; i < colorPaletteAttribute.Colors.Length; i++)
            {
                colorNames[i] = colorPaletteAttribute.Colors[i].Item2;
                if (colorPaletteAttribute.Colors[i].Item1 == property.colorValue)
                    index = i;
            }

            int newIdx = EditorGUI.Popup(position, label.text, index, colorNames);

            if (EditorGUI.EndChangeCheck())
            {
                property.colorValue = colorPaletteAttribute.Colors[newIdx].Item1;
            }
        }
    }
}