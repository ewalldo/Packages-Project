using System.Collections.Generic;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class EatAction : RestActionBase
    {
        protected override LocationType TargetLocation => LocationType.Restaurant;

        protected override void BuildRestPlacePrecondition(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsRestaurantFree, true));
        }
    }
}