using System;
using System.Collections.Generic;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class CurrencyStashTabLayouts : FileInMemory
{
	public class CurrencyStashTabLayoutHardcoded
	{
		public string Metadata { get; private set; }

		public short PosX { get; private set; }

		public short PosY { get; private set; }

		public short Order { get; private set; }

		public byte CategoryIndex { get; private set; }

		public CurrencyStashTabLayoutHardcoded(string metadata, short posX, short posY, short order, byte category)
		{
			Metadata = metadata;
			PosX = posX;
			PosY = posY;
			Order = order;
			CategoryIndex = category;
		}
	}

	public class CurrencyStashTabLayout : RemoteMemoryObject
	{
		public string Metadata { get; private set; }

		public short PosX { get; private set; }

		public short PosY { get; private set; }

		public short Order { get; private set; }

		public byte CategoryIndex { get; private set; }

		public CurrencyStashTabLayout(long addr)
			: base(addr)
		{
			Metadata = base.M.ReadStringU(base.M.ReadLong(addr), 255);
			PosX = (short)base.M.ReadInt(addr + 24L);
			PosY = (short)base.M.ReadInt(addr + 28L);
			Order = (short)base.M.ReadInt(addr + 32L);
			CategoryIndex = (byte)base.M.ReadInt(addr + 45L);
		}
	}

	private static Dictionary<string, CurrencyStashTabLayoutHardcoded> _data;

	public Dictionary<string, CurrencyStashTabLayout> records = new Dictionary<string, CurrencyStashTabLayout>(StringComparer.OrdinalIgnoreCase);

	public Dictionary<string, CurrencyStashTabLayoutHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<string, CurrencyStashTabLayoutHardcoded>();
				string[] array = Resources.CurrencyStashTabLayout.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace("\"", "").Replace("[", "").Replace("<", "")
							.Replace(">", "")
							.Replace("]", "");
						string[] array2 = text2.Split(',');
						string text3 = array2[0];
						short posX = Convert.ToInt16(array2[3]);
						short posY = Convert.ToInt16(array2[4]);
						short order = Convert.ToInt16(array2[5]);
						byte category = Convert.ToByte(array2[9]);
						_data.Add(text3, new CurrencyStashTabLayoutHardcoded(text3, posX, posY, order, category));
					}
				}
			}
			return _data;
		}
	}

	public CurrencyStashTabLayouts(Memory m, long address)
		: base(m, address)
	{
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			CurrencyStashTabLayout currencyStashTabLayout = new CurrencyStashTabLayout(item);
			if (!records.ContainsKey(currencyStashTabLayout.Metadata))
			{
				records.Add(currencyStashTabLayout.Metadata, currencyStashTabLayout);
			}
		}
	}
}
