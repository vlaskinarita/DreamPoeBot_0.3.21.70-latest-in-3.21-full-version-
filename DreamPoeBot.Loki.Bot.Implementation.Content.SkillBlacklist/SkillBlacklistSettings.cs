using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DreamPoeBot.Loki.Common;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Bot.Implementation.Content.SkillBlacklist;

public class SkillBlacklistSettings : JsonSettings
{
	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForType();

	private static SkillBlacklistSettings skillBlacklistSettings_0;

	private ObservableCollection<PlayerSkillWrapper> observableCollection_0 = new ObservableCollection<PlayerSkillWrapper>();

	private ObservableCollection<SkillId> observableCollection_1 = new ObservableCollection<SkillId>();

	private ObservableCollection<SkillName> observableCollection_2 = new ObservableCollection<SkillName>();

	public static SkillBlacklistSettings Instance
	{
		get
		{
			SkillBlacklistSettings result;
			if ((result = skillBlacklistSettings_0) == null)
			{
				result = (skillBlacklistSettings_0 = new SkillBlacklistSettings());
			}
			return result;
		}
	}

	[JsonIgnore]
	public ObservableCollection<PlayerSkillWrapper> PlayerSkillStrings
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			if (!observableCollection_0.Equals(value))
			{
				if (value == null)
				{
					observableCollection_0.Clear();
				}
				else
				{
					observableCollection_0 = value;
				}
				NotifyPropertyChanged(() => PlayerSkillStrings);
			}
		}
	}

	public ObservableCollection<SkillId> BlacklistedSkillIds
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			if (value == null)
			{
				observableCollection_1.Clear();
			}
			else
			{
				observableCollection_1 = value;
			}
			DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_0(new List<SkillId>(observableCollection_1));
			NotifyPropertyChanged(() => BlacklistedSkillIds);
			Save();
		}
	}

	public ObservableCollection<SkillName> BlacklistedSkillNames
	{
		get
		{
			return observableCollection_2;
		}
		set
		{
			if (value == null)
			{
				observableCollection_2.Clear();
			}
			else
			{
				observableCollection_2 = value;
			}
			DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_1(new List<SkillName>(observableCollection_2));
			NotifyPropertyChanged(() => BlacklistedSkillNames);
			Save();
		}
	}

	public SkillBlacklistSettings()
		: base(JsonSettings.GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "SkillBlacklist")))
	{
		if (observableCollection_1 == null)
		{
			observableCollection_1 = new ObservableCollection<SkillId>();
		}
		DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_0(new List<SkillId>(observableCollection_1));
		observableCollection_1.CollectionChanged += observableCollection_1_CollectionChanged;
		if (observableCollection_2 == null)
		{
			observableCollection_2 = new ObservableCollection<SkillName>();
		}
		DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_1(new List<SkillName>(observableCollection_2));
		observableCollection_2.CollectionChanged += observableCollection_2_CollectionChanged;
	}

	private void observableCollection_1_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (observableCollection_1 != null)
		{
			DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_0(new List<SkillId>(observableCollection_1));
			Save();
		}
	}

	private void observableCollection_2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (observableCollection_2 != null)
		{
			DreamPoeBot.Loki.Bot.SkillBlacklist.smethod_1(new List<SkillName>(observableCollection_2));
			Save();
		}
	}
}
