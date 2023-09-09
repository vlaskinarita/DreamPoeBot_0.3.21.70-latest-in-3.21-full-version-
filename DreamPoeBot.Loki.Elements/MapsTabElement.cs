using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class MapsTabElement : Element
{
	public class TierElementClass : Element
	{
		public bool IsSelected => base.M.ReadInt(base.Address + 632L) == 2;

		public int NrOfMaps => Convert.ToInt32(base.Children[1].Children[0].Text);
	}

	public class MapElementClass : Element
	{
		private StructureMapButton structure => base.M.FastIntPtrToStruct<StructureMapButton>(base.M.ReadLong(base.Address + 752L));

		public bool IsSelected => base.M.ReadInt(base.Address + 624L) == 2;

		public string Name
		{
			get
			{
				string text = Containers.StdStringWCustom(structure.name);
				if (string.IsNullOrEmpty(text))
				{
					text = base.M.ReadStringU(base.M.ReadLong(structure.MapStashSpecialTypeEntry + 28L));
				}
				return text;
			}
		}

		public string Region => "";

		public int NrOfMaps => Convert.ToInt32(base.Children[1].Text);

		public bool IsWitnessedByTheMaven
		{
			get
			{
				if (base.Tooltip != null && base.Tooltip.Text != null)
				{
					return base.Tooltip.Text.Contains("Witnessed By The Maven");
				}
				return false;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructureMapButton
	{
		private int filler1;

		private int filler2;

		private int filler3;

		private int filler4;

		public NativeStringWCustom name;

		public NativeStringWCustom tier;

		private int filler5;

		private int filler6;

		private int filler7;

		private int filler8;

		public long MapStashSpecialTypeEntry;

		public long MapStashSpecialTypeEntryFile;
	}

	public Element ScrollUp => base.Children[4].Children[0];

	public Element ScrollDown => base.Children[4].Children[1];

	public float MapListYOffset => base.M.ReadFloat(base.Children[2].Children[0].Address + 236L);

	public float MapListVisibleHeight => base.Children[2].Height * base.Children[2].Scale;

	public Inventory Inventory
	{
		get
		{
			if (base.Children[3].IsVisible)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				Element element;
				do
				{
					element = base.Children[3].Children.FirstOrDefault((Element x) => x.IsVisible);
				}
				while (element == null && stopwatch.ElapsedMilliseconds < 5000L);
				return element?.AsObject<Inventory>();
			}
			return null;
		}
	}

	public List<Inventory> InventoryList
	{
		get
		{
			List<Inventory> list = new List<Inventory>();
			foreach (Element child in base.Children[3].Children)
			{
				list.Add(child.AsObject<Inventory>());
			}
			return list;
		}
	}

	public List<TierElementClass> TiersList
	{
		get
		{
			List<TierElementClass> list = new List<TierElementClass>();
			List<long> list2 = base.M.ReadPointersArray(base.M.ReadLong(base.Address + 1080L), base.M.ReadLong(base.Address + 1088L));
			foreach (long item in list2)
			{
				list.Add(GetObject<TierElementClass>(item));
			}
			return list;
		}
	}

	public List<MapElementClass> MapsList
	{
		get
		{
			List<MapElementClass> list = new List<MapElementClass>();
			List<long> list2 = base.M.ReadPointersArray(base.M.ReadLong(base.Address + 1104L), base.M.ReadLong(base.Address + 1112L));
			foreach (long item in list2)
			{
				list.Add(GetObject<MapElementClass>(item));
			}
			return list;
		}
	}
}
