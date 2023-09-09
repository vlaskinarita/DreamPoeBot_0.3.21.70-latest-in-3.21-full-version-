using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamPoeBot.Loki.Game.GameData;

public class BestiaryCapturedMonster
{
	[Serializable]
	private sealed class Class330
	{
		public static readonly Class330 Class9 = new Class330();

		internal string method_0(BestiaryCapturedMonsterMod bestiaryCapturedMonsterMod_0)
		{
			return bestiaryCapturedMonsterMod_0.Mod.InternalName;
		}
	}

	public int Id { get; internal set; }

	public string Metadata { get; internal set; }

	public string Name { get; internal set; }

	public string FullName { get; internal set; }

	public int Level { get; internal set; }

	public Rarity Rarity { get; internal set; }

	public List<BestiaryCapturedMonsterMod> Mods { get; internal set; }

	public DatWordsWrapper Word1 { get; internal set; }

	public DatWordsWrapper Word2 { get; internal set; }

	public DatWordsWrapper Word3 { get; internal set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("[Id: {0}]", Id);
		stringBuilder.AppendFormat("[Metadata: {0}]", Metadata);
		stringBuilder.AppendFormat("[FullName: {0}]", FullName);
		stringBuilder.AppendFormat("[Name: {0}]", Name);
		stringBuilder.AppendFormat("[Level: {0}]", Level);
		stringBuilder.AppendFormat("[Rarity: {0}]", Rarity);
		stringBuilder.AppendFormat("[Mods: {0}]", string.Join(" | ", Mods.Select(Class330.Class9.method_0)));
		if (Word1 != null)
		{
			stringBuilder.AppendFormat("[Word1: {0}]", Word1.RealName);
		}
		if (Word2 != null)
		{
			stringBuilder.AppendFormat("[Word2: {0}]", Word2.RealName);
		}
		if (Word3 != null)
		{
			stringBuilder.AppendFormat("[Word3: {0}]", Word3.RealName);
		}
		return stringBuilder.ToString();
	}
}
