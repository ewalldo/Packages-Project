using System;
using System.Collections.Generic;
using GOAP.Sensing;
using GOAP.WorldStates;

namespace GOAP.Goals
{
    /// <summary>
    /// Evaluates all registered goals against the current world state and selects the highest-priority valid, unsatisfied goal.
    /// </summary>
    public class GoalSelector
    {
        // - Internal State -

        private readonly List<IGoal> goals = new List<IGoal>();
        private IGoal currentGoal;

        // - Public API -

        /// <summary>The currently active goal. Null if none has been selected yet.</summary>
        public IGoal CurrentGoal => currentGoal;

        /// <summary>Read-only view of all registered goals.</summary>
        public IReadOnlyList<IGoal> Goals => goals;

        // - Registration -

        /// <summary>Registers a goal to be considered during selection.</summary>
        public void RegisterGoal(IGoal goal)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (!goals.Contains(goal))
                goals.Add(goal);
        }

        /// <summary>Removes a previously registered goal.</summary>
        public void UnregisterGoal(IGoal goal)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            goals.Remove(goal);

            // If the current goal was removed, clear it
            if (currentGoal == goal)
                currentGoal = null;
        }

        /// <summary>Removes all registered goals and clears the current selection.</summary>
        public void ClearGoals()
        {
            goals.Clear();
            currentGoal = null;
        }

        // - Selection -

        /// <summary>
        /// Evaluates all registered goals and selects the best one.
        ///
        /// Selection rules:
        ///   1. Goal must pass IsValid(currentState)
        ///   2. Goal must not already be satisfied: !IsSatisfied(currentState)
        ///   3. Among all qualifying goals, the one with the highest GetPriority() wins
        ///   4. If the new best goal differs from the current one, lifecycle events are fired
        /// </summary>
        /// <param name="currentState">The agent's current world state snapshot.</param>
        /// <param name="blackboard">The agent's current blackboard snapshot.</param>
        public GoalSelectionResult SelectBestGoal(WorldState currentState, Blackboard blackboard)
        {
            if (currentState == null)
                throw new ArgumentNullException(nameof(currentState));

            IGoal bestGoal = null;
            float bestPriority = float.MinValue;
            bool  anyValid = false;
            bool  anyUnsatisfied = false;

            for (int i = 0; i < goals.Count; i++)
            {
                IGoal goal = goals[i];

                // Step 1: validity check
                if (!goal.IsValid(currentState))
                    continue;

                anyValid = true;

                // Step 2: skip already satisfied goals
                if (goal.IsSatisfied(currentState))
                    continue;

                anyUnsatisfied = true;

                // Step 3: priority comparison
                float priority = goal.GetPriority(currentState, blackboard);
                if (priority > bestPriority)
                {
                    bestPriority = priority;
                    bestGoal     = goal;
                }
            }

            // - Build result -
            if (bestGoal == null)
            {
                return anyValid && !anyUnsatisfied
                    ? GoalSelectionResult.AllSatisfied()
                    : GoalSelectionResult.NoneValid();
            }

            // - Transition to new goal if changed -
            if (bestGoal != currentGoal)
                TransitionToGoal(bestGoal, GoalDeactivationReason.Interrupted);

            return GoalSelectionResult.Found(bestGoal, bestPriority);
        }

        /// <summary>
        /// Forces the current goal to be deactivated without selecting a new one.
        /// Useful when the agent is disabled or a plan fails catastrophically.
        /// </summary>
        public void ClearCurrentGoal(GoalDeactivationReason reason)
        {
            if (currentGoal == null)
                return;

            currentGoal.OnGoalDeactivated(reason);
            currentGoal = null;
        }

        // - Private Helpers -

        private void TransitionToGoal(IGoal newGoal, GoalDeactivationReason deactivationReason)
        {
            // Deactivate old goal
            currentGoal?.OnGoalDeactivated(deactivationReason);

            // Activate new goal
            currentGoal = newGoal;
            currentGoal.OnGoalActivated();
        }
    }
}