using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Monolith : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/Monolith";

	private string string_2;

	private int int_1 = -1;

	public int ChildNetworkObjectId
	{
		get
		{
			if (int_1 == -1)
			{
				Monster monster = LokiPoe.ObjectManager.GetObjectsByPosition<Monster>(base.Position).FirstOrDefault();
				if (monster != null)
				{
					int_1 = monster.Id;
				}
			}
			return int_1;
		}
	}

	public NetworkObject ChildNetworkObject => LokiPoe.ObjectManager.GetObjectById(ChildNetworkObjectId);

	public int OpenPhase => base.Components.MonolithComponent.OpenPhase;

	public bool IsCorrupted => base.Components.MonolithComponent.IsCorrupted;

	public virtual bool IsMini => false;

	public string MonsterTypeId => base.Components.MonolithComponent.MonsterTypeId;

	public string MonsterTypeMetadata => base.Components.MonolithComponent.MonsterTypeMetadata;

	public List<DatBaseItemTypeWrapper> EssenceBaseItemTypes => base.Components.MonolithComponent.EssenceBaseItemTypes;

	public override string Name
	{
		get
		{
			if (string_2 == null)
			{
				NetworkObject childNetworkObject = ChildNetworkObject;
				if (!object.Equals(ChildNetworkObject, null))
				{
					string_2 = childNetworkObject.Name;
				}
				else
				{
					string_2 = "Opened";
				}
			}
			return string_2;
		}
	}

	internal Monolith(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Monolith(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Name: {Name}");
		stringBuilder.AppendLine($"IsMini: {IsMini}");
		stringBuilder.AppendLine($"OpenPhase: {OpenPhase}");
		stringBuilder.AppendLine($"ChildNetworkObjectId: {ChildNetworkObjectId}");
		if (ChildNetworkObject != null)
		{
			stringBuilder.AppendLine($"ChildNetworkObject.Name: {ChildNetworkObject.Name}");
			stringBuilder.AppendLine($"ChildNetworkObject.Metadata: {ChildNetworkObject.Metadata}");
		}
		stringBuilder.AppendLine($"MonsterTypeId: {MonsterTypeId}");
		stringBuilder.AppendLine($"MonsterTypeMetadata: {MonsterTypeMetadata}");
		stringBuilder.AppendLine($"EssenceBaseItemTypes:");
		foreach (DatBaseItemTypeWrapper essenceBaseItemType in EssenceBaseItemTypes)
		{
			stringBuilder.AppendLine($"\t{essenceBaseItemType.Name}: {essenceBaseItemType.Metadata}");
		}
		return stringBuilder.ToString();
	}
}
