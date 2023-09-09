using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.Components;

public class Actor : Component
{
	public class ActionWrapper : RemoteMemoryObject
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct CurrentActionStruct276
		{
			private long intptr_0;

			private long intptr_1;

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

			private long intptr_17;

			private long intptr_18;

			private long intptr_19;

			private long intptr_20;

			private long intptr_21;

			private long intptr_22;

			private long intptr_23;

			public Struct242 struct242_0;

			private long intptr_24;

			private long intptr_25;

			private long intptr_26;

			public short SkillId;

			private short short_0;

			private short short_1;

			private short short_2;

			private int intptr_8int;

			private int intptr_9int;

			public long intptr_8Target;

			public Vector2i vector2i_Destination;
		}

		private CurrentActionStruct276 struct276_0;

		private Actor _actor;

		public Vector2i Destination => struct276_0.vector2i_Destination;

		public NetworkObject Target
		{
			get
			{
				if (struct276_0.intptr_8Target == 0L)
				{
					return null;
				}
				return new NetworkObject(struct276_0.intptr_8Target).ConvertNetworkObject();
			}
		}

		public Skill Skill
		{
			get
			{
				if (struct276_0.struct242_0.intptr_0 != 0L && struct276_0.struct242_0.intptr_1 != 0L)
				{
					return new Skill(struct276_0.struct242_0.intptr_0, _actor);
				}
				return null;
			}
		}

		internal ActionWrapper(long address, CurrentActionStruct276 native, Actor actor)
			: base(address)
		{
			struct276_0 = native;
			_actor = actor;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Destination: {0}", Destination);
			stringBuilder.AppendLine();
			if (Target != null)
			{
				stringBuilder.AppendFormat("Target: {0}", Target.Id);
				stringBuilder.AppendLine();
			}
			if (Skill != null)
			{
				stringBuilder.AppendFormat("Skill: {0}", Skill.InternalId);
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ActorStruct137
	{
		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int intunused0;

		private long intptr_00;

		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		public long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_141;

		private long intptr_151;

		private long intptr_162;

		private long intptr_000;

		private long intptr_001;

		private long intptr_002;

		private long intptr_003;

		private long intptr_004;

		private long intptr_005;

		private long intptr_006;

		private long intptr_007;

		private NativeVector nativeVector_000;

		private long intptr_008;

		private long intptr_009;

		private long intptr_010;

		private long intptr_011;

		private long intptr_012;

		private long intptr_013;

		private long intptr_014;

		private long intptr_015;

		private long intptr_016;

		private long intptr_017;

		private long intptr_018;

		private long intptr_019;

		private long intptr_020;

		private long intptr_021;

		private long intptr_022;

		private long intptr_023;

		private long intptr_024;

		private long intptr_025;

		private long intptr_026;

		private long intptr_027;

		private long intptr_028;

		private long intptr_029;

		public long intptr_9ActionWrapperStruct276;

		private long intptr_171;

		private long intptr_182;

		private long intptr_192;

		private int int_01;

		private int int_02;

		private int int_03;

		private int int_04;

		public NativeVector nativeVector_0Effects;

		private NativeVector nativeVector_1;

		public short short_0Flags;

		private short short_0;

		private short short_1;

		private short short_21;

		private long intptr_152;

		private long intptr_153;

		private long intptr_154;

		private long intptr_155;

		private byte byte_12;

		private byte byte_13;

		private byte byte_14;

		private byte byte_15;

		private int int_4;

		private int int_5;

		private Vector2i vector2i_0;

		private int int_6;

		private long intptr_156;

		public float float_0TimeSinceLastMove;

		public float float_1TimeSinceLastAction;

		private long intptr_157;

		private long intptr_158;

		private byte byte_16;

		private byte byte_17;

		private byte byte_18;

		private byte byte_19;

		private int intunused4;

		private Struct252 struct252_0;

		private Struct252 struct252_1;

		private Struct252 struct252_2;

		private Struct252 struct252_3;

		private long unusedPtr4;

		private long unusedPtr5;

		private long unusedPtr6;

		private long unusedPtr7;

		private long unusedPtr8;

		private long unusedPtr9;

		private long unusedPtr10;

		private long unusedPtr11;

		private long unusedPtr12;

		private long unusedPtr13;

		private long unusedPtr14;

		private long unusedPtr15;

		private long unusedPtr16;

		private long unusedPtr17;

		private long unusedPtr18;

		private long unusedPtr19;

		private long unusedPtr20;

		private long unusedPtr21;

		private long unusedPtr22;

		private long unusedPtr23;

		private long unusedPtr24;

		private long unusedPtr25;

		private long unusedPtr26;

		private long unusedPtr27;

		private int int_09;

		private int int_010;

		private long unusedPtr28;

		private long unusedPtr29;

		private long unusedPtr30;

		private long unusedPtr31;

		private long unusedPtr32;

		private long unusedPtr33;

		private long unusedPtr34;

		private long unusedPtr35;

		private long unusedPtr36;

		private long unusedPtr37;

		private long unusedPtr38;

		private long unusedPtr39;

		private long unusedPtr40;

		private long unusedPtr41;

		private long unusedPtr42;

		private long unusedPtr43;

		private long unusedPtr44;

		private long unusedPtr45;

		private long unusedPtr46;

		private long unusedPtr47;

		private long unusedPtr48;

		private long unusedPtr49;

		private long unusedPtr50;

		private long unusedPtr51;

		private long unusedPtr52;

		private long unusedPtr53;

		private long unusedPtr54;

		private long unusedPtr55;

		private long unusedPtr56;

		private long unusedPtr57;

		private long unusedPtr58;

		private long unusedPtr59;

		private long unusedPtr60;

		private long unusedPtr61;

		private long unusedPtr62;

		private long unusedPtr63;

		private long unusedPtr64;

		private long unusedPtr65;

		private long unusedPtr66;

		private long unusedPtr67;

		private long unusedPtr68;

		private long unusedPtr69;

		private long unusedPtr70;

		private long unusedPtr71;

		private long unusedPtr72;

		private long unusedPtr73;

		private long unusedPtr74;

		private long unusedPtr75;

		public NativeVector nativeVector_3AvailableSkills;

		public NativeVector nativeVector_4List_0CoolDownSkills;

		public NativeVector nativeVector_5List_1VaalSkills;

		public NativeVector nativeVector_7List_2DeployedObjects;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct138
	{
		public Struct243 struct243_0;

		public int maxSoul;

		public int currentSoul;

		private int int_2;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct139
	{
		private short short_0;

		private short short_1;

		private short short_3;

		private short short_4;

		public int Index;

		private int int_1;

		public NativeVector nativeVector_0;

		private long intPtr_9;

		public int int_5CoolDownCount;

		private int int_6MaxCooldownSecs;

		private int int_2;

		private short short_5;

		private short short_6;

		private int int_3;

		private short short_7;

		private short short_8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct140
	{
		private ushort ushort_0;

		public ushort ushort_1;

		public int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct141
	{
		private long intptr_0;

		private NativeVector nativeVector_0;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private PerFrameCachedValue<ActorStruct137> perFrameCachedValue_1;

	private PerFrameCachedValue<ActionWrapper.CurrentActionStruct276> perFrameCachedValue_2;

	private PerFrameCachedValue<ActionWrapper> perFrameCachedValue_3;

	private PerFrameCachedValue<ActionWrapper.CurrentActionStruct276> perFrameCachedValue_4;

	private SlowCacheValue<List<Skill>> perFrameCachedValue_5;

	private int _struct242Size = -1;

	private int _currentActionStruct276Size = -1;

	private int _struct139Size = -1;

	private int _struct138Size = -1;

	private int _struct140Size = -1;

	public List<Skill> AvailableSkills
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new SlowCacheValue<List<Skill>>(GetAvailableSkills);
			}
			return perFrameCachedValue_5;
		}
	}

	private int Struct242Size
	{
		get
		{
			if (_struct242Size == -1)
			{
				_struct242Size = MarshalCache<Struct242>.Size;
			}
			return _struct242Size;
		}
	}

	internal bool Boolean_0 => (ulong)Struct137_0.intptr_10 > 0uL;

	internal int CurrentActionStruct276Size
	{
		get
		{
			if (_currentActionStruct276Size == -1)
			{
				_currentActionStruct276Size = MarshalCache<ActionWrapper.CurrentActionStruct276>.Size;
			}
			return _currentActionStruct276Size;
		}
	}

	public ActionWrapper CurrentAction
	{
		get
		{
			long intptr_9ActionWrapperStruct = Struct137_0.intptr_9ActionWrapperStruct276;
			if (intptr_9ActionWrapperStruct == 0L)
			{
				return null;
			}
			return new ActionWrapper(intptr_9ActionWrapperStruct, base.M.FastIntPtrToStruct<ActionWrapper.CurrentActionStruct276>(intptr_9ActionWrapperStruct, CurrentActionStruct276Size), this);
		}
	}

	public List<long> ListOfDeployedEffect => Containers.StdLongVector<long>(Struct137_0.nativeVector_0Effects);

	public List<NetworkObject> DeployedObjects
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Struct140 list_2DeployedObject in List_2DeployedObjects)
			{
				NetworkObject objectById = LokiPoe.ObjectManager.GetObjectById(list_2DeployedObject.int_0);
				if (!object.Equals(objectById, null) && objectById.IsValid)
				{
					list.Add(objectById);
				}
			}
			return list;
		}
	}

	public uint Flags => (uint)Struct137_0.short_0Flags;

	public bool HasCurrentAction => CurrentAction != null;

	private int Struct139Size
	{
		get
		{
			if (_struct139Size == -1)
			{
				_struct139Size = MarshalCache<Struct139>.Size;
			}
			return _struct139Size;
		}
	}

	internal List<Struct139> List_0CoolDownSkills
	{
		get
		{
			int struct139Size = Struct139Size;
			int count = (int)((Struct137_0.nativeVector_4List_0CoolDownSkills.Last - Struct137_0.nativeVector_4List_0CoolDownSkills.First) / struct139Size);
			Struct139[] source = base.M.IntptrToStructArray<Struct139>(Struct137_0.nativeVector_4List_0CoolDownSkills.First, count, struct139Size);
			return source.ToList();
		}
	}

	private int Struct138Size
	{
		get
		{
			if (_struct138Size == -1)
			{
				_struct138Size = MarshalCache<Struct138>.Size;
			}
			return _struct138Size;
		}
	}

	internal List<Struct138> List_1VaalSkills
	{
		get
		{
			int struct138Size = Struct138Size;
			int count = (int)((Struct137_0.nativeVector_5List_1VaalSkills.Last - Struct137_0.nativeVector_5List_1VaalSkills.First) / struct138Size);
			Struct138[] source = base.M.IntptrToStructArray<Struct138>(Struct137_0.nativeVector_5List_1VaalSkills.First, count, struct138Size);
			return source.ToList();
		}
	}

	private int Struct140Size
	{
		get
		{
			if (_struct140Size == -1)
			{
				_struct140Size = MarshalCache<Struct140>.Size;
			}
			return _struct140Size;
		}
	}

	internal List<Struct140> List_2DeployedObjects
	{
		get
		{
			int struct140Size = Struct140Size;
			int count = (int)((Struct137_0.nativeVector_7List_2DeployedObjects.Last - Struct137_0.nativeVector_7List_2DeployedObjects.First) / struct140Size);
			Struct140[] source = base.M.IntptrToStructArray<Struct140>(Struct137_0.nativeVector_7List_2DeployedObjects.First, count, struct140Size);
			return source.ToList();
		}
	}

	internal ActorStruct137 Struct137_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<ActorStruct137>(() => base.M.FastIntPtrToStruct137(base.Address));
			}
			return perFrameCachedValue_1.Value;
		}
	}

	public float TimeSinceLastAction => 0f - Struct137_0.float_1TimeSinceLastAction;

	public float TimeSinceLastMove => 0f - Struct137_0.float_0TimeSinceLastMove;

	private List<Skill> GetAvailableSkills()
	{
		int count = (int)((Struct137_0.nativeVector_3AvailableSkills.Last - Struct137_0.nativeVector_3AvailableSkills.First) / 16L);
		Struct242[] array = base.M.IntptrToStructArray<Struct242>(Struct137_0.nativeVector_3AvailableSkills.First, count, Struct242Size);
		List<Skill> list = new List<Skill>();
		Struct242[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct242 @struct = array2[i];
			list.Add(new Skill(@struct.intptr_0, this));
		}
		return list;
	}

	public override string ToString()
	{
		_ = Struct137_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "ActorComponent"));
		stringBuilder.AppendLine(string.Format("Flags: {0} (0x{0:X})", Flags));
		stringBuilder.AppendLine($"TimeSinceLastMove: {TimeSinceLastMove}");
		stringBuilder.AppendLine($"TimeSinceLastAction: {TimeSinceLastAction}");
		stringBuilder.AppendLine($"HasCurrentAction: {HasCurrentAction}");
		if (HasCurrentAction)
		{
			ActionWrapper currentAction = CurrentAction;
			stringBuilder.AppendLine("CurrentAction");
			if (currentAction != null)
			{
				stringBuilder.AppendLine($"\t{currentAction.Skill.InternalName} - {currentAction.Skill.Name}");
				stringBuilder.AppendLine($"\tDestination: {currentAction.Destination}");
				if (!object.Equals(currentAction.Target, null))
				{
					stringBuilder.AppendLine($"\tTarget: [{currentAction.Target.Id}] {currentAction.Target.Name} - {currentAction.Target.Metadata}");
				}
				else
				{
					stringBuilder.AppendLine($"\tTarget: (none)");
				}
			}
		}
		stringBuilder.AppendLine("AvailableSkills:");
		foreach (Skill availableSkill in AvailableSkills)
		{
			stringBuilder.AppendLine($"{availableSkill.InternalName} - {availableSkill.Name}");
		}
		stringBuilder.AppendLine("DeployedObjects:");
		foreach (NetworkObject deployedObject in DeployedObjects)
		{
			stringBuilder.AppendLine($"\t[{deployedObject.Id}] {deployedObject.Name} - {deployedObject.Metadata}");
		}
		return stringBuilder.ToString();
	}
}
