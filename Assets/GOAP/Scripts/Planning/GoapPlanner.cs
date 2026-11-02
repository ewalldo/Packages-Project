using System;
using System.Collections.Generic;
using GOAP.Actions;
using GOAP.Goals;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Planning
{
    /// <summary>
    /// A forward-search A* GOAP planner.
    ///
    /// Algorithm overview:
    ///   1. Start from the current world state (root node, zero cost).
    ///   2. Expand the lowest f-cost node from the open set.
    ///   3. For each available action whose preconditions are met by the node's state:
    ///        a. Clone the state and apply the action's effects.
    ///        b. Compute g = parent.g + action.cost, h = heuristic(new state, goal).
    ///        c. If not visited with a lower cost, add a new node to the open set.
    ///   4. If the expanded node's state satisfies the goal, reconstruct the plan.
    ///   5. Stop if the open set is empty (no plan exists) or limits are exceeded.
    ///
    /// This class is a pure C# class (no MonoBehaviour) and can be unit tested
    /// in isolation. It is owned and driven by the GoapAgent.
    /// </summary>
    public class GoapPlanner : IPlanner
    {
        // - Dependencies -

        private readonly PlannerSettings settings;
        private readonly IPlannerHeuristic heuristic;
        private readonly NodePool nodePool;

        // - Reusable Search Structures -

        // Open set: nodes to be evaluated. Sorted by FCost ascending.
        private readonly List<PlannerNode>  openSet;

        // Closed set: maps a state hash to the best GCost seen for that state.
        // Prevents revisiting states with equal or worse cost.
        private readonly Dictionary<int, float> closedSet;

        // All nodes rented this cycle, collected for return to the pool.
        private readonly List<PlannerNode>  rentedNodes;

        // - Constructor -

        /// <param name="settings">Planner configuration. If null, defaults are used.</param>
        /// <param name="heuristic">Heuristic to guide search. If null, the default is used.</param>
        public GoapPlanner(PlannerSettings settings = null, IPlannerHeuristic heuristic = null)
        {
            this.settings = settings ?? PlannerSettings.CreateDefault();
            this.heuristic = heuristic ?? new UnsatisfiedConditionsHeuristic();
            nodePool = new NodePool(initialCapacity: 64);
            openSet = new List<PlannerNode>(64);
            closedSet = new Dictionary<int, float>(64);
            rentedNodes = new List<PlannerNode>(64);
        }

        // - IPlanner -

        /// <inheritdoc/>
        public GoapPlan CreatePlan(WorldState currentState, IGoal goal, IReadOnlyList<IAction> availableActions)
        {
            if (currentState == null)
                throw new ArgumentNullException(nameof(currentState));
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));
            if (availableActions == null)
                throw new ArgumentNullException(nameof(availableActions));

            // - Early exit -
            if (goal.IsSatisfied(currentState))
            {
                if (settings.DebugLog)
                    Debug.Log($"[GoapPlanner] Goal '{goal.Name}' is already satisfied. No plan needed.");
                return null;
            }

            // - Initialize search -
            PrepareSearch();

            WorldState goalState = goal.DesiredState;
            float initialH = heuristic.Compute(currentState, goalState) * settings.HeuristicWeight;

            PlannerNode rootNode = RentNode(
                simulatedState: currentState.Clone(),
                action: null,
                parent: null,
                gCost: 0f,
                hCost: initialH);

            InsertIntoOpenSet(rootNode);

            int iterations = 0;
            GoapPlan result = null;

            // - A* Search loop -
            while (openSet.Count > 0 && iterations < settings.MaxIterations)
            {
                iterations++;

                // Pop lowest f-cost node
                PlannerNode current = PopBestNode();
                int stateHash = ComputeStateHash(current.SimulatedState);

                // Skip if we already found a cheaper path to this state
                if (closedSet.TryGetValue(stateHash, out float bestCost) && current.GCost >= bestCost)
                    continue;

                closedSet[stateHash] = current.GCost;

                // - Goal check -
                if (current.SimulatedState.Satisfies(goalState))
                {
                    result = ReconstructPlan(current);

                    if (settings.DebugLog)
                        Debug.Log($"[GoapPlanner] Plan found for '{goal.Name}' " + $"in {iterations} iterations:\n{result}");
                    break;
                }

                // - Depth limit check -
                if (current.Depth >= settings.MaxPlanLength)
                    continue;

                // - Expand neighbours -
                ExpandNode(current, goalState, availableActions);
            }

            // - Cleanup -
            if (result == null && settings.DebugLog)
                Debug.LogWarning($"[GoapPlanner] No plan found for goal '{goal.Name}' " + $"after {iterations} iterations.");

            ReturnNodesToPool();
            return result;
        }

        // - Search Helpers -

        /// <summary>Expands a node by trying every available action.</summary>
        private void ExpandNode(PlannerNode current, WorldState goalState, IReadOnlyList<IAction> availableActions)
        {
            for (int i = 0; i < availableActions.Count; i++)
            {
                IAction action = availableActions[i];

                // - Check preconditions against simulated state -
                if (!ArePreconditionsMet(action, current.SimulatedState))
                    continue;

                // - Simulate state transition -
                WorldState nextState = current.SimulatedState.Clone();
                nextState.ApplyRange(action.Effects);

                // - Compute costs -
                float actionCost = action.GetCost(current.SimulatedState);
                float newGCost = current.GCost + actionCost;
                float newHCost = heuristic.Compute(nextState, goalState) * settings.HeuristicWeight;

                int nextHash = ComputeStateHash(nextState);

                // Skip if we already found an equal or cheaper path to this state
                if (closedSet.TryGetValue(nextHash, out float existingCost) && newGCost >= existingCost)
                    continue;

                PlannerNode nextNode = RentNode(
                    simulatedState: nextState,
                    action: action,
                    parent: current,
                    gCost: newGCost,
                    hCost: newHCost);

                InsertIntoOpenSet(nextNode);
            }
        }

        /// <summary>
        /// Checks whether all of an action's preconditions are met
        /// by the given simulated world state.
        /// </summary>
        private static bool ArePreconditionsMet(IAction action, WorldState state)
        {
            IReadOnlyList<WorldStateFact> preconditions = action.Preconditions;

            for (int i = 0; i < preconditions.Count; i++)
            {
                WorldStateFact pre = preconditions[i];

                if (!state.TryGet(pre.Key, out object currentValue) || !Equals(currentValue, pre.Value))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Reconstructs the ordered action sequence by walking
        /// back from the goal node to the root.
        /// </summary>
        private static GoapPlan ReconstructPlan(PlannerNode goalNode)
        {
            List<IAction> actions = new List<IAction>();
            PlannerNode current = goalNode;

            while (current.Action != null)
            {
                actions.Add(current.Action);
                current = current.Parent;
            }

            // Built in reverse (goal Å® root), so flip it
            actions.Reverse();
            return new GoapPlan(actions);
        }

        // - Open Set Helpers -

        /// <summary>
        /// Inserts a node into the open set in sorted order (ascending FCost).
        /// Uses binary search for O(log n) insertion.
        /// </summary>
        private void InsertIntoOpenSet(PlannerNode node)
        {
            int lo = 0;
            int hi = openSet.Count;

            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (openSet[mid].FCost < node.FCost)
                    lo = mid + 1;
                else
                    hi = mid;
            }

            openSet.Insert(lo, node);
        }

        /// <summary>Removes and returns the node with the lowest FCost (front of sorted list).</summary>
        private PlannerNode PopBestNode()
        {
            PlannerNode best = openSet[0];
            openSet.RemoveAt(0);
            return best;
        }

        // - Node Pool Helpers -

        private PlannerNode RentNode(WorldState simulatedState, IAction action, PlannerNode parent, float gCost, float hCost)
        {
            PlannerNode node = nodePool.Rent();
            node.Initialize(simulatedState, action, parent, gCost, hCost);
            rentedNodes.Add(node);
            return node;
        }

        private void ReturnNodesToPool()
        {
            nodePool.ReturnAll(rentedNodes);
            rentedNodes.Clear();
        }

        // - Misc Helpers -

        private void PrepareSearch()
        {
            openSet.Clear();
            closedSet.Clear();
            rentedNodes.Clear();
        }

        /// <summary>
        /// Computes a hash of a WorldState for use as a closed-set key.
        /// Combines each key-value pair's hash to produce a single integer.
        /// </summary>
        private static int ComputeStateHash(WorldState state)
        {
            int hash = 17;

            foreach (WorldStateFact fact in state.GetAllFacts())
            {
                hash = hash * 31 + fact.Key.GetHashCode();
                hash = hash * 31 + (fact.Value?.GetHashCode() ?? 0);
            }

            return hash;
        }
    }
}