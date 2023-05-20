using System;
using UnityEngine;

namespace Tween
{
    public class RestartLoop : ILoopType
	{
        private uint numLoops;
        public uint NumLoops { get => numLoops; set => numLoops = value; }
        public bool IsInfiniteLoop { get => numLoops == 0; }
        public Func<bool> EarlyExitCondition { get; }

        private float delayBetweenLoops;
        public float DelayBetweenLoops { get => delayBetweenLoops; set => delayBetweenLoops = value; }

        public RestartLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null)
        {
            this.numLoops = numLoops;
            this.delayBetweenLoops = delayBetweenLoops;
            this.EarlyExitCondition = earlyExit != null ? earlyExit : () => false;
        }

        public (float, float) AdjustTweenValues(float from, float to)
        {
            return (from, to);
        }

        public (Vector3, Vector3) AdjustTweenValues(Vector3 from, Vector3 to)
        {
            return (from, to);
        }

        public (Vector4, Vector4) AdjustTweenValues(Vector4 from, Vector4 to)
        {
            return (from, to);
        }

        public (Quaternion, Quaternion) AdjustTweenValues(Quaternion from, Quaternion to)
        {
            return (from, to);
        }
    }
}