using GOAP.Actions;
using UnityEngine;

namespace GOAP.Sample
{
    public abstract class VillageActionBase : GoapAction
    {
        [SerializeField] private VillagerStats villagerStats;
        [SerializeField] private VillagerNavigator villagerNavigator;

        protected VillagerStats VillagerStats { get; private set; }
        protected VillagerNavigator Navigator { get; private set; }

        private enum ActionPhase { Navigate, Act }
        private ActionPhase phase;

        public override void OnStart(ActionContext context)
        {
            base.OnStart(context);

            VillagerStats = villagerStats;
            Navigator = villagerNavigator;

            phase = ActionPhase.Navigate;

            Transform waypoint = GetTargetWaypoint();
            Navigator.MoveTo(waypoint.position);

            OnActionStart(context);
        }

        public override ActionStatus OnTick(ActionContext context)
        {
            switch (phase)
            {
                case ActionPhase.Navigate:
                    return TickNavigate(context);
                case ActionPhase.Act:
                    return TickAct(context);
                default:
                    return Fail();
            }
        }

        public override void OnStop(ActionContext context, ActionStopReason reason)
        {
            base.OnStop(context, reason);

            Navigator.Stop();
            OnActionStop(context, reason);
        }

        private ActionStatus TickNavigate(ActionContext context)
        {
            if (!Navigator.HasReachedDestination())
                return Continue();

            ActionStatus arrivalResult = OnArrived(context);

            if (arrivalResult == ActionStatus.Failed)
                return Fail();

            phase = ActionPhase.Act;
            return Continue();
        }

        private ActionStatus TickAct(ActionContext context)
        {
            return OnActTick(context);
        }

        protected abstract Transform GetTargetWaypoint();

        protected abstract ActionStatus OnArrived(ActionContext context);

        protected abstract ActionStatus OnActTick(ActionContext context);

        protected virtual void OnActionStart(ActionContext context) { }

        protected virtual void OnActionStop(ActionContext context, ActionStopReason reason) { }
    }
}