using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class StateMachine : Component
{
	public class StageState
	{
		public string Name { get; set; }

		public bool IsActive { get; set; }

		public StageState(string name, bool isActive)
		{
			Name = name;
			IsActive = isActive;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructStateMachine
	{
		private long vTable;

		private long intptr_Owner;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int int_0;

		private long vTable_1;

		private NativeVector vector0;

		private long intptr_0;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private NativeVector vector1;

		private long intptr_17;

		private long intptr_18;

		private long intptr_19;

		private long intptr_20;

		private long intptr_21;

		private long intptr_22;

		private long intptr_23;

		private long intptr_24;

		private long intptr_25;

		private long intptr_26;

		private long intptr_27;

		private long intptr_28;

		private long intptr_29;

		private long intptr_30;

		private long intptr_31;

		private long intptr_32;

		private long intptr_33;

		public long StatesDescriptionStructure;

		public NativeVector ActiveStatesVector;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StatesDescriptionStructure
	{
		private long vTable;

		private long intptr_Owner;

		public NativeVector vector0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StatesStructure
	{
		public NativeStringWCustom description;

		private int int0;

		private int int1;

		private int int2;

		private int int3;

		private long intptr_0;

		private int int4;

		private int int5;

		private long intptr_1;

		private int int6;

		private int int7;

		private long intptr_2;

		private int int8;

		private int int9;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;
	}

	private PerFrameCachedValue<StructStateMachine> perFrameCachedValue_1;

	private PerFrameCachedValue<StatesDescriptionStructure> perFrameCachedValue_2;

	private int _statesStructureSize = -1;

	public bool HasState => false;

	public int Stage => 0;

	public bool IsRitualActive
	{
		get
		{
			List<StageState> stageStates = StageStates;
			return stageStates.FirstOrDefault((StageState x) => x.Name == "encounter_started")?.IsActive ?? false;
		}
	}

	public bool Encounter_Started
	{
		get
		{
			List<StageState> stageStates = StageStates;
			return stageStates.FirstOrDefault((StageState x) => x.Name == "encounter_started")?.IsActive ?? false;
		}
	}

	public bool Encounter_Finished
	{
		get
		{
			List<StageState> stageStates = StageStates;
			return stageStates.FirstOrDefault((StageState x) => x.Name == "encounter_finished")?.IsActive ?? false;
		}
	}

	internal StructStateMachine StructStateMachine_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<StructStateMachine>(() => base.M.FastIntPtrToStruct<StructStateMachine>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}

	internal StatesDescriptionStructure StatesDescriptionStructure_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<StatesDescriptionStructure>(() => base.M.FastIntPtrToStruct<StatesDescriptionStructure>(StructStateMachine_0.StatesDescriptionStructure));
			}
			return perFrameCachedValue_2;
		}
	}

	public List<StageState> StageStates
	{
		get
		{
			List<StageState> list = new List<StageState>();
			Dictionary<int, StatesStructure> getAviableStages = GetAviableStages;
			foreach (KeyValuePair<int, StatesStructure> item in getAviableStages)
			{
				long addr = StructStateMachine_0.ActiveStatesVector.First + 8 * item.Key;
				byte b = base.M.ReadByte(addr);
				list.Add(new StageState(Containers.StdStringACustom(item.Value.description), b > 0));
			}
			return list;
		}
	}

	private int StatesStructureSize
	{
		get
		{
			if (_statesStructureSize == -1)
			{
				_statesStructureSize = MarshalCache<StatesStructure>.Size;
			}
			return _statesStructureSize;
		}
	}

	private Dictionary<int, StatesStructure> GetAviableStages
	{
		get
		{
			Dictionary<int, StatesStructure> dictionary = new Dictionary<int, StatesStructure>();
			StatesStructure[] array = base.M.IntptrToStructArray<StatesStructure>(StatesDescriptionStructure_0.vector0, StatesStructureSize);
			int num = 0;
			StatesStructure[] array2 = array;
			foreach (StatesStructure value in array2)
			{
				dictionary.Add(num, value);
				num++;
			}
			return dictionary;
		}
	}
}
