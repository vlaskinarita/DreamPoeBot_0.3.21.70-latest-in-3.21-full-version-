using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IronPython;
using IronPython.Hosting;
using IronPython.Runtime.Types;
using log4net;
using Microsoft.Scripting.Hosting;

namespace DreamPoeBot.Loki.Common;

public class ScriptManager
{
	public class InputOutputProxy
	{
		private readonly ILog ilog_0;

		public InputOutputProxy()
		{
			ilog_0 = Logger.GetLoggerInstanceForType();
		}

		public InputOutputProxy(ILog log)
		{
			ilog_0 = log;
		}

		public void write(string s)
		{
			ilog_0.DebugFormat("{0}", (object)s);
		}
	}

	[Serializable]
	private sealed class Class398
	{
		public static readonly Class398 Class9 = new Class398();

		public static Func<string, bool> Method9__15_0;

		internal bool method_0(string string_0)
		{
			return !string.IsNullOrEmpty(string_0);
		}
	}

	private ILog ilog_0;

	private ScriptEngine scriptEngine_0;

	private ScriptScope scriptScope_0;

	private readonly AppDomain appDomain_0;

	private static readonly List<string> list_0 = new List<string>
	{
		"System", "System.Threading", "System.Diagnostics", "System.Linq", "System.Linq.Expressions", "System.Windows.Media", "System.Text", "System.Collections", "System.Collections.Concurrent", "System.Collections.Generic",
		"System.Collections.ObjectModel"
	};

	public ScriptEngine Engine => scriptEngine_0;

	public ScriptScope Scope => scriptScope_0;

	public InputOutputProxy IoProxy { get; set; }

	public ScriptManager(AppDomain domain)
	{
		appDomain_0 = domain;
	}

	public ScriptManager()
	{
		appDomain_0 = AppDomain.CurrentDomain;
	}

	public void Deinitialize()
	{
		appDomain_0.AssemblyLoad -= appDomain_0_AssemblyLoad;
		scriptEngine_0 = null;
		scriptScope_0 = null;
	}

	public void Initialize(IEnumerable<Type> shortcutsDefinitions, IEnumerable<string> customNamespaces)
	{
		Initialize(Logger.GetLoggerInstanceForType(), shortcutsDefinitions, customNamespaces);
	}

	public void Initialize(ILog log, IEnumerable<Type> shortcutsDefinitions, IEnumerable<string> customNamespaces)
	{
		ilog_0 = log;
		if (IoProxy == null)
		{
			IoProxy = new InputOutputProxy(ilog_0);
		}
		try
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["DivisionOptions"] = (object)(PythonDivisionOptions)1;
			scriptEngine_0 = Python.CreateEngine((IDictionary<string, object>)dictionary);
			Assembly[] assemblies = appDomain_0.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				scriptEngine_0.Runtime.LoadAssembly(assembly);
			}
			scriptScope_0 = scriptEngine_0.CreateScope();
			method_0(customNamespaces);
			if (shortcutsDefinitions != null)
			{
				foreach (Type shortcutsDefinition in shortcutsDefinitions)
				{
					scriptScope_0.SetVariable(shortcutsDefinition.Name, (object)DynamicHelpers.GetPythonTypeFromType(shortcutsDefinition));
				}
			}
			appDomain_0.AssemblyLoad += appDomain_0_AssemblyLoad;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception while loading Python runtime. Exception follows", ex);
		}
	}

	private void appDomain_0_AssemblyLoad(object sender, AssemblyLoadEventArgs e)
	{
		scriptEngine_0.Runtime.LoadAssembly(e.LoadedAssembly);
	}

	private void method_0(IEnumerable<string> ienumerable_0)
	{
		List<string> list = new List<string>(list_0);
		if (ienumerable_0 != null)
		{
			list.AddRange(ienumerable_0.Where(Class398.Class9.method_0));
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("import clr");
		foreach (string item in list)
		{
			stringBuilder.AppendLine("import " + item);
		}
		foreach (string item2 in list)
		{
			stringBuilder.AppendLine("from " + item2 + " import *");
		}
		foreach (string item3 in list)
		{
			stringBuilder.AppendLine("clr.ImportExtensions(" + item3 + ")");
		}
		scriptEngine_0.Execute(stringBuilder.ToString(), scriptScope_0);
	}

	public Action GetStatement(string statement)
	{
		ScriptSource val = scriptEngine_0.CreateScriptSourceFromString(statement.Trim());
		scriptScope_0.SetVariable("ioproxy", (object)IoProxy);
		val.Execute(scriptScope_0);
		return scriptScope_0.GetVariable<Action>("Execute");
	}

	public string FormatSyntaxErrorException(Exception ex)
	{
		return scriptEngine_0.GetService<ExceptionOperations>(Array.Empty<object>()).FormatException(ex);
	}
}
