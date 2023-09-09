namespace DreamPoeBot.Loki.Coroutine;

public struct ExternalTaskWaitResult<T>
{
	internal static readonly ExternalTaskWaitResult<T> externalTaskWaitResult_0;

	public bool Completed { get; private set; }

	public T Result { get; private set; }

	private ExternalTaskWaitResult(T result)
	{
		Completed = true;
		Result = result;
	}

	internal static ExternalTaskWaitResult<T> smethod_0(T gparam_1)
	{
		return new ExternalTaskWaitResult<T>(gparam_1);
	}
}
