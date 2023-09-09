using System;
using System.Diagnostics;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Bot;

internal static class HookManager
{
	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	internal static bool ShouldUpdateCache => LokiPoe.Memory.ReadByte(Hooking.HookingdataIntPtr.ToInt64() + 995L) > 0;

	internal static void Initialize(Process process)
	{
		Hooking.InitializeHook(process);
		long num = 0L;
		long num2 = 0L;
		while (true)
		{
			num = LokiPoe.Memory.ReadLong(Hooking.HookingdataIntPtr.ToInt64() + 1952L);
			if (num != 0L)
			{
				num2 = LokiPoe.Memory.ReadLong(Hooking.HookingdataIntPtr.ToInt64() + 1960L);
				if (num2 != 0L)
				{
					break;
				}
			}
		}
		int num3 = LokiPoe.Memory.ReadInt(num + 3L);
		int num4 = LokiPoe.Memory.ReadInt(num2 + 3L);
		LokiPoe.Memory.offsets.TerrainRotationSelector = LokiPoe.Memory.ReadBytes(num3 + num + 7L, 9);
		LokiPoe.Memory.offsets.TerrainRotationHelper = LokiPoe.Memory.ReadBytes(num4 + num2 + 7L, 24);
	}

	internal static void InstallHook()
	{
		ResetKeyState();
		Hooking.InstallHook();
	}

	internal static void RemoveHook()
	{
		ResetKeyState();
		Hooking.RemoveHook();
	}

	internal static void SetMousePosition(Vector2i point)
	{
		if (point.X >= 0 && point.Y >= 0)
		{
			LokiPoe.Memory.WriteVector2i(Hooking.HookingdataIntPtr.ToInt64(), point);
		}
	}

	internal static Vector2i GetMousePosition()
	{
		return LokiPoe.Memory.ReadVector2i(Hooking.HookingdataIntPtr.ToInt64());
	}

	internal static void SetKeyState(int key, short state)
	{
		LokiPoe.Memory.WriteShort(Hooking.HookingdataIntPtr.ToInt64() + key * 2 + 8L, state);
	}

	internal static short GetKeyState(int key)
	{
		return LokiPoe.Memory.ReadShort(Hooking.HookingdataIntPtr.ToInt64() + key * 2 + 8L);
	}

	internal static void ResetKeyState()
	{
		byte[] data = new byte[512];
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 8L, data);
	}

	internal static void SetClipboard(string text)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(text + "\0\0");
		int data = bytes.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 996L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 1000L, bytes);
	}

	internal static void SetHideoutTemplateDirectory(string directory)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(directory + "\0\0");
		int data = bytes.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 1996L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 2000L, bytes);
	}

	internal static void SetHideoutTemplateFileName(string fileName)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(fileName + "\0\0");
		int data = bytes.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 2996L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 3000L, bytes);
	}

	internal static void SetKey(string text)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		int data = bytes.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 4064L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 4068L, bytes);
	}

	internal static void SetBackgroundFPS(byte fps)
	{
		LokiPoe.Memory.WriteByte(Hooking.HookingdataIntPtr.ToInt64() + 776L, fps);
	}

	internal static byte GetBackgroundFPS()
	{
		return LokiPoe.Memory.ReadByte(Hooking.HookingdataIntPtr.ToInt64() + 776L);
	}

	public static void SetRenderIsDisabled(bool disabled)
	{
		if (disabled)
		{
			LokiPoe.Memory.WriteByte(Hooking.HookingdataIntPtr.ToInt64() + 527L, 1);
		}
		else
		{
			LokiPoe.Memory.WriteByte(Hooking.HookingdataIntPtr.ToInt64() + 527L, 0);
		}
	}

	public static void SetRenderState(bool disabled)
	{
		if (disabled)
		{
			LokiPoe.Memory.WriteByte(Hooking.HookingdataIntPtr.ToInt64() + 995L, 1);
		}
		else
		{
			LokiPoe.Memory.WriteByte(Hooking.HookingdataIntPtr.ToInt64() + 995L, 0);
		}
	}

	internal static void SetDebugPacchetto(byte[] bytes, byte[] trigger)
	{
		int data = bytes.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 528L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 536L, bytes);
		data = trigger.Length;
		LokiPoe.Memory.WriteInt(Hooking.HookingdataIntPtr.ToInt64() + 640L, data);
		LokiPoe.Memory.WriteMem(Hooking.HookingdataIntPtr.ToInt64() + 648L, trigger);
	}

	internal static float GetDataFromTheClient()
	{
		long data = LokiPoe.Memory.ReadLong(GameController.Instance.Game.IngameState.Address + 24L) + 2464L;
		Vector2i data2 = new Vector2i(LokiPoe.LocalData.MyPosition.Y, LokiPoe.LocalData.MyPosition.X);
		Log.WarnFormat(string.Format("[GetDataFromTheClient] My Pos: {0}, {1}, CurrentAreaAddr: {2}.", data2.Y, data2.X, data.ToString("X2")), Array.Empty<object>());
		LokiPoe.Memory.Writelong(Hooking.HookingdataIntPtr.ToInt64() + 1968L, data);
		LokiPoe.Memory.WriteVector2i(Hooking.HookingdataIntPtr.ToInt64() + 1976L, data2);
		LokiPoe.Memory.WriteFloat(Hooking.HookingdataIntPtr.ToInt64() + 1984L, float.MinValue);
		Stopwatch stopwatch = Stopwatch.StartNew();
		float num;
		do
		{
			if (stopwatch.ElapsedMilliseconds <= 1000L)
			{
				num = LokiPoe.Memory.ReadFloat(Hooking.HookingdataIntPtr.ToInt64() + 1984L);
				continue;
			}
			return 0f;
		}
		while (num == float.MinValue);
		return 0f - num * 7.8125f;
	}

	internal static long GetRotationHelper()
	{
		return LokiPoe.Memory.ReadLong(Hooking.HookingdataIntPtr.ToInt64() + 1952L);
	}

	internal static long GetRotationSelector()
	{
		return LokiPoe.Memory.ReadLong(Hooking.HookingdataIntPtr.ToInt64() + 1960L);
	}
}
