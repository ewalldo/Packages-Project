using System;
using UnityEngine;

namespace Tween
{
    public interface ILoopType
	{
        uint NumLoops { get; }
        bool IsInfiniteLoop { get; }
        float DelayBetweenLoops { get; }
        Func<bool> EarlyExitCondition { get; }

        (float, float) AdjustTweenValues(float from, float to);
        (Vector3, Vector3) AdjustTweenValues(Vector3 from, Vector3 to);
        (Vector4, Vector4) AdjustTweenValues(Vector4 from, Vector4 to);
    }
}