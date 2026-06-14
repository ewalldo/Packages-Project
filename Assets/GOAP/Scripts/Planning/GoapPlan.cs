using System;
using System.Collections.Generic;
using GOAP.Actions;

namespace GOAP.Planning
{
    /// <summary>
    /// An ordered sequence of actions produced by the GoapPlanner.
    /// Consumed sequentially by the PlanExecutor.
    ///
    /// Internally backed by a Queue for O(1) dequeue operations,
    /// while also maintaining a snapshot list for inspection and debugging.
    /// </summary>
    public class GoapPlan
    {
        // - Internal Storage -

        private readonly Queue<IAction> actionQueue;
        private readonly List<IAction>  actionSnapshot;

        // - State -

        private PlanStatus status;

        // - Properties -

        /// <summary>Current lifecycle status of this plan.</summary>
        public PlanStatus Status
        {
            get => status;
            internal set => status = value;
        }

        /// <summary>Whether there are no remaining actions to execute.</summary>
        public bool IsEmpty => actionQueue.Count == 0;

        /// <summary>Number of actions remaining in the plan.</summary>
        public int RemainingCount => actionQueue.Count;

        /// <summary>Total number of actions in the original plan (including already executed ones).</summary>
        public int TotalCount => actionSnapshot.Count;

        /// <summary>
        /// Read-only snapshot of all actions in the plan in execution order.
        /// Includes already-executed actions.
        /// Safe to iterate for debugging without consuming the queue.
        /// </summary>
        public IReadOnlyList<IAction> Actions => actionSnapshot;

        // - Constructor -

        /// <summary>
        /// Creates a new plan from an ordered list of actions.
        /// Called exclusively by GoapPlanner.
        /// </summary>
        internal GoapPlan(List<IAction> orderedActions)
        {
            if (orderedActions == null)
                throw new ArgumentNullException(nameof(orderedActions));
            if (orderedActions.Count == 0)
                throw new ArgumentException("A plan must contain at least one action.", nameof(orderedActions));

            actionSnapshot = new List<IAction>(orderedActions);
            actionQueue = new Queue<IAction>(orderedActions);
            status = PlanStatus.Idle;
        }

        // - Consumption API (used by PlanExecutor) -

        /// <summary>
        /// Returns the next action without removing it from the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the plan is empty.</exception>
        public IAction Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Cannot peek an empty plan.");
            return actionQueue.Peek();
        }

        /// <summary>
        /// Removes and returns the next action from the plan.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the plan is empty.</exception>
        public IAction Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Cannot dequeue from an empty plan.");
            return actionQueue.Dequeue();
        }

        /// <summary>Tries to peek without throwing. Returns false if empty.</summary>
        public bool TryPeek(out IAction action)
        {
            if (IsEmpty)
            {
                action = null;
                return false;
            }

            action = actionQueue.Peek();
            return true;
        }

        /// <summary>Tries to dequeue without throwing. Returns false if empty.</summary>
        public bool TryDequeue(out IAction action)
        {
            if (IsEmpty)
            {
                action = null;
                return false;
            }

            action = actionQueue.Dequeue();
            return true;
        }

        // - Debug -

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"GoapPlan [{status}] ({TotalCount} actions):");
            for (int i = 0; i < actionSnapshot.Count; i++)
                sb.AppendLine($"  [{i + 1}] {actionSnapshot[i].Name}");

            return sb.ToString();
        }
    }
}