using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DreamPoeBot.Loki.Game;

public class GuiTickEventArgs : EventArgs
{
	[CompilerGenerated]
	private Window window_0;

	public Window Window { get; internal set; }

	internal GuiTickEventArgs(Window window)
	{
		Window = window;
	}

	internal GuiTickEventArgs()
	{
	}
}
