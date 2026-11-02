using System.Collections.Generic;
using GOAP.Actions;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class WaitAction : GoapAction
    {
        [SerializeField, Min(0.1f)] private float waitDuration = 3f;

        public override ActionStatus OnTick(ActionContext context)
        {
            if (context.TimeSinceActionStarted >= waitDuration)
                return Complete();

            return Continue();
        }

        protected override void BuildEffects(List<WorldStateFact> effects)
        {
            effects.Add(WorldStateFact.Create(VillageWorldKeys.IsWaiting, true));
        }

        protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        {
            //
        }

        public override void OnStop(ActionContext context, ActionStopReason reason)
        {
            base.OnStop(context, reason);
            if (reason == ActionStopReason.Completed)
                context.CurrentWorldState.Set(VillageWorldKeys.IsWaiting, false);
        }
    }
}