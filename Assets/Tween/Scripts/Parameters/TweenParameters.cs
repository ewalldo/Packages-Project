using UnityEngine;

namespace Tween
{
	[System.Serializable]
	public class TweenParameters<T>
	{
        [SerializeField] private T initialValue;
        [SerializeField] private T endValue;
        [SerializeField] private float duration;
        [SerializeField] private float delay;
        [SerializeField] private EasingType easingType;
        [SerializeField] private AnimationCurve customAnimationCurve;
        [SerializeField] private LoopTypes loop;
        [SerializeField] private uint numLoops;
        [SerializeField] private float delayBetweenLoops;

        private EasingFunction easingFunction;
        private ILoopType loopType;

        public enum LoopTypes
        {
            None,
            Restart,
            PingPong,
            Incremental
        }

        public TweenParameters(T initialValue, T endValue, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
            this.duration = duration;
            this.delay = delay;
            this.easingFunction = easingFunction;
            this.loopType = loopType;

            easingType = easingFunction.EasingName;
            if (easingType == EasingType.AnimationCurveEasing)
            {
                AnimationCurveEasing animationCurveEasing = easingFunction as AnimationCurveEasing;
                customAnimationCurve = animationCurveEasing.EasingCurve;
            }

            loop = loopType switch
            {
                RestartLoop => LoopTypes.Restart,
                PingPongLoop => LoopTypes.PingPong,
                IncrementalLoop => LoopTypes.Incremental,
                _ => LoopTypes.None,
            };
            numLoops = loopType.NumLoops;
            delayBetweenLoops = loopType.DelayBetweenLoops;
        }

        public T GetInitialValue => initialValue;

        public T GetEndValue => endValue;

        public float GetDuration => duration;

        public float GetDelay => delay;

        public EasingFunction GetEasing => easingFunction ?? CreateEasing();

        public ILoopType GetLoop => loopType ?? CreateLoop();

        public void ApplyOverriddenParameters()
        {
            easingFunction = CreateEasing();
            loopType = CreateLoop();
        }

        private EasingFunction CreateEasing()
        {
            if (easingType == EasingType.AnimationCurveEasing)
                easingFunction = new AnimationCurveEasing(customAnimationCurve);
            else
                easingFunction = EasingFactory.GetEasing(easingType);

            return easingFunction;
        }

        private ILoopType CreateLoop()
        {
            loopType = loop switch
            {
                LoopTypes.None => null,
                LoopTypes.Restart => new RestartLoop(numLoops, delayBetweenLoops),
                LoopTypes.PingPong => new PingPongLoop(numLoops, delayBetweenLoops),
                LoopTypes.Incremental => new IncrementalLoop(numLoops, delayBetweenLoops),
                _ => null,
            };

            return loopType;
        }

        public static string GetNameOfInitialValue => nameof(initialValue);
        public static string GetNameOfEndValue => nameof(endValue);
        public static string GetNameOfDuration => nameof(duration);
        public static string GetNameOfDelay => nameof(delay);
        public static string GetNameOfEasingType => nameof(easingType);
        public static string GetNameOfCustomAnimationCurve => nameof(customAnimationCurve);
        public static string GetNameOfLoop => nameof(loop);
        public static string GetNameOfNumLoops => nameof(numLoops);
        public static string GetNameOfDelayBetweenLoops => nameof(delayBetweenLoops);
    }
}