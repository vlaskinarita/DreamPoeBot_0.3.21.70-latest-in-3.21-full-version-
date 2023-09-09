using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class MinimapIconWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct278
	{
		public readonly Struct243 struct243_0;

		private readonly int int_0;

		public readonly Vector2i vector2i_0LastSeenPosition;

		private readonly int unusedInt_0;

		private readonly IntPtr intptr_0;

		private readonly IntPtr intptr_1;

		private readonly IntPtr intptr_2;

		private readonly IntPtr intptr_3;

		private readonly IntPtr intptr_4;

		private readonly IntPtr intptr_5;

		private readonly IntPtr intptr_6;

		private readonly IntPtr intptr_7;

		private readonly IntPtr intptr_8;

		public readonly int int_1ObjectId;

		private readonly int unusedInt_1;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		private readonly int unusedInt_2;

		private readonly IntPtr intptr_9;

		private readonly IntPtr intptr_10;

		private readonly IntPtr intptr_11;

		private readonly IntPtr intptr_12;

		private readonly IntPtr intptr_13;

		private readonly IntPtr intptr_14;
	}

	public DatMinimapIconWrapper MinimapIcon { get; private set; }

	public int ObjectId { get; private set; }

	public NetworkObject NetworkObject => LokiPoe.ObjectManager.GetObjectById(ObjectId);

	public Vector2i LastSeenPosition { get; private set; }

	internal MinimapIconWrapper(Struct278 native)
	{
		MinimapIcon = Dat.smethod_60(native.struct243_0.intptr_1, bool_0: true);
		ObjectId = native.int_1ObjectId;
		LastSeenPosition = native.vector2i_0LastSeenPosition;
	}
}
