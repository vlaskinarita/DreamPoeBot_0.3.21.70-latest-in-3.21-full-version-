using System;
using System.Collections;
using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.FilesInMemory.Base;

public class UniversalFileWrapper<RecordType> : FileInMemory where RecordType : RemoteMemoryObject, new()
{
	protected Dictionary<long, RecordType> EntriesAddressDictionary { get; set; } = new Dictionary<long, RecordType>();


	protected List<RecordType> CachedEntriesList { get; set; } = new List<RecordType>();


	public List<RecordType> EntriesList
	{
		get
		{
			CheckCache();
			return CachedEntriesList;
		}
	}

	public UniversalFileWrapper(Memory m, long address)
		: base(m, address)
	{
	}

	public RecordType GetByAddress(long address)
	{
		CheckCache();
		EntriesAddressDictionary.TryGetValue(address, out var value);
		return value;
	}

	public void CheckCache()
	{
		if (EntriesAddressDictionary.Count != 0)
		{
			return;
		}
		IEnumerable<long> enumerable = RecordAddresses();
		IEnumerator<long> enumerator = enumerable.GetEnumerator();
		try
		{
			while (smethod_0((IEnumerator)enumerator))
			{
				long current = enumerator.Current;
				if (!EntriesAddressDictionary.ContainsKey(current))
				{
					RecordType @object = GameController.Instance.Game.IngameState.GetObject<RecordType>(current);
					EntriesAddressDictionary.Add(current, @object);
					EntriesList.Add(@object);
					EntryAdded(current, @object);
				}
			}
		}
		finally
		{
			if (enumerator != null)
			{
				smethod_1((IDisposable)enumerator);
			}
		}
	}

	protected virtual void EntryAdded(long addr, RecordType entry)
	{
	}

	static bool smethod_0(IEnumerator ienumerator_0)
	{
		return ienumerator_0.MoveNext();
	}

	static void smethod_1(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}
}
