using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class Pathfinding : Component
{
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct PathfindingComponentOffsets
	{
		public static int PathNodeStart = 44;

		[FieldOffset(44)]
		public Vector2i ClickToNextPosition;

		[FieldOffset(52)]
		public Vector2i WasInThisPosition;

		[FieldOffset(1136)]
		public byte IsMoving;

		[FieldOffset(1136)]
		public int DestinationNodes;

		[FieldOffset(1352)]
		public Vector2i WantMoveToPosition;

		[FieldOffset(1364)]
		public float StayTime;
	}

	private readonly PerFrameCachedValue<PathfindingComponentOffsets> _cachedValue;

	private PathfindingComponentOffsets _offsets => _cachedValue.Value;

	public Vector2i TargetMovePos => _offsets.ClickToNextPosition;

	public Vector2i PreviousMovePos => _offsets.WasInThisPosition;

	public Vector2i WantMoveToPosition => _offsets.WantMoveToPosition;

	public bool IsMoving => _offsets.DestinationNodes > 0;

	public int DestinationNodes => _offsets.DestinationNodes;

	public float StayTime => _offsets.StayTime;

	public IList<Vector2i> PathingNodes
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			int destinationNodes = _offsets.DestinationNodes;
			if (destinationNodes >= 0 && destinationNodes <= 30)
			{
				int num = destinationNodes * 4 * 2;
				byte[] value = base.M.ReadMem(base.Address + PathfindingComponentOffsets.PathNodeStart, num);
				List<Vector2i> list = new List<Vector2i>();
				for (int i = 0; i < num; i += 8)
				{
					int x = BitConverter.ToInt32(value, i);
					int y = BitConverter.ToInt32(value, i + 4);
					list.Add(new Vector2i(x, y));
				}
				list.Reverse();
				return list;
			}
			return new List<Vector2i>();
		}
	}

	public Pathfinding()
	{
		_cachedValue = new PerFrameCachedValue<PathfindingComponentOffsets>(() => base.M.FastIntPtrToStruct<PathfindingComponentOffsets>(base.Address));
	}
}
