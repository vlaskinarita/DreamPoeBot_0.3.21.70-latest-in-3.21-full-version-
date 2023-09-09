using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Structures.ns11;

internal static class Class98
{
	private sealed class Class99
	{
		public List<Process> list_0;

		internal void method_0(Process process_0)
		{
			if (smethod_2(process_0) && smethod_3(process_0))
			{
				List<Process> list = list_0;
				lock (list)
				{
					list_0.Add(process_0);
				}
			}
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	internal static Dictionary<Process, string> Dictionary_0
	{
		get
		{
			Dictionary<Process, string> dictionary = new Dictionary<Process, string>();
			foreach (Process item in smethod_4().ToList())
			{
				bool bool_;
				Mutex mutex = smethod_0(item.Id, out bool_);
				if (bool_ && mutex != null)
				{
					string directoryName = Path.GetDirectoryName(item.MainModule.FileName);
					string value = (File.Exists(directoryName + "\\poetw.version") ? "(Unsupported Garena Taiwan Client)" : (File.Exists(directoryName + "\\poe.version") ? "(Unsupported Garena Singapore Client)" : (File.Exists(directoryName + "\\poecis.version") ? "(Unsupported Garena CIS Client)" : ((!File.Exists(directoryName + "\\steam_api.dll")) ? "(Path of Exile Client)" : "(Steam Client)"))));
					dictionary.Add(item, value);
					mutex.ReleaseMutex();
					mutex.Dispose();
				}
			}
			return dictionary;
		}
	}

	internal static Mutex smethod_0(int int_0, out bool bool_0)
	{
		return new Mutex(initiallyOwned: true, "Local\\" + (Environment.MachineName.GetHashCode() ^ int_0.GetHashCode() ^ TimeZone.CurrentTimeZone.StandardName.GetHashCode() ^ ("GGG_PoE_Alcor75".GetHashCode() + 25)), out bool_0);
	}

	internal static bool smethod_1(out Mutex mutex_0, out Process process_0)
	{
		mutex_0 = null;
		process_0 = null;
		Arguments arguments = CommandLine.Arguments;
		if (arguments.Exists("pid"))
		{
			try
			{
				int num = int.Parse(arguments.Single("pid"));
				process_0 = Process.GetProcessById(num);
				if (smethod_3(process_0))
				{
					mutex_0 = smethod_0(num, out var bool_);
					if (bool_)
					{
						return true;
					}
					mutex_0 = null;
					process_0 = null;
					ilog_0.Error((object)("Invalid PID specifier passed to the command line: " + arguments.Single("pid") + ". This process has already been attached to."));
					return false;
				}
				ilog_0.Error((object)("Invalid PID specifier passed to the command line: " + arguments.Single("pid") + ". This process is not a Path of Exile client."));
				return false;
			}
			catch
			{
				ilog_0.Error((object)("Invalid PID specifier passed to the command line: " + arguments.Single("pid")));
				return false;
			}
		}
		if (arguments.Exists("pname"))
		{
			try
			{
				string processName = arguments.Single("pname");
				process_0 = Process.GetProcessesByName(processName).FirstOrDefault();
				if (process_0 != null && smethod_3(process_0))
				{
					mutex_0 = smethod_0(process_0.Id, out var bool_2);
					if (bool_2)
					{
						return true;
					}
					mutex_0 = null;
					process_0 = null;
					ilog_0.Error((object)("Invalid PNAME specifier passed to the command line: " + arguments.Single("pname") + ". This process has already been attached to."));
					return false;
				}
				ilog_0.Error((object)("Invalid PNAME specifier passed to the command line: " + arguments.Single("pname") + ". This process is not a Path of Exile client."));
				return false;
			}
			catch
			{
				ilog_0.Error((object)("Invalid PNAME specifier passed to the command line: " + arguments.Single("pname")));
				return false;
			}
		}
		List<Process> list = smethod_4().ToList();
		if (!list.Any())
		{
			return false;
		}
		if (!arguments.Exists("noautoattach") && list.Count == 1)
		{
			mutex_0 = smethod_0(list[0].Id, out var bool_3);
			if (bool_3)
			{
				process_0 = list[0];
				return true;
			}
			mutex_0.Dispose();
		}
		return false;
	}

	internal static bool smethod_2(Process process_0)
	{
		try
		{
			if (process_0 == null)
			{
				return false;
			}
			if (File.Exists(Path.Combine(Path.GetDirectoryName(process_0.MainModule.FileName), "Content.ggpk")))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	internal static bool smethod_3(Process process_0)
	{
		try
		{
			if (X509Certificate.CreateFromSignedFile(process_0.MainModule.FileName).Subject.Contains("Grinding Gear Games Limited"))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	internal static List<Process> smethod_4()
	{
		Class99 @class = new Class99();
		@class.list_0 = new List<Process>();
		Parallel.ForEach(Process.GetProcesses(), @class.method_0);
		return @class.list_0;
	}
}
