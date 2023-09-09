using System;
using System.Collections.Generic;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class DivinationStashTabLayouts
{
	public class DivinationStashTabLayoutHardcoded
	{
		public int BaseItemTypeId { get; private set; }

		public bool IsEnabled { get; private set; }

		public bool Unknown { get; private set; }

		public DivinationStashTabLayoutHardcoded(int baseItemTypeId, bool isEnabled, bool unknown)
		{
			BaseItemTypeId = baseItemTypeId;
			IsEnabled = isEnabled;
			Unknown = unknown;
		}
	}

	private static Dictionary<int, DivinationStashTabLayoutHardcoded> _data;

	public Dictionary<int, DivinationStashTabLayoutHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<int, DivinationStashTabLayoutHardcoded>();
				string[] array = Resources.DivinationCardStashTabLayout.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace("\"", "").Replace("[", "").Replace("<", "")
							.Replace(">", "")
							.Replace("]", "");
						string[] array2 = text2.Split(',');
						short num = Convert.ToInt16(array2[0]);
						bool isEnabled = array2[2] == "True";
						bool unknown = array2[3] == "True";
						_data.Add(num, new DivinationStashTabLayoutHardcoded(num, isEnabled, unknown));
					}
				}
			}
			return _data;
		}
	}
}
