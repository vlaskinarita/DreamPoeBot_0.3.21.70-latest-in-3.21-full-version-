using System.Windows.Controls;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class GlobalSettingsWrapper : IConfigurable
{
	private GlobalSettingsGui globalSettingsGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			GlobalSettingsGui result;
			if ((result = globalSettingsGui_0) == null)
			{
				result = (globalSettingsGui_0 = new GlobalSettingsGui(GlobalSettings.Instance));
			}
			return result;
		}
	}

	internal GlobalSettingsWrapper()
	{
		_ = Control;
	}
}
