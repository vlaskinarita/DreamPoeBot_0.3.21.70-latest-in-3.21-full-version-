using System.Text;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Game.Objects;

public class DarkShrine : NetworkObject
{
	public const string TypeMetadata = "Metadata/Shrines/DarkShrine";

	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	public bool IsDeactivated
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<bool>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	internal DarkShrine(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[DarkShrine]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base._entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tDistance: {base.Distance}");
		stringBuilder.AppendLine($"\tIsDeactivated: {IsDeactivated}");
		return stringBuilder.ToString();
	}

	private bool method_8()
	{
		return base.Components.TransitionableComponent.Flag1 != 1;
	}
}
