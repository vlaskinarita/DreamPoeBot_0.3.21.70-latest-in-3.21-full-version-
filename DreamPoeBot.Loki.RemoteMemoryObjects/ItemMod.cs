using System;
using System.Linq;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using log4net;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ItemMod : RemoteMemoryObject
{
	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	private int level;

	private string name;

	private string rawName;

	private string displayName;

	private StatTypeGGG statTypeGGG;

	public int Value1 => base.M.ReadInt(base.Address, default(long));

	public int Value2 => base.M.ReadInt(base.Address, 4L);

	public int Value3 => base.M.ReadInt(base.Address, 8L);

	public int Value4 => base.M.ReadInt(base.Address, 12L);

	public string RawName
	{
		get
		{
			if (rawName == null)
			{
				ParseName();
			}
			return rawName;
		}
	}

	public string Name
	{
		get
		{
			if (rawName == null)
			{
				ParseName();
			}
			return name;
		}
	}

	public StatTypeGGG StatTypeGGG
	{
		get
		{
			if (rawName == null)
			{
				ParseName();
			}
			return statTypeGGG;
		}
	}

	public string DisplayName
	{
		get
		{
			if (rawName == null)
			{
				ParseName();
			}
			return displayName;
		}
	}

	public int Level
	{
		get
		{
			if (rawName == null)
			{
				ParseName();
			}
			return level;
		}
	}

	private void ParseName()
	{
		long addr = base.M.ReadLong(base.Address + 32L, default(long));
		rawName = base.M.ReadStringU(addr);
		if (GameController.Instance.Files.Mods.records.ContainsKey(rawName))
		{
			try
			{
				if (GameController.Instance.Files.Mods.records[rawName].StatNames.Any() && GameController.Instance.Files.Mods.records[rawName].StatNames[0] != null)
				{
					displayName = GameController.Instance.Files.Mods.records[rawName].StatNames[0].Key;
					string value = GameController.Instance.Files.Mods.records[rawName].StatNames[0].StatTypeGGG;
					statTypeGGG = (Enum.TryParse<StatTypeGGG>(value, out var result) ? result : StatTypeGGG.None);
				}
				else
				{
					displayName = "";
					statTypeGGG = StatTypeGGG.None;
				}
			}
			catch (Exception arg)
			{
				displayName = "";
				statTypeGGG = StatTypeGGG.None;
				Log.ErrorFormat($"[ItemMod-ParseName] Exception: {arg}", Array.Empty<object>());
				Log.ErrorFormat("[ItemMod-ParseName] rawName = " + rawName, Array.Empty<object>());
				Log.ErrorFormat($"[ItemMod-ParseName] GameController: {GameController.Instance == null}", Array.Empty<object>());
				Log.ErrorFormat($"[ItemMod-ParseName] GameController.Instance.Files: {GameController.Instance.Files == null}", Array.Empty<object>());
				Log.ErrorFormat($"[ItemMod-ParseName] GameController.Instance.Files.Mods: {GameController.Instance.Files.Mods == null}", Array.Empty<object>());
				Log.ErrorFormat($"[ItemMod-ParseName] GameController.Instance.Files.Mods.records[rawName].StatNames[0] null: {GameController.Instance.Files.Mods.records[rawName].StatNames[0] == null}", Array.Empty<object>());
			}
		}
		else
		{
			displayName = "";
			statTypeGGG = StatTypeGGG.None;
		}
		name = rawName.Replace("_", "");
		int num = name.IndexOfAny("0123456789".ToCharArray());
		if (num >= 0 && int.TryParse(name.Substring(num), out level))
		{
			name = name.Substring(0, num);
		}
		else
		{
			level = 1;
		}
	}

	public override string ToString()
	{
		return $"{Name} ({Value1}, {Value2}, {Value3}, {Value4}";
	}
}
