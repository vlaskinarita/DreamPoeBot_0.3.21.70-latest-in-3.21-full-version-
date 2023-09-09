using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class FragmentStashTabLayouts : FileInMemory
{
	public class FragmentStashTabLayoutHardcoded
	{
		public string Metadata { get; private set; }

		public short PosX { get; private set; }

		public short PosY { get; private set; }

		public short Order { get; private set; }

		public byte CategoryIndex { get; private set; }

		public byte BreachElementIndex { get; private set; }

		public List<int> StorableBaseItemTypeKeys { get; private set; }

		public FragmentStashTabLayoutHardcoded(string metadata, short posX, short posY, short order, byte category, List<int> baseItemTypes, byte breachElementIndex)
		{
			Metadata = metadata;
			PosX = posX;
			PosY = posY;
			Order = order;
			CategoryIndex = category;
			StorableBaseItemTypeKeys = baseItemTypes;
			BreachElementIndex = breachElementIndex;
		}
	}

	public class FragmentStashTabLayout : RemoteMemoryObject
	{
		public string Metadata { get; private set; }

		public short PosX { get; private set; }

		public short PosY { get; private set; }

		public short Order { get; private set; }

		public byte CategoryIndex { get; private set; }

		public int StorableBaseItemTypeCount { get; private set; }

		public long StorableBaseItemTypeAddress { get; private set; }

		public List<int> StorableBaseItemTypeKeys
		{
			get
			{
				List<int> list = new List<int>();
				for (int i = 0; i < StorableBaseItemTypeCount; i++)
				{
					DatBaseItemTypeWrapper baseItemTypeWrapperByAddress = Dat.GetBaseItemTypeWrapperByAddress(base.M.ReadLong(StorableBaseItemTypeAddress + i * 16));
					if (baseItemTypeWrapperByAddress != null)
					{
						list.Add(baseItemTypeWrapperByAddress.Index);
					}
				}
				return list;
			}
		}

		public FragmentStashTabLayout(long addr)
			: base(addr)
		{
			Metadata = base.M.ReadStringU(base.M.ReadLong(addr), 255);
			PosX = (short)base.M.ReadInt(addr + 8L);
			PosY = (short)base.M.ReadInt(addr + 12L);
			Order = (short)base.M.ReadInt(addr + 16L);
			CategoryIndex = (byte)base.M.ReadInt(addr + 33L);
			StorableBaseItemTypeCount = base.M.ReadInt(addr + 42L);
			StorableBaseItemTypeAddress = base.M.ReadLong(addr + 50L);
		}
	}

	private static Dictionary<string, FragmentStashTabLayoutHardcoded> _data;

	public Dictionary<string, FragmentStashTabLayout> records = new Dictionary<string, FragmentStashTabLayout>(StringComparer.OrdinalIgnoreCase);

	public Dictionary<string, FragmentStashTabLayoutHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<string, FragmentStashTabLayoutHardcoded>();
				string[] array = Resources.FragmentStashTabLayout.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					string text2 = text.Replace("\"", "").Replace("[", "").Replace("<", "")
						.Replace(">", "")
						.Replace("]", "");
					string[] array2 = text2.Split(',');
					string text3 = array2[0];
					short posX = Convert.ToInt16(array2[1]);
					short posY = Convert.ToInt16(array2[2]);
					short order = Convert.ToInt16(array2[3]);
					byte category = Convert.ToByte(array2[7]);
					byte breachElementIndex = Convert.ToByte(array2[array2.Length - 4]);
					List<int> list = new List<int>();
					for (int j = 11; j < array2.Length - 10; j++)
					{
						int num = Convert.ToInt32(array2[j]);
						if (num != 0)
						{
							list.Add(num);
						}
					}
					_data.Add(text3, new FragmentStashTabLayoutHardcoded(text3, posX, posY, order, category, list, breachElementIndex));
				}
			}
			return _data;
		}
	}

	public FragmentStashTabLayouts(Memory m, long address)
		: base(m, address)
	{
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			FragmentStashTabLayout fragmentStashTabLayout = new FragmentStashTabLayout(item);
			if (!records.ContainsKey(fragmentStashTabLayout.Metadata))
			{
				records.Add(fragmentStashTabLayout.Metadata, fragmentStashTabLayout);
			}
		}
	}
}
