using UnityEngine;
using UnityEditor;
using System;

namespace FavoritesWindow
{
	public class TextInputPopup : EditorWindow
	{
        private string inputText = "";
        private Func<string, bool> onConfirm;

        public static void Show(string title, string defaultText, Func<string, bool> onConfirmAction)
        {
            TextInputPopup window = CreateInstance<TextInputPopup>();
            window.titleContent = new GUIContent(title);
            window.inputText = defaultText;
            window.onConfirm = onConfirmAction;
            window.maxSize = new Vector2(250, 100);
            window.ShowModal();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Enter name: ", EditorStyles.wordWrappedLabel);
            inputText = EditorGUILayout.TextField(inputText);

            EditorGUILayout.Space(10f);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Confirm"))
            {
                bool wasSuccessful = true;

                if (onConfirm != null)
                    wasSuccessful = onConfirm.Invoke(inputText);

                if (wasSuccessful)
                {
                    EditorGUILayout.EndHorizontal();
                    Close();
                }
            }

            if (GUILayout.Button("Cancel"))
            {
                EditorGUILayout.EndHorizontal();
                Close();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}