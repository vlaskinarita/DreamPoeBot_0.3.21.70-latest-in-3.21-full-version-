using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Projectile : NetworkObject
{
	internal Projectile(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Projectile(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Projectile] 0x{base._entity.Address:X}");
		stringBuilder.AppendLine($"\t{base.AnimatedPropertiesMetadata}");
		return stringBuilder.ToString();
	}
}
