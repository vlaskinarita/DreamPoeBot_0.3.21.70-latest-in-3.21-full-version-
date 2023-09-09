using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class DownloadWindow : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly string string_0;

	private readonly string filter;

	internal ProgressRing progressRing_0;

	public DownloadWindow(MainWindow mainWindow, string filter)
	{
		try
		{
			this.filter = filter;
			if (string.IsNullOrEmpty(GlobalSettings.Instance.BuddyUpdaterName))
			{
				string_0 = Path.Combine(Path.GetTempPath(), $"dpbupdater{Environment.TickCount}.exe");
			}
			else
			{
				string_0 = GlobalSettings.Instance.BuddyUpdaterName + ".exe";
			}
			InitializeComponent();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		progressRing_0.IsActive = true;
		ThreadPool.QueueUserWorkItem(method_1);
	}

	private static string EscapeCommandLineArguments(string[] args)
	{
		string text = "";
		foreach (string input in args)
		{
			text += Regex.Replace(input, "(\\\\*)\"", "$1$1\\\"");
		}
		return text;
	}

	private void method_1(object object_0)
	{
		try
		{
			using WebClient webClient = new WebClient();
			webClient.DownloadFile("http://51.75.249.226:9001/DPBUpdater.exe", string_0);
			if (File.Exists(string_0))
			{
				LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.Updating;
				string[] args = CommandLine.Arguments.GetOriginalArguments.ToArray();
				string text = EscapeCommandLineArguments(args);
				string arguments = filter + " \"" + Assembly.GetEntryAssembly().Location + "\" " + GlobalSettings.Instance.CustomRDServerName + " \"" + text + "\"";
				Process.Start(string_0, arguments);
				base.Dispatcher.Invoke(delegate
				{
					Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
				});
			}
			else
			{
				LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.UpdaterNotFound;
				if (!CommandLine.Arguments.Exists("silent"))
				{
					MessageBox.Show("\"Unable to find the file " + string_0 + "\"", Util.RandomWindowTitle("UpdaterError"), MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				base.Dispatcher.Invoke(delegate
				{
					Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
				});
			}
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("[UpdaterError] An exception occurred: {0}.", (object)ex);
			if (!CommandLine.Arguments.Exists("silent"))
			{
				MessageBox.Show("\"UpdaterError\" \n'\r An exception occurred: " + ex.ToString(), Util.RandomWindowTitle("UpdaterError"), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.UpdateException;
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
			});
		}
	}
}
