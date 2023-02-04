using UnityEngine;
using UnityEditor;

namespace StatsSystem
{
	[CustomPropertyDrawer(typeof(StatsModifier))]
	public class StatsModifierProperty : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //StatsModifier statsModifier = (StatsModifier)fieldInfo.GetValue(property.serializedObject.targetObject);

            SerializedProperty valueProperty = property.FindPropertyRelative(StatsModifier.GetNameOfValue);
            SerializedProperty statTargetProperty = property.FindPropertyRelative(StatsModifier.GetNameOfStaticTypeTarget);
            SerializedProperty statModifierTypeProperty = property.FindPropertyRelative(StatsModifier.GetNameOfStatModifierType);
            SerializedProperty canEditModifierOrderProperty = property.FindPropertyRelative(StatsModifier.GetNameOfCanEditModifierOrder);
            SerializedProperty modifierOrderProperty = property.FindPropertyRelative(StatsModifier.GetNameOfModifierOrder);
            SerializedProperty modifierSourceProperty = property.FindPropertyRelative(StatsModifier.GetNameOfModifierSource);

            int modifierTypeValueIndex = statModifierTypeProperty.enumValueIndex;
            if (modifierTypeValueIndex == -1)
            {
                statModifierTypeProperty.enumValueIndex = 0;
            }

            EditorGUI.BeginChangeCheck();

            EditorGUI.BeginProperty(position, label, property);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect contentPosition = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            float newValue = EditorGUI.FloatField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, EditorGUIUtility.singleLineHeight), new GUIContent("Modifier Value"), valueProperty.floatValue);
            contentPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.ObjectField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, EditorGUIUtility.singleLineHeight), statTargetProperty, typeof(StatType), new GUIContent("Target Stats"));
            contentPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, EditorGUIUtility.singleLineHeight), statModifierTypeProperty, new GUIContent("Modifier Type"));
            contentPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            bool toggleValue = EditorGUI.ToggleLeft(new Rect(contentPosition.x, contentPosition.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), new GUIContent("Overwrite order?"), canEditModifierOrderProperty.boolValue);

            int newOrder;
            if (toggleValue)
            {
                newOrder = EditorGUI.IntField(new Rect(contentPosition.x + EditorGUIUtility.labelWidth, contentPosition.y, contentPosition.width - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), GUIContent.none, modifierOrderProperty.intValue);
            }
            else
            {
                GUI.enabled = false;
                newOrder = EditorGUI.IntField(new Rect(contentPosition.x + EditorGUIUtility.labelWidth, contentPosition.y, contentPosition.width - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), GUIContent.none, statModifierTypeProperty.enumValueFlag);
                GUI.enabled = true;
            }

            contentPosition.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            Object obj = modifierSourceProperty.objectReferenceValue;
            if (obj == null || obj != property.serializedObject.targetObject)
                modifierSourceProperty.objectReferenceValue = property.serializedObject.targetObject;

            GUI.enabled = false;
            EditorGUI.ObjectField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, EditorGUIUtility.singleLineHeight), modifierSourceProperty, new GUIContent("Modifier Source"));
            GUI.enabled = true;

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();

            if (EditorGUI.EndChangeCheck())
            {
                valueProperty.floatValue = newValue;
                modifierOrderProperty.intValue = newOrder;
                canEditModifierOrderProperty.boolValue = toggleValue;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return (EditorGUIUtility.singleLineHeight * 5) + (EditorGUIUtility.standardVerticalSpacing * 5);
        }
    }
}