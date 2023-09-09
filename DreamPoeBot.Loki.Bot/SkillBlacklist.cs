using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using DreamPoeBot.Loki.Bot.Implementation.Content.SkillBlacklist;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Bot;

public class SkillBlacklist : IAuthored, IBase, IConfigurable, IContent, ILogicProvider, IMessageHandler, IUrlProvider
{
	[Serializable]
	private sealed class Class446
	{
		public static readonly Class446 Class9 = new Class446();

		internal bool method_0(IContent icontent_0)
		{
			return icontent_0.Name.Equals("SkillBlacklist");
		}

		internal ushort method_1(SkillId skillId_0)
		{
			return skillId_0.Id;
		}

		internal string method_2(SkillName skillName_0)
		{
			return skillName_0.Name;
		}
	}

	private sealed class Class447
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string_1.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class448
	{
		public int int_0;

		public Func<SkillId, bool> func_0;

		internal void method_0()
		{
			ObservableCollection<SkillId> blacklistedSkillIds = SkillBlacklistSettings.Instance.BlacklistedSkillIds;
			IEnumerable<SkillId> source = blacklistedSkillIds;
			Func<SkillId, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = method_1);
			}
			if (source.FirstOrDefault(predicate) == null)
			{
				blacklistedSkillIds.Add(new SkillId
				{
					Id = (ushort)int_0
				});
			}
		}

		internal bool method_1(SkillId skillId_0)
		{
			return skillId_0.Id == int_0;
		}
	}

	private sealed class Class449
	{
		public string string_0;

		public Func<SkillName, bool> func_0;

		internal void method_0()
		{
			ObservableCollection<SkillName> blacklistedSkillNames = SkillBlacklistSettings.Instance.BlacklistedSkillNames;
			IEnumerable<SkillName> source = blacklistedSkillNames;
			Func<SkillName, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = method_1);
			}
			if (source.FirstOrDefault(predicate) == null)
			{
				blacklistedSkillNames.Add(new SkillName
				{
					Name = string_0
				});
			}
		}

		internal bool method_1(SkillName skillName_0)
		{
			return skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class450
	{
		public int int_0;

		public Func<SkillId, bool> func_0;

		internal void method_0()
		{
			ObservableCollection<SkillId> blacklistedSkillIds = SkillBlacklistSettings.Instance.BlacklistedSkillIds;
			IEnumerable<SkillId> source = blacklistedSkillIds;
			Func<SkillId, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = method_1);
			}
			SkillId skillId = source.FirstOrDefault(predicate);
			if (skillId != null)
			{
				blacklistedSkillIds.Remove(skillId);
			}
		}

		internal bool method_1(SkillId skillId_0)
		{
			return skillId_0.Id == int_0;
		}
	}

	private sealed class Class451
	{
		public string string_0;

		public Func<SkillName, bool> func_0;

		internal void method_0()
		{
			ObservableCollection<SkillName> blacklistedSkillNames = SkillBlacklistSettings.Instance.BlacklistedSkillNames;
			IEnumerable<SkillName> source = blacklistedSkillNames;
			Func<SkillName, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = method_1);
			}
			SkillName skillName = source.FirstOrDefault(predicate);
			if (skillName != null)
			{
				blacklistedSkillNames.Remove(skillName);
			}
		}

		internal bool method_1(SkillName skillName_0)
		{
			return skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static SkillBlacklist skillBlacklist_0;

	private Gui gui_0;

	private static object object_0 = new object();

	private static List<ushort> list_0 = new List<ushort>();

	private static List<string> list_1 = new List<string>();

	public static SkillBlacklist Instance
	{
		get
		{
			if (skillBlacklist_0 == null)
			{
				skillBlacklist_0 = ContentManager.Contents.FirstOrDefault(Class446.Class9.method_0) as SkillBlacklist;
			}
			return skillBlacklist_0;
		}
	}

	public string Name => "SkillBlacklist";

	public string Author => "pushedx";

	public string Description => "A manager for blacklisting skills.";

	public string Version => "0.0.1.1";

	public JsonSettings Settings => SkillBlacklistSettings.Instance;

	public UserControl Control
	{
		get
		{
			Gui result;
			if ((result = gui_0) == null)
			{
				result = (gui_0 = new Gui(this));
			}
			return result;
		}
	}

	public string Url => "";

	public void Initialize()
	{
	}

	public void Deinitialize()
	{
	}

	public MessageResult Message(Message message)
	{
		return MessageResult.Unprocessed;
	}

	public async Task<LogicResult> Logic(Logic logic)
	{
		return LogicResult.Unprovided;
	}

	public override string ToString()
	{
		return Name + ": " + Description;
	}

	internal static void smethod_0(List<SkillId> list_2)
	{
		object obj = object_0;
		lock (obj)
		{
			list_0.Clear();
			list_0.AddRange(list_2.Select(Class446.Class9.method_1));
		}
	}

	internal static void smethod_1(List<SkillName> list_2)
	{
		object obj = object_0;
		lock (obj)
		{
			list_1.Clear();
			list_1.AddRange(list_2.Select(Class446.Class9.method_2));
		}
	}

	private static bool smethod_2(string string_0)
	{
		Class447 @class = new Class447();
		@class.string_0 = string_0;
		return list_1.Any(@class.method_0);
	}

	private static bool smethod_3(int int_0)
	{
		return list_0.Contains((ushort)int_0);
	}

	public static bool IsBlacklisted(string name)
	{
		object obj = object_0;
		lock (obj)
		{
			return smethod_2(name);
		}
	}

	public static bool IsBlacklisted(int id)
	{
		object obj = object_0;
		lock (obj)
		{
			return smethod_3(id);
		}
	}

	public static bool IsBlacklisted(Skill skill)
	{
		if (!(skill == null))
		{
			if (!IsBlacklisted(skill.Id))
			{
				return IsBlacklisted(skill.Name);
			}
			return true;
		}
		return false;
	}

	public static bool Add(int id)
	{
		Class448 @class = new Class448();
		@class.int_0 = id;
		object obj = object_0;
		lock (obj)
		{
			if (smethod_3(@class.int_0))
			{
				return false;
			}
		}
		LokiPoe.BeginDispatchIfNecessary(@class.method_0);
		return true;
	}

	public static bool Add(string name)
	{
		Class449 @class = new Class449();
		@class.string_0 = name;
		object obj = object_0;
		lock (obj)
		{
			if (smethod_2(@class.string_0))
			{
				return false;
			}
		}
		LokiPoe.BeginDispatchIfNecessary(@class.method_0);
		return true;
	}

	public static bool Remove(int id)
	{
		Class450 @class = new Class450();
		@class.int_0 = id;
		object obj = object_0;
		lock (obj)
		{
			if (!smethod_3(@class.int_0))
			{
				return false;
			}
		}
		LokiPoe.BeginDispatchIfNecessary(@class.method_0);
		return true;
	}

	public static bool Remove(string name)
	{
		Class451 @class = new Class451();
		@class.string_0 = name;
		object obj = object_0;
		lock (obj)
		{
			if (!smethod_2(@class.string_0))
			{
				return false;
			}
		}
		LokiPoe.BeginDispatchIfNecessary(@class.method_0);
		return true;
	}
}
