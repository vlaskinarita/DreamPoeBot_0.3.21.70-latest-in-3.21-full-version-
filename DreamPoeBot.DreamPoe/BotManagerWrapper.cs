using System.Windows.Controls;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class BotManagerWrapper : IConfigurable
{
	private BotManagerGui botManagerGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			BotManagerGui result;
			if ((result = botManagerGui_0) == null)
			{
				result = (botManagerGui_0 = new BotManagerGui());
			}
			return result;
		}
	}

	internal BotManagerWrapper()
	{
		_ = Control;
	}
}
