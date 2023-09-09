using System;

namespace DreamPoeBot.Loki.Game.Utilities;

public abstract class PerCachedValue<T>
{
	private readonly Func<T> func_0;

	private T gparam_0;

	private EventHandler<CacheUpdateEvent> eventHandler_0;

	private bool bool_0;

	public T Value
	{
		get
		{
			if (ShouldUpdateCache(bool_0))
			{
				bool_0 = false;
				gparam_0 = func_0();
				if (eventHandler_0 != null)
				{
					Delegate[] array = smethod_1((Delegate)eventHandler_0);
					for (int i = 0; i < array.Length; i++)
					{
						smethod_2(array[i], new object[2]
						{
							null,
							new CacheUpdateEvent()
						});
					}
				}
			}
			return gparam_0;
		}
	}

	protected abstract bool ShouldUpdateCache(bool force = false);

	protected PerCachedValue(Func<T> producer)
	{
		if (producer == null)
		{
			throw smethod_0("producer");
		}
		func_0 = producer;
	}

	public static implicit operator T(PerCachedValue<T> pfcv)
	{
		return pfcv.Value;
	}

	public void RequestCacheFlush()
	{
		bool_0 = true;
	}

	static ArgumentNullException smethod_0(string string_0)
	{
		return new ArgumentNullException(string_0);
	}

	static Delegate[] smethod_1(Delegate delegate_0)
	{
		return delegate_0.GetInvocationList();
	}

	static object smethod_2(Delegate delegate_0, object[] object_0)
	{
		return delegate_0.DynamicInvoke(object_0);
	}
}
