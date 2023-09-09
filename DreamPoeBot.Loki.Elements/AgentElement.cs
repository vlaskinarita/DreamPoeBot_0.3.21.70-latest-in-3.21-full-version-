using System;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class AgentElement : Element
{
	public string Name => base.Children[2]?.Children[0]?.Text;

	public int Level
	{
		get
		{
			string value = base.Children[1]?.Children[0]?.Text;
			if (string.IsNullOrEmpty(value))
			{
				return -1;
			}
			return Convert.ToInt32(value);
		}
	}

	public int Cost
	{
		get
		{
			string text = base.Children[4]?.Children[1]?.Text;
			if (string.IsNullOrEmpty(text))
			{
				return -1;
			}
			return Convert.ToInt32(text.TrimStart('x'));
		}
	}

	public void Select()
	{
		Vector2i pos = LokiPoe.ElementClickLocation(this);
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(30);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(30);
	}
}
