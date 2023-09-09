using System.Windows.Controls;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class CurrentConfigurationSettingsWrapper : IConfigurable
{
	private CurrentConfigurationGui currentConfigurationGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			CurrentConfigurationGui result;
			if ((result = currentConfigurationGui_0) == null)
			{
				result = (currentConfigurationGui_0 = new CurrentConfigurationGui(Configuration.Instance));
			}
			return result;
		}
	}

	internal CurrentConfigurationSettingsWrapper()
	{
		_ = Control;
	}
}
