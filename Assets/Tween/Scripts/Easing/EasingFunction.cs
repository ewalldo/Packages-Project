using UnityEngine;

namespace Tween
{
	public abstract class EasingFunction
	{
        public abstract float Evaluate(float start, float end, float value);

        public virtual Vector3 Evaluate(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Evaluate(start.x, end.x, value), Evaluate(start.y, end.y, value), Evaluate(start.z, end.z, value));
        }

        public virtual Vector4 Evaluate(Vector4 start, Vector4 end, float value)
        {
            return new Vector4(Evaluate(start.x, end.x, value), Evaluate(start.y, end.y, value), Evaluate(start.z, end.z, value), Evaluate(start.w, end.w, value));
        }
    }

    public class LinearEasing : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }
    }

    public class EaseInQuad : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }
    }

    public class EaseOutQuad : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return -end * value * (value - 2) + start;
        }
    }

    public class EaseInOutQuad : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return end * 0.5f * value * value + start;

            value--;
            return -end * 0.5f * (value * (value - 2) - 1) + start;
        }
    }

    public class EaseInCubic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value + start;
        }
    }

    public class EaseOutCubic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }
    }

    public class EaseInOutCubic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return end * 0.5f * value * value * value + start;

            value -= 2;
            return end * 0.5f * (value * value * value + 2) + start;
        }
    }

    public class EaseInQuart : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value + start;
        }
    }

    public class EaseOutQuart : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }
    }

    public class EaseInOutQuart : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return end * 0.5f * value * value * value * value + start;

            value -= 2;
            return -end * 0.5f * (value * value * value * value - 2) + start;
        }
    }

    public class EaseInQuint : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value * value + start;
        }
    }

    public class EaseOutQuint : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value * value * value + 1) + start;
        }
    }

    public class EaseInOutQuint : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return end * 0.5f * value * value * value * value * value + start;

            value -= 2;
            return end * 0.5f * (value * value * value * value * value + 2) + start;
        }
    }

    public class EaseInSine : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
        }
    }

    public class EaseOutSine : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
        }
    }

    public class EaseInOutSine : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
        }
    }

    public class EaseInExpo : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Pow(2, 10 * (value - 1)) + start;
        }
    }

    public class EaseOutExpo : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
        }
    }

    public class EaseInOutExpo : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;

            value--;
            return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
        }
    }

    public class EaseInCirc : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
        }
    }

    public class EaseOutCirc : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * Mathf.Sqrt(1 - value * value) + start;
        }
    }

    public class EaseInOutCirc : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= .5f;
            end -= start;

            if (value < 1)
                return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;

            value -= 2;
            return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
        }
    }

    public class EaseInBounce : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            EaseOutBounce easeOutBounce = new EaseOutBounce();

            end -= start;
            float d = 1f;
            return end - easeOutBounce.Evaluate(0, end, d - value) + start;
        }
    }

    public class EaseOutBounce : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return end * (7.5625f * (value) * value + .984375f) + start;
            }
        }
    }

    public class EaseInOutBounce : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            float d = 1f;

            if (value < d * 0.5f)
            {
                EaseInBounce easeInBounce = new EaseInBounce();
                return easeInBounce.Evaluate(0, end, value * 2) * 0.5f + start;
            }
            else
            {
                EaseOutBounce easeOutBounce = new EaseOutBounce();
                return easeOutBounce.Evaluate(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
            }
        }
    }

    public class EaseInBack : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }
    }

    public class EaseOutBack : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }
    }

    public class EaseInOutBack : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;

            if ((value) < 1)
            {
                s *= (1.525f);
                return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
            }

            value -= 2;
            s *= (1.525f);
            return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }
    }

    public class EaseInElastic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        }
    }

    public class EaseOutElastic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
        }
    }

    public class EaseInOutElastic : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d * 0.5f) == 2) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
            return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
        }
    }

    public class SpringEasing : EasingFunction
    {
        public override float Evaluate(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }
    }
}