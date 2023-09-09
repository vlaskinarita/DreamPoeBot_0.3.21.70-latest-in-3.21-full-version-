using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.DreamPoe;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.Structures.ns27;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Bot;

public static class ThirdPartyLoader
{
	internal enum SourceType
	{
		Zip,
		Folder,
		Stream
	}

	internal class ThirdPartyLoaderConfiguration
	{
		public string Name { get; set; }

		public SourceType SourceType { get; set; }

		public string String_0 { get; set; }

		public string DirectoryName { get; set; }

		public string String_2 { get; set; }

		public bool Boolean_0 { get; set; }

		public List<string> FileList { get; set; }

		public List<string> DependenciesList { get; set; }

		public List<string> ReferencesList { get; set; }
	}

	private sealed class Class473
	{
		public static readonly Class473 Class9 = new Class473();

		public static Func<KeyValuePair<string, ThirdPartyInstance>, ThirdPartyInstance> Method9__26_0;

		public static Func<IBot, string> Method9__33_0;

		public static Func<IPlugin, string> Method9__33_1;

		public static Func<IRoutine, string> Method9__33_2;

		public static Func<IContent, string> Method9__33_3;

		public static Func<IPlayerMover, string> Method9__33_4;

		public static Func<ZipArchiveEntry, bool> Method9__34_0;

		public static Func<string, bool> Method9__35_0;

		public static Func<string, string> Method9__36_6;

		public static Func<string, string> Method9__36_7;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, bool> Method9__36_0;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_1;

		public static Func<string, string> Method9__36_2;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_4;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, ThirdPartyLoaderConfiguration> Method9__36_5;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_9;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, ThirdPartyLoaderConfiguration> Method9__36_10;

		internal ThirdPartyInstance method_0(KeyValuePair<string, ThirdPartyInstance> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}

		internal string method_1(IBot ibot_0)
		{
			return ibot_0.GetType().Name + " (" + ibot_0.Name + ": " + ibot_0.Version + ")";
		}

		internal string method_2(IPlugin iplugin_0)
		{
			return iplugin_0.GetType().Name + " (" + iplugin_0.Name + ": " + iplugin_0.Version + ")";
		}

		internal string method_3(IRoutine iroutine_0)
		{
			return iroutine_0.GetType().Name + " (" + iroutine_0.Name + ": " + iroutine_0.Version + ")";
		}

		internal string method_4(IContent icontent_0)
		{
			return icontent_0.GetType().Name + " (" + icontent_0.Name + ": " + icontent_0.Version + ")";
		}

		internal string method_5(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.GetType().Name + " (" + iplayerMover_0.Name + ": " + iplayerMover_0.Version + ")";
		}

		internal bool method_6(ZipArchiveEntry zipArchiveEntry_0)
		{
			return zipArchiveEntry_0.Name.Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_7(string string_0)
		{
			return Path.GetFileName(string_0).Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase);
		}

		internal string method_8(string string_0)
		{
			return string_0;
		}

		internal string method_9(string string_0)
		{
			return string_0;
		}

		internal bool method_10(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return !keyValuePair_0.Value.DependenciesList.Any();
		}

		internal string method_11(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal string method_12(string string_0)
		{
			return string_0;
		}

		internal string method_13(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key.ToLowerInvariant();
		}

		internal ThirdPartyLoaderConfiguration method_14(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}

		internal string method_15(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key.ToLowerInvariant();
		}

		internal ThirdPartyLoaderConfiguration method_16(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}
	}

	private sealed class Class474
	{
		public Dictionary<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyNames;

		public Dictionary<string, string> dictionary_1;

		public Action<string> action_0;

		internal void method_0(string string_0)
		{
			Compile(dictionaryAssemblyNames, string_0);
		}

		internal void method_Premium(KeyValuePair<string, byte[]> pair)
		{
			CompileStream(pair);
		}

		internal void method_1(string string_0)
		{
			Compile(dictionaryAssemblyNames, dictionary_1[string_0]);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForName("ThirdPartyLoader");

	private const string string_0 = "_CONFIGS_";

	private static Dictionary<string, ThirdPartyInstance> dictionary_0;

	private static Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_1;

	private static readonly List<CompilerErrorCollection> compileErrorsList = new List<CompilerErrorCollection>();

	private static readonly List<Exception> compileExceptionsList = new List<Exception>();

	private static readonly List<string> errorsList = new List<string>();

	private static readonly List<string> cleanupPaths = new List<string>();

	private const string string_1 = "3rdparty.json";

	private static string String_0 => Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

	public static string ThirdPartyPath => Path.Combine(String_0, "3rdParty");

	public static string RootPath => Path.Combine(ThirdPartyPath, "_CONFIGS_");

	public static string ProfileConfigPath => Path.Combine(RootPath, "Production");

	public static IReadOnlyList<string> CleanupPaths => cleanupPaths;

	public static IReadOnlyList<CompilerErrorCollection> CompileErrors
	{
		get
		{
			List<CompilerErrorCollection> list = compileErrorsList;
			lock (list)
			{
				return compileErrorsList.ToList();
			}
		}
	}

	public static IReadOnlyList<Exception> CompileExceptions
	{
		get
		{
			List<Exception> list = compileExceptionsList;
			lock (list)
			{
				return compileExceptionsList.ToList();
			}
		}
	}

	public static IReadOnlyList<string> LoadErrors
	{
		get
		{
			List<string> list = errorsList;
			lock (list)
			{
				return errorsList.ToList();
			}
		}
	}

	public static IReadOnlyList<ThirdPartyInstance> Instances => dictionary_0.Select(Class473.Class9.method_0).ToList();

	public static ThirdPartyInstance GetInstance(string name)
	{
		dictionary_0.TryGetValue(name, out var value);
		return value;
	}

	private static string smethod_0(string string_2)
	{
		using MD5 mD = MD5.Create();
		using FileStream inputStream = File.OpenRead(string_2);
		return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLower();
	}

	private static void DeleteDirectoryAndVerify(string string_2, string string_3)
	{
		try
		{
			Directory.Delete(string_2, recursive: true);
		}
		catch
		{
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (Directory.Exists(string_2))
		{
			ilog_0.InfoFormat("[DeleteDirectoryAndVerify] Waiting for the [{0}] directory to be deleted.", (object)string_3);
			Thread.Sleep(1000);
			try
			{
				Directory.Delete(string_2, recursive: true);
			}
			catch
			{
			}
			if (stopwatch.ElapsedMilliseconds > 5000L)
			{
				throw new Exception($"[DeleteDirectoryAndVerify] {stopwatch.Elapsed} elapsed when waiting for the [{string_3}] directory to be deleted.");
			}
		}
	}

	private static void CreateDirectoryAndVerify(string string_2, string string_3)
	{
		try
		{
			Directory.CreateDirectory(string_2);
		}
		catch
		{
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (!Directory.Exists(string_2))
		{
			ilog_0.InfoFormat("[CreateDirectoryAndVerify] Waiting for the [{0}] directory to be created.", (object)string_3);
			Thread.Sleep(1000);
			try
			{
				Directory.CreateDirectory(string_2);
			}
			catch
			{
			}
			if (stopwatch.ElapsedMilliseconds > 5000L)
			{
				throw new Exception($"[CreateDirectoryAndVerify] {stopwatch.Elapsed} elapsed when waiting for the [{string_3}] directory to be created.");
			}
		}
	}

	public static void RedirectAssembly()
	{
		ResolveEventHandler value = (object sender, ResolveEventArgs args) => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == new AssemblyName(args.Name).Name);
		AppDomain.CurrentDomain.AssemblyResolve += value;
	}

	internal static bool CompileStream(KeyValuePair<string, byte[]> data)
	{
		try
		{
			RedirectAssembly();
			Assembly assembly = Assembly.Load(data.Value);
			string fullName = assembly.FullName;
			string name = fullName.Split(',')[0];
			ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(fullName, "", "", assembly);
			Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
			lock (dictionary)
			{
				dictionary_0.Add(fullName, thirdPartyInstance);
				ilog_0.InfoFormat("{0}", (object)fullName);
				ilog_0.InfoFormat("                   [Bots] : {0}", (object)string.Join(", ", thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
				ilog_0.InfoFormat("                   [Plugins] : {0}", (object)string.Join(", ", thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
				ilog_0.InfoFormat("                   [Routines] : {0}", (object)string.Join(", ", thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
				ilog_0.InfoFormat("                   [Content] : {0}", (object)string.Join(", ", thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
				ilog_0.InfoFormat("                   [PlayerMovers] : {0}", (object)string.Join(", ", thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
			}
			if (GlobalSettings.Instance.PremiumContent.All((PremiumContentClass x) => x.Id != data.Key))
			{
				PremiumContentClass item = new PremiumContentClass
				{
					Name = name,
					Id = data.Key,
					Enabled = true
				};
				GlobalSettings.Instance.PremiumContent.Add(item);
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return false;
		}
		return true;
	}

	internal static bool Compile(Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, string name)
	{
		try
		{
			string text = Path.Combine(ProfileConfigPath, name);
			bool flag = false;
			if (Directory.Exists(text) && CommandLine.Arguments.Exists("forcedll"))
			{
				List<string> source = Directory.EnumerateDirectories(text).ToList();
				string text2 = source.OrderByDescending((string x) => x).FirstOrDefault((string x) => x.Contains("Content-"));
				string text3 = source.OrderByDescending((string x) => x).FirstOrDefault((string x) => x.Contains("Compiled-"));
				if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3) && File.Exists(Path.Combine(text3, name + ".dll")))
				{
					string assemblyFile = Path.Combine(text3, name + ".dll");
					try
					{
						RedirectAssembly();
						Assembly compiledAssembly = Assembly.LoadFrom(assemblyFile);
						flag = true;
						ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(name, text2, text3, compiledAssembly);
						Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
						lock (dictionary)
						{
							dictionary_0.Add(name, thirdPartyInstance);
							ilog_0.InfoFormat("{0}", (object)name);
							ilog_0.InfoFormat("                   [Bots] : {0}", (object)string.Join(", ", thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
							ilog_0.InfoFormat("                   [Plugins] : {0}", (object)string.Join(", ", thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
							ilog_0.InfoFormat("                   [Routines] : {0}", (object)string.Join(", ", thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
							ilog_0.InfoFormat("                   [Content] : {0}", (object)string.Join(", ", thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
							ilog_0.InfoFormat("                   [PlayerMovers] : {0}", (object)string.Join(", ", thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
						}
					}
					catch (Exception value)
					{
						flag = false;
						Console.WriteLine(value);
					}
				}
			}
			if (!flag && !CommandLine.Arguments.Exists("nocompile"))
			{
				try
				{
					if (Directory.Exists(text))
					{
						string[] directories = Directory.GetDirectories(text);
						foreach (string path in directories)
						{
							try
							{
								Directory.Delete(path, recursive: true);
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
				int tickCount = Environment.TickCount;
				string text4 = Path.Combine(text, "Content-" + tickCount);
				string text5 = Path.Combine(text, "Compiled-" + tickCount);
				List<string> list = cleanupPaths;
				lock (list)
				{
					cleanupPaths.Add(text4);
					cleanupPaths.Add(text5);
				}
				ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = dictionary_2[name];
				string text6 = thirdPartyLoaderConfiguration.DirectoryName;
				if (Directory.Exists(text5))
				{
					DeleteDirectoryAndVerify(text5, "compiled");
				}
				CreateDirectoryAndVerify(text5, "compiled");
				string path2 = Path.Combine(text4, "do_not_delete.txt");
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = true;
				if (Directory.Exists(text4))
				{
					bool flag5 = false;
					if (!File.Exists(path2))
					{
						flag5 = true;
					}
					else if (File.ReadAllText(path2).Trim() != thirdPartyLoaderConfiguration.String_2)
					{
						flag5 = true;
					}
					else
					{
						flag4 = false;
					}
					if (flag5)
					{
						DeleteDirectoryAndVerify(text4, "content");
						flag2 = true;
						flag3 = true;
					}
				}
				else
				{
					flag2 = true;
					flag3 = true;
				}
				if (flag2)
				{
					CreateDirectoryAndVerify(text4, "content");
				}
				if (flag3 && thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
				{
					File.WriteAllText(path2, thirdPartyLoaderConfiguration.String_2);
				}
				if (flag4)
				{
					if (!string.IsNullOrEmpty(text6))
					{
						text6 += "/";
					}
					bool flag6 = string.IsNullOrEmpty(text6);
					int length = text6.Length;
					List<string> list2 = new List<string>(thirdPartyLoaderConfiguration.FileList);
					if (thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
					{
						using ZipArchive zipArchive = ZipFile.Open(thirdPartyLoaderConfiguration.String_0, ZipArchiveMode.Read);
						foreach (ZipArchiveEntry entry in zipArchive.Entries)
						{
							if (!flag6 && entry.FullName.IndexOf(text6, StringComparison.OrdinalIgnoreCase) != 0)
							{
								continue;
							}
							string text7 = (flag6 ? entry.FullName : entry.FullName.Substring(length));
							text7 = text7.Replace('\\', '/');
							if (!string.IsNullOrEmpty(entry.Name))
							{
								if (Path.GetFileName(text7).Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase))
								{
									continue;
								}
								if (thirdPartyLoaderConfiguration.Boolean_0)
								{
									string item = text7.ToLowerInvariant();
									if (!thirdPartyLoaderConfiguration.FileList.Contains(item))
									{
										continue;
									}
									list2.Remove(item);
								}
								string text8 = Path.Combine(text4, text7);
								string directoryName = Path.GetDirectoryName(text8);
								if (!string.IsNullOrEmpty(directoryName))
								{
									Directory.CreateDirectory(directoryName);
								}
								entry.ExtractToFile(text8);
							}
							else if (!string.IsNullOrEmpty(text7))
							{
								CreateDirectoryAndVerify(Path.Combine(text4, text7), "zip-content");
							}
						}
					}
					else if (thirdPartyLoaderConfiguration.SourceType == SourceType.Folder)
					{
						string[] directories2 = Directory.GetDirectories(thirdPartyLoaderConfiguration.DirectoryName, "*.*", SearchOption.AllDirectories);
						for (int j = 0; j < directories2.Length; j++)
						{
							string path3 = directories2[j].Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
							CreateDirectoryAndVerify(Path.Combine(text4, path3), "folder-content");
						}
						string[] files = Directory.GetFiles(thirdPartyLoaderConfiguration.DirectoryName, "*.*", SearchOption.AllDirectories);
						foreach (string text9 in files)
						{
							string text10 = (flag6 ? text9 : text9.Substring(length));
							text10 = text10.Replace('\\', '/');
							if (Path.GetFileName(text10).Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							if (thirdPartyLoaderConfiguration.Boolean_0)
							{
								string item2 = text10.ToLowerInvariant();
								if (!thirdPartyLoaderConfiguration.FileList.Contains(item2))
								{
									continue;
								}
								list2.Remove(item2);
							}
							string path4 = text9.Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
							File.Copy(text9, Path.Combine(text4, path4));
						}
					}
					if (thirdPartyLoaderConfiguration.Boolean_0 && list2.Any())
					{
						list = errorsList;
						lock (list)
						{
							errorsList.Add(thirdPartyLoaderConfiguration.Name);
						}
						ilog_0.ErrorFormat("Cannot load [{0}] because files are missing: [{1}].", (object)name, (object)string.Join(", ", list2));
						return false;
					}
				}
				Class470 @class = new Class470(name, text4, text5, thirdPartyLoaderConfiguration.ReferencesList);
				CompilerResults compilerResults = @class.DoCompile();
				if (compilerResults != null)
				{
					if (compilerResults.Errors.HasErrors)
					{
						List<CompilerErrorCollection> list3 = compileErrorsList;
						lock (list3)
						{
							compileErrorsList.Add(compilerResults.Errors);
						}
						StringBuilder stringBuilder = new StringBuilder();
						foreach (object error in compilerResults.Errors)
						{
							stringBuilder.AppendLine(error.ToString());
						}
						throw new Exception(stringBuilder.ToString());
					}
					ThirdPartyInstance thirdPartyInstance2 = new ThirdPartyInstance(name, text4, text5, @class.CompiledAssembly);
					Dictionary<string, ThirdPartyInstance> dictionary2 = dictionary_0;
					lock (dictionary2)
					{
						dictionary_0.Add(name, thirdPartyInstance2);
						ilog_0.InfoFormat("{0}", (object)name);
						ilog_0.InfoFormat("                   [Bots] : {0}", (object)string.Join(", ", thirdPartyInstance2.BotInstances.Select(Class473.Class9.method_1)));
						ilog_0.InfoFormat("                   [Plugins] : {0}", (object)string.Join(", ", thirdPartyInstance2.PluginInstances.Select(Class473.Class9.method_2)));
						ilog_0.InfoFormat("                   [Routines] : {0}", (object)string.Join(", ", thirdPartyInstance2.RoutineInstances.Select(Class473.Class9.method_3)));
						ilog_0.InfoFormat("                   [Content] : {0}", (object)string.Join(", ", thirdPartyInstance2.ContentInstances.Select(Class473.Class9.method_4)));
						ilog_0.InfoFormat("                   [PlayerMovers] : {0}", (object)string.Join(", ", thirdPartyInstance2.PlayerMoverInstances.Select(Class473.Class9.method_5)));
					}
					return true;
				}
				ilog_0.ErrorFormat("Cannot load [{0}] because there was nothing to compile.", (object)name);
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("Cannot load [{0}] because an exception occurred [{1}].", (object)name, (object)ex.Message);
			List<Exception> list4 = compileExceptionsList;
			lock (list4)
			{
				compileExceptionsList.Add(ex);
			}
			if (ex is ReflectionTypeLoadException)
			{
				Exception[] loaderExceptions = (ex as ReflectionTypeLoadException).LoaderExceptions;
				foreach (Exception ex2 in loaderExceptions)
				{
					ilog_0.ErrorFormat("{0}", (object)ex2);
				}
			}
			else
			{
				ilog_0.ErrorFormat("{0}", (object)ex);
			}
		}
		return false;
	}

	internal static bool CompileOriginal(Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, string name)
	{
		try
		{
			string text = Path.Combine(ProfileConfigPath, name);
			try
			{
				if (Directory.Exists(text))
				{
					string[] directories = Directory.GetDirectories(text);
					foreach (string path in directories)
					{
						try
						{
							Directory.Delete(path, recursive: true);
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
			int tickCount = Environment.TickCount;
			string text2 = Path.Combine(text, "Content-" + tickCount);
			string text3 = Path.Combine(text, "Compiled-" + tickCount);
			List<string> list = cleanupPaths;
			lock (list)
			{
				cleanupPaths.Add(text2);
				cleanupPaths.Add(text3);
			}
			ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = dictionary_2[name];
			string text4 = thirdPartyLoaderConfiguration.DirectoryName;
			if (Directory.Exists(text3))
			{
				DeleteDirectoryAndVerify(text3, "compiled");
			}
			CreateDirectoryAndVerify(text3, "compiled");
			string path2 = Path.Combine(text2, "do_not_delete.txt");
			bool flag = false;
			bool flag2 = false;
			bool flag3 = true;
			if (Directory.Exists(text2))
			{
				bool flag4 = false;
				if (File.Exists(path2))
				{
					if (!(File.ReadAllText(path2).Trim() != thirdPartyLoaderConfiguration.String_2))
					{
						flag3 = false;
					}
					else
					{
						flag4 = true;
					}
				}
				else
				{
					flag4 = true;
				}
				if (flag4)
				{
					DeleteDirectoryAndVerify(text2, "content");
					flag = true;
					flag2 = true;
				}
			}
			else
			{
				flag = true;
				flag2 = true;
			}
			if (flag)
			{
				CreateDirectoryAndVerify(text2, "content");
			}
			if (flag2 && thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
			{
				File.WriteAllText(path2, thirdPartyLoaderConfiguration.String_2);
			}
			if (flag3)
			{
				if (!string.IsNullOrEmpty(text4))
				{
					text4 += "/";
				}
				bool flag5 = string.IsNullOrEmpty(text4);
				int length = text4.Length;
				List<string> list2 = new List<string>(thirdPartyLoaderConfiguration.FileList);
				if (thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
				{
					using ZipArchive zipArchive = ZipFile.Open(thirdPartyLoaderConfiguration.String_0, ZipArchiveMode.Read);
					foreach (ZipArchiveEntry entry in zipArchive.Entries)
					{
						if (!flag5 && entry.FullName.IndexOf(text4, StringComparison.OrdinalIgnoreCase) != 0)
						{
							continue;
						}
						string text5 = (flag5 ? entry.FullName : entry.FullName.Substring(length));
						text5 = text5.Replace('\\', '/');
						if (string.IsNullOrEmpty(entry.Name))
						{
							if (!string.IsNullOrEmpty(text5))
							{
								CreateDirectoryAndVerify(Path.Combine(text2, text5), "zip-content");
							}
						}
						else
						{
							if (Path.GetFileName(text5).Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							if (thirdPartyLoaderConfiguration.Boolean_0)
							{
								string item = text5.ToLowerInvariant();
								if (!thirdPartyLoaderConfiguration.FileList.Contains(item))
								{
									continue;
								}
								list2.Remove(item);
							}
							string text6 = Path.Combine(text2, text5);
							string directoryName = Path.GetDirectoryName(text6);
							if (!string.IsNullOrEmpty(directoryName))
							{
								Directory.CreateDirectory(directoryName);
							}
							entry.ExtractToFile(text6);
						}
					}
				}
				else if (thirdPartyLoaderConfiguration.SourceType == SourceType.Folder)
				{
					string[] directories2 = Directory.GetDirectories(thirdPartyLoaderConfiguration.DirectoryName, "*.*", SearchOption.AllDirectories);
					for (int j = 0; j < directories2.Length; j++)
					{
						string path3 = directories2[j].Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
						CreateDirectoryAndVerify(Path.Combine(text2, path3), "folder-content");
					}
					string[] files = Directory.GetFiles(thirdPartyLoaderConfiguration.DirectoryName, "*.*", SearchOption.AllDirectories);
					foreach (string text7 in files)
					{
						string text8 = (flag5 ? text7 : text7.Substring(length));
						text8 = text8.Replace('\\', '/');
						if (Path.GetFileName(text8).Equals("3rdparty.json", StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
						if (thirdPartyLoaderConfiguration.Boolean_0)
						{
							string item2 = text8.ToLowerInvariant();
							if (!thirdPartyLoaderConfiguration.FileList.Contains(item2))
							{
								continue;
							}
							list2.Remove(item2);
						}
						string path4 = text7.Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
						File.Copy(text7, Path.Combine(text2, path4));
					}
				}
				if (thirdPartyLoaderConfiguration.Boolean_0 && list2.Any())
				{
					list = errorsList;
					lock (list)
					{
						errorsList.Add(thirdPartyLoaderConfiguration.Name);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because files are missing: [{1}].", (object)name, (object)string.Join(", ", list2));
					return false;
				}
			}
			Class470 @class = new Class470(name, text2, text3, thirdPartyLoaderConfiguration.ReferencesList);
			CompilerResults compilerResults = @class.DoCompile();
			if (compilerResults != null)
			{
				if (compilerResults.Errors.HasErrors)
				{
					List<CompilerErrorCollection> list3 = compileErrorsList;
					lock (list3)
					{
						compileErrorsList.Add(compilerResults.Errors);
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object error in compilerResults.Errors)
					{
						stringBuilder.AppendLine(error.ToString());
					}
					throw new Exception(stringBuilder.ToString());
				}
				ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(name, text2, text3, @class.CompiledAssembly);
				Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
				lock (dictionary)
				{
					dictionary_0.Add(name, thirdPartyInstance);
					ilog_0.InfoFormat("{0}", (object)name);
					ilog_0.InfoFormat("                   [Bots] : {0}", (object)string.Join(", ", thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
					ilog_0.InfoFormat("                   [Plugins] : {0}", (object)string.Join(", ", thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
					ilog_0.InfoFormat("                   [Routines] : {0}", (object)string.Join(", ", thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
					ilog_0.InfoFormat("                   [Content] : {0}", (object)string.Join(", ", thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
					ilog_0.InfoFormat("                   [PlayerMovers] : {0}", (object)string.Join(", ", thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
				}
				return true;
			}
			ilog_0.ErrorFormat("Cannot load [{0}] because there was nothing to compile.", (object)name);
			return false;
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("Cannot load [{0}] because an exception occurred [{1}].", (object)name, (object)ex.Message);
			List<Exception> list4 = compileExceptionsList;
			lock (list4)
			{
				compileExceptionsList.Add(ex);
			}
			if (ex is ReflectionTypeLoadException)
			{
				Exception[] loaderExceptions = (ex as ReflectionTypeLoadException).LoaderExceptions;
				foreach (Exception ex2 in loaderExceptions)
				{
					ilog_0.ErrorFormat("{0}", (object)ex2);
				}
			}
			else
			{
				ilog_0.ErrorFormat("{0}", (object)ex);
			}
		}
		return false;
	}

	private static void PrecompileFromZip(string zipFileName, Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, List<string> list_4)
	{
		string text = "";
		try
		{
			text = Path.GetFileNameWithoutExtension(zipFileName);
			ilog_0.DebugFormat("Now loading [{0}].", (object)text);
			using ZipArchive zipArchive = ZipFile.Open(zipFileName, ZipArchiveMode.Read);
			ThirdPartyConfig thirdPartyConfig = null;
			string text2 = null;
			ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault(Class473.Class9.method_6);
			if (zipArchiveEntry != null)
			{
				using (TextReader textReader = new StreamReader(zipArchiveEntry.Open()))
				{
					try
					{
						thirdPartyConfig = JsonConvert.DeserializeObject<ThirdPartyConfig>(textReader.ReadToEnd());
						thirdPartyConfig.Validate();
					}
					catch (Exception ex)
					{
						List<string> list = errorsList;
						lock (list)
						{
							errorsList.Add(text);
						}
						ilog_0.ErrorFormat("Cannot load [{0}] because the [{1}] file could not be deserialized: {2}", (object)text, (object)"3rdparty.json", (object)ex);
						return;
					}
				}
				text2 = thirdPartyConfig.AssemblyName;
				if (string.IsNullOrEmpty(text2))
				{
					List<string> list2 = errorsList;
					lock (list2)
					{
						errorsList.Add(text);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because the AssemblyName in the [{1}] file is empty.", (object)text, (object)"3rdparty.json");
					return;
				}
				string directoryName = Path.GetDirectoryName(zipArchiveEntry.FullName);
				if (dictionary_2.ContainsKey(text2))
				{
					List<string> list3 = errorsList;
					lock (list3)
					{
						errorsList.Add(text);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because the assembly name [{1}] is already in use.", (object)text, (object)text2);
					return;
				}
				if (list_4.Contains(text2.ToLowerInvariant()))
				{
					ilog_0.WarnFormat("Will not load [{0}] because the assembly name [{1}] is in the [DisabledContent] list.", (object)text, (object)text2);
					return;
				}
				ilog_0.DebugFormat("[{0}] will be loaded as [{1}]. The base path is [{2}].", (object)text, (object)text2, (object)directoryName);
				ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = new ThirdPartyLoaderConfiguration
				{
					Name = text2,
					SourceType = SourceType.Zip,
					String_0 = zipFileName,
					DirectoryName = directoryName,
					String_2 = smethod_0(zipFileName),
					Boolean_0 = false,
					FileList = new List<string>(),
					DependenciesList = new List<string>(),
					ReferencesList = new List<string>()
				};
				if (thirdPartyConfig.FileList.Any())
				{
					thirdPartyLoaderConfiguration.Boolean_0 = true;
					foreach (string file in thirdPartyConfig.FileList)
					{
						thirdPartyLoaderConfiguration.FileList.Add(file.Replace('\\', '/').ToLowerInvariant());
					}
				}
				if (thirdPartyConfig.Dependencies.Any())
				{
					thirdPartyLoaderConfiguration.DependenciesList.AddRange(thirdPartyConfig.Dependencies);
				}
				if (thirdPartyConfig.References.Any())
				{
					thirdPartyLoaderConfiguration.ReferencesList.AddRange(thirdPartyConfig.References);
				}
				dictionary_2.Add(text2, thirdPartyLoaderConfiguration);
			}
			else
			{
				List<string> list4 = errorsList;
				lock (list4)
				{
					errorsList.Add(text);
				}
				ilog_0.ErrorFormat("Cannot load [{0}] because there is no [{1}] file.", (object)text, (object)"3rdparty.json");
			}
		}
		catch (Exception ex2)
		{
			List<Exception> list5 = compileExceptionsList;
			lock (list5)
			{
				compileExceptionsList.Add(ex2);
			}
			ilog_0.ErrorFormat("Cannot load [{0}] because an exception occurred [{1}].", (object)text, (object)ex2.Message);
			ilog_0.ErrorFormat("{0}", (object)ex2);
		}
	}

	public static T Deserialize<T>(byte[] data, Encoding encoding = null) where T : class
	{
		using MemoryStream stream = new MemoryStream(data);
		if (encoding == null)
		{
			using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
			{
				return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
			}
		}
		using StreamReader streamReader2 = new StreamReader(stream, encoding);
		return JsonConvert.DeserializeObject<T>(streamReader2.ReadToEnd());
	}

	private static void PrecompileFromDirectory(string directiryName, Dictionary<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyNames, List<string> disabledContent)
	{
		string fileName = Path.GetFileName(directiryName);
		if (string.IsNullOrEmpty(fileName) || fileName.Equals("_CONFIGS_", StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		try
		{
			ilog_0.DebugFormat("Now loading [{0}].", (object)fileName);
			ThirdPartyConfig thirdPartyConfig = null;
			string text = null;
			string text2 = Directory.GetFiles(directiryName, "*.json", SearchOption.AllDirectories).FirstOrDefault(Class473.Class9.method_7);
			if (text2 != null)
			{
				try
				{
					Deserialize<ThirdPartyConfig>(new byte[0], Encoding.UTF8);
					thirdPartyConfig = JsonConvert.DeserializeObject<ThirdPartyConfig>(File.ReadAllText(text2));
					thirdPartyConfig.Validate();
				}
				catch (Exception ex)
				{
					List<string> list = errorsList;
					lock (list)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because the [{1}] file could not be deserialized: {2}", (object)fileName, (object)"3rdparty.json", (object)ex);
					return;
				}
				text = thirdPartyConfig.AssemblyName;
				if (string.IsNullOrEmpty(text))
				{
					List<string> list2 = errorsList;
					lock (list2)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because the AssemblyName in the [{1}] file is empty.", (object)fileName, (object)"3rdparty.json");
					return;
				}
				string directoryName = Path.GetDirectoryName(text2);
				if (dictionaryAssemblyNames.ContainsKey(text))
				{
					List<string> list3 = errorsList;
					lock (list3)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat("Cannot load [{0}] because the assembly name [{1}] is already in use.", (object)fileName, (object)text);
				}
				else if (!disabledContent.Contains(text.ToLowerInvariant()))
				{
					string text3 = directoryName.Replace(directiryName, "").Trim('/', '\\');
					ilog_0.DebugFormat("[{0}] will be loaded as [{1}]. The base path is [{2}].", (object)fileName, (object)text, (object)text3);
					ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = new ThirdPartyLoaderConfiguration
					{
						Name = text,
						SourceType = SourceType.Folder,
						DirectoryName = directoryName,
						String_2 = "",
						Boolean_0 = false,
						FileList = new List<string>(),
						DependenciesList = new List<string>(),
						ReferencesList = new List<string>()
					};
					if (thirdPartyConfig.FileList.Any())
					{
						thirdPartyLoaderConfiguration.Boolean_0 = true;
						foreach (string file in thirdPartyConfig.FileList)
						{
							thirdPartyLoaderConfiguration.FileList.Add(file.Replace('\\', '/').ToLowerInvariant());
						}
					}
					if (thirdPartyConfig.Dependencies.Any())
					{
						thirdPartyLoaderConfiguration.DependenciesList.AddRange(thirdPartyConfig.Dependencies);
					}
					if (thirdPartyConfig.References.Any())
					{
						thirdPartyLoaderConfiguration.ReferencesList.AddRange(thirdPartyConfig.References);
					}
					dictionaryAssemblyNames.Add(text, thirdPartyLoaderConfiguration);
				}
				else
				{
					ilog_0.WarnFormat("Cannot load [{0}] because the assembly name [{1}] is in the [DisabledContent] list.", (object)fileName, (object)text);
				}
			}
			else
			{
				List<string> list4 = errorsList;
				lock (list4)
				{
					errorsList.Add(fileName);
				}
				ilog_0.ErrorFormat("Cannot load [{0}] because there is no [{1}] file.", (object)fileName, (object)"3rdparty.json");
			}
		}
		catch (Exception ex2)
		{
			List<Exception> list5 = compileExceptionsList;
			lock (list5)
			{
				compileExceptionsList.Add(ex2);
			}
			ilog_0.ErrorFormat("Cannot load [{0}] because an exception occurred [{1}].", (object)fileName, (object)ex2.Message);
			ilog_0.ErrorFormat("{0}", (object)ex2);
		}
	}

	internal static void CompileAllTherdParty(List<string> disabledPlugin, bool compileAsync)
	{
		string thirdPartyPath = ThirdPartyPath;
		dictionary_0 = new Dictionary<string, ThirdPartyInstance>();
		dictionary_1 = new Dictionary<string, ThirdPartyLoaderConfiguration>();
		ilog_0.DebugFormat("Loading start.", Array.Empty<object>());
		try
		{
			Class474 @class = new Class474();
			if (!Directory.Exists(thirdPartyPath))
			{
				ilog_0.DebugFormat("The directory does not exist. Now creating it.", Array.Empty<object>());
				Directory.CreateDirectory(thirdPartyPath);
				return;
			}
			@class.dictionaryAssemblyNames = new Dictionary<string, ThirdPartyLoaderConfiguration>();
			foreach (string item in Directory.GetDirectories(thirdPartyPath, "*.*", SearchOption.TopDirectoryOnly).OrderBy(Class473.Class9.method_8))
			{
				PrecompileFromDirectory(item, @class.dictionaryAssemblyNames, disabledPlugin);
			}
			foreach (string item2 in Directory.GetFiles(thirdPartyPath, "*.zip", SearchOption.TopDirectoryOnly).OrderBy(Class473.Class9.method_9))
			{
				PrecompileFromZip(item2, @class.dictionaryAssemblyNames, disabledPlugin);
			}
			@class.dictionary_1 = new Dictionary<string, string>();
			foreach (KeyValuePair<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyName in @class.dictionaryAssemblyNames)
			{
				@class.dictionary_1.Add(dictionaryAssemblyName.Key.ToLowerInvariant(), dictionaryAssemblyName.Key);
			}
			List<string> list = (from x in @class.dictionaryAssemblyNames
				where !x.Value.DependenciesList.Any()
				select x.Key).OrderBy(Class473.Class9.method_12).ToList();
			Stopwatch stopwatch;
			if (compileAsync)
			{
				ilog_0.InfoFormat("Now asynchronously compiling dependency free content...", Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				Parallel.ForEach(list, @class.method_0);
			}
			else
			{
				ilog_0.InfoFormat("Now synchronously compiling dependency free content...", Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				foreach (string item3 in list)
				{
					Compile(@class.dictionaryAssemblyNames, item3);
				}
			}
			ilog_0.InfoFormat("Content compiled in {0}.", (object)stopwatch.Elapsed);
			Dictionary<string, ThirdPartyLoaderConfiguration> dictionary = @class.dictionaryAssemblyNames.ToDictionary(Class473.Class9.method_13, Class473.Class9.method_14);
			foreach (string item4 in list)
			{
				dictionary.Remove(item4.ToLowerInvariant());
			}
			if (dictionary.Any())
			{
				for (int i = 0; i < 16; i++)
				{
					if (!dictionary.Any())
					{
						break;
					}
					list = new List<string>();
					foreach (KeyValuePair<string, ThirdPartyLoaderConfiguration> item5 in dictionary)
					{
						bool flag = true;
						foreach (string dependencies in item5.Value.DependenciesList)
						{
							if (dictionary.ContainsKey(dependencies.ToLowerInvariant()))
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list.Add(item5.Key);
						}
					}
					if (!list.Any())
					{
						break;
					}
					if (compileAsync)
					{
						ilog_0.InfoFormat("Now asynchronously compiling dependency ready [Level {0}] content...", (object)(i + 1));
						stopwatch = Stopwatch.StartNew();
						IEnumerable<string> source = list;
						Action<string> body;
						if ((body = @class.action_0) == null)
						{
							body = (@class.action_0 = @class.method_1);
						}
						Parallel.ForEach(source, body);
					}
					else
					{
						ilog_0.InfoFormat("Now synchronously compiling dependency ready [Level {0}]content...", (object)(i + 1));
						stopwatch = Stopwatch.StartNew();
						foreach (string item6 in list)
						{
							Compile(@class.dictionaryAssemblyNames, @class.dictionary_1[item6]);
						}
					}
					ilog_0.InfoFormat("Content compiled in {0}.", (object)stopwatch.Elapsed);
					Dictionary<string, ThirdPartyLoaderConfiguration> dictionary2 = dictionary.ToDictionary(Class473.Class9.method_15, Class473.Class9.method_16);
					foreach (string item7 in list)
					{
						dictionary2.Remove(item7.ToLowerInvariant());
					}
					dictionary = dictionary2;
				}
			}
			dictionary_1 = @class.dictionaryAssemblyNames;
			List<string> products = Class104.GetProducts();
			for (int num = GlobalSettings.Instance.PremiumContent.Count - 1; num >= 0; num--)
			{
				PremiumContentClass premiumContentClass = GlobalSettings.Instance.PremiumContent[num];
				string text = products.FirstOrDefault((string x) => x == premiumContentClass.Id);
				if (text != null)
				{
					if (!premiumContentClass.Enabled)
					{
						products.Remove(text);
					}
				}
				else
				{
					GlobalSettings.Instance.PremiumContent.RemoveAt(num);
				}
			}
			List<KeyValuePair<string, byte[]>> premiumContent = GetPremiumContent(products);
			if (!premiumContent.Any())
			{
				return;
			}
			if (compileAsync)
			{
				ilog_0.InfoFormat("Now asynchronously compiling Premium content...", Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				Parallel.ForEach(premiumContent, @class.method_Premium);
			}
			else
			{
				ilog_0.InfoFormat("Now synchronously compiling Premium content...", Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				foreach (KeyValuePair<string, byte[]> item8 in premiumContent)
				{
					CompileStream(item8);
				}
			}
			ilog_0.InfoFormat("Premium Content compiled in {0}.", (object)stopwatch.Elapsed);
		}
		finally
		{
			ilog_0.DebugFormat("Loading finished!", Array.Empty<object>());
		}
	}

	private static List<KeyValuePair<string, byte[]>> GetPremiumContent(List<string> products)
	{
		if (products == null)
		{
			return new List<KeyValuePair<string, byte[]>>();
		}
		return DlPromiumContent(products);
	}

	private static List<KeyValuePair<string, byte[]>> DlPromiumContent(List<string> ids)
	{
		List<KeyValuePair<string, byte[]>> list = new List<KeyValuePair<string, byte[]>>();
		foreach (string id in ids)
		{
			byte[] product = Class104.GetProduct(id);
			if (product.Length != 0)
			{
				list.Add(new KeyValuePair<string, byte[]>(id, product));
			}
		}
		return list;
	}
}
