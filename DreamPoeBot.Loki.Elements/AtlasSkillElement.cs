using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class AtlasSkillElement : Element
{
	public Element ApplyButton => base.Children[3].Children[1].Children[0];

	public Element CancelButton => base.Children[3].Children[1].Children[1];

	public Element ResetAllPassiveButton => base.Children[3].Children[2];

	public Element RefoundPassiveButton => base.Children[3].Children[0].Children[2];

	public Element AtlasPassiveMap => base.Children[1];

	public bool IsApplyEnabled => ApplyButton.IsEnable;

	public bool IsApplyVisible => ApplyButton.IsVisible;

	public bool IsCancelEnabled => CancelButton.IsEnable;

	public bool IsCancelVisible => CancelButton.IsVisible;

	public bool IsRefundPassivesEnabled => RefoundPassiveButton.IsEnable;

	public bool IsRefundPassivesVisible => RefoundPassiveButton.IsVisible;

	public bool IsResetAllPassivesEnabled => ResetAllPassiveButton.IsEnable;

	public bool IsResetAllPassivesVisible => ResetAllPassiveButton.IsVisible;

	public Dictionary<int, long> Dictionary_0AtlasPassive => Containers.StdInt_LongHashMap<int, long>(LokiPoe.Memory.FastIntPtrToStruct<NativeHashMap>(AtlasPassiveMap.Address + 4792L));

	public Dictionary<DatPassiveSkillWrapper, Element> PasDict
	{
		get
		{
			Dictionary<DatPassiveSkillWrapper, Element> dictionary = new Dictionary<DatPassiveSkillWrapper, Element>();
			Dat.BuildPassinveLookupTable();
			foreach (KeyValuePair<int, long> item in Dictionary_0AtlasPassive)
			{
				DatPassiveSkillWrapper key = Dat.dictionary_IdToPassiveSkillWrapper[item.Key];
				Element elementAt = GetElementAt(item.Value);
				dictionary.Add(key, elementAt);
			}
			return dictionary;
		}
	}

	public Vector2i ClickLocationFor(long intPtr)
	{
		Element elementAt = GetElementAt(intPtr);
		return LokiPoe.ElementClickLocation(elementAt);
	}

	public Element GetElementAt(long intPtr)
	{
		return base.M.GetObject<Element>(intPtr);
	}

	internal void CenterElement(Element element)
	{
		element.Parent.Parent.Children.Where((Element g) => g.ChildCount == 0L);
		Vector2i vector2i = new Vector2i(LokiPoe.ClientWindowInfo.Window.Right - LokiPoe.ClientWindowInfo.Window.Left, LokiPoe.ClientWindowInfo.Window.Bottom - LokiPoe.ClientWindowInfo.Window.Top);
		_ = element.Scale;
		float data = (element.X / element.Scale + element.Parent.X / element.Parent.Scale - (float)(vector2i.X / 2)) / base.Scale;
		float num = (element.Y / element.Scale + element.Parent.Y / element.Parent.Scale - (float)(vector2i.Y / 2)) / base.Scale;
		base.M.WriteFloat(AtlasPassiveMap.XAddress, data);
		base.M.WriteFloat(AtlasPassiveMap.YAddress, num * 2f);
	}
}
