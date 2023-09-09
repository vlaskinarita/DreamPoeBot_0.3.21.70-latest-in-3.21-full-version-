using System;
using System.Linq;
using System.Reflection;
using System.Text;
using DreamPoeBot.Loki.Bot;

namespace DreamPoeBot.DreamPoe;

public class ThirdPartyInstanceWrapper
{
	[Serializable]
	private sealed class Class17
	{
		public static readonly Class17 Class9 = new Class17();

		internal string method_0(IBot ibot_0)
		{
			return ibot_0.Name;
		}

		internal string method_1(IRoutine iroutine_0)
		{
			return iroutine_0.Name;
		}

		internal string method_2(IPlugin iplugin_0)
		{
			return iplugin_0.Name;
		}

		internal string method_3(IContent icontent_0)
		{
			return icontent_0.Name;
		}

		internal string method_4(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.Name;
		}
	}

	internal ThirdPartyInstance ThirdPartyInstance_0 { get; }

	public string Name { get; }

	public Assembly CompiledAssembly { get; }

	public string Bots { get; }

	public string Routines { get; }

	public string Plugins { get; }

	public string Contents { get; }

	public string PlayerMovers { get; }

	private string method_0(string string_6)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < string_6.Length; i++)
		{
			num++;
			stringBuilder.Append(string_6[i]);
			if (string_6[i] == '|' && num > 25)
			{
				stringBuilder.Append(Environment.NewLine);
				num = 0;
			}
		}
		return stringBuilder.ToString();
	}

	internal ThirdPartyInstanceWrapper(ThirdPartyInstance instance)
	{
		ThirdPartyInstance_0 = instance;
		Name = instance.Name;
		CompiledAssembly = instance.CompiledAssembly;
		Bots = method_0(string.Join(" | ", instance.BotInstances.Select(Class17.Class9.method_0)));
		Routines = method_0(string.Join(" | ", instance.RoutineInstances.Select(Class17.Class9.method_1)));
		Plugins = method_0(string.Join(" | ", instance.PluginInstances.Select(Class17.Class9.method_2)));
		Contents = method_0(string.Join(" | ", instance.ContentInstances.Select(Class17.Class9.method_3)));
		PlayerMovers = method_0(string.Join(" | ", instance.PlayerMoverInstances.Select(Class17.Class9.method_4)));
	}
}
