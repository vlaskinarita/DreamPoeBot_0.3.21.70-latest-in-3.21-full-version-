using System;
using System.Linq;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Models.Enums;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class IngameState : RemoteMemoryObject
{
	private const int ingameDataOffset = 24;

	private const int serverDataOffset = 1904;

	public DiagnosticElementNew DiagnosticData = new DiagnosticElementNew();

	private IngameData Datareal { get; set; }

	private ServerData ServerDatareal { get; set; }

	public bool InGame => GameStateController.IsInGameState;

	public bool PausedGame => GameStateController.IsWaitingState;

	public bool HasEnteredTheGame => true;

	public long EntityLabelMap => base.M.ReadLong(base.Address + 192L, 672L);

	public AreaMap CurrentAreaMap => ReadObject<AreaMap>(base.Address + 24L);

	public IngameData Data
	{
		get
		{
			if (Datareal == null)
			{
				Datareal = ReadObject<IngameData>(base.Address + 24L + base.Offsets.IgsOffset);
			}
			else
			{
				long l = base.M.ReadLong(base.Address + 24L + base.Offsets.IgsOffset);
				Datareal.UpdateAddress(l);
			}
			return Datareal;
		}
	}

	public ServerData ServerData
	{
		get
		{
			if (ServerDatareal == null)
			{
				ServerDatareal = GetObject<ServerData>(Data.ServerDataAddress);
			}
			else
			{
				ServerDatareal.UpdateAddress(Data.ServerDataAddress);
			}
			return ServerDatareal;
		}
	}
  
internal long IngameUIElementsAddress => base.M.ReadLong(base.Address + 1112L + base.Offsets.IgsOffset);

	public IngameUIElements IngameUi => ReadObjectAt<IngameUIElements>(1112 + base.Offsets.IgsOffset);

	public Element UIRoot => ReadObjectAt<Element>(424 + base.Offsets.IgsOffset);

	public Element UIHover => ReadObjectAt<Element>(480 + base.Offsets.IgsOffset);

	public float UIHoverX => base.M.ReadFloat(base.Address + 488L + base.Offsets.IgsOffset);

	public float UIHoverY => base.M.ReadFloat(base.Address + 492L + base.Offsets.IgsOffset);

	public Element UIHoverTooltip => ReadObjectAt<Element>(496 + base.Offsets.IgsOffset);

	public float TimeInGameF => base.M.ReadFloat(base.Address + 1048L + base.Offsets.IgsOffset);

	public DiagnosticInfoType DiagnosticInfoType => (DiagnosticInfoType)base.M.ReadInt(base.Address + 1560L + base.Offsets.IgsOffset);

	public short Fps => (short)(1000000 / (int)base.M.ReadUShort(base.Address + 32L + base.Offsets.IgsOffset));

	public float FloatFps => 1000000f / (float)(int)base.M.ReadUShort(base.Address + 32L + base.Offsets.IgsOffset);

	public Camera Camera => ReadObject<Camera>(base.Address + 120L + base.Offsets.IgsOffsetDelta);

	public Element CursorHoverElement => ReadObject<Element>(FrameUnderCursor);

	public long FrameUnderCursor => base.M.ReadLong(base.M.ReadLong(base.M.ReadLong(base.Address + 104L) + 824L) + 168L);

	public float CurentUIElementPosX => UIHoverX;

	public float CurentUIElementPosY => UIHoverY;

	public float CurLatency => ServerData.Latency;

	public float CurFrameTime => DiagnosticData.FrameTimeValues.Last();

	public float CurFps => DiagnosticData.FPSValues.Last();

	public TimeSpan TimeInGame => TimeSpan.FromSeconds(TimeInGameF);
}
