using ExtraAttributes;
using UnityEngine;

namespace GenericNamespace
{
	public class AttributesSampleScript : MonoBehaviour
	{
		[HeaderPlus("Header plus", new float[] { 0f, 0f, 1f }, TextAnchor.MiddleCenter, "attributeIcon")]
		[AssetPath] [SerializeField] private string assetPath;
		[ResourcesPath] [SerializeField] private string resourcesPath;
		
		[Space(10)]
		
		[ColorPalette("Red", "Green", "Blue")] [SerializeField] private Color colorPalette;
		
		[Space(10)]
		
		[FloatRangeWithStep(0f, 1f, 0.1f)] [SerializeField] private float floatRangeWithStep;
		[IntRangeWithStep(0, 10, 2)] [SerializeField] private int intRangeWithStep;

		[Space(10)]

		[HideOnEdit] [SerializeField] private int hideOnEdit;
		[HideOnPlay] [SerializeField] private int hideOnPlay;

		[Space(10)]

		[PrettyField("Pretty field", new float[] { 0f, 1f, 0f}, "attributeIcon")] [SerializeField] private int prettyField;

		[Space(10)]

		[ReadOnly] [SerializeField] private int readOnly;
		[ReadOnlyOnEdit] [SerializeField] private int readOnlyOnEdit;
		[ReadOnlyOnPlay] [SerializeField] private int readOnlyOnPlay;

		[Space(10)]

        [RequiredField] [SerializeField] private Light requiredField;

        [Space(10)]

        [ProjectOnly] [SerializeField] private Light projectOnly;
        [SceneOnly] [SerializeField] private Light sceneOnly;

        [Space(10)]

		[LayerField] [SerializeField] private int layerField;
		[SceneField] [SerializeField] private string sceneField;
		[TagField] [SerializeField] private string tagField;
	}
}