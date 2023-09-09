namespace DreamPoeBot.Loki.Elements;

public class HeisLockerElement : Element
{
	private Element CategoryElement => base.Children[4];

	public Element ContrantsCategoryElement => base.Children[4].Children[0];

	public Element BlueprintsCategoryElement => base.Children[4].Children[1];

	private Element AffinityElement => base.Children[5];

	private Element SearchElement => base.Children[6];

	private Element BunkerContractElement => base.Children[7];

	private Element DenContractElement => base.Children[8];

	private Element LaboratoryContractElement => base.Children[9];

	private Element RepositoryContractElement => base.Children[10];

	private Element ProhibitedLibraryContractElement => base.Children[11];

	private Element TunnelsContractElement => base.Children[12];

	private Element UnberbellyContractElement => base.Children[13];

	private Element RecordsOfficeContractElement => base.Children[14];

	private Element MansionContractElement => base.Children[15];

	private Element BunkerBlueprintsElement => base.Children[16];

	private Element DenBlueprintsElement => base.Children[17];

	private Element LaboratoryBlueprintsElement => base.Children[18];

	private Element RepositoryBlueprintsElement => base.Children[19];

	private Element ProhibitedLibraryBlueprintsElement => base.Children[20];

	private Element TunnelsBlueprintsElement => base.Children[21];

	private Element UnberbellyBlueprintsElement => base.Children[22];

	private Element RecordsOfficeBlueprintsElement => base.Children[23];

	private Element MansionBlueprintsElement => base.Children[24];
}
