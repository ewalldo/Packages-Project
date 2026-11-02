namespace BehaviorTree
{
    /// <summary>
    /// A Sequence whose child order is reshuffled every time it starts.
    /// </summary>
    [NodeInfo("Random Sequence", "Composites", "A Sequence whose child order is shuffled each time it starts.")]
    public class RandomSequence : Sequence
    {
        /// <summary>Creates a random sequence over the given children</summary>
        /// <param name="children">The children to shuffle and run</param>
        public RandomSequence(params Node[] children) : base(children) { }

        /// <summary>Shuffles the children, then restarts from the first</summary>
        protected override void OnEnter(BehaviorTreeContext context)
        {
            RandomUtility.Shuffle(Children);
            base.OnEnter(context);
        }
    }
}