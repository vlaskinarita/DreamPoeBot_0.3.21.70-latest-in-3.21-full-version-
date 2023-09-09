using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class PassiveElement : Element
{
	private Element AcceptButton => base.Children[4].Children[0].Children[0];

	private Element CancelButton => base.Children[4].Children[1].Children[0];

	public Vector2i AcceptButtonLocation => LokiPoe.ElementClickLocation(AcceptButton);

	public Vector2i CancelButtonLocation => LokiPoe.ElementClickLocation(CancelButton);

	private Dictionary<int, long> Dictionary_0 => Containers.StdInt_LongHashMap<int, long>(LokiPoe.Memory.FastIntPtrToStruct<NativeHashMap>(base.Children[2].Address + 1024L));

	public Dictionary<DatPassiveSkillWrapper, Element> PassiveDictionary
	{
		get
		{
			Dictionary<DatPassiveSkillWrapper, Element> dictionary = new Dictionary<DatPassiveSkillWrapper, Element>();
			Dat.BuildPassinveLookupTable();
			foreach (KeyValuePair<int, long> item in Dictionary_0)
			{
				DatPassiveSkillWrapper key = Dat.dictionary_IdToPassiveSkillWrapper[item.Key];
				Element elementAt = GetElementAt(item.Value);
				dictionary.Add(key, elementAt);
			}
			return dictionary;
		}
	}

	public Vector2i ClickLocationForPassive(long intPtr)
	{
		Element elementAt = GetElementAt(intPtr);
		return LokiPoe.ElementClickLocation(elementAt);
	}

	private Element GetElementAt(long intPtr)
	{
		return base.M.GetObject<Element>(intPtr);
	}
}
