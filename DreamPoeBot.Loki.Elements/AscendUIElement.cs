using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class AscendUIElement : Element
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct AscendMetadata
	{
		public readonly NativeStringWCustom metadata;
	}

	private List<Element> AscendElements
	{
		get
		{
			List<Element> list = new List<Element>();
			if (base.ChildCount == 4L)
			{
				list.Add(base.Children[1]);
				list.Add(base.Children[2]);
				list.Add(base.Children[3]);
			}
			if (base.ChildCount == 2L)
			{
				list.Add(base.Children[1]);
			}
			return list;
		}
	}

	public Element Occultist => SelectAcendPannel("Occultist");

	public Element Elementalist => SelectAcendPannel("Elementalist");

	public Element Necromancer => SelectAcendPannel("Necromancer");

	public Element Juggernaut => SelectAcendPannel("Juggernaut");

	public Element Berserker => SelectAcendPannel("Berserker");

	public Element Chieftain => SelectAcendPannel("Chieftain");

	public Element Slayer => SelectAcendPannel("Slayer");

	public Element Gladiator => SelectAcendPannel("Gladiator");

	public Element Champion => SelectAcendPannel("Champion");

	public Element Assassin => SelectAcendPannel("Assassin");

	public Element Saboteur => SelectAcendPannel("Saboteur");

	public Element Trickster => SelectAcendPannel("Trickster");

	public Element Deadeye => SelectAcendPannel("Deadeye");

	public Element Raider => SelectAcendPannel("Raider");

	public Element Pathfinder => SelectAcendPannel("Pathfinder");

	public Element Inquisitor => SelectAcendPannel("Inquisitor");

	public Element Hierophant => SelectAcendPannel("Hierophant");

	public Element Guardian => SelectAcendPannel("Guardian");

	public Element Ascendant => SelectAcendPannel("Ascendant");

	private Element SelectAcendPannel(string _class)
	{
		foreach (Element ascendElement in AscendElements)
		{
			string text = base.M.ReadStringU(base.M.ReadLong(ascendElement.Children[0].Address + 416L, default(long)));
			if (text.Contains(_class))
			{
				return ascendElement;
			}
		}
		return null;
	}

	public Element Next(Element elem)
	{
		return elem.Children[1].Children[0].Children[0].Children[0];
	}

	public Element Ascend(Element elem)
	{
		return elem.Children[2].Children[0].Children[1].Children[0];
	}

	public int AscendStage(Element elem)
	{
		return base.M.ReadByte(elem.Address + 1032L);
	}
}
