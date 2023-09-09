using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.FilesInMemory;

public class BaseItemTypes : FileInMemory
{
	public readonly Dictionary<string, BaseItemType> contents = new Dictionary<string, BaseItemType>();

	public BaseItemTypes(Memory m, long address)
		: base(m, address)
	{
		LoadItemTypes();
	}

	public BaseItemType Translate(string metadata)
	{
		if (string.IsNullOrEmpty(metadata))
		{
			return null;
		}
		if (contents.Count == 0)
		{
			LoadItemTypes();
		}
		if (!contents.TryGetValue(metadata, out var value))
		{
			Console.WriteLine("Key not found in BaseItemTypes: " + metadata);
			return null;
		}
		return value;
	}

	private void LoadItemTypes()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			string text = base.M.ReadStringU(base.M.ReadLong(item));
			BaseItemType baseItemType = new BaseItemType();
			baseItemType.Address = item;
			baseItemType.ClassName = base.M.ReadStringU(base.M.ReadLong(item + 8L, default(long)));
			baseItemType.Width = base.M.ReadInt(item + 24L);
			baseItemType.Height = base.M.ReadInt(item + 28L);
			baseItemType.BaseName = base.M.ReadStringU(base.M.ReadLong(item + 32L));
			baseItemType.Metadata = base.M.ReadStringU(base.M.ReadLong(item + 40L));
			baseItemType.DropLevel = base.M.ReadInt(item + 48L);
			baseItemType.Tags = new string[base.M.ReadLong(item + 104L)];
			BaseItemType baseItemType2 = baseItemType;
			long num = base.M.ReadLong(item + 112L);
			for (int i = 0; i < baseItemType2.Tags.Length; i++)
			{
				long addr = num + 16 * i;
				baseItemType2.Tags[i] = base.M.ReadStringU(base.M.ReadLong(addr, default(long)), 255);
			}
			string[] array = text.Split('/');
			if (array.Length > 3)
			{
				baseItemType2.MoreTagsFromPath = new string[array.Length - 3];
				for (int j = 2; j < array.Length - 1; j++)
				{
					string text2 = Regex.Replace(array[j], "(?<!_)([A-Z])", "_$1").ToLower().Remove(0, 1);
					if (text2[text2.Length - 1] == 's')
					{
						text2 = text2.Remove(text2.Length - 1);
					}
					baseItemType2.MoreTagsFromPath[j - 2] = text2;
				}
			}
			else
			{
				baseItemType2.MoreTagsFromPath = new string[1];
				baseItemType2.MoreTagsFromPath[0] = "";
			}
			if (!contents.ContainsKey(text))
			{
				contents.Add(text, baseItemType2);
			}
		}
	}
}
