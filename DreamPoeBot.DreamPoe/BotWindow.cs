using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using log4net.Core;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class BotWindow : System.Windows.Controls.UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class21
	{
		public static readonly Class21 Class9 = new Class21();

		internal void method_0()
		{
			System.Windows.Application.Current.Shutdown();
		}

		internal void method_1()
		{
			LokiPoe.BotWindow.Show();
			LokiPoe.BotWindow.WindowState = System.Windows.WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}

		internal void method_5()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal void method_6()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal void method_11(Hotkey hotkey_0)
		{
			if (BotManager.IsRunning)
			{
				if (!BotManager.IsStopping)
				{
					BotManager.Stop(new StopReasonData("core_gui_hotkey", "The user has pressed the Stop hotkey."));
				}
			}
			else
			{
				BotManager.Start();
			}
		}

		internal void method_12(Hotkey hotkey_0)
		{
			if (LokiPoe.Initialized)
			{
				LokiPoe.BotWindow.Dispatcher.BeginInvoke(new Action(Class9.method_13));
			}
		}

		internal void method_13()
		{
			LokiPoe.BotWindow.Show();
			LokiPoe.BotWindow.WindowState = System.Windows.WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}

		internal void method_14(Hotkey hotkey_0)
		{
			MouseManager.DebugCursor = !MouseManager.DebugCursor;
			ilog_0.WarnFormat("[DebugMouseCursorPos] is now {0}", (object)(MouseManager.DebugCursor ? "On" : "Off"));
		}

		internal void method_15(Hotkey hotkey_0)
		{
			HookManager.RemoveHook();
		}

		internal void method_16(Hotkey hotkey_0)
		{
			HookManager.InstallHook();
		}

		internal void method_17(Hotkey hotkey_0)
		{
			HookManager.ResetKeyState();
		}

		internal void method_18(Hotkey hotkey_0)
		{
			if (LokiPoe.IsInGame)
			{
				Vector2i myPosition = LokiPoe.LocalData.MyPosition;
				ilog_0.InfoFormat("[{1}, {2}] {0}", (object)LokiPoe.TerrainData.TgtUnderPlayer.TgtName, (object)(myPosition.X / 23), (object)(myPosition.Y / 23));
			}
		}

		internal void method_DumpPassive(Hotkey hotkey_0)
		{
			if (GameStateController.IsInGameState)
			{
				if (GameStateController.IsEscapeState)
				{
					return;
				}
				LogFrameUnderCursor();
				if (!LokiPoe.InGameState.SkillsUi.IsOpened)
				{
					if (!LokiPoe.InGameState.AtlasSkillsUi.IsOpened)
					{
						return;
					}
					long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
					if (frameUnderCursor != 0L)
					{
						Dat.BuildPassinveLookupTable();
						DatPassiveSkillWrapper datPassiveSkillWrapper = LokiPoe.InGameState.AtlasSkillsUi.smethod_1(frameUnderCursor);
						if (datPassiveSkillWrapper != null)
						{
							LokiPoe.InGameState.AtlasSkillsUi.smethod_0(datPassiveSkillWrapper);
						}
					}
					return;
				}
				long frameUnderCursor2 = LokiPoe.InGameState.FrameUnderCursor;
				if (frameUnderCursor2 != 0L)
				{
					Dat.BuildPassinveLookupTable();
					DatPassiveSkillWrapper datPassiveSkillWrapper2 = LokiPoe.InGameState.SkillsUi.PassiveDumpEventFunction(frameUnderCursor2);
					if (datPassiveSkillWrapper2 != null)
					{
						LokiPoe.InGameState.SkillsUi.DumpPassive(datPassiveSkillWrapper2);
					}
				}
			}
			else if (!LokiPoe.IsInLoginScreen)
			{
				_ = LokiPoe.IsInCharacterSelectionScreen;
			}
		}

		private void LogFrameUnderCursor()
		{
			long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
			string text = "Element Address: " + frameUnderCursor.ToString("X2");
			Element element = LokiPoe.Memory.GetObject<Element>(frameUnderCursor);
			if (!(element.IdLabel == "root"))
			{
				while (element.Parent.IdLabel != "root")
				{
					Element parent = element.Parent;
					int num = (int)parent.ChildCount - 1;
					while (num >= 0)
					{
						if (parent.Children[num].Address != element.Address)
						{
							num--;
							continue;
						}
						text = $"Children[{num}]." + text;
						break;
					}
					element = parent;
				}
				Element parent2 = element.Parent;
				int num2 = (int)parent2.ChildCount - 1;
				while (num2 >= 0)
				{
					if (parent2.Children[num2].Address != element.Address)
					{
						num2--;
						continue;
					}
					text = $"root.Children[{num2}]." + text;
					break;
				}
			}
			else
			{
				text = "[root] " + text;
			}
			ilog_0.DebugFormat(text, Array.Empty<object>());
		}

		internal void method_DumpDelve(Hotkey hotkey_0)
		{
			if (GameStateController.IsInGameState)
			{
				if (GameStateController.IsEscapeState)
				{
					return;
				}
				long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
				if (frameUnderCursor != 0L)
				{
					Dat.BuildPassinveLookupTable();
					SubterainChartElement.DelveNode @object = LokiPoe.Memory.GetObject<SubterainChartElement.DelveNode>(frameUnderCursor);
					if (@object != null)
					{
						LokiPoe.InGameState.DelveSubterrainChartUi.DumpNode(@object);
					}
				}
			}
			else if (!LokiPoe.IsInLoginScreen)
			{
				_ = LokiPoe.IsInCharacterSelectionScreen;
			}
		}

		internal void method_ToggleRender(Hotkey hotkey_0)
		{
			if (LokiPoe.ClientFunctions.IsRenderEnabled)
			{
				LokiPoe.ClientFunctions.DisableRender();
				HookManager.SetRenderIsDisabled(disabled: true);
			}
			else
			{
				LokiPoe.ClientFunctions.EnableRender();
				HookManager.SetRenderIsDisabled(disabled: false);
			}
		}

		internal void method_20()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal System.Windows.WindowState method_21()
		{
			System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
			return System.Windows.WindowState.Minimized;
		}

		internal void method_22()
		{
			System.Windows.Application.Current.Shutdown();
		}
	}

	private sealed class Class25
	{
		public string string_0;

		internal bool method_0(IRoutine iroutine_0)
		{
			return iroutine_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class26
	{
		public BotWindow botWindow_0;

		public BotChangedEventArgs botChangedEventArgs_0;

		internal void method_0()
		{
			botWindow_0.BotsComboBox.SelectedItem = botChangedEventArgs_0.New;
		}
	}

	private sealed class Class27
	{
		public BotWindow botWindow_0;

		public RoutineChangedEventArgs routineChangedEventArgs_0;

		internal void method_0()
		{
			botWindow_0.RoutinesComboBox.SelectedItem = routineChangedEventArgs_0.New;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private DispatcherTimer dispatcherTimer_0;

	private bool bool_0 = true;

	private DispatcherTimer dispatcherTimer_1;

	private bool bool_1;

	internal ToggleSwitch RenderSwitch;

	internal void method_0(object sender, EventArgs e)
	{
		if (dispatcherTimer_0 != null)
		{
			dispatcherTimer_0.Stop();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (LokiPoe.IsBotFullyLoaded)
		{
			base.Dispatcher.BeginInvoke(new Action(method_8));
		}
	}

	public BotWindow(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			Logger.AddWpfListener(ScrollLog, LogRichTextBox);
			GuiSettings.Instance.LoadRowDefinitions(TopRowDefinition, SplitterRowDefinition, BottomRowDefinition);
			TextboxLogFileName.Text = Logger.FileName;
			mainWindow_0.TitleButton.Content = string.Concat("DreamPoeBot", " [", Assembly.GetEntryAssembly().GetName().Version, "]");
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class21.Class9.method_0);
		}
	}

	private void menuItem_2_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Logger.Clear();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void menuItem_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			System.Windows.Clipboard.SetText(Logger.FileName);
			ilog_0.DebugFormat("{0}: {1}", (object)LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:LogFileNameCopied"), (object)Logger.FileName.Replace(Environment.UserName, "<Username>"));
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void menuItem_1_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(text);
			File.Copy(Logger.FileName, Path.Combine(text, Path.GetFileName(Logger.FileName)));
			string text2 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", "")) + ".zip";
			ZipFile.CreateFromDirectory(text, text2);
			System.Windows.Clipboard.SetText(text2);
			ilog_0.DebugFormat("{0}: {1}", (object)LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:LogFileZipSuccess"), (object)text2);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)string.Format("{0}", LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:LogFileZipFail")), ex);
		}
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		ThreadPool.QueueUserWorkItem(method_9);
	}

	private void method_3(IBot ibot_0)
	{
		if (bool_0)
		{
			base.Dispatcher.BeginInvoke(new Action(method_15));
		}
	}

	private void method_4(IBot ibot_0)
	{
		if (bool_0)
		{
			base.Dispatcher.BeginInvoke(new Action(method_16));
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		Configuration.Instance.SaveAll();
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
		try
		{
			bool_0 = false;
			if (!BotManager.IsRunning)
			{
				BotManager.Start();
			}
			else
			{
				BotManager.Stop(new StopReasonData("core_gui_button", "The user has pressed the Stop button."));
			}
		}
		finally
		{
			bool_0 = true;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		StartStopButton.IsEnabled = true;
		bool flag = !BotManager.IsRunning;
		BotsComboBox.IsEnabled = flag;
		RoutinesComboBox.IsEnabled = flag;
		ForceStopButton.IsEnabled = !flag;
		StartStopButton.Content = ((!flag) ? LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Stop") : LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Start"));
	}

	private void method_RenderOff()
	{
		RenderSwitch.IsChecked = false;
		LokiPoe.ClientFunctions.DisableRender();
		HookManager.SetRenderIsDisabled(disabled: true);
	}

	private void method_RenderOn()
	{
		RenderSwitch.IsChecked = true;
		LokiPoe.ClientFunctions.EnableRender();
		HookManager.SetRenderIsDisabled(disabled: false);
	}

	private void comboBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IBot bot2 = (BotManager.Current = BotsComboBox.SelectedItem as IBot);
			if (bot2 != null)
			{
				GuiSettings.Instance.LastBot = bot2.Name;
			}
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void comboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IRoutine routine2 = (RoutineManager.Current = RoutinesComboBox.SelectedItem as IRoutine);
			if (routine2 != null)
			{
				GuiSettings.Instance.LastRoutine = routine2.Name;
			}
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void LogLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			ComboBoxItem comboBoxItem = (ComboBoxItem)LogLevelComboBox.SelectedItem;
			string logLevel = comboBoxItem.Content.ToString();
			GuiSettings.Instance.LogLevel = logLevel;
			Configuration.Instance.SaveAll();
			if (BotManager.IsRunning)
			{
				switch (GuiSettings.Instance.LogLevel)
				{
				case "Warn":
					Logger.ChangeLogFilterLevel(Level.Warn, Level.Error);
					break;
				case "None":
					Logger.ChangeLogFilterLevel(Level.Off, Level.Off);
					break;
				default:
					Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
					break;
				case "Full":
					Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void method_6(object sender, BotChangedEventArgs e)
	{
		Class26 @class = new Class26();
		@class.botWindow_0 = this;
		@class.botChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void method_7(object sender, RoutineChangedEventArgs e)
	{
		Class27 @class = new Class27();
		@class.botWindow_0 = this;
		@class.routineChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		if (BotManager.IsRunning && System.Windows.MessageBox.Show(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:ForceStopBot"), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			ForceStopButton.IsEnabled = false;
			HookManager.ResetKeyState();
			HookManager.RemoveHook();
			BotManager.Stop(force: true);
		}
	}

	private void method_8()
	{
		try
		{
			LokiPoe.smethod_5((Window)(object)mainWindow_0);
		}
		catch (Exception ex)
		{
			ilog_0.Debug((object)"An exception was caught in BotGuiTimer:", ex);
		}
	}

	private void method_9(object object_0)
	{
		try
		{
			if (!GlobalSettings.Instance.DontAutoFocusGameWindow)
			{
				Interop.SwitchToThisWindow(Interop.smethod_0(mainWindow_0.process_0, "POEWindowClass"), turnOn: true);
			}
			if (!GlobalSettings.Instance.HookCompatibility0 && !CommandLine.Arguments.Exists("HookCompatibility0"))
			{
				if (!GlobalSettings.Instance.HookCompatibility1)
				{
					if (CommandLine.Arguments.Exists("HookCompatibilityDepth"))
					{
						LokiPoe.int_0 = int.Parse(CommandLine.Arguments.Single("HookCompatibilityDepth"));
						ilog_0.InfoFormat("HookCompatibilityDepth = {0}.", (object)LokiPoe.int_0);
					}
				}
				else
				{
					LokiPoe.int_0 = GlobalSettings.Instance.HookCompatibilityDepth;
					ilog_0.InfoFormat("HookCompatibilityDepth = {0}.", (object)LokiPoe.int_0);
				}
			}
			else
			{
				LokiPoe.bool_2 = true;
				ilog_0.InfoFormat("HookCompatibility0 = {0}.", (object)true);
			}
			if (!LokiPoe.smethod_1(mainWindow_0.process_0, Class104.smethod_6, out var string_))
			{
				ilog_0.ErrorFormat(string_, Array.Empty<object>());
				if (!CommandLine.Arguments.Exists("silent"))
				{
					System.Windows.MessageBox.Show(string_, Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				base.Dispatcher.BeginInvoke(new Action(method_10));
				return;
			}
			if (!GlobalSettings.Instance.DontAutoFocusBotWindow)
			{
				base.Dispatcher.BeginInvoke(new Action(Class21.Class9.method_1));
			}
			string[] array = new string[11]
			{
				"HelixToolkit.dll", "HelixToolkit.Wpf.dll", "ICSharpCode.AvalonEdit.dll", "IronPython.dll", "IronPython.Modules.dll", "IronPython.SQLite.dll", "IronPython.Wpf.dll", "Microsoft.Dynamic.dll", "Microsoft.Scripting.AspNet.dll", "Microsoft.Scripting.dll",
				"Microsoft.Scripting.Metadata.dll"
			};
			foreach (string path in array)
			{
				string text = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), path);
				try
				{
					AssemblyName[] referencedAssemblies = Assembly.LoadFrom(text).GetReferencedAssemblies();
					foreach (AssemblyName assemblyRef in referencedAssemblies)
					{
						try
						{
							Assembly.Load(assemblyRef);
						}
						catch (Exception ex)
						{
							ilog_0.Warn((object)"[Preload] ", ex);
						}
					}
				}
				catch (FileLoadException)
				{
					ilog_0.Error((object)"Windows has most likely blocked DreamPoeBot content, which will prevent it from working correctly.");
				}
				catch (Exception ex3)
				{
					ilog_0.Warn((object)"[Preload] ", ex3);
					try
					{
						AssemblyName[] referencedAssemblies2 = Assembly.Load(text).GetReferencedAssemblies();
						foreach (AssemblyName assemblyRef2 in referencedAssemblies2)
						{
							try
							{
								Assembly.Load(assemblyRef2);
							}
							catch (Exception ex4)
							{
								ilog_0.Warn((object)"[Preload] ", ex4);
							}
						}
					}
					catch (Exception ex5)
					{
						ilog_0.Warn((object)"[Preload] ", ex5);
					}
				}
			}
			if (GlobalSettings.Instance.MinimizeGameOnHook && !Interop.IsIconic(mainWindow_0.process_0.MainWindowHandle))
			{
				Interop.ShowWindow(mainWindow_0.process_0.MainWindowHandle, Interop.Cmd.Minimize);
			}
			if (GlobalSettings.Instance.EnableMouseDegudOnHook)
			{
				MouseManager.DebugCursor = true;
			}
			HookManager.Initialize(mainWindow_0.process_0);
			if (!GlobalSettings.Instance.StopRenderOnHook)
			{
				base.Dispatcher.Invoke(method_RenderOn);
			}
			else
			{
				base.Dispatcher.Invoke(method_RenderOff);
			}
			Configuration.Instance.AddSettings(GuiSettings.Instance);
			Configuration.Instance.SaveAll();
			BotManager.PreStart += method_4;
			BotManager.PostStop += method_3;
			LokiPoe.Input.Binding.Update();
			ThirdPartyLoader.CompileAllTherdParty((from x in GuiSettings.Instance.DisabledContent
				where !string.IsNullOrEmpty(x.Name)
				select x.Name.ToLowerInvariant()).ToList(), GuiSettings.Instance.CompileAsynchronously);
			if ((!GuiSettings.Instance.ExitOnCompileErrors && !CommandLine.Arguments.Exists("exitoncompileerrors")) || (!ThirdPartyLoader.CompileErrors.Any() && !ThirdPartyLoader.CompileExceptions.Any()))
			{
				if ((!GuiSettings.Instance.ExitOnLoadErrors && !CommandLine.Arguments.Exists("exitonloaderrors")) || !ThirdPartyLoader.LoadErrors.Any())
				{
					base.Dispatcher.Invoke(SetLogLevel);
					List<string> list = (from x in GuiSettings.Instance.ContentOrder
						where !string.IsNullOrEmpty(x.Name)
						select x.Name).ToList();
					ContentManager.AddContent(ThirdPartyLoader.Instances, list);
					BotManager.smethod_5LoadBots(ThirdPartyLoader.Instances);
					base.Dispatcher.Invoke(SetupIBot);
					BotManager.OnBotChanged += method_6;
					RoutineManager.AddRoutines(ThirdPartyLoader.Instances);
					base.Dispatcher.Invoke(SetupRoutine);
					RoutineManager.OnRoutineChanged += method_7;
					PlayerMoverManager.AddPlayerMovers(ThirdPartyLoader.Instances);
					PluginManager.AddPlugins(ThirdPartyLoader.Instances, GuiSettings.Instance.EnabledPlugins, list);
					base.Dispatcher.Invoke(method_13);
					base.Dispatcher.Invoke(method_14);
					dispatcherTimer_1 = new DispatcherTimer(TimeSpan.FromMilliseconds(1000.0), DispatcherPriority.Normal, method_5, base.Dispatcher);
					dispatcherTimer_1.Start();
					if (GlobalSettings.Instance.StartStopBotEnabled)
					{
						Hotkeys.Register("BotWindow.StartStopBot", GlobalSettings.Instance.StartStopBotKey, GlobalSettings.Instance.StartStopBotMod, Class21.Class9.method_11);
					}
					if (GlobalSettings.Instance.FocusBotWindowEnabled)
					{
						Hotkeys.Register("LokiPoe.Input.FocusBotWindow", GlobalSettings.Instance.FocusBotWindowKey, GlobalSettings.Instance.FocusBotWindowMod, Class21.Class9.method_12);
					}
					if (GlobalSettings.Instance.DebugMouseCursorPosEnabled)
					{
						Hotkeys.Register("LokiPoe.Input.DebugMouseCursorPos", GlobalSettings.Instance.DebugMouseCursorPosKey, GlobalSettings.Instance.DebugMouseCursorPosMod, Class21.Class9.method_14);
					}
					if (GlobalSettings.Instance.DisablePHMEnabled)
					{
						Hotkeys.Register("LokiPoe.ProcessHookManager.Disable", GlobalSettings.Instance.DisablePHMKey, GlobalSettings.Instance.DisablePHMMod, Class21.Class9.method_15);
					}
					if (GlobalSettings.Instance.EnablePHMEnabled)
					{
						Hotkeys.Register("LokiPoe.ProcessHookManager.Enable", GlobalSettings.Instance.EnablePHMKey, GlobalSettings.Instance.EnablePHMMod, Class21.Class9.method_16);
					}
					if (GlobalSettings.Instance.ResetPHMEnabled)
					{
						Hotkeys.Register("LokiPoe.ProcessHookManager.Reset", GlobalSettings.Instance.ResetPHMKey, GlobalSettings.Instance.ResetPHMMod, Class21.Class9.method_17);
					}
					if (GlobalSettings.Instance.DumpTGTEnabled)
					{
						Hotkeys.Register("LokiPoe.ProcessHookManager.DumpTGT", GlobalSettings.Instance.DumpTGTKey, GlobalSettings.Instance.DumpTGTMod, Class21.Class9.method_18);
					}
					if (GlobalSettings.Instance.DumpFrameUnderCursorEnabled)
					{
						Hotkeys.Register("LokiPoe.InGameState.DumpFrameUnderCursor", GlobalSettings.Instance.DumpFrameUnderCursorKey, GlobalSettings.Instance.DumpFrameUnderCursorMod, Class21.Class9.method_DumpPassive);
					}
					Hotkeys.Register("LokiPoe.InGameState.DumpDelveCelUnderCursor", Keys.L, ModifierKeys.Alt | ModifierKeys.Shift, Class21.Class9.method_DumpDelve);
					LokiPoe.InGameState.DelveSubterrainChartUi.OnPassiveDump += LokiPoe.OnDelveCellDump;
					Hotkeys.Register("LokiPoe.Input.ToggleRender", Keys.Z, ModifierKeys.Alt | ModifierKeys.Shift, Class21.Class9.method_ToggleRender);
					ilog_0.InfoFormat("{0}{1}{0}{2}", (object)Environment.NewLine, (object)LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:GuideText"), (object)LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:GuideLink"));
					LokiPoe.IsBotFullyLoaded = true;
					if (CommandLine.Arguments.Exists("failwitherror"))
					{
						string text2 = CommandLine.Arguments.Single("failwitherror");
						ilog_0.DebugFormat("Intentionally failing with error: {0}.", (object)text2);
						LokiPoe.ApplicationExitCodes_0 = (ApplicationExitCodes)int.Parse(text2);
						base.Dispatcher.Invoke(Class21.Class9.method_20);
						return;
					}
					Utility.BroadcastMessage(null, "core_bot_fully_loaded_event");
					if (CommandLine.Arguments.Exists("autostart"))
					{
						BotManager.Start();
					}
					if (CommandLine.Arguments.Exists("autominimize"))
					{
						base.Dispatcher.Invoke((Func<System.Windows.WindowState>)Class21.Class9.method_21);
					}
				}
				else
				{
					ilog_0.InfoFormat("Now exiting because there were load errors and ExitOnLoadErrors is enabled.", Array.Empty<object>());
					LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.LoadErrors;
					base.Dispatcher.Invoke(Class21.Class9.method_6);
				}
			}
			else
			{
				ilog_0.InfoFormat("Now exiting because there were compile errors and ExitOnCompileErrors is enabled.", Array.Empty<object>());
				LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.CompileErrors;
				base.Dispatcher.Invoke(Class21.Class9.method_5);
			}
		}
		catch (Exception ex6)
		{
			ilog_0.Error((object)"An exception occurred.", ex6);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class21.Class9.method_22);
		}
	}

	private void method_10()
	{
		((Window)(object)mainWindow_0).Close();
		System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
	}

	private void SetupIBot()
	{
		List<IBot> list = BotManager.Bots.Where((IBot x) => !string.IsNullOrEmpty(x.Name)).ToList();
		BotsComboBox.ItemsSource = list;
		if (CommandLine.Arguments.Exists("bot"))
		{
			string str2 = CommandLine.Arguments.Single("bot");
			IBot bot = list.FirstOrDefault((IBot x) => x.Name.Equals(str2, StringComparison.OrdinalIgnoreCase));
			if (bot != null)
			{
				BotsComboBox.SelectedItem = bot;
			}
		}
		else if (!string.IsNullOrEmpty(GuiSettings.Instance.LastBot))
		{
			string str = GuiSettings.Instance.LastBot;
			IBot bot2 = list.FirstOrDefault((IBot x) => x.Name.Equals(str, StringComparison.OrdinalIgnoreCase));
			if (bot2 != null)
			{
				BotsComboBox.SelectedItem = bot2;
			}
		}
		if (BotsComboBox.SelectedItem == null)
		{
			BotsComboBox.SelectedItem = list.FirstOrDefault();
		}
	}

	private void SetupRoutine()
	{
		List<IRoutine> list = RoutineManager.Routines.Where((IRoutine x) => !string.IsNullOrEmpty(x.Name)).ToList();
		RoutinesComboBox.ItemsSource = list;
		if (CommandLine.Arguments.Exists("routine"))
		{
			string str2 = CommandLine.Arguments.Single("routine");
			IRoutine routine = list.FirstOrDefault((IRoutine x) => x.Name.Equals(str2, StringComparison.OrdinalIgnoreCase));
			if (routine != null)
			{
				RoutinesComboBox.SelectedItem = routine;
			}
		}
		else if (!string.IsNullOrEmpty(GuiSettings.Instance.LastRoutine))
		{
			string str = GuiSettings.Instance.LastRoutine;
			IRoutine routine2 = list.FirstOrDefault((IRoutine x) => x.Name.Equals(str, StringComparison.OrdinalIgnoreCase));
			if (routine2 != null)
			{
				RoutinesComboBox.SelectedItem = routine2;
			}
		}
		if (RoutinesComboBox.SelectedItem == null)
		{
			RoutinesComboBox.SelectedItem = list.FirstOrDefault();
		}
	}

	private void method_13()
	{
		BotsComboBox.IsEnabled = true;
		RoutinesComboBox.IsEnabled = true;
		mainWindow_0.NewSettingsWindow_0.method_13();
	}

	private void method_14()
	{
		dispatcherTimer_0 = new DispatcherTimer(TimeSpan.FromMilliseconds(1000.0), DispatcherPriority.Normal, method_1, base.Dispatcher);
		dispatcherTimer_0.Start();
	}

	private void method_15()
	{
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
	}

	private void method_16()
	{
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
	}

	private void SetLogLevel()
	{
		LogLevelComboBox.SelectedValue = GuiSettings.Instance.LogLevel;
	}

	private void ToggleSwitch_OnClick(object sender, RoutedEventArgs e)
	{
		ToggleSwitch val = (ToggleSwitch)((sender is ToggleSwitch) ? sender : null);
		if (val != null)
		{
			if (!RenderSwitch.IsChecked.HasValue || !RenderSwitch.IsChecked.Value)
			{
				LokiPoe.ClientFunctions.DisableRender();
				HookManager.SetRenderIsDisabled(disabled: true);
			}
			else
			{
				LokiPoe.ClientFunctions.EnableRender();
				HookManager.SetRenderIsDisabled(disabled: false);
			}
		}
	}
}
