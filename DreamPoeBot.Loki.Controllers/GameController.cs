using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.Framework;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Controllers;

public class GameController
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public static GameController Instance;

	internal bool IsRenderDisabled;

	private bool ShouldKillRenderLoop;

	public readonly Runner CoroutineRunner;

	public readonly Runner CoroutineRunnerParallel;

	public GameStateController GameStateController { get; private set; }

	public static bool UseGameStateController => true;

	public GameWindow Window { get; private set; }

	public TheGame Game { get; }

	public AreaController Area { get; }

	public Memory Memory { get; private set; }

	public Stopwatch MainTimer { get; }

	public bool InGame { get; private set; }

	public bool InGameReal => Game.IngameState.InGame;

	public FsController Files { get; private set; }

	public long RenderCount { get; private set; }

	public GameController(Memory memory)
	{
		Instance = this;
		Memory = memory;
		Game = new TheGame();
		GameStateController = new GameStateController();
		Area = new AreaController();
		Window = new GameWindow(memory.Process);
		Files = new FsController(memory);
		InGame = InGameReal;
		MainTimer = Stopwatch.StartNew();
	}

	public async Task WhileLoop()
	{
		int id = Window.Process.Id;
		WinApi.EmptyWorkingSet(Memory.Process.Handle);
		Stopwatch stopwatch = Stopwatch.StartNew();
		bool closing = false;
		LokiPoe.BotWindow.Closing += delegate
		{
			closing = true;
		};
		while (true)
		{
			Thread.Sleep(1500);
			if (!(LokiPoe.BotWindow == null || closing))
			{
				if (LokiPoe.BotWindow == null)
				{
					break;
				}
				Process[] processes = Process.GetProcesses();
				Process process = processes.FirstOrDefault((Process pr) => pr.Id == id);
				if (process != null)
				{
					if (Memory.Process != null && stopwatch.ElapsedMilliseconds > 900000L)
					{
						WinApi.EmptyWorkingSet(Memory.Process.Handle);
						stopwatch.Restart();
					}
					continue;
				}
				ilog_0.InfoFormat("The Game Proces is closed, now terminating DPB", Array.Empty<object>());
				break;
			}
			ilog_0.InfoFormat("The Bot window is closed, now terminating DPB", Array.Empty<object>());
			break;
		}
		ShouldKillRenderLoop = true;
		Thread.Sleep(1000);
		Process.GetCurrentProcess().Kill();
	}

	public async Task RenderLoop()
	{
		Stopwatch stopwatch = new Stopwatch();
		int id = Window.Process.Id;
		bool flag = false;
		bool closing = false;
		LokiPoe.BotWindow.Closing += delegate
		{
			closing = true;
		};
		while (true)
		{
			if (ShouldKillRenderLoop)
			{
				return;
			}
			if (LokiPoe.BotWindow == null || closing)
			{
				break;
			}
			Process[] processes = Process.GetProcesses();
			Process process = processes.FirstOrDefault((Process pr) => pr.Id == id);
			if (process != null)
			{
				if (Instance.IsRenderDisabled)
				{
					if (!stopwatch.IsRunning)
					{
						stopwatch.Restart();
					}
					if (stopwatch.ElapsedMilliseconds > 60000L)
					{
						LokiPoe.ClientFunctions.EnableRender();
						stopwatch.Restart();
						while (stopwatch.ElapsedMilliseconds < 5000L && !ShouldKillRenderLoop)
						{
							Thread.Sleep(500);
						}
						LokiPoe.ClientFunctions.DisableRender();
						stopwatch.Restart();
					}
					if (GameStateController.IsLoading || GameStateController.IsAreaLoading)
					{
						LokiPoe.ClientFunctions.EnableRender();
						flag = true;
					}
				}
				if (flag && LokiPoe.IsInGame)
				{
					flag = false;
					LokiPoe.ClientFunctions.DisableRender();
				}
				if (!ShouldKillRenderLoop)
				{
					if (!Instance.IsRenderDisabled && stopwatch.IsRunning)
					{
						stopwatch.Stop();
					}
					Thread.Sleep(1500);
					continue;
				}
				if (Instance.IsRenderDisabled)
				{
					LokiPoe.ClientFunctions.EnableRender();
				}
				return;
			}
			ilog_0.InfoFormat("The Game Proces is closed, now terminating the Render Loop", Array.Empty<object>());
			return;
		}
		ilog_0.InfoFormat("The Bot window is closed, now terminating the Render Loop", Array.Empty<object>());
	}
}
