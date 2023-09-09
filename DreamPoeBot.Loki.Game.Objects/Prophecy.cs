using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game.Objects;

public class Prophecy
{
	public DatPropheciesWrapper DatPropheciesWrapper { get; }

	public int Index { get; }

	public int SealCost { get; }

	internal Prophecy(DreamPoeBot.Loki.Components.Player.Struct190 data)
	{
		Index = data.byte_0;
		DatPropheciesWrapper = Dat.LookupProphecy(data.ushort_0);
		SealCost = ((DatPropheciesWrapper != null) ? DatPropheciesWrapper.SealCost : 0);
	}
}
