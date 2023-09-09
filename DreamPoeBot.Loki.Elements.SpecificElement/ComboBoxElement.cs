using System.Collections.Generic;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements.SpecificElement;

public class ComboBoxElement : Element
{
	public int SelectedIndex => base.M.ReadInt(base.Address + 1080L);

	public List<string> Options
	{
		get
		{
			List<string> list = new List<string>();
			int size = MarshalCache<ComboBoxOption>.Size;
			NativeVector nativeVector = base.M.FastIntPtrToStruct<NativeVector>(base.Address + 1472L, 24);
			for (long num = nativeVector.First; num < nativeVector.Last; num += size)
			{
				string item = Containers.StdStringWCustom(base.M.FastIntPtrToStruct<ComboBoxOption>(num, size).TextAddress);
				list.Add(item);
			}
			return list;
		}
	}
}
