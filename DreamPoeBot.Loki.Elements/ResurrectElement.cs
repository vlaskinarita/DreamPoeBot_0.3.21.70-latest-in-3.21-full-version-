using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class ResurrectElement : Element
{
	private Element ResurrectInTown => base.Children[1].Children[0];

	private Element ResurrectAtCheckpoint => base.Children[3].Children[0];

	public bool ResurrectInTownEnabled => ResurrectInTown.IsEnable;

	public bool ResurrectAtCheckpointEnabled => ResurrectAtCheckpoint.IsEnable;

	public Vector2i ResInTownClickPos => LokiPoe.ElementClickLocation(ResurrectInTown);

	public Vector2i ResAtCheckpointClickPos => LokiPoe.ElementClickLocation(ResurrectAtCheckpoint);
}
