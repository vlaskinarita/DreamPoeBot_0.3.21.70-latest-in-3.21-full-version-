using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Elements;

public class ThePantheonElement : Element
{
	public List<LokiPoe.InGameState.PantheonUI.PantheonNodes> All
	{
		get
		{
			List<LokiPoe.InGameState.PantheonUI.PantheonNodes> list = new List<LokiPoe.InGameState.PantheonUI.PantheonNodes>();
			List<Element> children = base.Children[2].Children[0].Children[1].Children[0].Children[0].Children;
			foreach (Element item in children)
			{
				list.Add(new LokiPoe.InGameState.PantheonUI.PantheonNodes(item));
			}
			return list;
		}
	}

	public List<LokiPoe.InGameState.PantheonUI.PantheonNodes> Majour => All.Where((LokiPoe.InGameState.PantheonUI.PantheonNodes x) => x.God == PantheonGod.Lunaris || x.God == PantheonGod.Arakaali || x.God == PantheonGod.Solaris || x.God == PantheonGod.TheBrineKing).ToList();

	public List<LokiPoe.InGameState.PantheonUI.PantheonNodes> Minor => All.Where((LokiPoe.InGameState.PantheonUI.PantheonNodes x) => x.God == PantheonGod.Yugul || x.God == PantheonGod.Ralakesh || x.God == PantheonGod.Shakari || x.God == PantheonGod.Abberath || x.God == PantheonGod.Tukohama || x.God == PantheonGod.Ryslatha || x.God == PantheonGod.Garukhan || x.God == PantheonGod.Gruthkul).ToList();
}
