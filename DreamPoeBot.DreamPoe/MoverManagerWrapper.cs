using System.Windows.Controls;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class MoverManagerWrapper : IConfigurable
{
	private MoverManagerGui moverManagerGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			MoverManagerGui result;
			if ((result = moverManagerGui_0) == null)
			{
				result = (moverManagerGui_0 = new MoverManagerGui());
			}
			return result;
		}
	}

	internal MoverManagerWrapper()
	{
		_ = Control;
	}
}
