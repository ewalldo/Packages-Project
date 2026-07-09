using UnityEngine;

namespace GOAP.Sample
{
	public class WorkAtFarmAction : WorkActionBase
	{
		protected override LocationType TargetStation => LocationType.Farm;
		protected override ToolType GetExpectedTool() => ToolType.Hoe;
	}
}