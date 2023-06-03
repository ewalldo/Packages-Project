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
        Action OnOneLoopCompleted { get; }

        (float, float) AdjustTweenValues(float from, float to);
        (Vector2, Vector2) AdjustTweenValues(Vector2 from, Vector2 to);
        (Vector3, Vector3) AdjustTweenValues(Vector3 from, Vector3 to);
        (Vector4, Vector4) AdjustTweenValues(Vector4 from, Vector4 to);
        (Color, Color) AdjustTweenValues(Color from, Color to);
        (Quaternion, Quaternion) AdjustTweenValues(Quaternion from, Quaternion to);
    }
}