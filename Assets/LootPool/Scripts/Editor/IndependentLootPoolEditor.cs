using UnityEngine;
using UnityEditor;

namespace LootSystem
{
    [CustomEditor(typeof(IndependentLootPool))]
    public class IndependentLootPoolEditor : LootPoolEditor
    {
        private IndependentLootPool independentLootPool;

        protected override void OnEnable()
        {
            base.OnEnable();

            independentLootPool = target as IndependentLootPool;
        }

        protected override void DrawList(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = lootList.serializedProperty.GetArrayElementAtIndex(index);
            DrawItem(lootList, rect, index, (weight) => element.FindPropertyRelative(nameof(LootItem.weight)).floatValue = weight);
        }

        protected override void DrawListTable(Rect tableRect)
        {
            for (int i = 0; i < lootPool.LootPoolList.Count; i++)
            {
                Rect messageRect = new Rect(tableRect.x, tableRect.y + (progressBarHeight * i), tableRect.width, progressBarHeight);
                if (lootPool.LootPoolList[i].item == null)
                    EditorGUI.HelpBox(messageRect, $"Loot Pool at index {i}: Missing Game Object", MessageType.Warning);
                else
                    DrawProgressBar(messageRect, lootPool.LootPoolList[i]);
            }
        }
    }
}