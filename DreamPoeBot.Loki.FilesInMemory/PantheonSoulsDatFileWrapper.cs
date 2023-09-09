using System;
using System.Collections.Generic;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class PantheonSoulsDatFileWrapper
{
	public class PantheonSoulsDatFileHardcoded
	{
		public int WorldAreaId { get; private set; }

		public int BaseItemTypeId { get; private set; }

		public int QuestFlagId { get; private set; }

		public int MonsterVarietyId { get; private set; }

		public int PantheonPannelLayoutKey { get; private set; }

		public PantheonSoulsDatFileHardcoded(int worldAreaId, int baseItemTypeId, int questFlagId, int monsterVarietyId, int pantheonPannelLayoutKey)
		{
			WorldAreaId = worldAreaId;
			BaseItemTypeId = baseItemTypeId;
			QuestFlagId = questFlagId;
			MonsterVarietyId = monsterVarietyId;
			PantheonPannelLayoutKey = pantheonPannelLayoutKey;
		}
	}

	private static Dictionary<int, PantheonSoulsDatFileHardcoded> _data;

	public Dictionary<int, PantheonSoulsDatFileHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<int, PantheonSoulsDatFileHardcoded>();
				string[] array = Resources.PantheonSouls.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace("\"", "").Replace("[", "").Replace("<", "")
							.Replace(">", "")
							.Replace("]", "");
						string[] array2 = text2.Split(',');
						int worldAreaId = Convert.ToInt32(array2[0]);
						int baseItemTypeId = Convert.ToInt32(array2[2]);
						int num = Convert.ToInt32(array2[4]);
						int monsterVarietyId = Convert.ToInt32(array2[6]);
						int pantheonPannelLayoutKey = Convert.ToInt32(array2[8]);
						_data.Add(num, new PantheonSoulsDatFileHardcoded(worldAreaId, baseItemTypeId, num, monsterVarietyId, pantheonPannelLayoutKey));
					}
				}
			}
			return _data;
		}
	}
}
