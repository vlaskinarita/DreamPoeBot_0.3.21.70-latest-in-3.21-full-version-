using System;
using System.Collections.Generic;

namespace DreamPoeBot.Framework.Helpers;

public static class LinqHelper
{
	public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
	{
		foreach (T item in enumerable)
		{
			action(item);
		}
	}

	public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Action<TKey, TValue> action)
	{
		foreach (KeyValuePair<TKey, TValue> item in dictionary)
		{
			action(item.Key, item.Value);
		}
	}
}
