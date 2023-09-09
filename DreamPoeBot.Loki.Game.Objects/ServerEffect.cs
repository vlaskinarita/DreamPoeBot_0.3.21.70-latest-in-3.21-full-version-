using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class ServerEffect : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/ServerEffect";

	internal ServerEffect(EntityWrapper entry)
		: base(entry)
	{
	}

	internal ServerEffect(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[ServerEffect] 0x{base._entity.Address:X}");
		stringBuilder.AppendLine($"\t{base.AnimatedPropertiesMetadata}");
		return stringBuilder.ToString();
	}
}
