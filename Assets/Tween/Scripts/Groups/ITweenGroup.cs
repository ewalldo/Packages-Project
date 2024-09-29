using System;

namespace Tween
{
	public interface ITweenGroup
	{
		event Action OnAllTweensCompleted;
		ITweenGroup AddTween(ITweener tween);
		void Execute();
		void Reset();
		void Stop();
	}
}