using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class MavenButtonElement : Element
{
	public bool IsButtonVisible => LokiPoe.Memory.ReadByte(base.Address + 699L) == 1;

	public bool IsClicked => LokiPoe.Memory.ReadByte(base.Address + 697L) == 1;

	public bool IsEnabled => LokiPoe.Memory.ReadShort(base.Address + 356L) == -1;

	public string TooltipText => base.Tooltip.Text;
}
