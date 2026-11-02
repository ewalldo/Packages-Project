using UnityEngine;

namespace GOAP.Sample
{
	public class WorkAtForestAction : WorkActionBase
	{
		protected override LocationType TargetStation => LocationType.Forest;
		protected override ToolType GetExpectedTool() => ToolType.Axe;
	}
}