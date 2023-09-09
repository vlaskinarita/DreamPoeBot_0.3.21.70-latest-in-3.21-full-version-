using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Structures.ns14;

internal class Class247 : MemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct123
	{
		public readonly long intptr_0;

		public readonly Vector2i vector2i_LocationTopLeft;

		public readonly Vector2i vector2i_Size;
	}

	public int LocalId { get; }

	internal Struct123 Struct123_0 => GameController.Instance.Memory.FastIntPtrToStruct<Struct123>(base.BaseAddress);

	public Vector2i LocationTopLeft => Struct123_0.vector2i_LocationTopLeft;

	public Vector2i LocationBottomRight => LocationTopLeft + Vector2i_2;

	public Vector2i Vector2i_2 => Struct123_0.vector2i_Size - Struct123_0.vector2i_LocationTopLeft;

	public Item Item_0 => new Item(this);

	internal Class247(long ptr, int localId)
		: base(ptr)
	{
		LocalId = localId;
	}
}
