namespace BehaviorTree
{
    /// <summary>Forces Failure for a duration after the child last finished running, then allows it to run again.</summary>
    [NodeInfo("Cooldown", "Decorators", "Forces Failure for a duration after the child last finished running.")]
    public class Cooldown : Decorator
    {
        private readonly float cooldownDuration;

        /// <summary>
        /// Time elapsed since the child last finished. Deliberately not reinitialized in OnEnter,
        /// the cooldown timer is meant to keep counting across the owning subtree being re-entered or
        /// the whole tree being reset.
        /// </summary>
        private float timeSinceLastRun;

        /// <summary>Creates a cooldown wrapping the given child</summary>
        /// <param name="child">The node to gate</param>
        /// <param name="cooldownDuration">How long, in seconds, to force failure for after the child last finished</param>
        public Cooldown(Node child, float cooldownDuration) : base(child)
        {
            this.cooldownDuration = cooldownDuration;
            this.timeSinceLastRun = cooldownDuration;
        }

        /// <inheritdoc/>
        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            if (timeSinceLastRun < cooldownDuration)
            {
                timeSinceLastRun += context.DeltaTime;
                return NodeStatus.Failure;
            }

            NodeStatus status = Child.Tick(context);

            if (status != NodeStatus.Running)
                timeSinceLastRun = 0f;

            return status;
        }
    }
}