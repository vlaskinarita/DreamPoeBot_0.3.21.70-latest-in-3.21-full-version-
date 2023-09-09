using System.Runtime.InteropServices;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Transitionable : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct227
	{
		public Struct252 struct252_0;

		public Struct252 struct252_1;

		public long intptr_0;

		public byte byte_4Flag2;

		public byte byte_5Flag3;

		public ushort ushort_0Flag1;

		public long intptr_1;
	}

	public ushort Flag1 => base.M.ReadUShort(base.Address + 288L);

	public byte Flag2 => base.M.ReadByte(base.Address + 286L);

	public byte Flag3 => base.M.ReadByte(base.Address + 287L);
}
