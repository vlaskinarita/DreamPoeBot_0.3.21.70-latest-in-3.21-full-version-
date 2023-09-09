using System;
using System.Collections;

namespace DreamPoeBot.Framework;

public class WaitFunction : YieldBase
{
	public WaitFunction(Func<bool> fn)
	{
		while (fn())
		{
			base.Current = GetEnumerator();
		}
	}

	public sealed override IEnumerator GetEnumerator()
	{
		yield return null;
	}
}
