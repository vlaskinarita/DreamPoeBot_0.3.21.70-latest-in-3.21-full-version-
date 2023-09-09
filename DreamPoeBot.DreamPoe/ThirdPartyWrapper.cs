using System.Windows.Controls;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class ThirdPartyWrapper : IConfigurable
{
	private ThirdPartySettingsGui thirdPartySettingsGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			ThirdPartySettingsGui result;
			if ((result = thirdPartySettingsGui_0) == null)
			{
				result = (thirdPartySettingsGui_0 = new ThirdPartySettingsGui());
			}
			return result;
		}
	}

	internal ThirdPartyWrapper()
	{
		_ = Control;
	}
}
