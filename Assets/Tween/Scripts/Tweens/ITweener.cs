using System;
using System.Collections;

namespace Tween
{
	public interface ITweener
	{
		bool IsExecuting { get; }
		event Action OnComplete;
		IEnumerator Execute();
		void ForceFinish();
	}
}