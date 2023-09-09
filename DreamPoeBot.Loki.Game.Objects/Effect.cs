using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Effect : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Effect";

	internal Effect(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Effect(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Effect] 0x{base._entity:X}");
		stringBuilder.AppendLine($"\t{base.AnimatedPropertiesMetadata}");
		return stringBuilder.ToString();
	}
}
