using UnityEngine;
using UnityEditor;

namespace LootSystem
{
    [CustomEditor(typeof(DependentLootPool))]
    public class DependentLootPoolEditor : LootPoolEditor
    {
        private DependentLootPool dependentLootPool;

        protected override void OnEnable()
        {
            base.OnEnable();

            dependentLootPool = target as DependentLootPool;
        }

        protected override void DrawList(Rect rect, int index, bool isActive, bool isFocused)
        {
            DrawItem(lootList, rect, index, (weight) => dependentLootPool.ValidateWeights(index, weight));
        }

        protected override void DrawListTable(Rect tableRect)
        {
            float dependentLootTotal = 0f;
            for (int i = 0; i < lootPool.LootPoolList.Count; i++)
            {
                dependentLootTotal += lootPool.LootPoolList[i].weight;

                Rect messageRect = new Rect(tableRect.x, tableRect.y + (progressBarHeight * i), tableRect.width, progressBarHeight);
                if (lootPool.LootPoolList[i].item == null)
                    EditorGUI.HelpBox(messageRect, $"Dependent Loot Pool at index {i}: Missing Game Object", MessageType.Warning);
                else
                    DrawProgressBar(messageRect, lootPool.LootPoolList[i]);
            }

            if (dependentLootTotal < 1f)
                EditorGUI.ProgressBar(new Rect(tableRect.x, tableRect.y + (progressBarHeight * lootPool.LootPoolList.Count), tableRect.width, progressBarHeight), (1 - dependentLootTotal), $" --- No Item ---  - {(1 - dependentLootTotal) * 100:F2}%");
        }
    }
}