using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeStringA : IEquatable<NativeStringA>
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[UnsafeValueType]
	[CompilerGenerated]
	public struct Bufe__FixedBuffer
	{
		public byte FixedElementField;
	}

	public Bufe__FixedBuffer Buf;

	public readonly uint Size;

	private readonly uint filler0;

	public readonly uint ReservedSize;

	private readonly uint filler1;

	public unsafe bool Equals(NativeStringA other)
	{
		if (ReservedSize != other.ReservedSize)
		{
			return false;
		}
		if (Size == other.Size)
		{
			if (16 <= ReservedSize)
			{
				fixed (byte* ptr = &Buf.FixedElementField)
				{
					byte** ptr2 = (byte**)ptr;
					int num = *(int*)ptr2;
					int obj = *(int*)(&other.Buf.FixedElementField);
					return num.Equals(obj);
				}
			}
			fixed (byte* ptr3 = &Buf.FixedElementField)
			{
				byte** ptr4 = (byte**)ptr3;
				byte* ptr5 = (byte*)ptr4;
				for (int i = 0; i < Size; i++)
				{
					if (!ptr5[i].Equals((&other.Buf.FixedElementField)[i]))
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}
}
