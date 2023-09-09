using System.Text;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Game.Objects;

public class Arrow : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/Masters/Dex/Arrow";

	public override string Name => "Arrow";

	public Vector2i Destination => new Vector2i(0, 0);

	public bool Visible => false;

	internal Arrow(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Arrow]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base._entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tDistance: {base.Distance}");
		stringBuilder.AppendLine($"\tVisible: {Visible}");
		stringBuilder.AppendLine($"\tDestination: {Destination}");
		return stringBuilder.ToString();
	}
}
