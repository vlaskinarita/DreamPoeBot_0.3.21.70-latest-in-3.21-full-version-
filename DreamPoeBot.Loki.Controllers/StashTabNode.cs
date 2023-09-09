using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Controllers;

public class StashTabNode
{
	public const string EMPTYNAME = "-NoName-";

	public string Name { get; set; } = "-NoName-";


	public int VisibleIndex { get; set; } = -1;


	[JsonIgnore]
	public bool Exist { get; set; }

	[JsonIgnore]
	internal int Id { get; set; } = -1;


	[JsonIgnore]
	public bool IsRemoveOnly { get; set; }

	public StashTabNode()
	{
	}

	public StashTabNode(string name, int visibleIndex)
	{
		Name = name;
		VisibleIndex = visibleIndex;
	}

	public StashTabNode(ServerStashTab serverTab, int id)
	{
		Name = serverTab.DisplayName;
		VisibleIndex = serverTab.DisplayIndex;
		IsRemoveOnly = (serverTab.inventoryTabFlags & InventoryTabFlags.RemoveOnly) == InventoryTabFlags.RemoveOnly;
		Id = id;
	}
}
