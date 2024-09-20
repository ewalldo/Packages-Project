using UnityEngine;

namespace Tween
{
	[System.Serializable]
	public class ShakeParameters
	{
        [SerializeField] private Vector3 initialValue;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float duration;
        [SerializeField] private float delay;
        [SerializeField] private float speed;
        [SerializeField] private float maxMagnitude;
        [SerializeField] private float noiseMagnitude;
        [SerializeField] private IgnoreAxisNoise ignoreAxisNoise;
        [SerializeField] private EasingType easingType;
        [SerializeField] private AnimationCurve customAnimationCurve;
        [SerializeField] private LoopTypes loop;
        [SerializeField] private uint numLoops;
        [SerializeField] private float delayBetweenLoops;

        private EasingFunction easingFunction;
        private RestartLoop loopType;

        public enum LoopTypes
        {
            None,
            Restart,
        }

        public ShakeParameters(Vector3 initialValue, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null)
        {
            this.initialValue = initialValue;
            this.direction = direction;
            this.duration = duration;
            this.delay = delay;
            this.speed = speed;
            this.maxMagnitude = maxMagnitude;
            this.noiseMagnitude = noiseMagnitude;
            this.ignoreAxisNoise = ignoreAxisNoise;
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
                _ => LoopTypes.None,
            };
            numLoops = loopType.NumLoops;
            delayBetweenLoops = loopType.DelayBetweenLoops;
        }

        public Vector3 GetInitialValue => initialValue;

        public Vector3 GetDirection => direction;

        public float GetDuration => duration;

        public float GetDelay => delay;

        public float GetSpeed => speed;

        public float GetMaxMagnitude => maxMagnitude;

        public float GetNoiseMagnitude => noiseMagnitude;

        public IgnoreAxisNoise GetIgnoreAxisNoise => ignoreAxisNoise;

        public EasingFunction GetEasing => easingFunction ?? CreateEasing();

        public RestartLoop GetLoop => loopType ?? CreateLoop();

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

        private RestartLoop CreateLoop()
        {
            loopType = loop switch
            {
                LoopTypes.None => null,
                LoopTypes.Restart => new RestartLoop(numLoops, delayBetweenLoops),
                _ => null,
            };

            return loopType;
        }

        public static string GetNameOfInitialValue => nameof(initialValue);
        public static string GetNameOfDirection => nameof(direction);
        public static string GetNameOfDuration => nameof(duration);
        public static string GetNameOfDelay => nameof(delay);
        public static string GetNameOfSpeed => nameof(speed);
        public static string GetNameOfMaxMagnitude => nameof(maxMagnitude);
        public static string GetNameOfNoiseMagnitude => nameof(noiseMagnitude);
        public static string GetNameOfIgnoreAxisNoise => nameof(ignoreAxisNoise);
        public static string GetNameOfEasingType => nameof(easingType);
        public static string GetNameOfCustomAnimationCurve => nameof(customAnimationCurve);
        public static string GetNameOfLoop => nameof(loop);
        public static string GetNameOfNumLoops => nameof(numLoops);
        public static string GetNameOfDelayBetweenLoops => nameof(delayBetweenLoops);
    }
}