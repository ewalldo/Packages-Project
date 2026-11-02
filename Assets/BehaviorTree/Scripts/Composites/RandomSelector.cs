namespace BehaviorTree
{
    /// <summary>
    /// A Selector whose child order is reshuffled every time it starts.
    /// </summary>
    [NodeInfo("Random Selector", "Composites", "A Selector whose child order is shuffled each time it starts.")]
    public class RandomSelector : Selector
    {
        /// <summary>Creates a random selector over the given children</summary>
        /// <param name="children">The children to shuffle and try</param>
        public RandomSelector(params Node[] children) : base(children) { }

        /// <summary>Shuffles the children, then restarts from the first</summary>
        protected override void OnEnter(BehaviorTreeContext context)
        {
            RandomUtility.Shuffle(Children);
            base.OnEnter(context);
        }
    }
}