using System.Collections;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Framework;

public class WaitTime : YieldBase
{
	public int Milliseconds { get; }

	public WaitTime(int milliseconds)
	{
		Milliseconds = milliseconds;
		base.Current = GetEnumerator();
	}

	public sealed override IEnumerator GetEnumerator()
	{
		long wait = GameController.Instance.MainTimer.ElapsedMilliseconds + Milliseconds;
		while (GameController.Instance.MainTimer.ElapsedMilliseconds < wait)
		{
			yield return null;
		}
	}
}
