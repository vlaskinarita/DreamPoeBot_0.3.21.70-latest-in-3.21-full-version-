using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;
using log4net;

namespace DreamPoeBot.Loki.Common;

public static class Hotkeys
{
	[CompilerGenerated]
	private sealed class Class395
	{
		public MSG msg_0;

		public Func<Hotkey, bool> func_0;

		internal bool method_0(Hotkey hotkey_0)
		{
			return hotkey_0.Id == (int)msg_0.wParam;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly List<Hotkey> _registeredHotkeys = new List<Hotkey>();

	private const int int_0 = 786;

	private static bool isInitialized;

	private static IntPtr address;

	private static int int_1;

	private static Thread thread;

	private static readonly Queue<Hotkey> hotkeyToRegister = new Queue<Hotkey>();

	private static readonly Queue<Hotkey> hotkeysToUnregister = new Queue<Hotkey>();

	public static IEnumerable<Hotkey> RegisteredHotkeys => _registeredHotkeys.AsReadOnly();

	internal static bool IsGameWindowForeground => GetForegroundWindow() == address;

	public static Hotkey Register(string name, Keys key, ModifierKeys modifierKeys, Action<Hotkey> callback)
	{
		Hotkey hotkey = new Hotkey(name, key, modifierKeys, int_1++, callback);
		hotkeyToRegister.Enqueue(hotkey);
		ProcessHotkeyLoop();
		return hotkey;
	}

	public static void Unregister(string name)
	{
		Hotkey hotkey = _registeredHotkeys.FirstOrDefault((Hotkey x) => x.Name == name);
		if (hotkey != null)
		{
			Unregister(hotkey);
		}
	}

	public static void Unregister(Hotkey hotkey)
	{
		if (hotkey != null)
		{
			hotkeysToUnregister.Enqueue(hotkey);
		}
	}

	public static void Initialize(IntPtr windowHandleToWatch)
	{
		if (!isInitialized)
		{
			MouseHook.CreateMousePollingThread();
			address = windowHandleToWatch;
			isInitialized = true;
		}
	}

	private static void ExecuteRegisterHotKey(Hotkey hotkey_0)
	{
		if (!hotkey_0.IsRegistered && RegisterHotKey(IntPtr.Zero, hotkey_0.Id, (uint)hotkey_0.ModifierKeys, (uint)hotkey_0.Key))
		{
			hotkey_0.IsRegistered = true;
		}
	}

	private static void ExecuteUnRegisterHotKey(Hotkey hotkey_0)
	{
		if (hotkey_0.IsRegistered && UnregisterHotKey(IntPtr.Zero, hotkey_0.Id))
		{
			hotkey_0.IsRegistered = false;
		}
	}

	private static void ProcessHotkeyLoop()
	{
		if (thread == null)
		{
			thread = new Thread(ThreadLoop)
			{
				Name = "Hotkey Processing Loop",
				IsBackground = true
			};
			thread.Start();
		}
	}

	private static void ThreadLoop()
	{
		while (true)
		{
			if (hotkeyToRegister.Count == 0)
			{
				while (hotkeysToUnregister.Count != 0)
				{
					Hotkey hotkey = hotkeysToUnregister.Dequeue();
					ExecuteUnRegisterHotKey(hotkey);
					_registeredHotkeys.Remove(hotkey);
				}
				if (!IsGameWindowForeground)
				{
					foreach (Hotkey registeredHotkey in _registeredHotkeys)
					{
						ExecuteUnRegisterHotKey(registeredHotkey);
					}
					Thread.Sleep(100);
					continue;
				}
				foreach (Hotkey registeredHotkey2 in _registeredHotkeys)
				{
					ExecuteRegisterHotKey(registeredHotkey2);
				}
				MouseHook.CreateMousePollingThread();
				smethod_4();
				Thread.Sleep(100);
			}
			else
			{
				Hotkey hotkey2 = hotkeyToRegister.Dequeue();
				ExecuteRegisterHotKey(hotkey2);
				_registeredHotkeys.Add(hotkey2);
			}
		}
	}

	private static void smethod_4()
	{
		MSG msg_0;
		Func<Hotkey, bool> func_0 = default(Func<Hotkey, bool>);
		while (PeekMessage(out msg_0, IntPtr.Zero, 786u, 786u, 1u))
		{
			IEnumerable<Hotkey> registeredHotkeys = RegisteredHotkeys;
			Func<Hotkey, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = (Hotkey hotkey_0) => hotkey_0.Id == (int)msg_0.wParam);
			}
			Hotkey hotkey = registeredHotkeys.FirstOrDefault(predicate);
			if (hotkey != null)
			{
				ilog_0.DebugFormat(hotkey.Name + " pressed.", Array.Empty<object>());
				hotkey.Callback(hotkey);
			}
		}
	}

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool RegisterHotKey(IntPtr intptr_1, int int_2, uint uint_0, uint uint_1);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool UnregisterHotKey(IntPtr intptr_1, int int_2);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool PeekMessage(out MSG msg_0, IntPtr intptr_1, uint uint_0, uint uint_1, uint uint_2);
}
