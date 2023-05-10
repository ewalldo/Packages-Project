using System;
using System.Collections;

namespace Tween
{
	public interface ITweener
	{
		event Action OnComplete;
		IEnumerator Execute();
	}
}