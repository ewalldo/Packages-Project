using UnityEngine;
using UnityEditor;

namespace Tween
{
	[CustomPropertyDrawer(typeof(TweenParameters<>), true)]
	public class TweenParametersPropertyDrawer : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int numberSingleLineFields = CalculateNumberOfLines(property);

            return (EditorGUIUtility.singleLineHeight * numberSingleLineFields) + (EditorGUIUtility.standardVerticalSpacing * (numberSingleLineFields - 1));
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty initialValueProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfInitialValue);
            SerializedProperty endValueProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfEndValue);
            SerializedProperty durationProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfDuration);
            SerializedProperty delayProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfDelay);
            SerializedProperty easingTypeProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfEasingType);
            SerializedProperty customAnimationCurveProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfCustomAnimationCurve);
            SerializedProperty loopProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfLoop);
            SerializedProperty numLoopsProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfNumLoops);
            SerializedProperty delayBetweenLoopsProperty = property.FindPropertyRelative(TweenParameters<float>.GetNameOfDelayBetweenLoops);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            float curHeight = position.y;

            EditorGUI.LabelField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), property.displayName);
            EditorGUI.indentLevel++;

            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), initialValueProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), endValueProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), durationProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), delayProperty);
            EasingType easingType = DrawEasingFields(ref curHeight, position, easingTypeProperty, customAnimationCurveProperty);
            TweenParameters<float>.LoopTypes loopTypes = DrawLoopingFields(ref curHeight, position, loopProperty, numLoopsProperty, delayBetweenLoopsProperty);

            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                easingTypeProperty.enumValueIndex = (int)easingType;
                loopProperty.enumValueIndex = (int)loopTypes;
            }

            EditorGUI.EndProperty();
        }

        private EasingType DrawEasingFields(ref float curHeight, Rect position, SerializedProperty easingTypeProperty, SerializedProperty customAnimationCurveProperty)
        {
            EasingType easingType = (EasingType)EditorGUI.EnumPopup(GetNextRect(ref curHeight, position), new GUIContent("Easing Type"), (EasingType)easingTypeProperty.enumValueIndex);

            if (easingType == EasingType.AnimationCurveEasing)
            {
                EditorGUI.indentLevel++;
                EditorGUI.PropertyField(GetNextRect(ref curHeight, position), customAnimationCurveProperty);
                EditorGUI.indentLevel--;
            }

            return easingType;
        }

        private TweenParameters<float>.LoopTypes DrawLoopingFields(ref float curHeight, Rect position, SerializedProperty loopProperty, SerializedProperty numLoopsProperty, SerializedProperty delayBetweenLoopsProperty)
        {
            TweenParameters<float>.LoopTypes loopTypes = (TweenParameters<float>.LoopTypes)EditorGUI.EnumPopup(GetNextRect(ref curHeight, position), new GUIContent("Loop Type"), (TweenParameters<float>.LoopTypes)loopProperty.enumValueIndex);

            if (loopTypes != TweenParameters<float>.LoopTypes.None)
            {
                EditorGUI.indentLevel++;
                EditorGUI.PropertyField(GetNextRect(ref curHeight, position), numLoopsProperty);
                EditorGUI.PropertyField(GetNextRect(ref curHeight, position), delayBetweenLoopsProperty);
                EditorGUI.indentLevel--;
            }

            return loopTypes;
        }

        private Rect GetNextRect(ref float curHeight, Rect position)
        {
            curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
            return new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight);
        }

        private int CalculateNumberOfLines(SerializedProperty property)
        {
            int numberSingleLineFields = 7;

            EasingType easingType = (EasingType)property.FindPropertyRelative(TweenParameters<float>.GetNameOfEasingType).enumValueIndex;
            if (easingType == EasingType.AnimationCurveEasing)
                numberSingleLineFields++;

            TweenParameters<float>.LoopTypes loopTypes = (TweenParameters<float>.LoopTypes)property.FindPropertyRelative(TweenParameters<float>.GetNameOfLoop).enumValueIndex;
            if (loopTypes != TweenParameters<float>.LoopTypes.None)
                numberSingleLineFields += 2;

            return numberSingleLineFields;
        }
    }
}