using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.Structures.ns24;

namespace DreamPoeBot.Loki.Common.Controls;

public class FolderBrowserDialogEx : CommonDialog
{
	private class Class414
	{
		public const int int_0 = 0;

		public const int int_1 = 4096;

		public const int int_2 = 8192;

		public const int int_3 = 16384;

		public const int int_4 = 128;

		public const int int_5 = 2;

		public const int int_6 = 16;

		public const int int_7 = 64;

		public const int int_8 = 512;

		public const int int_9 = 8;

		public const int int_10 = 1;

		public const int int_11 = 32768;

		public const int int_12 = 4;

		public const int int_13 = 256;

		public const int int_14 = 32;

		public const int int_15 = 1024;
	}

	private static class Class415
	{
		public const int int_0 = 1;

		public const int int_1 = 2;

		public const int int_2 = 3;

		public const int int_3 = 4;

		public const int int_4 = 5;

		public const int int_5 = 1124;

		public const int int_6 = 1125;

		public const int int_7 = 1126;

		public const int int_8 = 1127;
	}

	private class Class416
	{
		public const int int_0 = 4;

		public const int int_1 = 18;
	}

	private static readonly int int_0 = 260;

	private Class417.Delegate3 delegate3_0;

	private string string_0;

	private bool bool_0;

	private IntPtr intptr_0;

	private bool bool_1 = true;

	private Environment.SpecialFolder specialFolder_0;

	private IntPtr intptr_1;

	private string string_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private bool bool_6;

	private int int_1;

	public string Description
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = ((value == null) ? string.Empty : value);
		}
	}

	public Environment.SpecialFolder RootFolder
	{
		get
		{
			return specialFolder_0;
		}
		set
		{
			if (!Enum.IsDefined(typeof(Environment.SpecialFolder), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(Environment.SpecialFolder));
			}
			specialFolder_0 = value;
		}
	}

	public string SelectedPath
	{
		get
		{
			if (string_1 != null && string_1.Length != 0 && bool_2)
			{
				((FolderBrowserDialogEx)(object)new FileIOPermission(FileIOPermissionAccess.PathDiscovery, string_1)).method_3();
				bool_2 = false;
			}
			return string_1;
		}
		set
		{
			string_1 = ((value == null) ? string.Empty : value);
			bool_2 = true;
		}
	}

	public bool ShowNewFolderButton
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool ShowEditBox
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool NewStyle
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool DontIncludeNetworkFoldersBelowDomainLevel
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool ShowFullPathInEditBox
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool ShowBothFilesAndFolders
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public new event EventHandler HelpRequest
	{
		add
		{
			base.HelpRequest += value;
		}
		remove
		{
			base.HelpRequest -= value;
		}
	}

	public FolderBrowserDialogEx()
	{
		Reset();
	}

	public static FolderBrowserDialogEx PrinterBrowser()
	{
		FolderBrowserDialogEx folderBrowserDialogEx = new FolderBrowserDialogEx();
		folderBrowserDialogEx.method_0();
		return folderBrowserDialogEx;
	}

	public static FolderBrowserDialogEx ComputerBrowser()
	{
		FolderBrowserDialogEx folderBrowserDialogEx = new FolderBrowserDialogEx();
		folderBrowserDialogEx.method_1();
		return folderBrowserDialogEx;
	}

	private void method_0()
	{
		int_1 += 8192;
		Description = "Select a printer:";
		Class417.Class419.SHGetSpecialFolderLocation(IntPtr.Zero, 4, ref intptr_1);
		ShowNewFolderButton = false;
		ShowEditBox = false;
	}

	private void method_1()
	{
		int_1 += 4096;
		Description = "Select a computer:";
		Class417.Class419.SHGetSpecialFolderLocation(IntPtr.Zero, 18, ref intptr_1);
		ShowNewFolderButton = false;
		ShowEditBox = false;
	}

	private int method_2(IntPtr intptr_2, int int_2, IntPtr intptr_3, IntPtr intptr_4)
	{
		switch (int_2)
		{
		case 2:
			if (!(intptr_3 != IntPtr.Zero))
			{
				break;
			}
			if ((int_1 & 0x2000) != 8192 && (int_1 & 0x1000) != 4096)
			{
				IntPtr intPtr = Marshal.AllocHGlobal(int_0 * Marshal.SystemDefaultCharSize);
				bool flag = Class417.Class419.SHGetPathFromIDList(intptr_3, intPtr);
				string value = Marshal.PtrToStringAuto(intPtr);
				Marshal.FreeHGlobal(intPtr);
				Class417.Class420.SendMessage_1(new HandleRef(null, intptr_2), 1125, 0, flag ? 1 : 0);
				if (flag && !string.IsNullOrEmpty(value))
				{
					if (bool_4 && bool_5 && intptr_0 != IntPtr.Zero)
					{
						Class417.Class420.SetWindowText(intptr_0, value);
					}
					if ((int_1 & 4) != 4)
					{
						return 0;
					}
					Class417.Class420.SendMessage(new HandleRef(null, intptr_2), 1124, 0, value);
					return 0;
				}
				return 0;
			}
			Class417.Class420.SendMessage_1(new HandleRef(null, intptr_2), 1125, 0, 1);
			break;
		case 1:
			if (string_1.Length != 0)
			{
				Class417.Class420.SendMessage(new HandleRef(null, intptr_2), 1127, 1, string_1);
				if (bool_4 && bool_5)
				{
					intptr_0 = Class417.Class420.FindWindowEx(new HandleRef(null, intptr_2), IntPtr.Zero, "Edit", null);
					Class417.Class420.SetWindowText(intptr_0, string_1);
				}
			}
			break;
		}
		return 0;
	}

	private static Class417.Interface8 smethod_0()
	{
		Class417.Interface8[] array = new Class417.Interface8[1];
		Class417.Class419.SHGetMalloc(array);
		return array[0];
	}

	public override void Reset()
	{
		specialFolder_0 = Environment.SpecialFolder.Desktop;
		string_0 = string.Empty;
		string_1 = string.Empty;
		bool_2 = false;
		bool_6 = true;
		bool_4 = true;
		bool_1 = true;
		bool_0 = false;
		intptr_0 = IntPtr.Zero;
		intptr_1 = IntPtr.Zero;
	}

	protected override bool RunDialog(IntPtr hWndOwner)
	{
		bool result = false;
		if (intptr_1 == IntPtr.Zero)
		{
			Class417.Class419.SHGetSpecialFolderLocation(hWndOwner, (int)specialFolder_0, ref intptr_1);
			if (intptr_1 == IntPtr.Zero)
			{
				Class417.Class419.SHGetSpecialFolderLocation(hWndOwner, 0, ref intptr_1);
				if (intptr_1 == IntPtr.Zero)
				{
					throw new InvalidOperationException("FolderBrowserDialogNoRootFolder");
				}
			}
		}
		intptr_0 = IntPtr.Zero;
		if (bool_0)
		{
			int_1 += 2;
		}
		if (bool_1)
		{
			int_1 += 64;
		}
		if (!bool_6)
		{
			int_1 += 512;
		}
		if (bool_4)
		{
			int_1 += 16;
		}
		if (bool_3)
		{
			int_1 += 16384;
		}
		if (Control.CheckForIllegalCrossThreadCalls && Application.OleRequired() != 0)
		{
			throw new ThreadStateException("DebuggingException: ThreadMustBeSTA");
		}
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		try
		{
			Class417.Class418 @class = new Class417.Class418();
			intPtr2 = Marshal.AllocHGlobal(int_0 * Marshal.SystemDefaultCharSize);
			intPtr3 = Marshal.AllocHGlobal(int_0 * Marshal.SystemDefaultCharSize);
			delegate3_0 = method_2;
			@class.intptr_1 = intptr_1;
			@class.intptr_0 = hWndOwner;
			@class.intptr_2 = intPtr2;
			@class.string_0 = string_0;
			@class.int_0 = int_1;
			@class.delegate3_0 = delegate3_0;
			@class.intptr_3 = IntPtr.Zero;
			@class.int_1 = 0;
			intPtr = Class417.Class419.SHBrowseForFolder(@class);
			if ((int_1 & 0x2000) == 8192 || (int_1 & 0x1000) == 4096)
			{
				string_1 = Marshal.PtrToStringAuto(@class.intptr_2);
				return true;
			}
			if (intPtr != IntPtr.Zero)
			{
				Class417.Class419.SHGetPathFromIDList(intPtr, intPtr3);
				bool_2 = true;
				string_1 = Marshal.PtrToStringAuto(intPtr3);
				result = true;
			}
			return result;
		}
		finally
		{
			Class417.Interface8 @interface = smethod_0();
			@interface.Free(intptr_1);
			intptr_1 = IntPtr.Zero;
			if (intPtr != IntPtr.Zero)
			{
				@interface.Free(intPtr);
			}
			if (intPtr3 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr3);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr2);
			}
			delegate3_0 = null;
		}
	}

	void method_3()
	{
		((CodeAccessPermission)(object)this).Demand();
	}
}
