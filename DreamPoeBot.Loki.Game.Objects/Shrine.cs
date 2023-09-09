using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Shrine : NetworkObject
{
	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	private PerFrameCachedValue<string> perFrameCachedValue_6;

	private PerFrameCachedValue<string> perFrameCachedValue_7;

	private PerFrameCachedValue<string> perFrameCachedValue_8;

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

	public string ShrineId
	{
		get
		{
			if (perFrameCachedValue_6 == null)
			{
				perFrameCachedValue_6 = new PerFrameCachedValue<string>(method_9);
			}
			return perFrameCachedValue_6;
		}
	}

	public string ShrineName
	{
		get
		{
			if (perFrameCachedValue_7 == null)
			{
				perFrameCachedValue_7 = new PerFrameCachedValue<string>(method_10);
			}
			return perFrameCachedValue_7;
		}
	}

	public string ShrineDescription
	{
		get
		{
			if (perFrameCachedValue_8 == null)
			{
				perFrameCachedValue_8 = new PerFrameCachedValue<string>(method_11);
			}
			return perFrameCachedValue_8;
		}
	}

	internal Shrine(EntityWrapper entity)
		: base(entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Shrine]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base._entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tDistance: {base.Distance}");
		stringBuilder.AppendLine($"\tShrineId: {ShrineId}");
		stringBuilder.AppendLine($"\tShrineName: {ShrineName}");
		stringBuilder.AppendLine($"\tShrineDescription: {ShrineDescription}");
		stringBuilder.AppendLine($"\tIsDeactivated: {IsDeactivated}");
		return stringBuilder.ToString();
	}

	private bool method_8()
	{
		return base.Components.ShrineComponent.IsDeactivated;
	}

	private string method_9()
	{
		return base.Components.ShrineComponent.ShrineId;
	}

	private string method_10()
	{
		return base.Components.ShrineComponent.ShrineName;
	}

	private string method_11()
	{
		return base.Components.ShrineComponent.ShrineDescription;
	}
}
