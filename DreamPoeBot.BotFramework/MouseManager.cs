using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using DreamPoeBot.Common;
using DreamPoeBot.Framework;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.BotFramework;

public static class MouseManager
{
	private enum side
	{
		None,
		Left,
		Righ,
		Top,
		Bottom
	}

	private class Movepos
	{
		public Vector2i Pos { get; set; }

		public int Delay { get; set; }

		public Movepos(int x, int y, int delay)
		{
			Pos = new Vector2i(x, y);
			Delay = delay;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private const int mouseMovepause = 30;

	private const int clickpause = 10;

	private static Stopwatch limiter = Stopwatch.StartNew();

	private static readonly double sqrt2 = Math.Sqrt(2.0);

	private static readonly double sqrt3 = Math.Sqrt(3.0);

	private static readonly double sqrt5 = Math.Sqrt(5.0);

	public static bool DebugCursor = false;

	private static Thread _mouseThread;

	private static volatile bool shouldRunThread = false;

	private static volatile float mouseXThread = 0f;

	private static volatile float mouseYThread = 0f;

	private static volatile float mouseZThread = 0f;

	private static volatile string reasonThread;

	private static int MousePoseX { get; set; }

	private static int MousePoseY { get; set; }

	public static bool LogEvents { get; set; }

	public static IMouseHandler Instance { get; set; }

	private static Vector2i EnsureMouseIsInside(int posX, int posY)
	{
		RectangleF windowRectangle = GameController.Instance.Window.GetWindowRectangle();
		int x = (int)(windowRectangle.Width / 2f);
		int y = (int)(windowRectangle.Height / 2f);
		Vector2i v = new Vector2i(x, y);
		if (!windowRectangle.Contains(posX, posY))
		{
			Vector2i end = new Vector2i(posX, posY);
			int num = end.Distance(v);
			int num2 = num;
			while (num2 >= 0)
			{
				Vector2i pointAtDistanceBeforeEnd = v.GetPointAtDistanceBeforeEnd(end, num2);
				if (!windowRectangle.Contains(pointAtDistanceBeforeEnd.X, pointAtDistanceBeforeEnd.Y))
				{
					num2--;
					continue;
				}
				return pointAtDistanceBeforeEnd;
			}
		}
		return new Vector2i(posX, posY);
	}

	private static void MoveMouse(int cx, int cy, bool sleep = true)
	{
		if (cx >= 0 && cy >= 0)
		{
			Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 512, IntPtr.Zero, (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16)));
			if (sleep)
			{
				Thread.Sleep(LokiPoe.Random.Next(0, 4));
			}
		}
	}

	private static Vector2i NormalizePosition(Vector2i position)
	{
		IntPtr clientWindowHandle = LokiPoe.ClientWindowHandle;
		if (!WinApi.IsIconic(clientWindowHandle))
		{
			RectangleF windowRectangleReal = GameController.Instance.Window.GetWindowRectangleReal();
			return PointOnRect(position, windowRectangleReal);
		}
		return position;
	}

	private static Vector2i PointOnRect(Vector2i dest, RectangleF rectangle)
	{
		Vector2i result = new Vector2i(dest.X + (int)rectangle.Location.X, dest.Y + (int)rectangle.Location.Y);
		if (rectangle.Contains(result.X, result.Y))
		{
			return dest;
		}
		float num = (rectangle.Left + rectangle.Right) / 2f;
		float num2 = (rectangle.Top + rectangle.Bottom) / 2f;
		if (result.X == (int)num && result.Y == (int)num2)
		{
			return result;
		}
		Vector2 b = new Vector2(rectangle.Left + 3f, rectangle.Top + 3f);
		Vector2 vector = new Vector2(rectangle.Right - 3f, rectangle.Top + 3f);
		Vector2 vector2 = new Vector2(rectangle.Left + 3f, rectangle.Bottom - 3f);
		Vector2 b2 = new Vector2(rectangle.Right - 3f, rectangle.Bottom - 3f);
		Vector2 a = new Vector2(num, num2);
		List<side> list = new List<side>();
		if ((float)result.X < num)
		{
			list.Add(side.Left);
		}
		else if ((float)result.X > num)
		{
			list.Add(side.Righ);
		}
		if ((float)result.Y < num2)
		{
			list.Add(side.Top);
		}
		else if ((float)result.Y > num2)
		{
			list.Add(side.Bottom);
		}
		using List<side>.Enumerator enumerator = list.GetEnumerator();
		uint num3 = default(uint);
		Vector2i result2 = default(Vector2i);
		Vector2 intersection = default(Vector2);
		Vector2 intersection2 = default(Vector2);
		Vector2 intersection3 = default(Vector2);
		Vector2 intersection4 = default(Vector2);
		while (enumerator.MoveNext())
		{
			while (true)
			{
				side current = enumerator.Current;
				while (true)
				{
					switch (current)
					{
					case side.Left:
						goto IL_0220;
					case side.Righ:
						goto IL_0237;
					case side.Top:
						goto IL_024f;
					case side.Bottom:
						goto IL_0266;
					}
					int num4 = (int)((num3 * 636416874) ^ 0x24FF577);
					while (true)
					{
						switch ((num3 = (uint)num4 ^ 0xFFA01098u) % 16u)
						{
						case 5u:
							num4 = ((int)num3 * -876192409) ^ -752411623;
							continue;
						case 1u:
							break;
						case 12u:
						case 15u:
							goto end_IL_01f7;
						case 14u:
							goto IL_0220;
						case 4u:
							goto IL_0237;
						case 7u:
							goto IL_024f;
						case 0u:
							goto IL_0266;
						case 2u:
							goto end_IL_0215;
						case 10u:
							goto IL_028d;
						case 13u:
							goto IL_02b9;
						case 9u:
							goto IL_02e2;
						case 8u:
							goto IL_030b;
						case 6u:
							return result2;
						case 11u:
							return result2;
						default:
							return dest;
						case 3u:
							return dest;
						}
						break;
					}
					continue;
					IL_0220:
					if (!Intersects(a, result.ToVector2(), b, vector2, out intersection))
					{
						goto end_IL_0215;
					}
					goto IL_028d;
					IL_028d:
					return new Vector2i((int)(intersection.X - rectangle.Left), (int)(intersection.Y - rectangle.Top));
					IL_0266:
					if (!Intersects(a, result.ToVector2(), vector2, b2, out intersection2))
					{
						goto end_IL_0215;
					}
					goto IL_030b;
					IL_030b:
					return new Vector2i((int)(intersection2.X - rectangle.Left), (int)(intersection2.Y - rectangle.Top));
					IL_024f:
					if (!Intersects(a, result.ToVector2(), b, vector, out intersection3))
					{
						goto end_IL_0215;
					}
					goto IL_02e2;
					IL_02e2:
					return new Vector2i((int)(intersection3.X - rectangle.Left), (int)(intersection3.Y - rectangle.Top));
					IL_0237:
					if (!Intersects(a, result.ToVector2(), vector, b2, out intersection4))
					{
						goto end_IL_0215;
					}
					goto IL_02b9;
					IL_02b9:
					return new Vector2i((int)(intersection4.X - rectangle.Left), (int)(intersection4.Y - rectangle.Top));
					continue;
					end_IL_01f7:
					break;
				}
				continue;
				end_IL_0215:
				break;
			}
		}
		return dest;
	}

	private static bool Intersects(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2, out Vector2 intersection)
	{
		intersection = Vector2.Zero;
		Vector2 vector = a2 - a1;
		Vector2 vector2 = b2 - b1;
		float num = vector.X * vector2.Y - vector.Y * vector2.X;
		if (num != 0f)
		{
			Vector2 vector3 = b1 - a1;
			float num2 = (vector3.X * vector2.Y - vector3.Y * vector2.X) / num;
			if (!(num2 < 0f) && num2 <= 1f)
			{
				float num3 = (vector3.X * vector.Y - vector3.Y * vector.X) / num;
				if (!(num3 < 0f) && num3 <= 1f)
				{
					intersection = new Vector2(a1.X + num2 * vector.X, a1.Y + num2 * vector.Y);
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static double Hypotenuse(double x, double y)
	{
		return Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0));
	}

	private static void HumanWindMouse(Vector2i destination, double targetArea = 1.0)
	{
		List<Movepos> list = new List<Movepos>();
		double num = LokiPoe.Random.Next(400, 600);
		double num2 = LokiPoe.Random.Next(6, 15);
		double num3 = LokiPoe.Random.Next(6, 10);
		Vector2i mousePosition = HookManager.GetMousePosition();
		Vector2i vector2i = new Vector2i(mousePosition.X, mousePosition.Y);
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = num;
		int num9 = vector2i.Distance(destination);
		uint num10 = (uint)(Environment.TickCount + 10000);
		double num11 = 0.0;
		while (Environment.TickCount <= num10)
		{
			double num12 = Hypotenuse(vector2i.X - destination.X, vector2i.Y - destination.Y);
			num2 = Math.Min(num2, num12);
			if (num12 < 1.0)
			{
				num12 = 1.0;
			}
			double num13 = Math.Round(Math.Round((double)num9) * 0.3) / 7.0;
			if (num13 > 25.0)
			{
				num13 = 25.0;
			}
			if (num13 < 5.0)
			{
				num13 = 5.0;
			}
			double num14 = LokiPoe.Random.Next(6);
			if (num14 == 1.0)
			{
				num13 = 2.0;
			}
			double num15 = ((num13 <= Math.Round(num12)) ? num13 : Math.Round(num12));
			if (num12 >= targetArea)
			{
				num6 = num6 / sqrt3 + ((double)LokiPoe.Random.Next((int)(Math.Round(num2) * 2.0 + 1.0)) - num2) / sqrt5;
				num7 = num7 / sqrt3 + ((double)LokiPoe.Random.Next((int)(Math.Round(num2) * 2.0 + 1.0)) - num2) / sqrt5;
			}
			else
			{
				num6 /= sqrt2;
				num7 /= sqrt2;
			}
			num4 += num6;
			num5 += num7;
			num4 += num3 * (double)(destination.X - vector2i.X) / num12;
			num5 += num3 * (double)(destination.Y - vector2i.Y) / num12;
			if (Hypotenuse(num4, num5) > num15)
			{
				double num16 = num15 / 2.0 + (double)LokiPoe.Random.Next((int)(Math.Round(num15) / 2.0));
				double num17 = Math.Sqrt(num4 * num4 + num5 * num5);
				num4 = num4 / num17 * num16;
				num5 = num5 / num17 * num16;
			}
			int x = vector2i.X;
			int y = vector2i.Y;
			vector2i.X += (int)num4;
			vector2i.Y += (int)num5;
			num11 = Hypotenuse(vector2i.X - destination.X, vector2i.Y - destination.Y);
			if (x != vector2i.X || y != vector2i.Y)
			{
				int num18 = LokiPoe.Random.Next((int)Math.Round(100.0 / num8)) * 6;
				if (num18 < 0)
				{
					num18 = 0;
				}
				num18 = (int)Math.Round((double)num18 * 0.9);
				if (num11 < 9.0 && list.Count > 4)
				{
					num18 += (int)(100.0 / num11);
				}
				list.Add(new Movepos(vector2i.X, vector2i.Y, num18));
			}
			if (!(num11 >= 4.0))
			{
				break;
			}
		}
		if (destination.X != vector2i.X || destination.Y != vector2i.Y)
		{
			list.Add(new Movepos(destination.X, destination.Y, 0));
		}
		if (list.Count > 2)
		{
			List<Movepos> list2 = new List<Movepos> { list.First() };
			int num19 = list.First().Pos.Distance(list.Last().Pos);
			int num20 = LokiPoe.Random.Next(1, GlobalSettings.Instance.HumanLikeMouseMaxStep + 1);
			int num21 = num19 / num20;
			int num22 = 0;
			while (num22 < list.Count - 1)
			{
				if (list[num22].Pos.Distance(list[num22 + 1].Pos) >= num21)
				{
					list2.Add(list[num22 + 1]);
					num22++;
				}
				else
				{
					list.RemoveAt(num22 + 1);
				}
			}
			list2.Add(list.Last());
			list = list2;
		}
		foreach (Movepos item in list)
		{
			if (DebugCursor)
			{
				Vector2i pos = item.Pos;
				Vector2i vector2i2 = LokiPoe.Utility.MousePosToScreenPosAbsoluteDebug(pos);
				WinApi.SetCursorPos(vector2i2.X, vector2i2.Y);
			}
			HookManager.SetMousePosition(destination);
			MoveMouse(destination.X, destination.Y);
			while (HookManager.GetMousePosition() != destination)
			{
				Thread.Sleep(0);
			}
			if (item.Delay > 0)
			{
				Thread.Sleep(item.Delay);
			}
		}
	}

	internal static void OnInternalPreMove(string reason, int posX, int posY)
	{
		if (LogEvents)
		{
			ilog_0.Warn((object)$"[OnInternalPreMove] {reason} ({posX}, {posY})");
		}
		Instance?.OnPreMove(reason, posX, posY, isUserCall: false);
	}

	internal static void smethod_4(string reason, Vector3 destination, bool actualymove = true)
	{
		LokiPoe.InGameState.CameraTrasformerNew(destination.X, destination.Y, destination.Z, out var outX, out var outY);
		smethod_5(reason, outX, outY, actualymove);
	}

	internal static void smethod_5(string reason, int posX, int posY, bool actualymove = true)
	{
		OnInternalPreMove(reason, posX, posY);
		SetMousePosition(posX, posY);
	}

	public static void ResetMousePosition()
	{
		RectangleF windowRectangle = GameController.Instance.Window.GetWindowRectangle();
		int posX = (int)(windowRectangle.Width / 2f);
		int posY = (int)(windowRectangle.Height / 2f);
		SetMousePosition(posX, posY);
	}

	public static void SetMousePos(string reason, Vector2i destination, bool actualymove = true)
	{
		Vector3 destination2 = destination.MapToWorld3();
		smethod_4(reason, destination2, actualymove);
	}

	public static void SetMousePos(string reason, Vector2 destination, bool actualymove = true)
	{
		Vector3 destination2 = destination.MapToWorld3();
		smethod_4(reason, destination2, actualymove);
	}

	public static void SetMousePosition(int posX, int posY, bool sleep = true)
	{
		MousePoseX = posX;
		MousePoseY = posY;
		Vector2i vector2i = NormalizePosition(new Vector2i(MousePoseX, MousePoseY));
		if (DebugCursor)
		{
			Vector2i vector2i2 = LokiPoe.Utility.MousePosToScreenPosAbsoluteDebug(vector2i);
			WinApi.SetCursorPos(vector2i2.X, vector2i2.Y);
		}
		HookManager.SetMousePosition(vector2i);
		MoveMouse(MousePoseX, MousePoseY, sleep);
	}

	public static void SetMousePosition(Vector2i pos, bool useRandomPos = true)
	{
		if (useRandomPos)
		{
			SetMousePosition(pos.X + LokiPoe.Random.Next(-2, 3), pos.Y + LokiPoe.Random.Next(-2, 3));
		}
		else
		{
			SetMousePosition(pos.X, pos.Y);
		}
	}

	public static void SetMousePosition(Vector2 pos, bool sleep = true)
	{
		SetMousePosition((int)pos.X, (int)pos.Y, sleep);
	}

	public static void ClickLMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		PressLMB(cx, cy);
		Thread.Sleep(10);
		ReleaseLMB(cx, cy);
		limiter.Restart();
	}

	public static void DblClickLMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 515, (IntPtr)1, lParam);
		limiter.Restart();
	}

	public static void PressLMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 513, (IntPtr)1, lParam);
		limiter.Restart();
	}

	public static void ReleaseLMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 514, (IntPtr)0, lParam);
		limiter.Restart();
	}

	public static void ClickRMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		PressRMB(cx, cy);
		Thread.Sleep(10);
		ReleaseRMB(cx, cy);
		limiter.Restart();
	}

	public static void DblClickRMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 518, (IntPtr)2, lParam);
		limiter.Restart();
	}

	public static void PressRMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 516, (IntPtr)2, lParam);
		limiter.Restart();
	}

	public static void ReleaseRMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 517, (IntPtr)0, lParam);
		limiter.Restart();
	}

	public static void ClickMMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		PressMMB(cx, cy);
		Thread.Sleep(10);
		ReleaseMMB(cx, cy);
		limiter.Restart();
	}

	public static void DblClickMMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 521, (IntPtr)16, lParam);
		limiter.Restart();
	}

	public static void PressMMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 519, (IntPtr)16, lParam);
		limiter.Restart();
	}

	public static void ReleaseMMB(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 520, (IntPtr)0, lParam);
		limiter.Restart();
	}

	public static void ScrollMouseDown(int clicks = 1, int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 522, (IntPtr)(clicks * -120 << 16), lParam);
		Thread.Sleep(5);
		limiter.Restart();
	}

	public static void ScrollMouseUp(int clicks = 1, int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 522, (IntPtr)(clicks * 120 << 16), lParam);
		Thread.Sleep(5);
		limiter.Restart();
	}

	public static void ClickXB1(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		PressXB1(cx, cy);
		Thread.Sleep(10);
		ReleaseXB1(cx, cy);
		limiter.Restart();
	}

	public static void DblClickXB1(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 525, (IntPtr)65568, lParam);
		limiter.Restart();
	}

	public static void PressXB1(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 523, (IntPtr)65568, lParam);
		limiter.Restart();
	}

	public static void ReleaseXB1(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 524, (IntPtr)0, lParam);
		limiter.Restart();
	}

	public static void ClickXB2(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		PressXB2(cx, cy);
		Thread.Sleep(10);
		ReleaseXB2(cx, cy);
		limiter.Restart();
	}

	public static void DblClickXB2(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 525, (IntPtr)131136, lParam);
		limiter.Restart();
	}

	public static void PressXB2(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 523, (IntPtr)131136, lParam);
		limiter.Restart();
	}

	public static void ReleaseXB2(int cx = 0, int cy = 0)
	{
		while (limiter.ElapsedMilliseconds < 10L)
		{
			Thread.Sleep(0);
		}
		IntPtr lParam = IntPtr.Zero;
		if (cx != 0 || cy != 0)
		{
			lParam = (IntPtr)((cx & 0xFFFF) | ((cy & 0xFFFF) << 16));
		}
		Interop.SendMessage(GameController.Instance.Window.Process.MainWindowHandle, 524, (IntPtr)0, lParam);
		limiter.Restart();
	}

	internal static void StartMouseThread()
	{
		if (_mouseThread != null)
		{
			_mouseThread.Abort();
			_mouseThread = null;
		}
		if (_mouseThread == null)
		{
			_mouseThread = new Thread(MouseThread);
		}
		shouldRunThread = true;
		_mouseThread.Start();
	}

	internal static void StopMouseThread()
	{
		shouldRunThread = false;
	}

	private static void MouseThread()
	{
		while (shouldRunThread)
		{
			LokiPoe.InGameState.CameraTrasformerNew(mouseXThread, mouseYThread, mouseZThread, out var outX, out var outY);
			smethod_5(reasonThread, outX, outY);
			Thread.Sleep(5);
		}
	}
}
