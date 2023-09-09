using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class Blacklist
{
	private class Class436
	{
		public int int_0;

		public DateTime dateTime_0;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly Dictionary<uint, Dictionary<int, Class436>> dictionary_0 = new Dictionary<uint, Dictionary<int, Class436>>();

	private static Dictionary<int, Class436> Dictionary_0
	{
		get
		{
			uint areaHash = LokiPoe.LocalData.AreaHash;
			if (!dictionary_0.TryGetValue(areaHash, out var value))
			{
				value = new Dictionary<int, Class436>();
				dictionary_0.Add(areaHash, value);
			}
			return value;
		}
	}

	public static IEnumerable<int> Ids => Dictionary_0.Keys.ToList();

	public static IEnumerable<NetworkObject> Objects
	{
		get
		{
			List<NetworkObject> list = new IndexedList<NetworkObject>();
			Dictionary<int, Class436> dictionary = Dictionary_0;
			foreach (KeyValuePair<int, Class436> item in dictionary)
			{
				NetworkObject objectById = LokiPoe.ObjectManager.GetObjectById(item.Key);
				if (objectById != null)
				{
					list.Add(objectById);
				}
			}
			return list;
		}
	}

	public static void Reset()
	{
		dictionary_0.Clear();
		ilog_0.DebugFormat("[Blacklist::Reset] Resetting all blacklists.", Array.Empty<object>());
	}

	public static void Add(int id, TimeSpan duration, string reason = "")
	{
		Dictionary<int, Class436> dictionary = Dictionary_0;
		if (!dictionary.TryGetValue(id, out var value))
		{
			value = new Class436
			{
				int_0 = id
			};
			dictionary.Add(id, value);
		}
		if (duration == TimeSpan.MaxValue)
		{
			value.dateTime_0 = DateTime.MaxValue;
		}
		else
		{
			value.dateTime_0 = DateTime.Now + duration;
		}
		ilog_0.DebugFormat("[Blacklist::Add] Blacklisting object with id {0} for {1} (Expires at: {2}). Reason: {3}", new object[4] { value.int_0, duration, value.dateTime_0, reason });
	}

	public static bool Remove(int id)
	{
		Dictionary<int, Class436> dictionary = Dictionary_0;
		ilog_0.DebugFormat("[Blacklist::Remove] Removing object with id {0}.", (object)id);
		return dictionary.Remove(id);
	}

	public static bool Contains(int id)
	{
		Dictionary<int, Class436> dictionary = Dictionary_0;
		if (dictionary.TryGetValue(id, out var value))
		{
			if (value.dateTime_0 > DateTime.Now)
			{
				return true;
			}
			dictionary.Remove(id);
		}
		return false;
	}

	public static bool Contains(NetworkObject entity)
	{
		if (!object.Equals(entity, null))
		{
			return Contains(entity.Id);
		}
		return false;
	}

	public static void Clear()
	{
		Dictionary_0.Clear();
		ilog_0.DebugFormat("[Blacklist::Clear] Clearing current blacklist.", Array.Empty<object>());
	}
}
