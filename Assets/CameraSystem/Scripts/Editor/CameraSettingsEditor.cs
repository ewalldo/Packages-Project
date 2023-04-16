using UnityEngine;
using UnityEditor;

namespace CameraSystem
{
    [CustomEditor(typeof(CameraSettings))]
    public class CameraSettingsEditor : Editor
	{
        private CameraSettings cameraSettings;

        private bool displayCinemachineSettings = true;
        private bool displayMovementSettings = true;
        private bool displayRotationSettings = true;
        private bool displayZoomSettings = true;

        private void OnEnable()
        {
            cameraSettings = target as CameraSettings;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorUtility.SetDirty(target);

            EditorGUILayout.LabelField("<color=white>Camera Settings</color>", new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                richText = true
            });
            EditorGUILayout.Space(20f);

            displayCinemachineSettings = EditorGUILayout.BeginFoldoutHeaderGroup(displayCinemachineSettings, "Cinemachine Settings");
            if (displayCinemachineSettings)
            {
                cameraSettings.OverrideCameraInitialOffset = EditorGUILayout.ToggleLeft("Override Initial Offset", cameraSettings.OverrideCameraInitialOffset);
                if (cameraSettings.OverrideCameraInitialOffset)
                {
                    EditorGUI.indentLevel++;
                    cameraSettings.CinemachineVirtualCameraInitialOffset = EditorGUILayout.Vector3Field("Initial Offset", cameraSettings.CinemachineVirtualCameraInitialOffset);
                    EditorGUI.indentLevel--;
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space(20f);

            displayMovementSettings = EditorGUILayout.BeginFoldoutHeaderGroup(displayMovementSettings, "Camera Movement Settings");
            if (displayMovementSettings)
            {
                cameraSettings.MoveCameraSpeed = EditorGUILayout.FloatField("Movement Speed", cameraSettings.MoveCameraSpeed);
                cameraSettings.UseEdgeScrolling = EditorGUILayout.ToggleLeft("Activate Edge Scrolling?", cameraSettings.UseEdgeScrolling);
                if (cameraSettings.UseEdgeScrolling)
                {
                    EditorGUI.indentLevel++;
                    cameraSettings.EdgeScrollSizeX = EditorGUILayout.Slider("X Sensitivity", cameraSettings.EdgeScrollSizeX, 0f, 0.49f);
                    cameraSettings.EdgeScrollSizeY = EditorGUILayout.Slider("Y Sensitivity", cameraSettings.EdgeScrollSizeY, 0f, 0.49f);
                    EditorGUI.indentLevel--;
                }
                cameraSettings.UseDragPan = EditorGUILayout.ToggleLeft("Allow Drag Pan?", cameraSettings.UseDragPan);
                if (cameraSettings.UseDragPan)
                {
                    EditorGUI.indentLevel++;
                    cameraSettings.DragPanSpeedMultiplier = EditorGUILayout.FloatField("Drag Speed Multiplier", cameraSettings.DragPanSpeedMultiplier);
                    EditorGUI.indentLevel--;
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space(20f);

            displayRotationSettings = EditorGUILayout.BeginFoldoutHeaderGroup(displayRotationSettings, "Camera Rotation Settings");
            if (displayRotationSettings)
            {
                cameraSettings.RotateCameraSpeed = EditorGUILayout.FloatField("Rotate Speed", cameraSettings.RotateCameraSpeed);
                cameraSettings.UseDragRotation = EditorGUILayout.ToggleLeft("Allow Drag Rotation?", cameraSettings.UseDragRotation);
                if (cameraSettings.UseDragRotation)
                {
                    EditorGUI.indentLevel++;
                    cameraSettings.DragRotationSpeedMultiplier = EditorGUILayout.FloatField("Drag Rotation Multiplier", cameraSettings.DragRotationSpeedMultiplier);
                    EditorGUI.indentLevel--;
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space(20f);

            displayZoomSettings = EditorGUILayout.BeginFoldoutHeaderGroup(displayZoomSettings, "Camera Zoom Settings");
            if (displayZoomSettings)
            {
                cameraSettings.ZoomCameraSpeed = EditorGUILayout.FloatField("Zoom Speed", cameraSettings.ZoomCameraSpeed);
                cameraSettings.ZoomCameraAmount = EditorGUILayout.FloatField("Zoom Amount", cameraSettings.ZoomCameraAmount);
                cameraSettings.UseZoom = EditorGUILayout.ToggleLeft("Allow Zoom?", cameraSettings.UseZoom);
                if (cameraSettings.UseZoom)
                {
                    EditorGUI.indentLevel++;
                    cameraSettings.FollowOffsetMin = EditorGUILayout.FloatField("Zoom Offset Min", cameraSettings.FollowOffsetMin);
                    cameraSettings.FollowOffsetMax = EditorGUILayout.FloatField("Zoom Offset Max", cameraSettings.FollowOffsetMax);
                    EditorGUI.indentLevel--;
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();


            serializedObject.ApplyModifiedProperties();
        }
    }
}