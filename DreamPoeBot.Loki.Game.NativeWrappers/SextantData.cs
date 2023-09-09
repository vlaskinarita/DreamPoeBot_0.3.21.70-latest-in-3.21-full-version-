using System.Collections.Generic;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class SextantData
{
	public int UsesLeft { get; internal set; }

	public DatWorldAreaWrapper WorldArea { get; internal set; }

	public DatModsWrapper Mod { get; internal set; }

	public List<int> Data { get; internal set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"WorldArea: {WorldArea.Id}");
		stringBuilder.AppendLine($"UsesLeft: {UsesLeft}");
		stringBuilder.AppendLine($"Mod: {Mod.InternalName}");
		stringBuilder.AppendLine(string.Format("Data: {0}", string.Join(" | ", Data)));
		return stringBuilder.ToString();
	}
}
