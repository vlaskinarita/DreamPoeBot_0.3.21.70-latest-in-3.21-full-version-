using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class SoclialPannelElement : Element
{
	internal class Class258
	{
		public long IntPtr_0 { get; }

		public long IntPtr_1 { get; }

		public string Name { get; }

		internal Class258(Struct110 entry)
		{
			IntPtr_0 = entry.intptr_0;
			IntPtr_1 = entry.intptr_1;
			Name = Containers.StdStringWCustom(entry.nativeStringW_0);
		}

		public new virtual bool Equals(object obj)
		{
			if (obj is Class258 @class && IntPtr_1 == @class.IntPtr_1 && IntPtr_0 == @class.IntPtr_0)
			{
				return Name.Equals(@class.Name);
			}
			return false;
		}

		public bool method_0(Class258 class258_0)
		{
			if (class258_0 != null && IntPtr_1 == class258_0.IntPtr_1 && IntPtr_0 == class258_0.IntPtr_0)
			{
				return Name.Equals(class258_0.Name);
			}
			return false;
		}

		public new virtual int GetHashCode()
		{
			return IntPtr_0.GetHashCode() ^ IntPtr_1.GetHashCode() ^ Name.GetHashCode();
		}
	}

	[Serializable]
	private sealed class Class259
	{
		public static readonly Class259 Class9 = new Class259();

		internal Class258 method_0(Struct110 struct110_0)
		{
			return new Class258(struct110_0);
		}

		internal string method_1(Class258 class258_0)
		{
			return class258_0.Name;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct110
	{
		public readonly long intptr_0;

		public readonly long intptr_1;

		public readonly NativeStringWCustom nativeStringW_0;
	}

	private const long tabContainerOffset = 568L;

	public bool IsOpened => base.IsVisible;

	public List<Element> Tabs => base.Children[2].Children[0].Children[5].Children[0].Children.Where((Element x) => x.Children.Count == 1).ToList();

	public long TotalStashes => StashInventoryPanel.ChildCount;

	public Element StashInventoryPanel
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			return GetObject<Element>(base.M.ReadLong(base.Address + 568L, 2432L));
		}
	}

	public Element ViewAllStashPanel
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			return GetObject<Element>(base.M.ReadLong(base.Address + 568L, 2448L, 976L));
		}
	}

	public int IndexVisibleStash => base.M.ReadInt(base.Address + 568L, 2536L);

	public List<string> AllStashNames => GetAllStashNames();

	public string VisibleStashName => AllStashNames[IndexVisibleStash];

	internal Class258 GetVisibleStash => method_1(IndexVisibleStash);

	internal List<Struct110> List_0
	{
		get
		{
			long num = base.M.ReadLong(base.Address + 568L);
			NativeVector nativeVector = base.M.ReadNativeVector(num + 2512L);
			return Containers.StdStruct110Vector<Struct110>(nativeVector);
		}
	}

	private List<Class258> List_1 => List_0.Select(Class259.Class9.method_0).ToList();

	private List<string> GetAllStashNames()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < TotalStashes; i++)
		{
			list.Add(GetStashName(i));
		}
		return list;
	}

	public string GetStashName(int index)
	{
		if (index < TotalStashes && index >= 0)
		{
			if (ViewAllStashPanel.Children[index].ChildCount != 1L)
			{
				return ViewAllStashPanel.Children[index].Children[1].AsObject<EntityLabel>().Text;
			}
			return ViewAllStashPanel.Children[index].Children[0].AsObject<EntityLabel>().Text;
		}
		return string.Empty;
	}

	private Element GetElementByIndex(int index)
	{
		if (index > List_1.Count - 1)
		{
			return null;
		}
		return base.M.GetObject<Element>(List_1[index].IntPtr_0);
	}

	public Vector2i GetElementClickLocationByIndex(int index)
	{
		if (index > List_1.Count - 1)
		{
			return Vector2i.Zero;
		}
		Element elementByIndex = GetElementByIndex(index);
		return LokiPoe.ElementClickLocation(elementByIndex);
	}

	private Class258 method_1(int int_0)
	{
		List<Class258> list_ = List_1;
		if (int_0 >= 0 && int_0 < list_.Count)
		{
			return list_[int_0];
		}
		return null;
	}
}
