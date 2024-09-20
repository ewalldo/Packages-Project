using UnityEngine;
using UnityEditor;

namespace Tween
{
	[CustomPropertyDrawer(typeof(ShakeParameters))]
	public class ShakeParametersPropertyDrawer : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int numberSingleLineFields = CalculateNumberOfLines(property);

            return (EditorGUIUtility.singleLineHeight * numberSingleLineFields) + (EditorGUIUtility.standardVerticalSpacing * (numberSingleLineFields - 1));
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty initialValueProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfInitialValue);
            SerializedProperty directionProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfDirection);
            SerializedProperty durationProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfDuration);
            SerializedProperty delayProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfDelay);
            SerializedProperty speedProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfSpeed);
            SerializedProperty maxMagnitudeProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfMaxMagnitude);
            SerializedProperty noiseMagnitudeProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfNoiseMagnitude);
            SerializedProperty ignoreAxisNoiseProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfIgnoreAxisNoise);
            SerializedProperty easingTypeProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfEasingType);
            SerializedProperty customAnimationCurveProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfCustomAnimationCurve);
            SerializedProperty loopProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfLoop);
            SerializedProperty numLoopsProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfNumLoops);
            SerializedProperty delayBetweenLoopsProperty = property.FindPropertyRelative(ShakeParameters.GetNameOfDelayBetweenLoops);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            float curHeight = position.y;

            EditorGUI.LabelField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), property.displayName);
            EditorGUI.indentLevel++;

            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), initialValueProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), directionProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), durationProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), delayProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), speedProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), maxMagnitudeProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), noiseMagnitudeProperty);
            EditorGUI.PropertyField(GetNextRect(ref curHeight, position), ignoreAxisNoiseProperty);
            EasingType easingType = DrawEasingFields(ref curHeight, position, easingTypeProperty, customAnimationCurveProperty);
            ShakeParameters.LoopTypes loopTypes = DrawLoopingFields(ref curHeight, position, loopProperty, numLoopsProperty, delayBetweenLoopsProperty);

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

        private ShakeParameters.LoopTypes DrawLoopingFields(ref float curHeight, Rect position, SerializedProperty loopProperty, SerializedProperty numLoopsProperty, SerializedProperty delayBetweenLoopsProperty)
        {
            ShakeParameters.LoopTypes loopTypes = (ShakeParameters.LoopTypes)EditorGUI.EnumPopup(GetNextRect(ref curHeight, position), new GUIContent("Loop Type"), (ShakeParameters.LoopTypes)loopProperty.enumValueIndex);

            if (loopTypes != ShakeParameters.LoopTypes.None)
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
            int numberSingleLineFields = 11;

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