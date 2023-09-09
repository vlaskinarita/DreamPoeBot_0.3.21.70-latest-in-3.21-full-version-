using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using DreamPoeBot.Framework;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Hooks;

internal static class Hooking
{
	public static IntPtr HookingdataIntPtr;

	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	private static long _dPBTimer = 0L;

	internal static bool IsInstalled { get; private set; } = false;


	internal static bool InitializeHook(Process process)
	{
		try
		{
			HookingdataIntPtr = Interop.VirtualAllocEx(LokiPoe.Memory.procHandle, IntPtr.Zero, 4096u, Interop.AllocationType.Commit, Interop.MemoryProtection.ReadWrite);
			byte[] data = new byte[4096];
			LokiPoe.Memory.WriteMem(HookingdataIntPtr.ToInt64(), data);
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 992L, 0);
			LokiPoe.Memory.Writelong(HookingdataIntPtr.ToInt64() + 768L, 1L);
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 776L, 50);
			HookManager.SetKey(GlobalSettings.Instance.AuthKey);
			if (!WinApi.initialize(GlobalSettings.Instance.AuthKey))
			{
				Log.ErrorFormat("[InstallHook] Initialization Failed.", Array.Empty<object>());
				return false;
			}
			string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
			if (!string.IsNullOrEmpty(directoryName))
			{
				Thread thread = new Thread(DPBTimer)
				{
					IsBackground = true
				};
				thread.Start();
				if (WinApi.start_injection("", "", process.MainWindowHandle.ToInt64(), HookingdataIntPtr.ToInt64(), process.Id, GlobalSettings.Instance.AuthKey))
				{
					return true;
				}
				Log.ErrorFormat("[InstallHook] Failed to Start Injection.", Array.Empty<object>());
				return false;
			}
			Log.ErrorFormat("[InstallHook] Failed to get Assembly path.", Array.Empty<object>());
			return false;
		}
		catch (Exception arg)
		{
			Log.ErrorFormat($"[InstallHook] Failed to install hooks. {arg}", Array.Empty<object>());
			return false;
		}
	}

	private static void DPBTimer()
	{
		while (true)
		{
			_dPBTimer++;
			LokiPoe.Memory.Writelong(HookingdataIntPtr.ToInt64() + 768L, _dPBTimer);
			byte b = LokiPoe.Memory.ReadByte(HookingdataIntPtr.ToInt64() + 994L);
			if (b == 1 && LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion != null)
			{
				LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion(null, new LokiPoe.ProcessHookManager.HookDisabledByIngecionEventArgs("The Injection failed to authenticate your key more than 5 times, this usually indicate that the time on your key is over, or that your not able to reach the authentication server."));
			}
			Thread.Sleep(1000);
		}
	}

	internal static void Deinitialize()
	{
		LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 992L, 1);
	}

	internal static bool InstallHook()
	{
		try
		{
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 993L, 1);
			IsInstalled = true;
			return true;
		}
		catch (Exception arg)
		{
			IsInstalled = false;
			Log.ErrorFormat($"[InstallHook] Failed to install Generic hooks. {arg}", Array.Empty<object>());
			return false;
		}
	}

	internal static void RemoveHook()
	{
		try
		{
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 993L, 0);
			Thread.Sleep(1000);
			IsInstalled = false;
		}
		catch (Exception arg)
		{
			Log.ErrorFormat($"[InstallHook] Failed to remove Generic hooks. {arg}", Array.Empty<object>());
		}
	}
}
