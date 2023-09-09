using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using DreamPoeBot.Framework.Enums;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Framework;

[SuppressUnmanagedCodeSecurity]
public static class WinApi
{
	private struct Margins
	{
		private int left;

		private int right;

		private int top;

		private int bottom;

		public static Margins FromRectangle(Rectangle rectangle)
		{
			Margins result = default(Margins);
			result.left = rectangle.Left;
			result.right = rectangle.Right;
			result.top = rectangle.Top;
			result.bottom = rectangle.Bottom;
			return result;
		}
	}

	private struct Rect
	{
		private readonly int left;

		private readonly int top;

		private readonly int right;

		private readonly int bottom;

		public Rectangle ToRectangle(Point point)
		{
			return new Rectangle(point.X, point.Y, right - left, bottom - top);
		}
	}

	private const int GWL_EXSTYLE = -20;

	private const int WS_EX_LAYERED = 524288;

	private const int WS_EX_TRANSPARENT = 32;

	private const int LWA_ALPHA = 2;

	private static Delegate GetSysCallDelegate(byte[] identifyer, Type T)
	{
		try
		{
			byte[] array = new byte[11]
			{
				76, 139, 209, 184, 0, 0, 0, 0, 15, 5,
				195
			};
			Buffer.BlockCopy(identifyer, 0, array, 4, 4);
			IntPtr handle = Process.GetCurrentProcess().Handle;
			IntPtr intPtr = Interop.VirtualAllocEx(handle, IntPtr.Zero, (uint)array.Length, Interop.AllocationType.Commit | Interop.AllocationType.Reserve, Interop.MemoryProtection.ExecuteReadWrite);
			if (intPtr == IntPtr.Zero)
			{
				throw new Exception("VirtualAlloc did not return a valid address" + Marshal.GetLastWin32Error());
			}
			Marshal.Copy(array, 0, intPtr, array.Length);
			return Marshal.GetDelegateForFunctionPointer(intPtr, T);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			throw;
		}
	}

	public static void EnableTransparent(IntPtr handle, Rectangle size)
	{
		int value = GetWindowLong(handle, -20) | 0x80000 | 0x20;
		SetWindowLong(handle, -20, new IntPtr(value));
		SetLayeredWindowAttributes(handle, 0u, byte.MaxValue, 2u);
		Margins pMarInset = Margins.FromRectangle(size);
		DwmExtendFrameIntoClientArea(handle, ref pMarInset);
	}

	public static Rectangle GetClientRectangle(IntPtr handle)
	{
		GetClientRect(handle, out var lpRect);
		ClientToScreen(handle, out var lpPoint);
		return lpRect.ToRectangle(lpPoint);
	}

	public static bool IsForegroundWindow(IntPtr handle)
	{
		return GetForegroundWindow() == handle;
	}

	public static bool IsKeyDown(Keys key)
	{
		return (GetAsyncKeyState(key) & 0x8000) != 0;
	}

	public static IntPtr OpenProcess(Process process, ProcessAccessFlags flags)
	{
		return OpenProcess(flags, bInheritHandle: false, process.Id);
	}

	public static bool WriteProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer)
	{
		IntPtr bytesWritten;
		return WriteProcessMemory(handle, baseAddress, buffer, buffer.Length, out bytesWritten);
	}

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsIconic(IntPtr hWnd);

	[DllImport("psapi")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool EmptyWorkingSet(IntPtr hProcess);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool start_injection(string dllPath, string processName, long mWH, long sharedMemory, long pID, string key);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool initialize(string key);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_server_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_ritual_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_delve_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_waypoint_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_incursion_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool ex_read_blight_data_bytes(long pHandle, long address, int length, byte* ret);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ex_get_patch_offset();

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern int getMagicNumber(int tx, int ty, int rotationselected, byte[] rotatorMatrixHelper, sbyte[] subTileHeightArray, int lenght);

	[DllImport("SoftMagic.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ex_read_objects_data_bytes(long address);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	[SuppressUnmanagedCodeSecurity]
	public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

	[DllImport("ComDlg32.dll", CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ChooseColor(ref ChooseColor chooseColor);

	[DllImport("kernel32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("User32.dll", CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

	[DllImport("kernel32.dll", ExactSpelling = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

	[DllImport("dwmapi.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern short GetAsyncKeyState(Keys vKey);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte* lpBuffer, int dwSize, out int lpNumberOfBytesRead);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool WriteProcessMemory(IntPtr hWnd, IntPtr baseAddr, byte[] buffer, int size, out IntPtr bytesWritten);

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

	[DllImport("user32.dll", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	[DllImport("winmm.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	public static extern short VkKeyScanEx(char ch, IntPtr dwhkl);

	[DllImport("user32.dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GetKeyboardLayout(uint idThread);

	[DllImport("User32.Dll")]
	[SuppressUnmanagedCodeSecurity]
	public static extern long SetCursorPos(int x, int y);
}
