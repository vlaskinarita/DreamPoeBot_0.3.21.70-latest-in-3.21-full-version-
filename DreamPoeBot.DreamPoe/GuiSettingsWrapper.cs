using System.Windows.Controls;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class GuiSettingsWrapper : IConfigurable
{
	private GuiSettingsGui guiSettingsGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			GuiSettingsGui result;
			if ((result = guiSettingsGui_0) == null)
			{
				result = (guiSettingsGui_0 = new GuiSettingsGui(GuiSettings.Instance));
			}
			return result;
		}
	}

	internal GuiSettingsWrapper()
	{
		_ = Control;
	}
}
