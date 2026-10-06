namespace BehaviorTree
{
    /// <summary>
    /// Controls how reactively a <see cref="ConditionGuard"/> responds to its condition changing.
    /// </summary>
    public enum AbortType
    {
        /// <summary>The condition is checked once, on first entry, like a static precondition. Never re-checked afterward</summary>
        None,

        /// <summary>
        /// Re-checks the condition every tick while this guard's own child is the active branch,
        /// aborting it if the condition turns false. Has no effect while a different (lower-priority) sibling is active instead.
        /// </summary>
        Self,

        /// <summary>
        /// Lets a parent reactively notice this guard's condition becoming true again while a lower-priority sibling is currently running, aborting that sibling and taking over. Has no effect while this guard's own child is active.
        /// </summary>
        LowerPriority,

        /// <summary>
        /// Combines the effects of Self and LowerPriority, re-checking the condition every tick and allowing a parent to notice it becoming true again while a lower-priority sibling is currently running.
        /// </summary>
        Both
    }
}