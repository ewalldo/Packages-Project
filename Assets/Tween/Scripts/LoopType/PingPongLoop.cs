using System;
using UnityEngine;

namespace Tween
{
	public class PingPongLoop : ILoopType
	{
        private uint numLoops;
        public uint NumLoops { get => numLoops; set => numLoops = value; }
        public bool IsInfiniteLoop { get => numLoops == 0; }
        public Func<bool> EarlyExitCondition { get; }
        public Action OnOneLoopCompleted { get; }

        private float delayBetweenLoops;
        public float DelayBetweenLoops { get => delayBetweenLoops; set => delayBetweenLoops = value; }

        public PingPongLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null)
        {
            this.numLoops = numLoops;
            this.delayBetweenLoops = delayBetweenLoops;
            this.EarlyExitCondition = earlyExit != null ? earlyExit : () => false;
            this.OnOneLoopCompleted = onOneLoopCompleted;
        }

        public (float, float) AdjustTweenValues(float from, float to)
        {
            return (to, from);
        }

        public (Vector2, Vector2) AdjustTweenValues(Vector2 from, Vector2 to)
        {
            return (to, from);
        }

        public (Vector3, Vector3) AdjustTweenValues(Vector3 from, Vector3 to)
        {
            return (to, from);
        }

        public (Vector4, Vector4) AdjustTweenValues(Vector4 from, Vector4 to)
        {
            return (to, from);
        }

        public (Color, Color) AdjustTweenValues(Color from, Color to)
        {
            return (to, from);
        }

        public (Quaternion, Quaternion) AdjustTweenValues(Quaternion from, Quaternion to)
        {
            return (to, from);
        }
    }
}