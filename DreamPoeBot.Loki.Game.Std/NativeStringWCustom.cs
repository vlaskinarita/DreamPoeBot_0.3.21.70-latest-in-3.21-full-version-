using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeStringWCustom : IEquatable<NativeStringWCustom>
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[CompilerGenerated]
	[UnsafeValueType]
	public struct Bufe__FixedBuffer
	{
		public long Address;

		public long Address2;
	}

	public Bufe__FixedBuffer Buf;

	public readonly uint Size;

	public readonly uint Sizeunused;

	public readonly uint ReservedSize;

	public readonly uint ReservedSizeunused;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"NativeStringW size: {DreamPoeBot.Loki.MarshalCache<NativeStringWCustom>.Size}");
		return stringBuilder.ToString();
	}

	public bool Equals(NativeStringWCustom other)
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
			string text = GameController.Instance.Memory.ReadStringU(Buf.Address);
			string value = GameController.Instance.Memory.ReadStringU(other.Buf.Address);
			return text.Equals(value);
		}
		byte[] bytes = BitConverter.GetBytes(Buf.Address);
		byte[] bytes2 = BitConverter.GetBytes(Buf.Address2);
		byte[] bytes3 = bytes.Concat(bytes2).ToArray();
		string text2 = Encoding.Unicode.GetString(bytes3).Substring(0, (int)other.Size);
		byte[] bytes4 = BitConverter.GetBytes(other.Buf.Address);
		byte[] bytes5 = BitConverter.GetBytes(other.Buf.Address2);
		byte[] bytes6 = bytes4.Concat(bytes5).ToArray();
		string value2 = Encoding.Unicode.GetString(bytes6).Substring(0, (int)other.Size);
		return text2.Equals(value2);
	}
}
