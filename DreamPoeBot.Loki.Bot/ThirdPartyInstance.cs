using System.Collections.Generic;
using System.Reflection;

namespace DreamPoeBot.Loki.Bot;

public class ThirdPartyInstance
{
	public string Name { get; }

	public string ContentPath { get; }

	public string CompiledPath { get; }

	public IReadOnlyCollection<IBot> BotInstances { get; }

	public IReadOnlyCollection<IPlugin> PluginInstances { get; }

	public IReadOnlyCollection<IRoutine> RoutineInstances { get; }

	public IReadOnlyCollection<IContent> ContentInstances { get; }

	public IReadOnlyCollection<IPlayerMover> PlayerMoverInstances { get; }

	public Assembly CompiledAssembly { get; }

	internal ThirdPartyInstance(string name, string contentPath, string compiledPath, Assembly compiledAssembly)
	{
		Name = name;
		ContentPath = contentPath;
		CompiledPath = compiledPath;
		CompiledAssembly = compiledAssembly;
		BotInstances = new List<IBot>(new TypeLoader<IBot>(CompiledAssembly));
		PluginInstances = new List<IPlugin>(new TypeLoader<IPlugin>(CompiledAssembly));
		RoutineInstances = new List<IRoutine>(new TypeLoader<IRoutine>(CompiledAssembly));
		ContentInstances = new List<IContent>(new TypeLoader<IContent>(CompiledAssembly));
		PlayerMoverInstances = new List<IPlayerMover>(new TypeLoader<IPlayerMover>(CompiledAssembly));
	}
}
