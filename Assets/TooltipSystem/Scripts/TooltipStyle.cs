using System.Collections.Generic;
using UnityEngine;

namespace TooltipSystem
{
	[CreateAssetMenu(fileName = "TooltipStyle", menuName = "Scriptable Objects/Tooltip System/New Tooltip Style")]
	public class TooltipStyle : ScriptableObject
	{
		[SerializeField] private List<string> textFieldsIds;
		[SerializeField] private List<string> imageFieldsIds;

		public List<string> GetTextFieldsIds => textFieldsIds;
		public List<string> GetImageFieldsIds => imageFieldsIds;
	}
}