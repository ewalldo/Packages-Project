using System;

namespace Tween
{
	public interface ITweenGroup
	{
		event Action OnAllTweensCompleted;
		ITweenGroup AddTween(ITweener tween);
		bool IsExecuting { get; }
		void Execute();
		void Reset();
		void Stop(bool forceFinish);
	}
}