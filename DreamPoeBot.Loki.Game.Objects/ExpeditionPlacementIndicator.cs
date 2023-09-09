namespace DreamPoeBot.Loki.Game.Objects;

public class ExpeditionPlacementIndicator : NetworkObject
{
	public override string Name => "ExpeditionPlacementIndicator";

	public bool IsMarkerEnabled => base.AnimatedPropertiesMetadata == "Metadata/Effects/Spells/monsters_effects/League_Expedition/dynamic_marker/marker.ao";

	internal ExpeditionPlacementIndicator(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
