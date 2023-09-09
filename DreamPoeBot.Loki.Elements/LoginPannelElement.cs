using System.Linq;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Elements;

public class LoginPannelElement : Element
{
	public Element LoginFrame => base.Children.FirstOrDefault((Element x) => x.IdLabel == "login_frame");

	public Element ConnectingFrame => base.Children.FirstOrDefault((Element x) => x.IdLabel == "connecting_frame");

	public Element QueueFrame => base.Children.FirstOrDefault((Element x) => x.IdLabel == "login_queue_frame");

	public Vector2i LoginTextboxPosition => GetElementPosition(LoginTextbox);

	public Vector2i PasswordTextboxPosition => GetElementPosition(PasswordTextbox);

	public Vector2i LoginButtonPosition => GetElementPosition(LoginButton);

	public string LoginTextBoxText
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return null;
			}
			return LoginFrame.Children[7].Text;
		}
	}

	public long LoginTextboxTextAddress
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return 0L;
			}
			return LoginFrame.Children[7].Address + 3144L;
		}
	}

	private Element LoginTextbox
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return null;
			}
			return LoginFrame.Children[7];
		}
	}

	private Element PasswordTextbox
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return null;
			}
			return LoginFrame.Children[9];
		}
	}

	public long PasswordTextboxTextAddress
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return 0L;
			}
			return LoginFrame.Children[9].Address + 3144L;
		}
	}

	public GatewayComboBoxElement GatewayComboBox
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return null;
			}
			return CreateObject<GatewayComboBoxElement>(LoginFrame.Children[11].Address);
		}
	}

	public Element LoginButton
	{
		get
		{
			if (!(LoginFrame != null))
			{
				return null;
			}
			return LoginFrame.Children[13];
		}
	}

	private Vector2i GetElementPosition(Element element)
	{
		float num = element.X + element.Width / 2f;
		float num2 = element.Y + element.Height / 2f;
		float x = element.Parent.X;
		float y = element.Parent.Y;
		return new Vector2i((int)((num + x) * element.Scale), (int)((num2 + y) * element.Scale));
	}
}
