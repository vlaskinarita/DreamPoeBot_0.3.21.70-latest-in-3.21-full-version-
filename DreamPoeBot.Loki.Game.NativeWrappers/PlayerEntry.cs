using System;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class PlayerEntry : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct281
	{
		public NativeStringWCustom nativeStringW_0AccountName;

		public NativeStringWCustom nativeStringW_1StatusMessage;

		public NativeStringWCustom nativeStringW_2Name;

		public NativeStringWCustom nativeStringW_3League;

		private NativeStringWCustom nativeStringW_4UnknownAddedasofpatch3_20_2;

		private int int_0;

		private int int_1;

		public ushort ushort1Area;

		private ushort ushort2;

		public ushort ushort1PreviousArea;

		private ushort ushort3;

		private int unusedInt_1;

		private int unusedInt_2;

		public byte byte_0Class;

		public byte byte_Level;

		public byte byte_2IsOnline;

		private byte byte_1;

		private int int_2;

		private IntPtr intptr_2;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private byte byte_8;

		private byte byte_9;

		private byte byte_10;

		private byte byte_11;
	}

	private readonly Struct281? nullable_0;

	public string AccountName => Containers.StdStringWCustom(Struct281_0.nativeStringW_0AccountName);

	public DatWorldAreaWrapper Area => Dat.LookupWorldAreaByworldAreaId(Struct281_0.ushort1Area);

	public CharacterClass Class => (CharacterClass)(Struct281_0.byte_0Class & 0xF);

	public bool IsOnline => Struct281_0.byte_2IsOnline == 1;

	public string League => Containers.StdStringWCustom(Struct281_0.nativeStringW_3League);

	public int Level => Struct281_0.byte_Level;

	public string Name => Containers.StdStringWCustom(Struct281_0.nativeStringW_2Name);

	public string StatusMessage => Containers.StdStringWCustom(Struct281_0.nativeStringW_1StatusMessage);

	internal Struct281 Struct281_0
	{
		get
		{
			if (nullable_0.HasValue)
			{
				return nullable_0.Value;
			}
			return base.M.FastIntPtrToStruct<Struct281>(base.Address);
		}
	}

	internal PlayerEntry(long address)
		: base(address)
	{
	}

	internal PlayerEntry(Struct281 native)
		: base(0L)
	{
		nullable_0 = native;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("[AccountName: {0}]", AccountName);
		stringBuilder.AppendFormat("[CharacterName: {0}]", Name);
		stringBuilder.AppendFormat("[IsOnline: {0}]", IsOnline);
		stringBuilder.AppendFormat("[StatusMessage: {0}]", StatusMessage);
		stringBuilder.AppendFormat("[Level: {0}]", Level);
		stringBuilder.AppendFormat("[Class: {0}]", Class);
		DatWorldAreaWrapper area = Area;
		if (area != null)
		{
			stringBuilder.AppendFormat("[AreaId: {0}]", area.Id);
			stringBuilder.AppendFormat("[AreaName: {0}]", area.Name);
		}
		stringBuilder.AppendFormat("[CharacterLeague: {0}]", League);
		return stringBuilder.ToString();
	}
}
