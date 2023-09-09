using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace DreamPoeBot.Loki.Game;

[SuppressUnmanagedCodeSecurity]
public static class Interop
{
	[Flags]
	internal enum AllocationType
	{
		Commit = 0x1000,
		Reserve = 0x2000,
		Decommit = 0x4000,
		Release = 0x8000,
		Reset = 0x80000,
		Physical = 0x400000,
		TopDown = 0x100000,
		WriteWatch = 0x200000,
		LargePages = 0x20000000
	}

	[Flags]
	internal enum MemoryProtection
	{
		Execute = 0x10,
		ExecuteRead = 0x20,
		ExecuteReadWrite = 0x40,
		ExecuteWriteCopy = 0x80,
		NoAccess = 1,
		ReadOnly = 2,
		ReadWrite = 4,
		WriteCopy = 8,
		GuardModifierflag = 0x100,
		NoCacheModifierflag = 0x200,
		WriteCombineModifierflag = 0x400
	}

	public enum Cmd
	{
		Hide,
		Normal,
		ShowMinimized,
		Maximize,
		ShowNoActivate,
		Show,
		Minimize,
		ShowMinNoActive,
		ShowNA,
		Restore,
		ShowDefault,
		ForceMinimize
	}

	public enum Protection
	{
		PAGE_NOACCESS = 1,
		PAGE_READONLY = 2,
		PAGE_READWRITE = 4,
		PAGE_WRITECOPY = 8,
		PAGE_EXECUTE = 0x10,
		PAGE_EXECUTE_READ = 0x20,
		PAGE_EXECUTE_READWRITE = 0x40,
		PAGE_EXECUTE_WRITECOPY = 0x80,
		PAGE_GUARD = 0x100,
		PAGE_NOCACHE = 0x200,
		PAGE_WRITECOMBINE = 0x400
	}

	public delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

	public struct WindowInfoWin32
	{
		public uint Size;

		public RectWin32 Window;

		public RectWin32 Client;

		public uint Style;

		public uint ExStyle;

		public uint WindowStatus;

		public uint WindowBordersX;

		public uint WindowBordersY;

		public ushort WindowType;

		public ushort CreatorVersion;
	}

	public struct RectWin32
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;

		public override string ToString()
		{
			return $"Left: {Left}, Top: {Top}, Right: {Right}, Bottom: {Bottom}";
		}
	}

	private sealed class Class261
	{
		public List<IntPtr> list_0;

		public EnumThreadDelegate enumThreadDelegate_0;

		internal bool method_0(IntPtr intptr_0, IntPtr intptr_1)
		{
			list_0.Add(intptr_0);
			return true;
		}
	}

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GetModuleHandle(string libname);

	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SetWindowText(IntPtr hWnd, string text);

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowInfo(IntPtr hWnd, ref WindowInfoWin32 pwi);

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCursorPos(int x, int y);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint GetTickCount();

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint MapVirtualKeyW(uint uCode, uint uMapType);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

	[DllImport("USER32.DLL")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, uint processId);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

	[DllImport("kernel32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool DebugActiveProcess(uint uint_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool DebugActiveProcessStop(uint uint_0);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool DebugSetProcessKillOnExit(uint uint_0);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ShowWindow(IntPtr hWnd, Cmd cmd);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsIconic(IntPtr hWnd);

	public static char MapVirtualKeyEx(Keys key)
	{
		return (char)MapVirtualKeyEx((uint)key, 2u, InputLanguage.CurrentInputLanguage.Handle);
	}

	internal static IntPtr smethod_0(Process process_0, string string_0)
	{
		foreach (IntPtr item in smethod_1(process_0))
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			GetClassName(item, stringBuilder, stringBuilder.Capacity);
			if (stringBuilder.ToString() == string_0)
			{
				return item;
			}
		}
		return IntPtr.Zero;
	}

	internal static IEnumerable<IntPtr> smethod_1(Process process_0)
	{
		Class261 @class = new Class261();
		@class.list_0 = new List<IntPtr>();
		foreach (object thread in process_0.Threads)
		{
			int id = ((ProcessThread)thread).Id;
			EnumThreadDelegate lpfn;
			if ((lpfn = @class.enumThreadDelegate_0) == null)
			{
				lpfn = (@class.enumThreadDelegate_0 = @class.method_0);
			}
			EnumThreadWindows(id, lpfn, IntPtr.Zero);
		}
		return @class.list_0;
	}
}
