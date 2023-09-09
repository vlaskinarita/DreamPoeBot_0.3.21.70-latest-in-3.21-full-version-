using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class ContentManager
{
	private sealed class Class438
	{
		public string string_0;

		internal bool method_0(IContent icontent_0)
		{
			return icontent_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_1(IContent icontent_0)
		{
			return icontent_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class439
	{
		public IContent icontent_0;

		internal bool method_0(IContent icontent_1)
		{
			return icontent_1.Name.Equals(icontent_0.Name, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class440
	{
		public static readonly Class440 Method9 = new Class440();

		internal string method_0(IContent icontent_0)
		{
			return icontent_0.Name;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly List<IContent> list_0 = new List<IContent>();

	public static IReadOnlyList<IContent> Contents => list_0;

	internal static void AddContent(IReadOnlyList<ThirdPartyInstance> ireadOnlyList_0, List<string> list_1)
	{
		List<IContent> list = new List<IContent>();
		list.AddRange(new TypeLoader<IContent>());
		List<IContent> list2 = new List<IContent>();
		using (List<string>.Enumerator enumerator = list_1.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class438 @class = new Class438();
				@class.string_0 = enumerator.Current;
				if (!list2.Any(@class.method_0))
				{
					IContent content = list.FirstOrDefault(@class.method_1);
					if (content != null)
					{
						list2.Add(content);
					}
				}
			}
		}
		list = list.OrderBy(Class440.Method9.method_0).ToList();
		using (List<IContent>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				Class439 class2 = new Class439();
				class2.icontent_0 = enumerator2.Current;
				if (!list2.Any(class2.method_0))
				{
					list2.Add(class2.icontent_0);
				}
			}
		}
		foreach (IContent item in list2)
		{
			if (Utility.smethod_1(ilog_0, item))
			{
				list_0.Add(item);
			}
		}
	}

	internal static void Deinitialize()
	{
		foreach (IContent content in Contents)
		{
			ilog_0.InfoFormat("[ContentManager.Deinitialize] {0}", (object)content.GetType());
			try
			{
				content.Deinitialize();
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat("[ContentManager] An exception occurred in {0}'s Deinitialize function. {1}", (object)content.Name, (object)ex);
			}
		}
		list_0.Clear();
	}
}
