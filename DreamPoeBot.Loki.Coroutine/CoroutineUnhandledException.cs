using System;

namespace DreamPoeBot.Loki.Coroutine;

public class CoroutineUnhandledException : CoroutineException
{
	public CoroutineUnhandledException(string message)
		: base(message)
	{
	}

	public CoroutineUnhandledException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
