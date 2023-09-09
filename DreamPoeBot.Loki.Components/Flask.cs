using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns15;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.Components;

public class Flask : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct160
	{
		private Struct253 struct253_0;

		private NativeVector nativeVector_0;

		public long intptr_0Struct161;

		public long intptr_1QualityComponent;

		public long intptr_2LocalStatComponent;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct161
	{
		private long intptr_0;

		private long intptr_1;

		private int int_0;

		private int int_1;

		public int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		public Class248.Struct132 struct132_0;

		public Class248.Struct132 struct132_1;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private LocalStats localStatsComponent_0;

	private PerFrameCachedValue<Struct160> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct161> perFrameCachedValue_2;

	private Quality qualityComponent_0;

	public bool IsInstantRecovery
	{
		get
		{
			if (LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskRecoversInstantly) == 0)
			{
				return LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskRecoveryAmountPctToRecoverInstantly) >= 100;
			}
			return true;
		}
	}

	public int LifeRecover
	{
		get
		{
			float num = method_1(StatTypeGGG.LocalFlaskLifeToRecover);
			float num2 = LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskLifeToRecoverPosPct);
			double num3 = (float)LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskAmountToRecoverPosPct);
			num2 = num2 * 0.01f + 1f;
			double num4 = num3 * 0.009999999776482582 + 1.0;
			double num5 = (double)QualityComponent_0.ItemQuality * 0.01 + 1.0;
			return (int)(num4 * (num5 * (double)num * (double)num2) + 0.5);
		}
	}

	private LocalStats LocalStatsComponent_0
	{
		get
		{
			if (localStatsComponent_0 == null)
			{
				localStatsComponent_0 = new LocalStats(Struct160_0.intptr_2LocalStatComponent);
			}
			localStatsComponent_0.UpdatePointer(Struct160_0.intptr_2LocalStatComponent);
			return localStatsComponent_0;
		}
	}

	public int ManaRecover
	{
		get
		{
			float num = method_1(StatTypeGGG.LocalFlaskManaToRecover);
			float num2 = LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskManaToRecoverPosPct);
			double num3 = (float)LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskAmountToRecoverPosPct);
			num2 = num2 * 0.01f + 1f;
			double num4 = num3 * 0.009999999776482582 + 1.0;
			double num5 = (double)QualityComponent_0.ItemQuality * 0.01 + 1.0;
			return (int)(num4 * (num5 * (double)num * (double)num2) + 0.5);
		}
	}

	private Quality QualityComponent_0
	{
		get
		{
			if (qualityComponent_0 == null)
			{
				qualityComponent_0 = new Quality(Struct160_0.intptr_1QualityComponent);
			}
			qualityComponent_0.UpdatePointer(Struct160_0.intptr_1QualityComponent);
			return qualityComponent_0;
		}
	}

	public TimeSpan RecoveryTime
	{
		get
		{
			float num = method_1(StatTypeGGG.LocalFlaskDecisecondsToRecover);
			float num2;
			float num3;
			if (Struct161_0.int_2 != 0)
			{
				num2 = 1f;
				num3 = (float)QualityComponent_0.ItemQuality / 100f + 1f;
			}
			else
			{
				num2 = (float)LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskRecoverySpeedPosPct) / 100f + 1f;
				num3 = 1f;
			}
			int stat = LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskDurationPosPct);
			if (stat != 0)
			{
				double num4 = (int)Math.Floor(num * num3 / num2 + 0.5f) * 100;
				return TimeSpan.FromMilliseconds(Math.Round(num4 + num4 * (double)stat / 100.0, 2, MidpointRounding.ToEven));
			}
			stat = LocalStatsComponent_0.GetStat(StatTypeGGG.LocalFlaskDurationPosPctFinal);
			if (stat == 0)
			{
				return TimeSpan.FromMilliseconds((int)Math.Floor(num * num3 / num2 + 0.5f) * 100);
			}
			double num5 = (int)Math.Floor(num * num3 / num2 + 0.5f) * 100;
			return TimeSpan.FromMilliseconds(Math.Round(num5 + num5 * (double)stat / 100.0, 2, MidpointRounding.ToEven));
		}
	}

	internal Struct160 Struct160_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct160>(method_2);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct161 Struct161_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct161>(method_3);
			}
			return perFrameCachedValue_2;
		}
	}

	private int method_1(StatTypeGGG statTypeGGG_0)
	{
		foreach (KeyValuePair<StatTypeGGG, int> item in Containers.StdStatType_IntVector<KeyValuePair<StatTypeGGG, int>>(Struct161_0.struct132_0.nativeVector_0))
		{
			if (item.Key == statTypeGGG_0)
			{
				return item.Value;
			}
		}
		foreach (KeyValuePair<StatTypeGGG, int> item2 in Containers.StdStatType_IntVector<KeyValuePair<StatTypeGGG, int>>(Struct161_0.struct132_1.nativeVector_0))
		{
			if (item2.Key == statTypeGGG_0)
			{
				return item2.Value;
			}
		}
		return 0;
	}

	private Struct160 method_2()
	{
		return GameController.Instance.Memory.FastIntPtrToStruct<Struct160>(base.Address);
	}

	private Struct161 method_3()
	{
		return GameController.Instance.Memory.FastIntPtrToStruct<Struct161>(Struct160_0.intptr_0Struct161);
	}
}
