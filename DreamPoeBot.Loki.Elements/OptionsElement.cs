using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class OptionsElement : Element
{
	public Element InputBindPanel => base.Children[2].Children[0].Children[2].Children[1].Children[4].Children[0].Children[2].Children[3];

	public bool IsAlwaysHighligthEnabled
	{
		get
		{
			byte b = base.M.ReadByte(AlwaysHightligthBaseAddress + 994L);
			return b == 1;
		}
	}

	private long AlwaysHightligthBaseAddress
	{
		get
		{
			Element element = UiOption.Children.FirstOrDefault((Element x) => x.ChildCount == 7L);
			if (element == null)
			{
				return 0L;
			}
			return element.Children[4].Children[1].Children[3].Children[10].Children[1].Children[0].Children[0].Address;
		}
	}

	private Element GraphicsOption => base.Children[2].Children[0].Children[2].Children[1].Children[0].Children[0].Children[0];

	private Element GameOption => base.Children[2].Children[0].Children[2].Children[1].Children[1].Children[0].Children[0];

	private Element UiOption => base.Children[2].Children[0].Children[2].Children[1].Children[2].Children[0].Children[1];

	private Element SoundOption => base.Children[2].Children[0].Children[2].Children[1].Children[3].Children[0].Children[0];

	private Element InputOption => base.Children[2].Children[0].Children[2].Children[1].Children[4].Children[0].Children[0];

	private Element NotificationOption => base.Children[2].Children[0].Children[2].Children[1].Children[5].Children[0].Children[0];
}
