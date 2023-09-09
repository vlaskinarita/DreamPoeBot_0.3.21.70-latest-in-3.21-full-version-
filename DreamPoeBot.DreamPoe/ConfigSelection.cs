using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DreamPoeBot.Framework.Helpers;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class ConfigSelection : UserControl, IComponentConnector
{
	private sealed class Class28
	{
		public static readonly Class28 Method9 = new Class28();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}
	}

	private string OldProfileBaseName = "";

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private bool bool_0;

	private void method_0()
	{
		int num = 0;
		bool flag = true;
		string[] directories = Directory.GetDirectories(JsonSettings.SettingsPath, "*.*", SearchOption.TopDirectoryOnly);
		foreach (string text in directories)
		{
			string fileName = Path.GetFileName(text);
			if (!fileName.Equals("Global", StringComparison.OrdinalIgnoreCase))
			{
				if (fileName.Equals("Default", StringComparison.OrdinalIgnoreCase))
				{
					flag = false;
				}
				if (File.Exists(Path.Combine(text, "Gui.json")))
				{
					ConfigComboBox.Items.Add(fileName);
					num++;
				}
			}
		}
		if (num == 0 || flag)
		{
			ConfigComboBox.Items.Add("Default");
		}
	}

	public ConfigSelection(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			method_0();
			OldProfileBaseName = GlobalSettings.Instance.ProfileBaseName;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class28.Method9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = "";
			if (GlobalSettings.Instance.RandomizeProfileSelection)
			{
				ilog_0.DebugFormat("Profile randomization enabled.", Array.Empty<object>());
				string text2 = (string.IsNullOrEmpty(GlobalSettings.Instance.ProfileBaseName) ? "" : GlobalSettings.Instance.ProfileBaseName);
				string text3 = Misc.LoadProfile();
				if (!string.IsNullOrEmpty(text3) && text3.Contains(text2))
				{
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath) && Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.DebugFormat("Profile selected: " + text3 + ", copying files...", Array.Empty<object>());
						Stopwatch stopwatch = Stopwatch.StartNew();
						IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, text3), Path.Combine(JsonSettings.SettingsPath, text3), copySubDirs: true);
						stopwatch.Stop();
						ilog_0.DebugFormat($"Copy completed in {stopwatch.Elapsed:hh\\:mm\\:ss\\.ff}", Array.Empty<object>());
					}
					else
					{
						ilog_0.DebugFormat("Profile selected: " + text3 + ", cant copy files,  files... ProfilesFolderPath is Inacessible.", Array.Empty<object>());
					}
				}
				else
				{
					ilog_0.DebugFormat(string.IsNullOrEmpty(text3) ? "RandomProfileSelected is empty, selecting a new random profile." : ("RandomProfileSelected [" + text3 + "] is different than base name [" + text2 + "], selecting a new random profile."), Array.Empty<object>());
					if (string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Profiles Folder Path is empty, be sure to select a valid path.", Array.Empty<object>());
						MessageBox.Show("Profiles Folder Path is empty, be sure to select a valid path.", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					if (!Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Profiles Folder Path do not exist.", Array.Empty<object>());
						MessageBox.Show("Profiles Folder Path do not exist.", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list = (from x in Directory.EnumerateDirectories(GlobalSettings.Instance.ProfilesFolderPath).ToList()
						where x.Contains(GlobalSettings.Instance.ProfileBaseName)
						select x).ToList();
					if (list.Count <= 0)
					{
						ilog_0.ErrorFormat("[SelectRandomProfile] Found 0 file matching basename: " + GlobalSettings.Instance.ProfileBaseName + " in " + GlobalSettings.Instance.ProfilesFolderPath + ".", Array.Empty<object>());
						MessageBox.Show("Found 0 file matching basename: " + GlobalSettings.Instance.ProfileBaseName + " in " + GlobalSettings.Instance.ProfilesFolderPath + ".", "Invalid ProfilesFolderPath", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list2 = new List<string>(list);
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.BlacklistedProfileWords))
					{
						List<string> list3 = GlobalSettings.Instance.BlacklistedProfileWords.Split(',').ToList();
						for (int num = list.Count - 1; num >= 0; num--)
						{
							bool flag = false;
							string text4 = list[num];
							foreach (string item in list3)
							{
								if (text4.Contains(item))
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								list.RemoveAt(num);
							}
						}
					}
					if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text2))
					{
						ilog_0.DebugFormat("[SelectRandomProfile] Extracting the profile suffix.", Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] randomProfileSelected: " + text3, Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] newProfileBaseName: " + text2, Array.Empty<object>());
						ilog_0.DebugFormat("[SelectRandomProfile] oldProfileBaseName: " + OldProfileBaseName, Array.Empty<object>());
						string text5 = text3.Remove(text3.IndexOf(OldProfileBaseName, StringComparison.Ordinal), OldProfileBaseName.Length);
						if (!string.IsNullOrEmpty(text5))
						{
							ilog_0.DebugFormat($"[SelectRandomProfile] Found suffix: {text5}, filtering profiles. [Initial Count: {list2.Count}]", Array.Empty<object>());
							for (int num2 = list2.Count - 1; num2 >= 0; num2--)
							{
								string text6 = list2[num2];
								if (!text6.Contains(text5))
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
					ilog_0.DebugFormat("Profile selected: " + name + ", copying files...", Array.Empty<object>());
					Stopwatch stopwatch2 = Stopwatch.StartNew();
					IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, name), Path.Combine(JsonSettings.SettingsPath, name), copySubDirs: true);
					stopwatch2.Stop();
					ilog_0.DebugFormat($"Copy completed in {stopwatch2.Elapsed:hh\\:mm\\:ss\\.ff}", Array.Empty<object>());
					text3 = name;
					Misc.SaveProfile(text3);
				}
				text = text3;
			}
			else
			{
				text = ConfigComboBox.Text;
			}
			if (string.IsNullOrEmpty(text))
			{
				MessageBox.Show(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:ChooseConfigErrorEmpty"), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			try
			{
				new FileInfo(text);
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat("[ChooseConfigButton_OnClick] An exception occurred: {0}.", (object)ex);
				MessageBox.Show(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:ChooseConfigErrorInvalid"), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			mainWindow_0.method_20(text);
			mainWindow_0.method_14();
		}
		catch (Exception ex2)
		{
			ilog_0.Error((object)"An exception occurred.", ex2);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class28.Method9.method_1);
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		ChooseConfigButton.Focus();
	}

	private void comboBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Return || e.Key == Key.Return)
		{
			(new ButtonAutomationPeer(ChooseConfigButton).GetPattern(PatternInterface.Invoke) as IInvokeProvider).Invoke();
		}
	}
}
