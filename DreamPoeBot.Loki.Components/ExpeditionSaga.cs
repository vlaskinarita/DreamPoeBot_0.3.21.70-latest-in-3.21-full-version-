using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class ExpeditionSaga : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ExpeditionSagaStructure
	{
		public readonly long vTable;

		public readonly long ownerObject;

		public readonly long intPtr0;

		public readonly NativeVector ExpeditionDataStructure;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ExpeditionDataStructure
	{
		public readonly long ExpeditioAreaAdr;

		public readonly long ExpeditionAreaDatFile;

		public readonly long ExpeditionFactionAdr;

		public readonly long ExpeditionFactionFile;

		public NativeVector Mods;

		private long filler;

		public NativeVector StringMods1;

		public NativeStringWCustom string1;

		private long filler1;

		public NativeVector StringMods2;

		public NativeStringWCustom string2;

		private long filler2;
	}

	private PerFrameCachedValue<ExpeditionSagaStructure> _pfvExpeditionSagaStructure;

	private PerFrameCachedValue<List<ExpeditionDataStructure>> _pfvExpeditionDataStructure;

	public IEnumerable<ExpeditionWrapper> Expeditions
	{
		get
		{
			foreach (ExpeditionDataStructure item in expeditionDataStructure)
			{
				yield return new ExpeditionWrapper(item);
			}
		}
	}

	internal ExpeditionSagaStructure expeditionSagaStructure
	{
		get
		{
			if (_pfvExpeditionSagaStructure == null)
			{
				_pfvExpeditionSagaStructure = new PerFrameCachedValue<ExpeditionSagaStructure>(method_1);
			}
			return _pfvExpeditionSagaStructure;
		}
	}

	internal List<ExpeditionDataStructure> expeditionDataStructure
	{
		get
		{
			if (_pfvExpeditionDataStructure == null)
			{
				_pfvExpeditionDataStructure = new PerFrameCachedValue<List<ExpeditionDataStructure>>(method_2);
			}
			return _pfvExpeditionDataStructure;
		}
	}

	private ExpeditionSagaStructure method_1()
	{
		return base.M.FastIntPtrToStruct<ExpeditionSagaStructure>(base.Address);
	}

	private List<ExpeditionDataStructure> method_2()
	{
		List<ExpeditionDataStructure> list = new List<ExpeditionDataStructure>();
		NativeVector nativeVector = expeditionSagaStructure.ExpeditionDataStructure;
		int size = MarshalCache<ExpeditionDataStructure>.Size;
		for (long num = nativeVector.First; num < nativeVector.Last; num += size)
		{
			list.Add(base.M.FastIntPtrToStruct<ExpeditionDataStructure>(num));
		}
		return list;
	}
}
