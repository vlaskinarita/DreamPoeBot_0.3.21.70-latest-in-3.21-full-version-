using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki;

public class Configuration
{
	private static readonly ConfigurationSavedEventArgs configurationSavedEventArgs_0 = new ConfigurationSavedEventArgs();

	private static EventHandler<ConfigurationSavedEventArgs> eventHandler_0;

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static Configuration configuration_0;

	private readonly List<JsonSettings> list_0 = new List<JsonSettings>();

	public static Configuration Instance
	{
		get
		{
			Configuration result;
			if ((result = configuration_0) == null)
			{
				result = (configuration_0 = new Configuration());
			}
			return result;
		}
	}

	public string Name { get; internal set; }

	public string Path => JsonSettings.GetSettingsFilePath(Name);

	public List<JsonSettings> Settings => list_0;

	public static event EventHandler<ConfigurationSavedEventArgs> OnSaveAll
	{
		add
		{
			EventHandler<ConfigurationSavedEventArgs> eventHandler = eventHandler_0;
			EventHandler<ConfigurationSavedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ConfigurationSavedEventArgs> value2 = (EventHandler<ConfigurationSavedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<ConfigurationSavedEventArgs> eventHandler = eventHandler_0;
			EventHandler<ConfigurationSavedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ConfigurationSavedEventArgs> value2 = (EventHandler<ConfigurationSavedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public void AddSettings(JsonSettings settings)
	{
		if (!list_0.Contains(settings))
		{
			list_0.Add(settings);
		}
	}

	public void RemoveSettings(JsonSettings settings)
	{
		list_0.Remove(settings);
	}

	public void SaveAll()
	{
		try
		{
			GlobalSettings.Instance.Save();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"[SaveAll] An exception occurred when saving GlobalSettings: ", ex);
		}
		foreach (JsonSettings item in list_0.ToList())
		{
			try
			{
				item.Save();
			}
			catch (Exception ex2)
			{
				ilog_0.ErrorFormat("[SaveAll][{0}] An exception occurred when saving: {1}", (object)item.FilePath, (object)ex2);
			}
		}
		configurationSavedEventArgs_0.Configuration = this;
		LokiPoe.InvokeEvent(eventHandler_0, null, configurationSavedEventArgs_0);
	}
}
