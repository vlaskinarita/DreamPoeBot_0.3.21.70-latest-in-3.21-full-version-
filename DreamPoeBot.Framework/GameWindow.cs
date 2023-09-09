using System;
using System.Diagnostics;
using System.Drawing;
using DreamPoeBot.Common;

namespace DreamPoeBot.Framework;

public class GameWindow
{
	private readonly IntPtr handle;

	public Process Process { get; private set; }

	public GameWindow(Process process)
	{
		Process = process;
		handle = process.MainWindowHandle;
	}

	public RectangleF GetWindowRectangle()
	{
		return GetWindowRectangleReal();
	}

	public RectangleF GetWindowRectangleReal()
	{
		Rectangle clientRectangle = WinApi.GetClientRectangle(handle);
		return new RectangleF(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, clientRectangle.Height);
	}

	public bool IsForeground()
	{
		return WinApi.IsForegroundWindow(handle);
	}

	public Vector2 ScreenToClient(int x, int y)
	{
		Point lpPoint = new Point(x, y);
		WinApi.ScreenToClient(handle, ref lpPoint);
		return new Vector2(lpPoint.X, lpPoint.Y);
	}
}
