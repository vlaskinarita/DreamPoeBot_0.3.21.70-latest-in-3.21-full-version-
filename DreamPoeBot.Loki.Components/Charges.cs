using System;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Charges : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct154
	{
		public Struct253 struct253_0;

		public long intptr_0Struct155;

		public int int_0CurrentCharges;

		private int int_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct155
	{
		private long intptr_0;

		private long intptr_1;

		public int int_0MaxBaseCharges;

		public int int_0MaxBaseCharges2;

		public int int_1ChargesPerUse;

		public int int_1ChargesPerUse2;
	}

	private PerFrameCachedValue<Struct154> perFrameCachedValue_1;

	public int ChargesPerUse => Struct155_0.int_1ChargesPerUse;

	public int CurrentCharges => Struct154_0.int_0CurrentCharges;

	public int ExtraCharges => method_1(StatTypeGGG.LocalExtraMaxCharges);

	public int MaxBaseCharges => Struct155_0.int_0MaxBaseCharges;

	public int MaxCharges
	{
		get
		{
			double maxChargesModifier = MaxChargesModifier;
			return Math.Max((int)((double)ExtraCharges + (double)MaxBaseCharges * maxChargesModifier), 1);
		}
	}

	public double MaxChargesModifier => (double)(method_1(StatTypeGGG.LocalMaxChargesPosPct) + 100) * 0.01;

	internal Struct154 Struct154_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct154>(method_2);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct155 Struct155_0 => base.M.FastIntPtrToStruct<Struct155>(Struct154_0.intptr_0Struct155);

	public int GetMaxCharges(LocalStats localStats)
	{
		if (localStats == null)
		{
			return 1;
		}
		double num = (double)(localStats.GetStat(StatTypeGGG.LocalMaxChargesPosPct) + 100) * 0.01;
		return Math.Max((int)((double)localStats.GetStat(StatTypeGGG.LocalExtraMaxCharges) + (double)MaxBaseCharges * num), 1);
	}

	private int method_1(StatTypeGGG statTypeGGG_0)
	{
		NetworkObject networkObject = LokiPoe.ObjectManager.Objects.FirstOrDefault(method_3);
		if (object.Equals(networkObject, null))
		{
			return 0;
		}
		return networkObject.Components.LocalStatsComponent.GetStat(statTypeGGG_0);
	}

	private Struct154 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct154>(base.Address);
	}

	private bool method_3(NetworkObject networkObject_0)
	{
		return networkObject_0.Entity.Address == Struct154_0.struct253_0.intptr_1;
	}
}
