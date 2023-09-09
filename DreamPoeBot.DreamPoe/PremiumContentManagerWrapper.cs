using System.Windows.Controls;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class PremiumContentManagerWrapper : IConfigurable
{
	private PremiumContentManagerGui globalSettingsGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			PremiumContentManagerGui result;
			if ((result = globalSettingsGui_0) == null)
			{
				result = (globalSettingsGui_0 = new PremiumContentManagerGui(GlobalSettings.Instance));
			}
			return result;
		}
	}

	internal PremiumContentManagerWrapper()
	{
		_ = Control;
	}
}
