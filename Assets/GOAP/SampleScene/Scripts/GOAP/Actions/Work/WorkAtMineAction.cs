using UnityEngine;

namespace GOAP.Sample
{
	public class WorkAtMineAction : WorkActionBase
	{
		protected override LocationType TargetStation => LocationType.Mine;
		protected override ToolType GetExpectedTool() => ToolType.Pickaxe;
	}
}