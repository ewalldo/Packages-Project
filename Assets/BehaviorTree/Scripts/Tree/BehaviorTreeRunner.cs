using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// Base class for a MonoBehaviour that runs a behavior tree on a Unity GameObject.
    /// 
    /// Subclasses must implement:
    ///     - BuildTree() : defines the behavior tree structure for this agent, returning the root node
    /// </summary>
    public abstract class BehaviorTreeRunner : MonoBehaviour
    {
        [Tooltip("Minimum time, in seconds, between ticks. 0 (the default) ticks every frame")]
        [SerializeField] private float tickInterval;

        [Tooltip("Controls which Unity update loop the tree uses to tick itself. Choose based on the nature of the agent's actions and physics requirements")]
        [SerializeField] private AgentTickMode tickMode = AgentTickMode.Update;

        /// <summary>
        /// True to reset the blackboard to a fresh instance each time this agent is enabled. False to preserve the blackboard across enable/disable cycles
        /// </summary>
        [SerializeField] private bool resetBlackboardOnEnable = true;

        private BehaviorTree tree;
        private Blackboard blackboard;

        /// <summary>Time accumulated since the last tick, reset to 0 each time the tree is actually ticked</summary>
        private float timeSinceLastTick;

        /// <summary>This agent's running tree instance</summary>
        public BehaviorTree Tree => tree;

        /// <summary>This agent's blackboard instance</summary>
        public Blackboard Blackboard => blackboard;

        /// <summary>
        /// Composes this agent's behavior.
        /// </summary>
        /// <param name="blackboard">The blackboard this agent's tree instance will use</param>
        /// <returns>The tree's root node</returns>
        protected abstract Node BuildTree(Blackboard blackboard);

        /// <summary>Builds a fresh tree instance for this agent</summary>
        protected void OnEnable()
        {
            if (resetBlackboardOnEnable || blackboard == null)
                blackboard = new Blackboard();
            tree = new BehaviorTree(BuildTree(blackboard), gameObject, blackboard);
            timeSinceLastTick = 0f;
        }

        protected void Update()
        {
            if (tickMode == AgentTickMode.Update)
                Tick(Time.deltaTime);
        }

        protected void FixedUpdate()
        {
            if (tickMode == AgentTickMode.FixedUpdate)
                Tick(Time.fixedDeltaTime);
        }

        /// <summary>Aborts the running tree</summary>
        protected void OnDisable()
        {
            tree?.Abort();
        }

        /// <summary>
        /// Manually ticks the tree, if tickMode is set to Manual. Otherwise, this is called automatically by Update() or FixedUpdate() depending on tickMode.
        /// </summary>
        public void Tick(float deltaTime)
        {
            timeSinceLastTick += deltaTime;

            if (timeSinceLastTick < tickInterval)
                return;

            timeSinceLastTick = 0f;
            tree.Tick(deltaTime);
        }
    }
}