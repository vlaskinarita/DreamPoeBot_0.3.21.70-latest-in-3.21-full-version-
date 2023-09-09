using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace DreamPoeBot.Loki.Common;

public static class MouseHook
{
	public delegate void MouseEventDelegate();

	private static Thread thread_0;

	private static volatile bool bool_0;

	[CompilerGenerated]
	private static MouseEventDelegate mouseEventDelegate_0;

	[CompilerGenerated]
	private static MouseEventDelegate mouseEventDelegate_1;

	private static bool Boolean_0
	{
		get
		{
			if ((GetAsyncKeyState(Keys.LButton) & 0x8001) == 0 && (GetAsyncKeyState(Keys.RButton) & 0x8001) == 0)
			{
				return (GetAsyncKeyState(Keys.MButton) & 0x8001) != 0;
			}
			return true;
		}
	}

	public static event MouseEventDelegate OnButtonDown
	{
		[CompilerGenerated]
		add
		{
			MouseEventDelegate mouseEventDelegate = mouseEventDelegate_0;
			MouseEventDelegate mouseEventDelegate2;
			do
			{
				mouseEventDelegate2 = mouseEventDelegate;
				MouseEventDelegate value2 = (MouseEventDelegate)Delegate.Combine(mouseEventDelegate2, value);
				mouseEventDelegate = Interlocked.CompareExchange(ref mouseEventDelegate_0, value2, mouseEventDelegate2);
			}
			while (mouseEventDelegate != mouseEventDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventDelegate mouseEventDelegate = mouseEventDelegate_0;
			MouseEventDelegate mouseEventDelegate2;
			do
			{
				mouseEventDelegate2 = mouseEventDelegate;
				MouseEventDelegate value2 = (MouseEventDelegate)Delegate.Remove(mouseEventDelegate2, value);
				mouseEventDelegate = Interlocked.CompareExchange(ref mouseEventDelegate_0, value2, mouseEventDelegate2);
			}
			while (mouseEventDelegate != mouseEventDelegate2);
		}
	}

	public static event MouseEventDelegate OnButtonUp
	{
		[CompilerGenerated]
		add
		{
			MouseEventDelegate mouseEventDelegate = mouseEventDelegate_1;
			MouseEventDelegate mouseEventDelegate2;
			do
			{
				mouseEventDelegate2 = mouseEventDelegate;
				MouseEventDelegate value2 = (MouseEventDelegate)Delegate.Combine(mouseEventDelegate2, value);
				mouseEventDelegate = Interlocked.CompareExchange(ref mouseEventDelegate_1, value2, mouseEventDelegate2);
			}
			while (mouseEventDelegate != mouseEventDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventDelegate mouseEventDelegate = mouseEventDelegate_1;
			MouseEventDelegate mouseEventDelegate2;
			do
			{
				mouseEventDelegate2 = mouseEventDelegate;
				MouseEventDelegate value2 = (MouseEventDelegate)Delegate.Remove(mouseEventDelegate2, value);
				mouseEventDelegate = Interlocked.CompareExchange(ref mouseEventDelegate_1, value2, mouseEventDelegate2);
			}
			while (mouseEventDelegate != mouseEventDelegate2);
		}
	}

	internal static void CreateMousePollingThread()
	{
		if (thread_0 == null || !thread_0.IsAlive)
		{
			thread_0 = new Thread(smethod_1)
			{
				IsBackground = true,
				Name = "Mouse Polling Thread"
			};
			thread_0.Start();
		}
	}

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern short GetAsyncKeyState(Keys keys_0);

	private static void smethod_1()
	{
		while (true)
		{
			Thread.Sleep(100);
			if (!Hotkeys.IsGameWindowForeground)
			{
				if (bool_0)
				{
					if (mouseEventDelegate_1 != null)
					{
						mouseEventDelegate_1();
					}
					bool_0 = false;
				}
			}
			else if (!Boolean_0)
			{
				if (bool_0)
				{
					if (mouseEventDelegate_1 != null)
					{
						mouseEventDelegate_1();
					}
					bool_0 = false;
				}
			}
			else if (!bool_0)
			{
				if (mouseEventDelegate_0 != null)
				{
					mouseEventDelegate_0();
				}
				bool_0 = true;
			}
		}
	}
}
