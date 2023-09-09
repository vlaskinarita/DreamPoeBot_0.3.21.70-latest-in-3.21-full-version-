using System;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class TimersPannelElement : Element
{
	private Element ActiveTimerElement => base.Children[0].Children.FirstOrDefault((Element x) => x.IsVisible);

	public bool IsTimerActive
	{
		get
		{
			Element element = ((ActiveTimerElement != null) ? ActiveTimerElement.Children[0] : null);
			if (element == null)
			{
				return false;
			}
			return element.Text != "00:00";
		}
	}

	public TimeSpan Timer
	{
		get
		{
			if (!IsTimerActive)
			{
				return TimeSpan.Parse("00:00");
			}
			return TimeSpan.ParseExact(ActiveTimerElement.Children[0].Text, "mm\\:ss", CultureInfo.InvariantCulture);
		}
	}
}
