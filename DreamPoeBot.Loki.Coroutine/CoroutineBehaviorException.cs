using System;

namespace DreamPoeBot.Loki.Coroutine;

public class CoroutineBehaviorException : CoroutineException
{
	public CoroutineBehaviorException(string message)
		: base(message)
	{
	}

	public CoroutineBehaviorException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
