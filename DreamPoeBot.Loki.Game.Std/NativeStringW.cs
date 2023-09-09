using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeStringW : IEquatable<NativeStringW>
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[UnsafeValueType]
	[CompilerGenerated]
	public struct Bufe__FixedBuffer
	{
		public unsafe fixed char FixedElementField[8];
	}

	public Bufe__FixedBuffer Buf;

	public readonly uint Size;

	public readonly uint Sizeunused;

	public readonly uint ReservedSize;

	public readonly uint ReservedSizeunused;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"NativeStringW size: {DreamPoeBot.Loki.MarshalCache<NativeStringW>.Size}");
		return stringBuilder.ToString();
	}

	public unsafe bool Equals(NativeStringW other)
	{
		if (ReservedSize != other.ReservedSize)
		{
			return false;
		}
		if (Size != other.Size)
		{
			return false;
		}
		if (8 <= ReservedSize)
		{
			fixed (char* ptr = Buf.FixedElementField)
			{
				char** ptr2 = (char**)ptr;
				int num = *(int*)ptr2;
				char* ptr3 = other.Buf.FixedElementField;
				int obj = *(int*)(&ptr3);
				return num.Equals(obj);
			}
		}
		fixed (char* ptr4 = Buf.FixedElementField)
		{
			char** ptr5 = (char**)ptr4;
			char* ptr6 = (char*)ptr5;
			for (int i = 0; i < Size; i++)
			{
				if (!ptr6[i].Equals(other.Buf.FixedElementField[i]))
				{
					return false;
				}
			}
		}
		return true;
	}
}
