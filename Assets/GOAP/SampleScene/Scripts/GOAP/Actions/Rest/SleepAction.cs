using System.Collections.Generic;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class SleepAction : RestActionBase
    {
        protected override LocationType TargetLocation => LocationType.House;

        protected override void BuildRestPlacePrecondition(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsHouseFree, true));
        }
    }
}