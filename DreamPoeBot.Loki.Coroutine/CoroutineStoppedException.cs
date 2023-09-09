using System;

namespace DreamPoeBot.Loki.Coroutine;

public class CoroutineStoppedException : Exception
{
	internal CoroutineStoppedException(string message)
		: base(message)
	{
	}
}
