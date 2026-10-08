using System;
using UnityEngine;

namespace BehaviorTree.Samples
{
	public class VillagerBT : BehaviorTreeRunner
    {
        [SerializeField] private VillagerStats villagerStats;
        [SerializeField] private VillagerNavigator villagerNavigator;
        [SerializeField] private ToolVisualController toolVisualController;
        [SerializeField] private VillageManager villageManager;

        private static readonly BlackboardKey TargetLocationKey = "targetLocationKey";
        private static readonly BlackboardKey HeldToolKey = "HeldToolKey";
        private static readonly BlackboardKey RestPlaceKey = "RestPlaceKey";

        protected override Node BuildTree(Blackboard blackboard)
        {
            return new Selector(
                new ConditionGuard( // work branch
                    new EnergyThresholdCondition(() => !villagerStats.IsEnergyLow),
                    new Sequence(
                        new GoToAction(villagerNavigator, villageManager.ToolShed.Waypoint.position),
                        new RandomSelector(
                            new PickupToolAction(villagerStats, toolVisualController, villageManager.ToolShed, ToolType.Pickaxe),
                            new PickupToolAction(villagerStats, toolVisualController, villageManager.ToolShed, ToolType.Axe),
                            new PickupToolAction(villagerStats, toolVisualController, villageManager.ToolShed, ToolType.Hoe)
                            ),
                        new GoToAction(villagerNavigator, Vector3.zero, true),
                        new WorkAction(villagerStats),
                        new GoToAction(villagerNavigator, villageManager.ToolShed.Waypoint.position),
                        new ReturnToolAction(villagerStats, toolVisualController, villageManager.ToolShed)
                        )
                    ),
                new ConditionGuard( // Rest branch
                    new EnergyThresholdCondition(() => !villagerStats.IsEnergyFull),
                    new Sequence(
                        new RandomSelector(
                            new PickupRestLocationAction(villageManager.GetRestPlace(LocationType.House)),
                            new PickupRestLocationAction(villageManager.GetRestPlace(LocationType.Restaurant))
                            ),
                        new GoToAction(villagerNavigator, Vector3.zero, true),
                        new ConditionGuard(
                            new IsRestLocationAvailableCondition(villagerStats),
                            new RestAction(villagerStats)
                            )
                        )
                    ),
                new WaitAction() // wait branch
                );
        }

        private class EnergyThresholdCondition : ConditionNode
        {
            private readonly Func<bool> _condition;

            public EnergyThresholdCondition(Func<bool> condition)
            {
                _condition = condition;
            }

            protected override bool Evaluate(BehaviorTreeContext context)
            {
                return _condition();
            }
        }

        private class GoToAction : ActionNode
        {
            private readonly VillagerNavigator _villagerNavigator;
            private readonly bool _shouldReadLocationFromBlackboard;
            private Vector3 _targetPosition;

            public GoToAction(VillagerNavigator villagerNavigator, Vector3 targetPosition, bool shouldReadLocationFromBlackboard = false)
            {
                _villagerNavigator = villagerNavigator;
                _targetPosition = targetPosition;
                _shouldReadLocationFromBlackboard = shouldReadLocationFromBlackboard;
            }

            protected override void OnEnter(BehaviorTreeContext context)
            {
                if (_shouldReadLocationFromBlackboard)
                    _targetPosition = context.Blackboard.GetValueOrDefault<Vector3>(TargetLocationKey);

                _villagerNavigator.MoveTo(_targetPosition);
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                if (!_villagerNavigator.HasReachedDestination())
                    return NodeStatus.Running;

                return NodeStatus.Success;
            }
        }

        private class PickupToolAction : ActionNode
        {
            private readonly VillagerStats _villagerStats;
            private readonly ToolVisualController _toolVisualController;
            private readonly ToolShed _toolShed;
            private readonly ToolType _toolType;

            public PickupToolAction(VillagerStats villagerStats, ToolVisualController toolVisualController, ToolShed toolShed, ToolType toolType)
            {
                _villagerStats = villagerStats;
                _toolVisualController = toolVisualController;
                _toolShed = toolShed;
                _toolType = toolType;
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                if (!_toolShed.TryClaimTool(_toolType, _villagerStats))
                    return NodeStatus.Failure;

                _villagerStats.SetHeldTool(_toolType);
                _toolVisualController.ToggleToolVisual(_toolType, true);
                context.Blackboard.SetValue(TargetLocationKey, VillageManager.Instance.GetWorkStationForTool(_toolType).Waypoint.position);
                context.Blackboard.SetValue(HeldToolKey, (int)_toolType);
                return NodeStatus.Success;
            }
        }

        private class WorkAction : ActionNode
        {
            private readonly VillagerStats _villagerStats;
            private WorkStation _workStation;

            public WorkAction(VillagerStats villagerStats)
            {
                _villagerStats = villagerStats;
            }

            protected override void OnEnter(BehaviorTreeContext context)
            {
                int heldToolType = context.Blackboard.GetValueOrDefault<int>(HeldToolKey);
                _workStation = VillageManager.Instance.GetWorkStationForTool((ToolType)heldToolType);
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                if (_villagerStats.IsEnergyLow)
                    return NodeStatus.Success;

                _villagerStats.ConsumeEnergy(_workStation.EnergyCost * context.DeltaTime);
                VillageManager.Instance.RegisterGatheredResource(_workStation.ProducedResource, context.DeltaTime);

                return NodeStatus.Running;
            }
        }

        private class ReturnToolAction : ActionNode
        {
            private readonly VillagerStats _villagerStats;
            private readonly ToolVisualController _toolVisualController;
            private readonly ToolShed _toolShed;

            public ReturnToolAction(VillagerStats villagerStats, ToolVisualController toolVisualController, ToolShed toolShed)
            {
                _villagerStats = villagerStats;
                _toolVisualController = toolVisualController;
                _toolShed = toolShed;
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                if (!_villagerStats.IsHoldingTool)
                    return NodeStatus.Failure;

                _toolVisualController.ToggleToolVisual(_villagerStats.HeldTool, false);
                _toolShed.ReturnTool(_villagerStats.HeldTool, _villagerStats);
                _villagerStats.SetHeldTool(ToolType.None);
                context.Blackboard.SetValue(HeldToolKey, (int)ToolType.None);

                return NodeStatus.Success;
            }
        }

        private class PickupRestLocationAction : ActionNode
        {
            private readonly RestPlace _restPlace;

            public PickupRestLocationAction(RestPlace restPlace)
            {
                _restPlace = restPlace;
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                if (!_restPlace.IsOccupied)
                {
                    context.Blackboard.SetValue(TargetLocationKey, _restPlace.Waypoint.position);
                    context.Blackboard.SetValue(RestPlaceKey, (int)_restPlace.PlaceType);

                    return NodeStatus.Success;
                }

                return NodeStatus.Failure;
            }
        }

        private class IsRestLocationAvailableCondition : ConditionNode
        {
            private readonly VillagerStats _villagerStats;

            public IsRestLocationAvailableCondition(VillagerStats villagerStats)
            {
                _villagerStats = villagerStats;
            }

            protected override bool Evaluate(BehaviorTreeContext context)
            {
                int restPlaceType = context.Blackboard.GetValueOrDefault<int>(RestPlaceKey);
                RestPlace _restPlace = VillageManager.Instance.GetRestPlace((LocationType)restPlaceType);

                return _restPlace.TryOccupy(_villagerStats);
            }
        }

        private class RestAction : ActionNode
        {
            private readonly VillagerStats _villagerStats;
            private RestPlace _restPlace;

            public RestAction(VillagerStats villagerStats)
            {
                _villagerStats = villagerStats;
            }

            protected override void OnEnter(BehaviorTreeContext context)
            {
                int restPlaceType = context.Blackboard.GetValueOrDefault<int>(RestPlaceKey);
                _restPlace = VillageManager.Instance.GetRestPlace((LocationType)restPlaceType);
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                _villagerStats.RecoverEnergy(_restPlace.EnergyRecoveryRate * context.DeltaTime);

                if (_villagerStats.IsEnergyFull)
                {
                    _restPlace.Vacate(_villagerStats);
                    return NodeStatus.Success;
                }

                return NodeStatus.Running;
            }
        }

        private class WaitAction : ActionNode
        {
            private readonly float _waitDuration;
            private float _elapsedTime;

            public WaitAction(float waitDuration = 1f)
            {
                _waitDuration = waitDuration;
            }

            protected override void OnEnter(BehaviorTreeContext context)
            {
                _elapsedTime = 0f;
            }

            protected override NodeStatus OnTick(BehaviorTreeContext context)
            {
                _elapsedTime += context.DeltaTime;

                if (_elapsedTime >= _waitDuration)
                    return NodeStatus.Success;

                return NodeStatus.Running;
            }
        }
    }
}