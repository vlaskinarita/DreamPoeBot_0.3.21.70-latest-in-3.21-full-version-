using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class CharacterEntry
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct107
	{
		public readonly NativeStringWCustom nativeStringW_0Name;

		public readonly NativeStringWCustom nativeStringW_1League;

		private readonly uint uint_0;

		private readonly byte byte_01;

		private readonly byte byte_02;

		private readonly byte byte_04;

		private readonly byte byte_0;

		public readonly byte byte_03Level;

		private readonly byte byte_2;

		public readonly byte byte_1Class;

		private readonly byte byte_3;

		private readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;
	}

	public string Name { get; }

	public string League { get; }

	public int Level { get; }

	public CharacterClass CharacterClass { get; }

	public AscendancyClass AscendancyClass { get; }

	internal CharacterEntry(Struct107 native)
	{
		Name = Containers.StdStringWCustom(native.nativeStringW_0Name);
		League = Containers.StdStringWCustom(native.nativeStringW_1League);
		Level = native.byte_03Level;
		CharacterClass = (CharacterClass)(native.byte_1Class & 0xF);
		if (native.byte_1Class <= 15)
		{
			AscendancyClass = AscendancyClass.None;
		}
		else
		{
			AscendancyClass = (AscendancyClass)native.byte_1Class;
		}
	}

	public override string ToString()
	{
		return $"{Name} {League} {Level} {CharacterClass} {AscendancyClass}";
	}
}
