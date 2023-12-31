using System;
using System.Collections.Generic;
using System.Drawing;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Models;

public sealed class AreaInstance
{
	public DateTime TimeEntered = DateTime.Now;

	private readonly string[] HexStringTable = new string[256]
	{
		"00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
		"0A", "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13",
		"14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D",
		"1E", "1F", "20", "21", "22", "23", "24", "25", "26", "27",
		"28", "29", "2A", "2B", "2C", "2D", "2E", "2F", "30", "31",
		"32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B",
		"3C", "3D", "3E", "3F", "40", "41", "42", "43", "44", "45",
		"46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F",
		"50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
		"5A", "5B", "5C", "5D", "5E", "5F", "60", "61", "62", "63",
		"64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D",
		"6E", "6F", "70", "71", "72", "73", "74", "75", "76", "77",
		"78", "79", "7A", "7B", "7C", "7D", "7E", "7F", "80", "81",
		"82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B",
		"8C", "8D", "8E", "8F", "90", "91", "92", "93", "94", "95",
		"96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F",
		"A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9",
		"AA", "AB", "AC", "AD", "AE", "AF", "B0", "B1", "B2", "B3",
		"B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD",
		"BE", "BF", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7",
		"C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF", "D0", "D1",
		"D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB",
		"DC", "DD", "DE", "DF", "E0", "E1", "E2", "E3", "E4", "E5",
		"E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF",
		"F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9",
		"FA", "FB", "FC", "FD", "FE", "FF"
	};

	public int RealLevel { get; }

	public string Name { get; }

	public int Act { get; }

	public bool IsTown { get; }

	public bool IsHideout { get; }

	public bool HasWaypoint { get; }

	public uint Hash { get; }

	public int Rows { get; private set; }

	public int Cols { get; private set; }

	public AreaMap AreaMap { get; }

	public string DisplayName => Name + " (" + RealLevel + ")";

	public AreaInstance(AreaTemplate area, AreaMap areaMap, uint hash, int realLevel)
	{
		Hash = hash;
		RealLevel = realLevel;
		Name = area.Name;
		Act = area.Act;
		IsTown = area.IsTown;
		HasWaypoint = area.HasWaypoint;
		IsHideout = Name.Contains("Hideout") && !Name.Contains("Syndicate");
		AreaMap = areaMap;
	}

	public override string ToString()
	{
		return $"{Name} ({RealLevel}) #{Hash}";
	}

	public static string GetTimeString(TimeSpan timeSpent)
	{
		int num = (int)timeSpent.TotalSeconds;
		int num2 = num % 60;
		int num3 = num / 60;
		int num4 = num3 / 60;
		num3 %= 60;
		return string.Format((num4 > 0) ? "{0}:{1:00}:{2:00}" : "{1}:{2:00}", num4, num3, num2);
	}

	private List<AreaTilesData> GenerateTiles()
	{
		if (!LokiPoe.IsInGame)
		{
			return new List<AreaTilesData>();
		}
		long grountMapStart = AreaMap.GrountMapStart;
		long groundMapEnd = AreaMap.GroundMapEnd;
		int mapWidth = AreaMap.MapWidth;
		Memory memory = AreaMap.Memory;
		int length = (int)(groundMapEnd - grountMapStart);
		byte[] array = memory.ReadBytes(grountMapStart, length);
		Rows = mapWidth;
		Cols = array.Length / mapWidth;
		List<AreaTilesData> list = new List<AreaTilesData>();
		int num = 0;
		int num2 = 0;
		byte[] array2 = array;
		foreach (byte @byte in array2)
		{
			AreaTilesData item = new AreaTilesData
			{
				X = num,
				Y = num2,
				Byte = @byte,
				Point = new Vector2i(num, num2)
			};
			list.Add(item);
			num++;
			if (num >= mapWidth)
			{
				num2++;
				num = 0;
			}
		}
		return list;
	}

	private Color getColorFromTile(AreaTilesData tile)
	{
		if (tile.Byte == 0)
		{
			return Color.White;
		}
		if (tile.Byte > 0 && tile.Byte < 17)
		{
			return Color.Black;
		}
		if (tile.Byte != 17)
		{
			if (tile.Byte > 17 && tile.Byte < 34)
			{
				return Color.Silver;
			}
			if (tile.Byte == 34)
			{
				return Color.LimeGreen;
			}
			if (tile.Byte > 34 && tile.Byte < 51)
			{
				return Color.LawnGreen;
			}
			if (tile.Byte != 51)
			{
				if (tile.Byte > 51 && tile.Byte < 68)
				{
					return Color.PaleGoldenrod;
				}
				if (tile.Byte == 68)
				{
					return Color.AntiqueWhite;
				}
				if (tile.Byte > 68 && tile.Byte < 85)
				{
					return Color.Beige;
				}
				if (tile.Byte != 85)
				{
					return Color.Pink;
				}
				return Color.White;
			}
			return Color.GreenYellow;
		}
		return Color.DarkSlateGray;
	}
}
