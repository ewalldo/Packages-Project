using UnityEngine;

namespace GOAP.Planning
{
    /// <summary>
    /// Configuration asset for the GoapPlanner.
    /// Create one via Assets > Create > Scriptable Objects > GOAP > Planner Settings
    /// and assign it to the GoapAgentConfig in the Inspector.
    /// </summary>
    [CreateAssetMenu(fileName = "PlannerSettings", menuName = "Scriptable Objects/GOAP/Planner Settings")]
    public class PlannerSettings : ScriptableObject
    {
        [Header("Search Limits")]
        [Tooltip("Maximum number of nodes the planner may expand before giving up. Prevents infinite loops on unsolvable goals.")]
        [SerializeField, Min(1)] private int maxIterations = 200;

        [Tooltip("Maximum number of actions allowed in a single plan. Prevents the planner from finding absurdly long plans.")]
        [SerializeField, Min(1)] private int maxPlanLength = 20;

        [Header("Cost")]
        [Tooltip("Weight applied to the heuristic component of the f-cost (f = g + weight * h). " +
                 "1.0 = standard A*. Higher values = faster but less optimal (weighted A*).")]
        [SerializeField, Min(1f)] private float heuristicWeight = 1f;

        [Header("Debug")]
        [Tooltip("If enabled, the planner will log search details to the console.")]
        [SerializeField] private bool debugLog = false;

        // - Public Accessors -

        public int MaxIterations => maxIterations;
        public int MaxPlanLength => maxPlanLength;
        public float HeuristicWeight => heuristicWeight;
        public bool DebugLog => debugLog;

        /// <summary>
        /// Creates a default PlannerSettings instance at runtime
        /// when no asset has been assigned.
        /// </summary>
        public static PlannerSettings CreateDefault()
        {
            PlannerSettings settings = CreateInstance<PlannerSettings>();
            settings.maxIterations = 200;
            settings.maxPlanLength = 20;
            settings.heuristicWeight = 1f;
            settings.debugLog = false;

            return settings;
        }
    }
}