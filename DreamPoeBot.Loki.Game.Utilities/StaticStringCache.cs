using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.Game.Utilities;

public class StaticStringCache
{
	private readonly Dictionary<long, string> dictionary_0 = new Dictionary<long, string>();

	private static int CallCount;

	public void ClearCache()
	{
		dictionary_0.Clear();
	}

	private void method_0()
	{
		if (CallCount > 1000)
		{
			ClearCache();
			CallCount = 0;
		}
	}

	public string ReadStringA(long address)
	{
		CallCount++;
		method_0();
		if (dictionary_0.TryGetValue(address, out var value))
		{
			return value;
		}
		value = GameController.Instance.Memory.ReadString(address);
		dictionary_0.Add(address, value);
		return value;
	}

	public string ReadStringW(long address)
	{
		CallCount++;
		method_0();
		if (dictionary_0.TryGetValue(address, out var value))
		{
			return value;
		}
		value = GameController.Instance.Memory.ReadStringU(address);
		dictionary_0.Add(address, value);
		return value;
	}
}
