using System;
using System.Collections.Generic;

namespace DreamPoeBot.Loki.Common;

public static class ListExtensions
{
	public static void Shuffle<T>(this IList<T> list)
	{
		Random random = new Random();
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = random.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}
}
