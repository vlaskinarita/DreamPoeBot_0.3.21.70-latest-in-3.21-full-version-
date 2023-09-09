using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class PlayerClass : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StrucPlayerClass
	{
		public byte byte_8Class;
	}

	private PerFrameCachedValue<StrucPlayerClass> perFrameCachedValue_1;

	private int _strucPlayerClassSize = -1;

	public CharacterClass Class => (CharacterClass)(strucPlayerClass.byte_8Class & 0xF);

	public AscendancyClass AscendencyClass
	{
		get
		{
			if (strucPlayerClass.byte_8Class <= 15)
			{
				return AscendancyClass.None;
			}
			return (AscendancyClass)strucPlayerClass.byte_8Class;
		}
	}

	private StrucPlayerClass strucPlayerClass
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<StrucPlayerClass>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal int StrucPlayerClassSize
	{
		get
		{
			if (_strucPlayerClassSize == -1)
			{
				_strucPlayerClassSize = MarshalCache<StrucPlayerClass>.Size;
			}
			return _strucPlayerClassSize;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[PlayerClassComponent]");
		stringBuilder.AppendLine($"\tClass: {Class}");
		stringBuilder.AppendLine($"\tAscendencyClass: {AscendencyClass}");
		return stringBuilder.ToString();
	}

	private StrucPlayerClass method_1()
	{
		return base.M.FastIntPtrToStruct<StrucPlayerClass>(base.Address + 344L, StrucPlayerClassSize);
	}
}
