using System;
using UnityEngine;

namespace Tween
{
	public abstract class ShakeTween : Vector3Tween
	{
		private readonly float speed;
		private readonly float maxMagnitude;
		private readonly float noiseMagnitude;
		private readonly IgnoreAxisNoise ignoreAxisNoise;
		private readonly Vector3 seed;

        public ShakeTween(Vector3 from, Vector3 direction, float duration, float delay, float speed, float maxMagnitude, float noiseMagnitude, IgnoreAxisNoise ignoreAxisNoise, EasingFunction easingFunction, RestartLoop loopType, Action onComplete)
			: base(from, direction, duration, delay, easingFunction, loopType, onComplete)
		{
			this.speed = speed;
			this.maxMagnitude = maxMagnitude;
			this.noiseMagnitude = noiseMagnitude;
			this.ignoreAxisNoise = ignoreAxisNoise;
			seed = GenerateSeed();
		}

		public ShakeTween(ShakeParameters shakeParameters, Action onComplete)
			: base(shakeParameters.GetInitialValue, shakeParameters.GetDirection.normalized, shakeParameters.GetDuration, shakeParameters.GetDelay, shakeParameters.GetEasing, shakeParameters.GetLoop, onComplete)
        {
			speed = shakeParameters.GetSpeed;
			maxMagnitude = shakeParameters.GetMaxMagnitude;
			noiseMagnitude = shakeParameters.GetNoiseMagnitude;
			ignoreAxisNoise = shakeParameters.GetIgnoreAxisNoise;
			seed = GenerateSeed();
		}


		protected override Vector3 TweenValue(float progress)
        {
			float strength = 1 - progress;
			strength = EasingEquations.Evaluate(easingFunction, strength);

			float sin = Mathf.Sin(speed * (seed.x + seed.y + seed.z + Time.time));
			Vector3 direction = endValue + GetNoise();
			direction.Normalize();
			Vector3 delta = direction * sin;

			return (initialValue + (maxMagnitude * strength * delta));
		}

		private Vector3 GetNoise()
        {
			if (ignoreAxisNoise.HasFlag(IgnoreAxisNoise.All))
				return Vector3.zero;

			float time = Time.time;

			return noiseMagnitude * new Vector3(
				ignoreAxisNoise.HasFlag(IgnoreAxisNoise.X) ? 0f : Mathf.PerlinNoise(seed.x, time) - 0.5f,
				ignoreAxisNoise.HasFlag(IgnoreAxisNoise.Y) ? 0f : Mathf.PerlinNoise(seed.y, time) - 0.5f,
				ignoreAxisNoise.HasFlag(IgnoreAxisNoise.Z) ? 0f : Mathf.PerlinNoise(seed.z, time) - 0.5f);
		}

		private Vector3 GenerateSeed()
        {
			return new Vector3(
				UnityEngine.Random.value,
				UnityEngine.Random.value,
				UnityEngine.Random.value);
		}
	}
}