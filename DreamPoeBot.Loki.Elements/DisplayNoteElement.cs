using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class DisplayNoteElement : Element
{
	public Element TextLabel => base.Children[0].Children[0].Children[1].Children[1].Children[0];

	private Element ComboBoxElement => base.Children[0]?.Children[0]?.Children[1]?.Children[0];

	public Vector2i TextPos
	{
		get
		{
			Vector2i vector2i = LokiPoe.ElementClickLocation(TextLabel);
			int num = (int)((double)TextLabel.Width * 0.4 * (double)base.Scale);
			return new Vector2i(vector2i.X + num, vector2i.Y);
		}
	}

	public Element Confirm => base.Children[0].Children[0].Children[2];

	public Vector2i ConfirmPos => LokiPoe.ElementClickLocation(Confirm);

	public Element ComboboxButton => ComboBoxElement.Children[1];

	public Vector2i ComboboxButtonPos => LokiPoe.ElementClickLocation(ComboboxButton);

	public bool IsComboboxOpen => LokiPoe.Memory.ReadByte(ComboBoxElement.Address + 956L) == 1;

	public string ComboboxSelectedItem => LokiPoe.Memory.ReadByte(ComboBoxElement.Address + 948L) switch
	{
		0 => "Note", 
		2 => "Exact Price", 
		3 => "Do Not Index", 
		_ => "Negotiable Price", 
	};
}
