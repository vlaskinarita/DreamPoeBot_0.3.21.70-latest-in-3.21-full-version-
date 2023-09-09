using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DelveLevelScalingWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DelveLevelScalingStruct
	{
		public int int_Depth;

		public int int_MonsterLevel;

		public int int_2;

		public int int_SulphiteCost;

		public int int_MonsterLevel2;

		public int int_MoreMonsterLife;

		public int int_MoreMonsterDamage;

		public int int_DarknessResistance;

		public int int_LightRadius;

		public int int_9;

		public int int_10;

		public int int_11;

		public int int_12;

		public int int_13;

		public int int_MonsterLevel3;
	}

	public long Address { get; private set; }

	public int Index { get; private set; }

	public int Depth { get; private set; }

	public int MonsterLevel { get; private set; }

	public int SulphiteCost { get; private set; }

	public int MoreMonsterLife { get; private set; }

	public int MoreMonsterDamage { get; private set; }

	public int DarknessResistance { get; private set; }

	public int LightRadius { get; private set; }

	internal DelveLevelScalingWrapper(long address, DelveLevelScalingStruct native, int index)
	{
		Address = address;
		Index = index;
		Depth = native.int_Depth;
		MonsterLevel = native.int_MonsterLevel;
		SulphiteCost = native.int_SulphiteCost;
		MoreMonsterLife = native.int_MoreMonsterLife;
		MoreMonsterDamage = native.int_MoreMonsterDamage;
		DarknessResistance = native.int_DarknessResistance;
		LightRadius = native.int_LightRadius;
	}
}
