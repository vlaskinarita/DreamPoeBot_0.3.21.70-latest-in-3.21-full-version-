using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class HeistBlueprint : Component
{
	public class Room
	{
		public string Id { get; private set; }

		public int Revealed { get; private set; }

		public Room(string id, int revealed)
		{
			Id = id;
			Revealed = revealed;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct HeistBlueprintStructure
	{
		public long vTable;

		public long intptr_Owner;

		public long intptr_0;

		public int int_0;

		public byte byte_0AreaLevel;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public NativeVector BlueprintWingsVector;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct BlueprintWingsStructure
	{
		public NativeVector DataHeistJobsRequirementVector;

		public byte byte_0Enabled;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public int int_0;

		public NativeVector Vector_1RewardRoomsRevealedVector;

		public NativeVector Vector_2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DataHeistJobsRequirementStructure
	{
		public long intptr_HeistJobsDat;

		public long intptr_HeistJobsFile;

		public byte byte_level;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct HeistJobsStructure
	{
		public long Id;

		public long Name;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DataHeistRewardRoomStructure
	{
		public long intptr_HeistChestRewardTypeDat;

		public long intptr_HeistChestRewardTypeFile;

		public byte byte_Revealed;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ChestRewardTypeStructure
	{
		public long intptr_Id;

		public long intptr_Art;

		public long intptr_RewardTypeName;

		public long intptr_0;

		public long intptr_1;

		public int int_MinLevel;

		public int int_MaxLevel;

		public int int_Weight;

		public long intptr_RewardRoomName2;

		public int int_KeysCount;

		public int int_0;

		public long intptr_Keys;

		public int int_1;
	}

	private PerFrameCachedValue<HeistBlueprintStructure> perFrameCachedValue_1;

	private PerFrameCachedValue<List<BlueprintWingsStructure>> perFrameCachedValue_2Wings;

	private PerFrameCachedValue<List<DataHeistJobsRequirementStructure>> perFrameCachedValue_3Jobs;

	private PerFrameCachedValue<List<DataHeistRewardRoomStructure>> perFrameCachedValue_3ChestReward;

	public int AreaLevel => HeistBlueprintStructure_0.byte_0AreaLevel;

	public int RevealedWings => ListOfWingsStructure_0.Count((BlueprintWingsStructure x) => x.byte_0Enabled == 1);

	public int UnRevealedWings => ListOfWingsStructure_0.Count((BlueprintWingsStructure x) => x.byte_0Enabled == 0);

	public List<Room> Rooms
	{
		get
		{
			List<Room> list = new List<Room>();
			foreach (DataHeistRewardRoomStructure item in ListOfChestRewardStructure_0)
			{
				string id = base.M.ReadStringU(base.M.FastIntPtrToStruct<ChestRewardTypeStructure>(item.intptr_HeistChestRewardTypeDat).intptr_Id);
				byte byte_Revealed = item.byte_Revealed;
				list.Add(new Room(id, byte_Revealed));
			}
			return list;
		}
	}

	internal HeistBlueprintStructure HeistBlueprintStructure_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<HeistBlueprintStructure>(() => base.M.FastIntPtrToStruct<HeistBlueprintStructure>(base.Address));
			}
			return perFrameCachedValue_1.Value;
		}
	}

	internal List<BlueprintWingsStructure> ListOfWingsStructure_0
	{
		get
		{
			if (perFrameCachedValue_2Wings == null)
			{
				perFrameCachedValue_2Wings = new PerFrameCachedValue<List<BlueprintWingsStructure>>(() => GetWings());
			}
			return perFrameCachedValue_2Wings.Value;
		}
	}

	internal List<DataHeistJobsRequirementStructure> ListOfJobssStructure_0
	{
		get
		{
			if (perFrameCachedValue_3Jobs == null)
			{
				perFrameCachedValue_3Jobs = new PerFrameCachedValue<List<DataHeistJobsRequirementStructure>>(() => GetJobs());
			}
			return perFrameCachedValue_3Jobs.Value;
		}
	}

	internal List<DataHeistRewardRoomStructure> ListOfChestRewardStructure_0
	{
		get
		{
			if (perFrameCachedValue_3ChestReward == null)
			{
				perFrameCachedValue_3ChestReward = new PerFrameCachedValue<List<DataHeistRewardRoomStructure>>(() => GetChestReward());
			}
			return perFrameCachedValue_3ChestReward.Value;
		}
	}

	private List<BlueprintWingsStructure> GetWings()
	{
		List<BlueprintWingsStructure> list = new List<BlueprintWingsStructure>();
		NativeVector blueprintWingsVector = HeistBlueprintStructure_0.BlueprintWingsVector;
		if (blueprintWingsVector.First != 0L && blueprintWingsVector.Last != 0L)
		{
			int size = MarshalCache<BlueprintWingsStructure>.Size;
			for (long num = blueprintWingsVector.First; num < blueprintWingsVector.Last; num += size)
			{
				list.Add(base.M.FastIntPtrToStruct<BlueprintWingsStructure>(num));
			}
			return list;
		}
		return list;
	}

	private List<DataHeistJobsRequirementStructure> GetJobs()
	{
		List<DataHeistJobsRequirementStructure> list = new List<DataHeistJobsRequirementStructure>();
		foreach (BlueprintWingsStructure item in ListOfWingsStructure_0)
		{
			NativeVector dataHeistJobsRequirementVector = item.DataHeistJobsRequirementVector;
			if (dataHeistJobsRequirementVector.First != 0L && dataHeistJobsRequirementVector.Last != 0L)
			{
				int size = MarshalCache<DataHeistJobsRequirementStructure>.Size;
				for (long num = dataHeistJobsRequirementVector.First; num < dataHeistJobsRequirementVector.Last; num += size)
				{
					list.Add(base.M.FastIntPtrToStruct<DataHeistJobsRequirementStructure>(num));
				}
				continue;
			}
			return list;
		}
		return list;
	}

	private List<DataHeistRewardRoomStructure> GetChestReward()
	{
		List<DataHeistRewardRoomStructure> list = new List<DataHeistRewardRoomStructure>();
		foreach (BlueprintWingsStructure item in ListOfWingsStructure_0.Where((BlueprintWingsStructure x) => x.byte_0Enabled == 1))
		{
			NativeVector vector_1RewardRoomsRevealedVector = item.Vector_1RewardRoomsRevealedVector;
			if (vector_1RewardRoomsRevealedVector.First != 0L && vector_1RewardRoomsRevealedVector.Last != 0L)
			{
				int size = MarshalCache<DataHeistRewardRoomStructure>.Size;
				for (long num = vector_1RewardRoomsRevealedVector.First; num < vector_1RewardRoomsRevealedVector.Last; num += size)
				{
					list.Add(base.M.FastIntPtrToStruct<DataHeistRewardRoomStructure>(num));
				}
				continue;
			}
			return list;
		}
		return list;
	}
}
