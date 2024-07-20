using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(AnimatorParamFieldAttribute))]
    public class AnimatorParamFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            if (property.propertyType != SerializedPropertyType.String && property.propertyType != SerializedPropertyType.Integer)
            {
                string errorMessage = "AnimatorParamField attribute: Must be used with string or int property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                ResetField(property);
                EditorGUI.EndProperty();
                return;
            }

            AnimatorParamFieldAttribute animatorParamFieldAttribute = attribute as AnimatorParamFieldAttribute;

            if (!TryGetAnimator(property, animatorParamFieldAttribute.AnimatorName, out AnimatorController animatorController))
            {
                EditorGUI.HelpBox(position, "AnimatorParamField attribute: Couldn't find an Animator property called \"" + animatorParamFieldAttribute.AnimatorName + "\" or the Animator has a null value", MessageType.Error);
                ResetField(property);
            }
            else
            {
                if (animatorController == null)
                {
                    EditorGUI.HelpBox(position, "AnimatorParamField attribute: No Animator Controller assigned in the Animator!", MessageType.Error);
                    ResetField(property);
                    EditorGUI.EndProperty();
                    return;
                }

                List<AnimatorControllerParameter> animatorParameters = new List<AnimatorControllerParameter>();
                for (int i = 0; i < animatorController.parameters.Length; i++)
                {
                    AnimatorControllerParameter animatorControllerParameter = animatorController.parameters[i];
                    if (animatorParamFieldAttribute.AnimatorParamType == null || animatorParamFieldAttribute.AnimatorParamType == animatorControllerParameter.type)
                    {
                        animatorParameters.Add(animatorControllerParameter);
                    }
                }

                if (animatorParameters.Count <= 0)
                {
                    EditorGUI.HelpBox(position, "AnimatorParamField attribute: No parameters or no parameters of the specified type were found in the Animator Controller!", MessageType.Error);
                    ResetField(property);
                    EditorGUI.EndProperty();
                    return;
                }

                if (property.propertyType == SerializedPropertyType.String)
                    DrawPropertyForString(position, property, label, animatorParameters);
                else if (property.propertyType == SerializedPropertyType.Integer)
                    DrawPropertyForInteger(position, property, label, animatorParameters);
            }

            EditorGUI.EndProperty();
        }

        private bool TryGetAnimator(SerializedProperty property, string animatorName, out AnimatorController animatorController)
        {
            animatorController = null;
            SerializedProperty animatorProperty = property.serializedObject.FindProperty(animatorName);

            if (animatorProperty == null)
                return false;

            if (animatorProperty.propertyType != SerializedPropertyType.ObjectReference || animatorProperty.objectReferenceValue == null)
                return false;

            if (animatorProperty.objectReferenceValue.GetType() != typeof(Animator))
                return false;

            Animator animator = animatorProperty.objectReferenceValue as Animator;
            animatorController = animator.runtimeAnimatorController as AnimatorController;

            return true;
        }

        private void DrawPropertyForString(Rect position, SerializedProperty property, GUIContent label, List<AnimatorControllerParameter> animatorParameters)
        {
            if (string.IsNullOrEmpty(property.stringValue))
            {
                property.stringValue = animatorParameters[0].name;
            }

            int index = 0;
            GUIContent[] gUIContents = new GUIContent[animatorParameters.Count];

            for (int i = 0; i < animatorParameters.Count; i++)
            {
                gUIContents[i] = new GUIContent(animatorParameters[i].name);
                if (animatorParameters[i].name == property.stringValue)
                    index = i;
            }

            EditorGUI.BeginChangeCheck();
            int newIdx = EditorGUI.Popup(position, label, index, gUIContents);

            if (EditorGUI.EndChangeCheck())
            {
                property.stringValue = animatorParameters[newIdx].name;
            }
        }

        private void DrawPropertyForInteger(Rect position, SerializedProperty property, GUIContent label, List<AnimatorControllerParameter> animatorParameters)
        {
            int index = 0;
            GUIContent[] gUIContents = new GUIContent[animatorParameters.Count];

            for (int i = 0; i < animatorParameters.Count; i++)
            {
                gUIContents[i] = new GUIContent(animatorParameters[i].name + ": Hash(" + animatorParameters[i].nameHash.ToString() + ")");
                if (animatorParameters[i].nameHash == property.intValue)
                    index = i;
            }

            EditorGUI.BeginChangeCheck();
            int newidx = EditorGUI.Popup(position, label, index, gUIContents);

            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = animatorParameters[newidx].nameHash;
            }
        }

        private void ResetField(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.String)
                property.stringValue = "";
            else if (property.propertyType == SerializedPropertyType.Integer)
                property.intValue = 0;
        }
    }
}
