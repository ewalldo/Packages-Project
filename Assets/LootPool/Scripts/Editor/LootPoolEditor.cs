using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace LootSystem
{
    [CustomEditor(typeof(LootPool))]
    public class LootPoolEditor : Editor
    {
        LootPool lootPool;

        private ReorderableList independentList;
        private ReorderableList dependentList;

        private SerializedProperty independentLootProperty;
        private SerializedProperty dependentLootProperty;

        private readonly float listItemHeight = 40f;
        private readonly float listItemSpacing = 2f;

        private readonly float progressBarHeight = 25f;
        private readonly float upSpacing = 10f;

        private void OnEnable()
        {
            lootPool = target as LootPool;

            independentLootProperty = serializedObject.FindProperty(nameof(LootPool.independentLootPool));
            dependentLootProperty = serializedObject.FindProperty(nameof(LootPool.dependentLootPool));

            independentList = new ReorderableList(serializedObject, independentLootProperty, true, true, true, true)
            {
                elementHeight = (listItemHeight + listItemSpacing) * 2
            };

            dependentList = new ReorderableList(serializedObject, dependentLootProperty, true, true, true, true)
            {
                elementHeight = (listItemHeight + listItemSpacing) * 2
            };

            independentList.drawHeaderCallback += DrawHeaderIndependentList;
            independentList.drawElementCallback += DrawIndependentList;
            independentList.onAddCallback += OnAddIndependentList;

            dependentList.drawHeaderCallback += DrawHeaderDependentList;
            dependentList.drawElementCallback += DrawDependentList;
            dependentList.onAddCallback += OnAddDependentList;
        }

        private void DrawHeaderIndependentList(Rect rect)
        {
            EditorGUI.LabelField(rect, "Independent Loot Pool");
        }

        private void DrawHeaderDependentList(Rect rect)
        {
            EditorGUI.LabelField(rect, "Dependent Loot Pool");
        }

        private void DrawIndependentList(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = independentList.serializedProperty.GetArrayElementAtIndex(index);
            //EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, rect.height), element, GUIContent.none);

            // 76% + 2% + 10% + 2% + 10%
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.00f), rect.y, rect.width * 0.76f, listItemHeight / 2), "Item");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.78f), rect.y, rect.width * 0.10f, listItemHeight / 2), "Min");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.90f), rect.y, rect.width * 0.10f, listItemHeight / 2), "Max");

            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.00f), rect.y + (listItemHeight / 2), rect.width * 0.76f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.item)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.78f), rect.y + (listItemHeight / 2), rect.width * 0.10f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.minCountItem)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.90f), rect.y + (listItemHeight / 2), rect.width * 0.10f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.maxCountItem)), GUIContent.none);

            EditorGUI.LabelField(new Rect(rect.x, rect.y + listItemHeight, rect.width, listItemHeight / 2), "Drop Chance (0~1)");
            EditorGUI.BeginChangeCheck();
            float weight = EditorGUI.Slider(new Rect(rect.x, rect.y + (listItemHeight + listItemHeight / 2), rect.width, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.weight)).floatValue, 0f, 1f);
            if (EditorGUI.EndChangeCheck())
            {
                weight = Mathf.Clamp01(weight);
                element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = weight;
            }
        }

        private void DrawDependentList(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = dependentList.serializedProperty.GetArrayElementAtIndex(index);
            //EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, rect.height), element, GUIContent.none);

            // 76% + 2% + 10% + 2% + 10%
            //EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0), rect.y, rect.width * 0.10f, listItemHeight / 2), "Weight (0~1)");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.00f), rect.y, rect.width * 0.76f, listItemHeight / 2), "Item");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.78f), rect.y, rect.width * 0.10f, listItemHeight / 2), "Min");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width * 0.90f), rect.y, rect.width * 0.10f, listItemHeight / 2), "Max");

            //EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0), rect.y + (listItemHeight / 2), rect.width * 0.10f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootPool.LootItem.weight)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.00f), rect.y + (listItemHeight / 2), rect.width * 0.76f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.item)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.78f), rect.y + (listItemHeight / 2), rect.width * 0.10f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.minCountItem)), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width * 0.90f), rect.y + (listItemHeight / 2), rect.width * 0.10f, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.maxCountItem)), GUIContent.none);

            EditorGUI.LabelField(new Rect(rect.x, rect.y + listItemHeight, rect.width, listItemHeight / 2), "Drop Chance (0~1)");
            EditorGUI.BeginChangeCheck();
            float weight = EditorGUI.Slider(new Rect(rect.x, rect.y + (listItemHeight + listItemHeight / 2), rect.width, listItemHeight / 2), element.FindPropertyRelative(nameof(LootItem.weight)).floatValue, 0f, 1f);
            if (EditorGUI.EndChangeCheck())
            {
                weight = Mathf.Clamp01(weight);
                lootPool.ValidateWeights(index, weight);
            }
        }

        private void OnAddIndependentList(ReorderableList list)
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = 1f;
            element.FindPropertyRelative(nameof(LootItem.item)).objectReferenceValue = null;
            element.FindPropertyRelative(nameof(LootItem.minCountItem)).intValue = 1;
            element.FindPropertyRelative(nameof(LootItem.maxCountItem)).intValue = 1;
        }

        private void OnAddDependentList(ReorderableList list)
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = 0f;
            element.FindPropertyRelative(nameof(LootItem.item)).objectReferenceValue = null;
            element.FindPropertyRelative(nameof(LootItem.minCountItem)).intValue = 1;
            element.FindPropertyRelative(nameof(LootItem.maxCountItem)).intValue = 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //EditorUtility.SetDirty(target);

            EditorGUILayout.LabelField("<color=white>Loot Pool</color>", new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 10,
                richText = true
            });

            EditorGUILayout.LabelField($"<color=white>{lootPool.name}</color>", new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                richText = true
            });

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
            EditorGUILayout.LabelField("<color=white>Loot</color>", new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                richText = true
            });

            Rect percentageRect = EditorGUILayout.BeginVertical();

            for (int i = 0; i < lootPool.independentLootPool.Count; i++)
            {
                string messageText;
                Rect messageRect = new Rect(percentageRect.x, percentageRect.y + upSpacing + (progressBarHeight * i), percentageRect.width, progressBarHeight);
                if (lootPool.independentLootPool[i].item == null)
                {
                    messageText = $"Independent Loot Pool at index {i}: Missing Game Object";
                    EditorGUI.HelpBox(messageRect, messageText, MessageType.Warning);
                }
                else
                {
                    messageText = $"{lootPool.independentLootPool[i].item.name}: ({lootPool.independentLootPool[i].minCountItem}~{lootPool.independentLootPool[i].maxCountItem}) - {lootPool.independentLootPool[i].weight * 100:F2}% chance";
                    EditorGUI.ProgressBar(messageRect, lootPool.independentLootPool[i].weight, messageText);
                }
            }

            float extraHeightSpacing = 0f;
            if (lootPool.independentLootPool.Count > 0)
            {
                EditorGUI.LabelField(new Rect(percentageRect.x, percentageRect.y + upSpacing + (progressBarHeight * lootPool.independentLootPool.Count), percentageRect.width, progressBarHeight), "<color=white>+ one of the following</color>", new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter,
                    //fontSize = 10,
                    richText = true
                });
                extraHeightSpacing = progressBarHeight;
            }

            float dependentLootTotal = 0f;
            for (int i = 0; i < lootPool.dependentLootPool.Count; i++)
            {
                dependentLootTotal += lootPool.dependentLootPool[i].weight;

                string messageText;
                Rect messageRect = new Rect(percentageRect.x, percentageRect.y + upSpacing + (progressBarHeight * i) + (lootPool.independentLootPool.Count * progressBarHeight) + extraHeightSpacing, percentageRect.width, progressBarHeight);
                if (lootPool.dependentLootPool[i].item == null)
                {
                    messageText = $"Dependent Loot Pool at index {i}: Missing Game Object";
                    EditorGUI.HelpBox(messageRect, messageText, MessageType.Warning);
                }
                else
                {
                    messageText = $"{lootPool.dependentLootPool[i].item.name}: ({lootPool.dependentLootPool[i].minCountItem}~{lootPool.dependentLootPool[i].maxCountItem}) - {lootPool.dependentLootPool[i].weight * 100:F2}% chance";
                    EditorGUI.ProgressBar(messageRect, lootPool.dependentLootPool[i].weight, messageText);
                }
            }

            if (dependentLootTotal < 1f)
            {
                EditorGUI.ProgressBar(new Rect(percentageRect.x, percentageRect.y + upSpacing + (lootPool.independentLootPool.Count * progressBarHeight) + (lootPool.dependentLootPool.Count * progressBarHeight) + extraHeightSpacing, percentageRect.width, progressBarHeight), (1 - dependentLootTotal), $" --- No Item ---  - {(1 - dependentLootTotal) * 100:F2}%");
            }

            EditorGUILayout.Space(upSpacing + (progressBarHeight * lootPool.independentLootPool.Count) + extraHeightSpacing + (lootPool.dependentLootPool.Count * progressBarHeight) + progressBarHeight + upSpacing);
            EditorGUILayout.EndVertical();
        }
    }
}
