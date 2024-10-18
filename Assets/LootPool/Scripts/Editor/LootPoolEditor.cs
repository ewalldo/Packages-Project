using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace LootSystem
{
    [CustomEditor(typeof(LootPool))]
    public class LootPoolEditor : Editor
    {
        private LootPool lootPool;

        private ReorderableList independentList;
        private ReorderableList dependentList;

        private SerializedProperty independentLootProperty;
        private SerializedProperty dependentLootProperty;

        private GUIStyle smallHeaderStyle;
        private GUIStyle bigHeaderStyle;

        private readonly float listItemHeight = 40f;
        private readonly float listItemSpacing = 2f;

        private readonly float progressBarHeight = 25f;

        private void OnEnable()
        {
            lootPool = target as LootPool;

            independentLootProperty = serializedObject.FindProperty(nameof(LootPool.independentLootPool));
            dependentLootProperty = serializedObject.FindProperty(nameof(LootPool.dependentLootPool));

            independentList = CreateReorderableList(independentLootProperty, DrawIndependentList, AddToList);
            dependentList = CreateReorderableList(dependentLootProperty, DrawDependentList, AddToList);

            smallHeaderStyle = StyleUtils.GetSmallHeaderStyle();
            bigHeaderStyle = StyleUtils.GetBigHeaderStyle();
        }

        private void DrawIndependentList(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = independentList.serializedProperty.GetArrayElementAtIndex(index);
            DrawItem(independentList, rect, index, (weight) => element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = weight);
        }

        private void DrawDependentList(Rect rect, int index, bool isActive, bool isFocused)
        {
            DrawItem(dependentList, rect, index, (weight) => lootPool.ValidateWeights(index, weight));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("<color=white>Loot Pool</color>", smallHeaderStyle);
            EditorGUILayout.LabelField($"<color=white>{lootPool.name}</color>", bigHeaderStyle);

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            independentLootProperty.isExpanded = EditorGUILayout.Foldout(independentLootProperty.isExpanded, "Independent Loot Pool");
            if (independentLootProperty.isExpanded)
                independentList.DoLayoutList();

            dependentLootProperty.isExpanded = EditorGUILayout.Foldout(dependentLootProperty.isExpanded, "Dependent Loot Pool");
            if (dependentLootProperty.isExpanded)
                dependentList.DoLayoutList();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("<color=white>Loot</color>", bigHeaderStyle);

            Rect percentageRect = EditorGUILayout.BeginVertical();

            for (int i = 0; i < lootPool.independentLootPool.Count; i++)
            {
                Rect messageRect = new Rect(percentageRect.x, percentageRect.y + (progressBarHeight * i), percentageRect.width, progressBarHeight);
                if (lootPool.independentLootPool[i].item == null)
                    EditorGUI.HelpBox(messageRect, $"Independent Loot Pool at index {i}: Missing Game Object", MessageType.Warning);
                else
                    DrawProgressBar(messageRect, lootPool.independentLootPool[i]);
            }

            float extraHeightSpacing = 0f;
            if (lootPool.independentLootPool.Count > 0)
            {
                EditorGUI.LabelField(new Rect(percentageRect.x, percentageRect.y + (progressBarHeight * lootPool.independentLootPool.Count), percentageRect.width, progressBarHeight), "<color=white>+ one of the following</color>", smallHeaderStyle);
                extraHeightSpacing = progressBarHeight;
            }

            float dependentLootTotal = 0f;
            for (int i = 0; i < lootPool.dependentLootPool.Count; i++)
            {
                dependentLootTotal += lootPool.dependentLootPool[i].weight;

                Rect messageRect = new Rect(percentageRect.x, percentageRect.y + (progressBarHeight * i) + (lootPool.independentLootPool.Count * progressBarHeight) + extraHeightSpacing, percentageRect.width, progressBarHeight);
                if (lootPool.dependentLootPool[i].item == null)
                    EditorGUI.HelpBox(messageRect, $"Dependent Loot Pool at index {i}: Missing Game Object", MessageType.Warning);
                else
                    DrawProgressBar(messageRect, lootPool.dependentLootPool[i]);
            }

            if (dependentLootTotal < 1f)
                EditorGUI.ProgressBar(new Rect(percentageRect.x, percentageRect.y + (lootPool.independentLootPool.Count * progressBarHeight) + (lootPool.dependentLootPool.Count * progressBarHeight) + extraHeightSpacing, percentageRect.width, progressBarHeight), (1 - dependentLootTotal), $" --- No Item ---  - {(1 - dependentLootTotal) * 100:F2}%");

            EditorGUILayout.Space((progressBarHeight * lootPool.independentLootPool.Count) + extraHeightSpacing + (lootPool.dependentLootPool.Count * progressBarHeight) + progressBarHeight);
            EditorGUILayout.EndVertical();
        }

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

        private void DrawItem(ReorderableList list, Rect rect, int index, Action<float> onSliderChanged)
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

        private void DrawProgressBar(Rect rect, LootItem lootItem)
        {
            EditorGUI.ProgressBar(rect, lootItem.weight, GetProgressBarMessage(lootItem));
        }

        private string GetProgressBarMessage(LootItem lootItem)
        {
            return $"{lootItem.item.name}: ({lootItem.minCountItem}~{lootItem.maxCountItem}) - {lootItem.weight * 100:F2}% chance";
        }
    }
}
