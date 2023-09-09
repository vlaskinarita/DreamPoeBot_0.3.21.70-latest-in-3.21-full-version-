using System.Diagnostics;
using System.Threading;

namespace DreamPoeBot.Loki.Elements;

public class PoeChatElement : Element
{
	internal Element CurrentMessageElement
	{
		get
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (base.ChildCount < 4L)
			{
				if (stopwatch.ElapsedMilliseconds <= 1000L)
				{
					Thread.Sleep(30);
					continue;
				}
				return null;
			}
			return base.Children[3];
		}
	}
}
