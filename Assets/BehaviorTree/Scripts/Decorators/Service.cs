namespace BehaviorTree
{
    /// <summary>
    /// Ticks its update on its own interval for as long as the child subtree is active, independent of what the child returns.
    /// Always passes the child's real status through unchanged.
    /// 
    /// Subclasses must implement:
    ///     - OnUpdate() : defines the service's own update logic.
    /// </summary>
    public abstract class Service : Decorator
    {
        private readonly float interval;
        private readonly bool updateOnFirstTick = true;

        private float elapsed;

        /// <summary>Creates a service wrapping the given child</summary>
        /// <param name="child">The subtree this service runs alongside</param>
        /// <param name="interval">How often, in seconds, to update the service</param>
        protected Service(Node child, float interval, bool updateOnFirstTick) : base(child)
        {
            this.interval = interval;
            this.updateOnFirstTick = updateOnFirstTick;
        }

        /// <summary>
        /// Resets the elapsed-time counter on every (re)entry
        /// </summary>
        protected override void OnEnter(BehaviorTreeContext context)
        {
            if (updateOnFirstTick)
                elapsed = interval; // force an immediate update on the first tick
            else
                elapsed = 0f;
        }

        protected override NodeStatus OnTick(BehaviorTreeContext context)
        {
            elapsed += context.DeltaTime;

            if (elapsed >= interval)
            {
                elapsed = 0f;
                OnUpdate(context);
            }

            return Child.Tick(context);
        }

        protected abstract void OnUpdate(BehaviorTreeContext context);
    }
}
