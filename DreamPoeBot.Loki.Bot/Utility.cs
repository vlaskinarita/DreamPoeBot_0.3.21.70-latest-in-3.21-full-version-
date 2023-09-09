using System;
using System.Threading.Tasks;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class Utility
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public static Message BroadcastMessage(object sender, string id, params dynamic[] input)
	{
		Message message = new Message(id, sender, input);
		foreach (IContent content in ContentManager.Contents)
		{
			content.Message(message);
		}
		BotManager.Current?.Message(message);
		RoutineManager.Current?.Message(message);
		PlayerMoverManager.Current?.Message(message);
		foreach (IPlugin enabledPlugin in PluginManager.EnabledPlugins)
		{
			enabledPlugin.Message(message);
		}
		return message;
	}

	public static async Task<Logic> BroadcastLogicRequest(object sender, string id, params dynamic[] input)
	{
		Logic logic = new Logic(id, sender, input);
		foreach (IContent content in ContentManager.Contents)
		{
			await content.Logic(logic);
		}
		IBot current2 = BotManager.Current;
		if (current2 != null)
		{
			await current2.Logic(logic);
		}
		IRoutine current3 = RoutineManager.Current;
		if (current3 != null)
		{
			await current3.Logic(logic);
		}
		if (PlayerMoverManager.Current != null)
		{
			await PlayerMoverManager.Current.Logic(logic);
		}
		foreach (IPlugin enabledPlugin in PluginManager.EnabledPlugins)
		{
			await enabledPlugin.Logic(logic);
		}
		return logic;
	}

	internal static bool smethod_0(ILog ilog_1, IPlayerMover iplayerMover_0)
	{
		return smethod_5(ilog_1, iplayerMover_0, bool_0: true);
	}

	internal static bool smethod_1(ILog ilog_1, IContent icontent_0)
	{
		return smethod_5(ilog_1, icontent_0, bool_0: true);
	}

	internal static bool smethod_2(ILog ilog_1, IPlugin iplugin_0)
	{
		return smethod_5(ilog_1, iplugin_0, bool_0: true);
	}

	internal static bool smethod_3(ILog ilog_1, IRoutine iroutine_0)
	{
		return smethod_5(ilog_1, iroutine_0, bool_0: true);
	}

	internal static bool smethod_4(ILog ilog_1, IBot ibot_0)
	{
		return smethod_5(ilog_1, ibot_0, bool_0: true);
	}

	private static bool smethod_5(ILog ilog_1, object object_0, bool bool_0)
	{
		string text = object_0.GetType().ToString();
		bool flag = false;
		try
		{
			if (object_0 is IAuthored authored && authored.Name != null)
			{
				text = authored.Name;
				smethod_6(object_0);
				flag = true;
			}
		}
		catch (Exception ex)
		{
			ilog_1.ErrorFormat("[Setup] Exception thrown when loading the settings for [{0}].", (object)text);
			ilog_1.Error((object)ex.ToString());
			return false;
		}
		if (!flag)
		{
			return false;
		}
		try
		{
			ilog_0.InfoFormat("[Initialize] {0}", (object)object_0.GetType());
			(object_0 as IBase).Initialize();
			return true;
		}
		catch (Exception ex3)
		{
			try
			{
				smethod_7(object_0);
			}
			catch (Exception ex2)
			{
				ilog_1.ErrorFormat("[Setup] Exception thrown when unloading the settings for [{0}].", (object)text);
				ilog_1.Error((object)ex2.ToString());
			}
			ilog_1.ErrorFormat("[Setup] Exception thrown when initializing [{0}].", (object)text);
			ilog_1.Error((object)ex3.ToString());
			return false;
		}
	}

	internal static void smethod_6(object object_0)
	{
		if (object_0 is IConfigurable configurable)
		{
			JsonSettings settings = configurable.Settings;
			if (settings != null)
			{
				Configuration.Instance.AddSettings(settings);
			}
		}
	}

	internal static void smethod_7(object object_0)
	{
		if (object_0 is IConfigurable configurable)
		{
			JsonSettings settings = configurable.Settings;
			if (settings != null)
			{
				Configuration.Instance.RemoveSettings(settings);
			}
		}
	}
}
