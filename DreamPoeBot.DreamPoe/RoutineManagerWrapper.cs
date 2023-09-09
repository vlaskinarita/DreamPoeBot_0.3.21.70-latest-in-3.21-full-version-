using System.Windows.Controls;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.DreamPoe;

public class RoutineManagerWrapper : IConfigurable
{
	private RoutineManagerGui routineManagerGui_0;

	public JsonSettings Settings => null;

	public UserControl Control
	{
		get
		{
			RoutineManagerGui result;
			if ((result = routineManagerGui_0) == null)
			{
				result = (routineManagerGui_0 = new RoutineManagerGui());
			}
			return result;
		}
	}

	internal RoutineManagerWrapper()
	{
		_ = Control;
	}
}
