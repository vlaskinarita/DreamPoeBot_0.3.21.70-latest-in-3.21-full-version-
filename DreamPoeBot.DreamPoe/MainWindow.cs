using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using DreamPoeBot.Framework.Helpers;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Structures.ns11;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Engine;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public class MainWindow : MetroWindow, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly NotifyIcon notifyIcon_0;

	private BotWindow botWindow_0;

	private LanguageSelection languageSelection_0;

	private ConfigSelection configSelection_0;

	private LoginWindow loginWindow_0;

	private UpdateWindow updateWindow_0;

	private DownloadWindow downloadWindow_0;

	private ProcessSelectorWindow processSelectorWindow_0;

	internal Mutex mutex_0;

	internal Process process_0;

	public static RoutedCommand ChangeLanguageToEn = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToRu = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToDe = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToFr = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToEs = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToZhCn = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToInvariant = new RoutedCommand();

	public static RoutedCommand OpenSettingsWindow = new RoutedCommand();

	internal System.Windows.Controls.Label StatusBarLeftLabel;

	internal System.Windows.Controls.Label StatusBarRightLabel;

	internal TransitioningContentControl transitioningContentControl_0;

	internal System.Windows.Controls.Button TitleButton;

	internal System.Windows.Controls.Button ProcessButton;

	internal System.Windows.Controls.Button TimeLeftButton;

	internal System.Windows.Controls.Button SettingsButton;

	private bool _contentLoaded;

	internal NewSettingsWindow NewSettingsWindow_0 { get; private set; }

	protected override void OnSourceInitialized(EventArgs e)
	{
		try
		{
			((Window)this).OnSourceInitialized(e);
			(PresentationSource.FromVisual((Visual)(object)this) as HwndSource).AddHook(method_0);
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("[OnSourceInitialized] {0}.", (object)ex);
			throw;
		}
	}

	public bool IsAdministrator()
	{
		using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
		WindowsPrincipal windowsPrincipal = new WindowsPrincipal(ntIdentity);
		return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
	}

	private IntPtr method_0(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2, ref bool bool_1)
	{
		if (LokiPoe.IsBotFullyLoaded && GlobalSettings.Instance.AllowExternalAccess)
		{
			if (int_0 >= 1024 && int_0 < 32768)
			{
				foreach (IPlugin enabledPlugin in PluginManager.EnabledPlugins)
				{
					DreamPoeBot.Loki.Bot.Message message = new DreamPoeBot.Loki.Bot.Message("wndproc_hook", this, intptr_0, int_0, intptr_1, intptr_2);
					if (enabledPlugin.Message(message) == MessageResult.Processed && message.Outputs.Any())
					{
						bool_1 = true;
						return message.GetOutput<IntPtr>();
					}
				}
			}
			return IntPtr.Zero;
		}
		return IntPtr.Zero;
	}

	private void method_1(object sender, ExecutedRoutedEventArgs e)
	{
		if (NewSettingsWindow_0 != null)
		{
			((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Visible;
			((Window)(object)NewSettingsWindow_0).Activate();
		}
	}

	private void method_2(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_3(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("en");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_4(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("es");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_5(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("de");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_6(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("fr");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_7(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("ru");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_8(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("zh-cn");
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	public MainWindow()
	{
		InitializeComponent();
		ChangeLanguageToInvariant.InputGestures.Add(new KeyGesture(Key.D0, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToEn.InputGestures.Add(new KeyGesture(Key.D1, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToRu.InputGestures.Add(new KeyGesture(Key.D2, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToFr.InputGestures.Add(new KeyGesture(Key.D3, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToDe.InputGestures.Add(new KeyGesture(Key.D4, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToEs.InputGestures.Add(new KeyGesture(Key.D5, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToZhCn.InputGestures.Add(new KeyGesture(Key.D6, System.Windows.Input.ModifierKeys.Control));
		OpenSettingsWindow.InputGestures.Add(new KeyGesture(Key.Tab, System.Windows.Input.ModifierKeys.Control));
		try
		{
			notifyIcon_0 = new NotifyIcon
			{
				Icon = new Icon(System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/DreamPoeBot;component/Images/Icon.ico")).Stream),
				Visible = true
			};
			notifyIcon_0.DoubleClick += notifyIcon_0_DoubleClick;
			notifyIcon_0.Text = "DreamPoeBot";
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
		}
	}

	protected override void OnStateChanged(EventArgs e)
	{
		if (!GuiSettings.Instance.NoHideOnMinimize && ((Window)this).WindowState == WindowState.Minimized)
		{
			((Window)this).Hide();
		}
		((Window)this).OnStateChanged(e);
	}

	internal void method_9()
	{
		bool flag = true;
		if (!CommandLine.Arguments.Exists("language") && !GlobalSettings.Instance.AutoChooseLanguage)
		{
			try
			{
				if (GlobalSettings.Instance.LastUsedLanguage == "iv")
				{
					LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
				}
				else
				{
					LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(GlobalSettings.Instance.LastUsedLanguage);
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"An exception occurred.", ex);
				GlobalSettings.Instance.LastUsedLanguage = "en";
			}
		}
		else
		{
			switch ((!GlobalSettings.Instance.AutoChooseLanguage) ? CommandLine.Arguments.Single("language").ToLowerInvariant() : GlobalSettings.Instance.AutoLanguage)
			{
			case "de":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("de");
				flag = false;
				break;
			default:
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("en");
				break;
			case "iv":
				LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
				flag = false;
				break;
			case "es":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("es");
				flag = false;
				break;
			case "ru":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("ru");
				flag = false;
				break;
			case "fr":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("fr");
				flag = false;
				break;
			case "zh-cn":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("zh-cn");
				flag = false;
				break;
			case "en":
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo("en");
				flag = false;
				break;
			}
		}
		if (flag)
		{
			ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
			LanguageSelection content;
			if ((content = languageSelection_0) == null)
			{
				content = (languageSelection_0 = new LanguageSelection(this));
			}
			contentControl.Content = content;
		}
		else
		{
			method_10();
		}
	}

	internal void method_10()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		bool flag = true;
		bool flag2 = GlobalSettings.Instance.RandomizeProfileSelection;
		string profileBaseName = GlobalSettings.Instance.ProfileBaseName;
		if (CommandLine.Arguments.Exists("randomprofile"))
		{
			flag2 = true;
		}
		if (CommandLine.Arguments.Exists("config") || GlobalSettings.Instance.AutoChooseConfig)
		{
			string string_ = "";
			if (GlobalSettings.Instance.AutoChooseConfig)
			{
				string_ = GlobalSettings.Instance.LastUsedConfiguration;
			}
			if (CommandLine.Arguments.Exists("config"))
			{
				string_ = CommandLine.Arguments.Single("config");
			}
			if (flag2)
			{
				ilog_0.DebugFormat("Profile randomization enabled.", Array.Empty<object>());
				string newProfileBaseName = (string.IsNullOrEmpty(GlobalSettings.Instance.ProfileBaseName) ? "" : GlobalSettings.Instance.ProfileBaseName);
				if (CommandLine.Arguments.Exists("config"))
				{
					newProfileBaseName = (string.IsNullOrEmpty(CommandLine.Arguments.Single("config")) ? "" : CommandLine.Arguments.Single("config"));
					if (!string.IsNullOrEmpty(newProfileBaseName))
					{
						ilog_0.DebugFormat("Detected config parameter, Using ProfileBaseName: " + newProfileBaseName + ".", Array.Empty<object>());
					}
					else
					{
						ilog_0.ErrorFormat("Detected config parameter, But ProfileBaseName is empty.", Array.Empty<object>());
					}
				}
				string text = Misc.LoadProfile();
				if (!string.IsNullOrEmpty(text) && (newProfileBaseName == null || text.Contains(newProfileBaseName)))
				{
					ilog_0.DebugFormat("Profile already selected: " + text + ", copying files...", Array.Empty<object>());
					Stopwatch stopwatch = Stopwatch.StartNew();
					IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, text), Path.Combine(JsonSettings.SettingsPath, text), copySubDirs: true);
					stopwatch.Stop();
					ilog_0.DebugFormat($"Copy completed in {stopwatch.Elapsed:hh\\:mm\\:ss\\.ff}", Array.Empty<object>());
				}
				else
				{
					ilog_0.DebugFormat(string.IsNullOrEmpty(text) ? "RandomProfileSelected is empty, selecting a new random profile." : ("RandomProfileSelected [" + text + "] is different than base name [" + newProfileBaseName + "], selecting a new random profile."), Array.Empty<object>());
					if (string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Profiles Folder Path is empty, be sure to select a valid path.", Array.Empty<object>());
						System.Windows.MessageBox.Show("Profiles Folder Path is empty, be sure to select a valid path.", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					if (!Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Profiles Folder Path do not exist.", Array.Empty<object>());
						System.Windows.MessageBox.Show("Profiles Folder Path do not exist.", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list = (from x in Directory.EnumerateDirectories(GlobalSettings.Instance.ProfilesFolderPath)
						where x.Contains(newProfileBaseName ?? "")
						select x).ToList();
					if (list.Count <= 0)
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Found 0 file matching basename: " + newProfileBaseName + " in " + GlobalSettings.Instance.ProfilesFolderPath + ".", Array.Empty<object>());
						System.Windows.MessageBox.Show("Found 0 file matching basename: " + newProfileBaseName + " in " + GlobalSettings.Instance.ProfilesFolderPath + ".", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list2 = new List<string>(list);
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.BlacklistedProfileWords))
					{
						List<string> list3 = GlobalSettings.Instance.BlacklistedProfileWords.Split(',').ToList();
						for (int num = list.Count - 1; num >= 0; num--)
						{
							bool flag3 = false;
							string text2 = list[num];
							foreach (string item in list3)
							{
								if (text2.Contains(item))
								{
									flag3 = true;
									break;
								}
							}
							if (flag3)
							{
								list.RemoveAt(num);
							}
						}
					}
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(newProfileBaseName))
					{
						ilog_0.DebugFormat("[SelectRandomProfile] Extracting the profile suffix.", Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] randomProfileSelected: " + text, Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] newProfileBaseName: " + newProfileBaseName, Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] oldProfileBaseName: " + profileBaseName, Array.Empty<object>());
						string text3 = text.Remove(text.IndexOf(profileBaseName, StringComparison.Ordinal), profileBaseName.Length);
						if (!string.IsNullOrEmpty(text3))
						{
							ilog_0.DebugFormat($"[SelectRandomProfile] Found suffix: {text3}, filtering profiles. [Initial Count: {list2.Count}]", Array.Empty<object>());
							for (int num2 = list2.Count - 1; num2 >= 0; num2--)
							{
								string text4 = list2[num2];
								if (!text4.Contains(text3))
								{
									list2.RemoveAt(num2);
								}
							}
							ilog_0.DebugFormat($"[SelectRandomProfile] Remaining profiles: {list2.Count}", Array.Empty<object>());
							list = list2;
						}
						else
						{
							ilog_0.DebugFormat("[SelectRandomProfile] Suffix is empty, a random profile will be selected.", Array.Empty<object>());
						}
					}
					DirectoryInfo directoryInfo = new DirectoryInfo(list.ElementAt(LokiPoe.Random.Next(0, list.Count)));
					string name = directoryInfo.Name;
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath) && Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.DebugFormat("Profile selected: " + name + ", copying files...", Array.Empty<object>());
						Stopwatch stopwatch2 = Stopwatch.StartNew();
						IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, name), Path.Combine(JsonSettings.SettingsPath, name), copySubDirs: true);
						stopwatch2.Stop();
						ilog_0.DebugFormat($"Copy completed in {stopwatch2.Elapsed:hh\\:mm\\:ss\\.ff}", Array.Empty<object>());
					}
					else
					{
						ilog_0.DebugFormat("Profile selected: " + name + ", cant copy files,  files... ProfilesFolderPath is Inacessible.", Array.Empty<object>());
					}
					text = name;
					Misc.SaveProfile(text);
				}
				string_ = text;
			}
			try
			{
				method_20(string_);
				flag = false;
			}
			catch
			{
				System.Windows.MessageBox.Show(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:ChooseConfigErrorInvalid"), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}
		if (flag)
		{
			ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
			ConfigSelection content;
			if ((content = configSelection_0) == null)
			{
				content = (configSelection_0 = new ConfigSelection(this));
			}
			contentControl.Content = content;
		}
		else
		{
			method_14();
		}
	}

	internal void method_11()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		LoginWindow content;
		if ((content = loginWindow_0) == null)
		{
			content = (loginWindow_0 = new LoginWindow(this));
		}
		contentControl.Content = content;
	}

	internal void method_12(string string_0)
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		UpdateWindow content;
		if ((content = updateWindow_0) == null)
		{
			content = (updateWindow_0 = new UpdateWindow(this, string_0));
		}
		contentControl.Content = content;
	}

	internal void method_13(string string_0)
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		DownloadWindow content;
		if ((content = downloadWindow_0) == null)
		{
			content = (downloadWindow_0 = new DownloadWindow(this, string_0));
		}
		contentControl.Content = content;
	}

	internal void method_14()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		notifyIcon_0.Text = Configuration.Instance.Name;
		if (!CommandLine.Arguments.Exists("noupdate") && !GlobalSettings.Instance.DisableUpdateCheck)
		{
			try
			{
				string text = new WebClient().DownloadString("http://51.75.249.226:8100/GetDPBVersion");
				Version version = new Version(text.Replace("\"", "").Replace("\\", ""));
				bool? flag = null;
				Version version2 = Assembly.GetEntryAssembly().GetName().Version;
				if (version == version2)
				{
					ilog_0.InfoFormat("{0} [{1}] is up to date!", (object)"DreamPoeBot", (object)version2);
					method_11();
					return;
				}
				if (version2.Major >= version.Major && version2.Minor >= version.Minor && version2.Build >= version.Build && version2.Revision >= version.Revision)
				{
					ilog_0.InfoFormat("{0} [{1}] is up to date!", (object)"DreamPoeBot", (object)version2);
					method_11();
					return;
				}
				if (version2.Major < version.Major)
				{
					_ = version.Revision;
					_ = version2.Revision;
					string text2 = string.Format("{0} [{1}] is now out-of-date. A new installation is required. Please check the Discord Channel for more information", "DreamPoeBot", version2);
					ilog_0.ErrorFormat(text2, Array.Empty<object>());
					System.Windows.MessageBox.Show(text2, Util.RandomWindowTitle("New Installation Required"), MessageBoxButton.OK, MessageBoxImage.Hand);
					Environment.Exit(0);
					return;
				}
				if (!(version < version2))
				{
					if (version > version2)
					{
						flag = false;
					}
				}
				else
				{
					flag = true;
				}
				if (flag.HasValue)
				{
					bool flag2;
					if (!CommandLine.Arguments.Exists("autoupdate"))
					{
						if (!flag.Value)
						{
							string string_ = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
							method_12(string_);
							return;
						}
						flag2 = false;
					}
					else
					{
						flag2 = true;
					}
					if (flag2)
					{
						string string_2 = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
						method_13(string_2);
					}
				}
			}
			catch (Exception ex)
			{
				((ContentControl)(object)transitioningContentControl_0).Content = null;
				ilog_0.Error((object)"An error occurred while checking for updates.", ex);
			}
		}
		else
		{
			ilog_0.Info((object)"Checking for updates is disabled.");
		}
		if (((ContentControl)(object)transitioningContentControl_0).Content == null)
		{
			method_11();
		}
	}

	internal void method_15(Process process_1)
	{
		try
		{
			if (process_1.HasExited)
			{
				return;
			}
			mutex_0 = Class98.smethod_0(process_1.Id, out var _);
			process_0 = process_1;
		}
		catch (Exception)
		{
			mutex_0 = null;
			process_0 = null;
			return;
		}
		method_18();
	}

	internal bool method_16()
	{
		if (Class98.smethod_1(out mutex_0, out process_0))
		{
			method_18();
			return true;
		}
		return false;
	}

	internal void method_17()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		ProcessSelectorWindow content;
		if ((content = processSelectorWindow_0) == null)
		{
			content = (processSelectorWindow_0 = new ProcessSelectorWindow(this));
		}
		contentControl.Content = content;
	}

	internal void method_18()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ProcessButton.Visibility = Visibility.Visible;
		ProcessButton.Content = $"PID: {process_0.Id}";
		SettingsButton.Visibility = Visibility.Visible;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		BotWindow content;
		if ((content = botWindow_0) == null)
		{
			content = (botWindow_0 = new BotWindow(this));
		}
		contentControl.Content = content;
		NewSettingsWindow newSettingsWindow_;
		if ((newSettingsWindow_ = NewSettingsWindow_0) == null)
		{
			NewSettingsWindow newSettingsWindow2 = (NewSettingsWindow_0 = new NewSettingsWindow(this));
			newSettingsWindow_ = newSettingsWindow2;
		}
		NewSettingsWindow_0 = newSettingsWindow_;
		((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Collapsed;
		((System.Windows.Controls.Control)(object)transitioningContentControl_0).VerticalContentAlignment = VerticalAlignment.Stretch;
		DispatcherTimer dispatcherTimer = new DispatcherTimer();
		dispatcherTimer.Interval = TimeSpan.FromSeconds(30.0);
		dispatcherTimer.Tick += timer_Tick;
		dispatcherTimer.Start();
	}

	internal void timer_Tick(object sender, EventArgs e)
	{
		string timeLeft = Class104.GetTimeLeft();
		long num = long.Parse(timeLeft);
		TimeSpan timeSpan = TimeSpan.FromSeconds(num);
		TimeLeftButton.Content = string.Format($"TimeLeft: {timeSpan.Days} Days, {timeSpan.Hours} H. {timeSpan.Minutes} M., {timeSpan.Seconds} S.");
	}

	private void method_19(object sender, RoutedEventArgs e)
	{
		try
		{
			Window window = Window.GetWindow((DependencyObject)(object)this);
			LokiPoe.BotWindowHandle = new WindowInteropHelper(window).Handle;
			LokiPoe.BotWindow = window;
			SettingsButton.Visibility = Visibility.Collapsed;
			ProcessButton.Visibility = Visibility.Collapsed;
			if (!IsAdministrator())
			{
				System.Windows.MessageBox.Show("Run DreamPoeBot as Administrator or make sure your user has Administrator right.", "This program must be run as Administrator.");
				((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
			}
			else
			{
				method_9();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
		}
	}

	internal void method_20(string string_0)
	{
		if (string_0.ToLower() == "auto")
		{
			Configuration.Instance.Name = GlobalSettings.Instance.LastUsedConfiguration;
		}
		else
		{
			GlobalSettings.Instance.LastUsedConfiguration = string_0;
			Configuration.Instance.Name = string_0;
		}
		bool flag = false;
		bool flag2 = false;
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen screen in allScreens)
		{
			if (screen.WorkingArea.Contains(GuiSettings.Instance.WindowX, GuiSettings.Instance.WindowY))
			{
				flag = true;
			}
			if (screen.WorkingArea.Contains(GuiSettings.Instance.SettingsWindowX, GuiSettings.Instance.SettingsWindowY))
			{
				flag2 = true;
			}
		}
		if (!flag)
		{
			GuiSettings.Instance.WindowX = 0;
			GuiSettings.Instance.WindowY = 0;
			GuiSettings.Instance.WindowWidth = 627;
			GuiSettings.Instance.WindowHeight = 755;
		}
		if (!flag2)
		{
			GuiSettings.Instance.SettingsWindowX = 0;
			GuiSettings.Instance.SettingsWindowY = 0;
			GuiSettings.Instance.SettingsWindowWidth = 627;
			GuiSettings.Instance.SettingsWindowHeight = 477;
		}
		if (GuiSettings.Instance.WindowX == 0 && GuiSettings.Instance.WindowY == 0 && GuiSettings.Instance.WindowWidth == 627 && GuiSettings.Instance.WindowHeight == 477)
		{
			GuiSettings.Instance.WindowX = (int)((Window)this).Left;
			GuiSettings.Instance.WindowY = (int)((Window)this).Top;
			GuiSettings.Instance.WindowWidth = (int)((FrameworkElement)this).Width;
			GuiSettings.Instance.WindowHeight = (int)((FrameworkElement)this).Height;
			GuiSettings.Instance.SettingsWindowX = (int)((Window)this).Left;
			GuiSettings.Instance.SettingsWindowY = (int)((Window)this).Top;
			GuiSettings.Instance.SettingsWindowWidth = (int)((FrameworkElement)this).Width;
			GuiSettings.Instance.SettingsWindowHeight = (int)((FrameworkElement)this).Height;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(method_23));
	}

	private void button_3_Click(object sender, RoutedEventArgs e)
	{
		((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Visible;
		((Window)(object)NewSettingsWindow_0).Activate();
		Configuration.Instance.SaveAll();
	}

	private void button_2_Click(object sender, RoutedEventArgs e)
	{
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Interop.SwitchToThisWindow(LokiPoe.ClientWindowHandle, turnOn: true);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
		}
	}

	private void method_21(object sender, CancelEventArgs e)
	{
		try
		{
			notifyIcon_0.Visible = false;
			notifyIcon_0.Icon = null;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		try
		{
			if (botWindow_0 != null)
			{
				botWindow_0.method_0(sender, e);
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
		}
		Class104.smethod_0();
		if (botWindow_0 != null)
		{
			GuiSettings.Instance.SaveRowDefinitions(botWindow_0.TopRowDefinition, botWindow_0.SplitterRowDefinition, botWindow_0.BottomRowDefinition);
		}
		Configuration.Instance.SaveAll();
		PluginManager.smethod_5();
		PlayerMoverManager.smethod_2();
		RoutineManager.smethod_2();
		BotManager.smethod_6Deinitializer();
		ContentManager.Deinitialize();
		foreach (object window2 in System.Windows.Application.Current.Windows)
		{
			Window window = (Window)window2;
			if (window.IsVisible)
			{
				window.Close();
			}
		}
		if (mutex_0 != null)
		{
			mutex_0.Dispose();
			mutex_0 = null;
		}
		if (process_0 != null)
		{
			process_0.Dispose();
			process_0 = null;
		}
		try
		{
			System.Windows.Application.Current.Shutdown();
		}
		catch
		{
		}
	}

	private void notifyIcon_0_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			((Window)this).Show();
			((Window)this).WindowState = WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
		}
	}

	private void method_23()
	{
		((FrameworkElement)this).SetBinding(Window.LeftProperty, (BindingBase)new System.Windows.Data.Binding("WindowX")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(Window.TopProperty, (BindingBase)new System.Windows.Data.Binding("WindowY")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.WidthProperty, (BindingBase)new System.Windows.Data.Binding("WindowWidth")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.HeightProperty, (BindingBase)new System.Windows.Data.Binding("WindowHeight")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/DreamPoeBot;component/dreampoe/mainwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		switch (connectionId)
		{
		default:
			_contentLoaded = true;
			break;
		case 1:
			((FrameworkElement)(object)(MainWindow)target).Loaded += method_19;
			((Window)(object)(MainWindow)target).Closing += method_21;
			((Window)(object)(MainWindow)target).Closed += method_22;
			break;
		case 2:
			((CommandBinding)target).Executed += method_2;
			break;
		case 3:
			((CommandBinding)target).Executed += method_3;
			break;
		case 4:
			((CommandBinding)target).Executed += method_7;
			break;
		case 5:
			((CommandBinding)target).Executed += method_5;
			break;
		case 6:
			((CommandBinding)target).Executed += method_6;
			break;
		case 7:
			((CommandBinding)target).Executed += method_4;
			break;
		case 8:
			((CommandBinding)target).Executed += method_8;
			break;
		case 9:
			((CommandBinding)target).Executed += method_1;
			break;
		case 10:
			StatusBarLeftLabel = (System.Windows.Controls.Label)target;
			break;
		case 11:
			StatusBarRightLabel = (System.Windows.Controls.Label)target;
			break;
		case 12:
			transitioningContentControl_0 = (TransitioningContentControl)target;
			break;
		case 13:
			TitleButton = (System.Windows.Controls.Button)target;
			break;
		case 14:
			ProcessButton = (System.Windows.Controls.Button)target;
			ProcessButton.Click += button_1_Click;
			break;
		case 15:
			TimeLeftButton = (System.Windows.Controls.Button)target;
			break;
		case 16:
			SettingsButton = (System.Windows.Controls.Button)target;
			SettingsButton.Click += button_3_Click;
			break;
		}
	}
}
