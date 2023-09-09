using System.Linq;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatQuestWrapper
{
	public int Index { get; private set; }

	public string Id { get; private set; }

	public int Act { get; private set; }

	public string Name { get; private set; }

	public int _0C { get; private set; }

	public string Icon { get; private set; }

	public int _14 { get; private set; }

	public int _18 { get; private set; }

	public byte _1C { get; private set; }

	public byte _1D { get; private set; }

	public DatQuestWrapper(string id)
	{
		Quest quest = GameController.Instance.Files.Quests.EntriesList.FirstOrDefault((Quest x) => x.Id == id);
		Id = quest.Id;
		Name = quest.Name;
		Icon = quest.Icon;
		Act = quest.Act;
	}

	public DatQuestWrapper(string id, string name, string icon, int act, int index)
	{
		Id = id;
		Name = name;
		Icon = icon;
		Act = act;
		Index = index;
	}
}
