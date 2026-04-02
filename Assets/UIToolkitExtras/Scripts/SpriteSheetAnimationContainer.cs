using UnityEngine;

namespace UIToolkitExtras
{
    [CreateAssetMenu(fileName = "SpriteSheetAnimationContainer", menuName = "Scriptable Objects/UI Toolkit Extras/SpriteSheetAnimationContainer")]
    public class SpriteSheetAnimationContainer : ScriptableObject
	{
		[SerializeField] private Sprite[] sprites = null;

		public Sprite[] Sprites => sprites;

		public Sprite GetSprite(int index)
        {
			if (index < 0 || index >= sprites.Length)
            {
                Debug.LogError($"Index {index} is out of bounds for sprite array of length {sprites.Length}.");
                return null;
            }

            return Sprites[index];
        }

        public int Length => sprites.Length;
	}
}