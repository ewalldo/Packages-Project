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

        public ShakeTween(float speed, float maxMagnitude, float noiseMagnitude, IgnoreAxisNoise ignoreAxisNoise)
        {
			this.speed = speed;
			this.maxMagnitude = maxMagnitude;
			this.noiseMagnitude = noiseMagnitude;
			this.ignoreAxisNoise = ignoreAxisNoise;
			seed = new Vector3(
				Random.value,
				Random.value,
				Random.value);
		}

        protected override void TweenValue(float progress)
        {
			float strength = 1 - progress;
			strength = EasingEquations.Evaluate(easingFunction, strength);

			float sin = Mathf.Sin(speed * (seed.x + seed.y + seed.z + Time.time));
			Vector3 direction = endValue + GetNoise();
			direction.Normalize();
			Vector3 delta = direction * sin;
			ApplyTween(initialValue + (maxMagnitude * strength * delta));
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

	}
}