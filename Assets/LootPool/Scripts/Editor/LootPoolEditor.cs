using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace LootSystem
{
    [CustomEditor(typeof(LootPool))]
    public abstract class LootPoolEditor : Editor
    {
        protected LootPool lootPool;

        protected ReorderableList lootList;

        private SerializedProperty lootListProperty;

        private readonly float listItemHeight = 40f;
        private readonly float listItemSpacing = 2f;

        private GUIStyle smallHeaderStyle;
        private GUIStyle bigHeaderStyle;

        protected readonly float progressBarHeight = 25f;

        protected virtual void OnEnable()
        {
            lootPool = target as LootPool;

            lootListProperty = serializedObject.FindProperty(LootPool.GetNameOfLootPool);
            lootList = CreateReorderableList(lootListProperty, DrawList, AddToList);

            smallHeaderStyle = StyleUtils.GetSmallHeaderStyle();
            bigHeaderStyle = StyleUtils.GetBigHeaderStyle();
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            serializedObject.Update();

            EditorGUILayout.LabelField("<color=white>Loot Pool</color>", smallHeaderStyle);
            EditorGUILayout.LabelField($"<color=white>{lootPool.name}</color>", bigHeaderStyle);

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            lootList.DoLayoutList();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("<color=white>Loot</color>", bigHeaderStyle);

            Rect percentageRect = EditorGUILayout.BeginVertical();

            DrawListTable(percentageRect);

            EditorGUILayout.Space((progressBarHeight * lootPool.LootPoolList.Count) + progressBarHeight);
            EditorGUILayout.EndVertical();
        }

        protected abstract void DrawList(Rect rect, int index, bool isActive, bool isFocused);

        private ReorderableList CreateReorderableList(SerializedProperty property, ReorderableList.ElementCallbackDelegate drawCallback, ReorderableList.AddCallbackDelegate addCallback)
        {
            ReorderableList list = new ReorderableList(serializedObject, property, true, false, true, true)
            {
                elementHeight = (listItemHeight + listItemSpacing) * 2,
                drawElementCallback = drawCallback,
                onAddCallback = addCallback
            };

            return list;
        }

        private void AddToList(ReorderableList list)
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            InitializeElement(element);
        }

        private void InitializeElement(SerializedProperty element)
        {
            element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = 0f;
            element.FindPropertyRelative(nameof(LootItem.item)).objectReferenceValue = null;
            element.FindPropertyRelative(nameof(LootItem.minCountItem)).intValue = 1;
            element.FindPropertyRelative(nameof(LootItem.maxCountItem)).intValue = 1;
        }

        protected void DrawItem(ReorderableList list, Rect rect, int index, Action<float> onSliderChanged)
        {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

            // 76% + 2% + 10% + 2% + 10%
            float itemWidth = rect.width * 0.76f;
            float minMaxWidth = rect.width * 0.10f;
            float spacing = rect.width * 0.02f;

            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.00f), rect.y, itemWidth, listItemHeight / 2), "<color=white>Item</color>", smallHeaderStyle);
            EditorGUI.LabelField(new Rect(rect.x + (itemWidth + spacing), rect.y, minMaxWidth, listItemHeight / 2), "<color=white>Min</color>", smallHeaderStyle);
            EditorGUI.LabelField(new Rect(rect.x + (itemWidth + minMaxWidth + spacing * 2), rect.y, minMaxWidth, listItemHeight / 2), "<color=white>Max</color>", smallHeaderStyle);

            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.00f), rect.y + (listItemHeight / 2), itemWidth, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.item)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (itemWidth + spacing), rect.y + (listItemHeight / 2), minMaxWidth, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.minCountItem)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (itemWidth + minMaxWidth + spacing * 2), rect.y + (listItemHeight / 2), minMaxWidth, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.maxCountItem)), GUIContent.none);

            EditorGUI.LabelField(new Rect(rect.x, rect.y + listItemHeight, rect.width, listItemHeight / 2), "Drop Chance (0~1)");
            EditorGUI.BeginChangeCheck();
            float weight = EditorGUI.Slider(new Rect(rect.x, rect.y + (listItemHeight + listItemHeight / 2), rect.width, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.weight)).floatValue, 0f, 1f);
            if (EditorGUI.EndChangeCheck())
            {
                weight = Mathf.Clamp01(weight);
                onSliderChanged?.Invoke(weight);
            }
        }

        protected abstract void DrawListTable(Rect tableRect);

        protected void DrawProgressBar(Rect rect, LootItem lootItem)
        {
            EditorGUI.ProgressBar(rect, lootItem.weight, GetProgressBarMessage(lootItem));
        }

        private string GetProgressBarMessage(LootItem lootItem)
        {
            return $"{lootItem.item.name}: ({lootItem.minCountItem}~{lootItem.maxCountItem}) - {lootItem.weight * 100:F2}% chance";
        }
    }
}