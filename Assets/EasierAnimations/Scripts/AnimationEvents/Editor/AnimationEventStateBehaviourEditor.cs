using UnityEngine;
using UnityEditor;
using System.Text;

namespace EasierAnimations
{
    [CustomEditor(typeof(AnimationEventBehaviour))]
    public class AnimationEventStateBehaviourEditor : Editor
	{
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (!EditorWindow.HasOpenInstances<AnimationWindow>())
                return;

            AnimationWindow animationWindow = EditorWindow.GetWindow<AnimationWindow>(false, null, false);

            if (animationWindow.animationClip == null)
                return;

            EditorGUILayout.Space(10);

            StringBuilder boxMessage = new StringBuilder("Animation window information:\n");
            boxMessage.Append("  Current clip:\t" + animationWindow.animationClip.name + "\n");
            boxMessage.Append("  Clip duration:\t" + animationWindow.animationClip.length + "s\n\n");
            boxMessage.Append("  Playhead information:\n");
            boxMessage.Append("    Current time:\t" + animationWindow.time + "s\n");
            boxMessage.Append("    Current frame:\t" + animationWindow.frame);

            EditorGUILayout.HelpBox(new GUIContent(boxMessage.ToString()), true);

            if (GUILayout.Button("Set trigger time to Animation playhead position"))
            {
                AnimationEventBehaviour stateBehaviour = target as AnimationEventBehaviour;
                stateBehaviour.SetTriggerTime(animationWindow.time / animationWindow.animationClip.length);
            }

            EditorGUILayout.Space(10);
        }
    }
}