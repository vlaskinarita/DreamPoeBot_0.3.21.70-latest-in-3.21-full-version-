using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.PathfindingClient;
using DreamPoeBot.Structures.ns13;
using log4net;

namespace DreamPoeBot;

public partial class App : System.Windows.Application
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool method_0()
	{
		return true;
	}

	private void method_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("DreamPoeBot Version: " + Assembly.GetEntryAssembly().GetName().Version);
		stringBuilder.AppendLine("Path: " + System.Windows.Forms.Application.ExecutablePath.Replace(Environment.UserName, "<Username>").Replace(AppDomain.CurrentDomain.FriendlyName, "<ExeName>"));
		stringBuilder.AppendLine("Arguments: " + string.Join(" ", CommandLine.Arguments.GetOriginalArguments));
		ManagementObject managementObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get().Cast<ManagementObject>().First();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("OS Name: " + ((string)managementObject["Caption"]).Trim());
		stringBuilder.AppendLine("OS Version: " + (string)managementObject["Version"]);
		stringBuilder.AppendLine("OS Architecture: " + (string)managementObject["OSArchitecture"]);
		stringBuilder.AppendLine("InstalledUICulture: " + CultureInfo.InstalledUICulture.Name + " [" + CultureInfo.InstalledUICulture.EnglishName + "]");
		stringBuilder.AppendLine("CurrentUICulture: " + CultureInfo.CurrentUICulture.Name + " [" + CultureInfo.CurrentUICulture.EnglishName + "]");
		stringBuilder.AppendLine("CurrentCulture: " + CultureInfo.CurrentCulture.Name + " [" + CultureInfo.CurrentCulture.EnglishName + "]");
		ilog_0.Info((object)stringBuilder);
	}

	private void method_2()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("DreamPoeBot Version: " + Assembly.GetEntryAssembly().GetName().Version);
		stringBuilder.AppendLine("Path: " + System.Windows.Forms.Application.ExecutablePath.Replace(Environment.UserName, "<Username>").Replace(AppDomain.CurrentDomain.FriendlyName, "<ExeName>"));
		stringBuilder.AppendLine("Arguments: " + string.Join(" ", CommandLine.Arguments.GetOriginalArguments));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("*** This information may be incorrect ***");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("OS Name: " + OSInfo.Name);
		stringBuilder.AppendLine("OS Edition: " + OSInfo.Edition);
		stringBuilder.AppendLine("OS Service Pack: " + OSInfo.ServicePack);
		stringBuilder.AppendLine("OS Version: " + OSInfo.Version);
		stringBuilder.AppendLine("OS Architecture: x" + (Environment.Is64BitOperatingSystem ? 64 : 86));
		ilog_0.Info((object)stringBuilder);
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		try
		{
			method_1();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred", ex);
			try
			{
				method_2();
			}
			catch (Exception ex2)
			{
				ilog_0.Error((object)"An exception occurred", ex2);
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
		}
		try
		{
			ilog_0.Info((object)"Now setting up JitProfiles...");
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "JitProfiles");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			ProfileOptimization.SetProfileRoot(text);
			ProfileOptimization.StartProfile("JitProfile.jpf");
			ilog_0.Info((object)"JitProfiles successfully setup!");
		}
		catch (Exception ex3)
		{
			ilog_0.Error((object)"An exception occurred", ex3);
		}
		try
		{
			string name = new DirectoryInfo(Environment.CurrentDirectory).Name;
			if (name.ToLowerInvariant().Contains("dreampoebot2"))
			{
				ilog_0.ErrorFormat("Please rename the current directory \"" + name + "\" to something without \"dreampoebot\" in it for your own security ***as soon as possible***.", Array.Empty<object>());
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
			string processName = Process.GetCurrentProcess().ProcessName;
			if (processName.ToLowerInvariant().Contains("dreampoebot2"))
			{
				ilog_0.ErrorFormat("Please rename \"" + processName + "\" to something without \"dreampoebot\" in it for your own security.", Array.Empty<object>());
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
		}
		catch (Exception ex4)
		{
			ilog_0.Error((object)"An exception occurred", ex4);
			Logger.OpenLogFile();
			System.Windows.Application.Current.Shutdown();
			return;
		}
		base.Dispatcher.UnhandledException += method_4;
		AppDomain.CurrentDomain.UnhandledException += method_3;
		try
		{
			ilog_0.Info((object)"Now checking prerequisites...");
			if (!method_0())
			{
				Shutdown((int)LokiPoe.ApplicationExitCodes_0);
				return;
			}
			ilog_0.Info((object)"Prerequisite check complete!");
		}
		catch (Exception ex5)
		{
			ilog_0.ErrorFormat("{0}", (object)ex5);
			Logger.OpenLogFile();
			Shutdown((int)LokiPoe.ApplicationExitCodes_0);
			return;
		}
		base.OnStartup(e);
	}

	private void method_3(object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject != null)
		{
			ilog_0.DebugFormat("Unhandled global exception! {0}", (object)e.ExceptionObject.ToString());
		}
		Class104.smethod_0();
	}

	private void method_4(object sender, DispatcherUnhandledExceptionEventArgs e)
	{
		e.Handled = true;
		if (e.Exception != null)
		{
			ilog_0.Error((object)"[Application_DispatcherUnhandledException] Unhandled exception", e.Exception);
			if (e.Exception.InnerException != null)
			{
				ilog_0.Error((object)"[Application_DispatcherUnhandledException] Unhandled inner exception", e.Exception.InnerException);
			}
		}
	}

	protected override void OnExit(ExitEventArgs e)
	{
		RDClient.Disconnect();
		Class104.smethod_0();
		LokiPoe.smethod_0();
		e.ApplicationExitCode = (int)LokiPoe.ApplicationExitCodes_0;
		base.OnExit(e);
	}
}
