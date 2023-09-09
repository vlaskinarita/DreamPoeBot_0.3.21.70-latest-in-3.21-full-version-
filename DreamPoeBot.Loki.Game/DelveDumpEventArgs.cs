using System;
using DreamPoeBot.Loki.Elements;

namespace DreamPoeBot.Loki.Game;

public class DelveDumpEventArgs : EventArgs
{
	private SubterainChartElement.DelveNode datPassiveSkillWrapper_0;

	public SubterainChartElement.DelveNode DelveCell { get; private set; }

	internal DelveDumpEventArgs(SubterainChartElement.DelveNode delveCell)
	{
		DelveCell = delveCell;
	}
}
