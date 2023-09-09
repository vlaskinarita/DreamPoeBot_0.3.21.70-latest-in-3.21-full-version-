using System.Runtime.CompilerServices;

namespace DreamPoeBot.Loki.Bot;

public static class Explorer
{
	public delegate IExplorer CreateExplorerDelegate();

	public delegate IExplorer GetExplorerDelegate(params dynamic[] user);

	[CompilerGenerated]
	private static CreateExplorerDelegate createExplorerDelegate_0;

	[CompilerGenerated]
	private static GetExplorerDelegate getExplorerDelegate_0;

	public static CreateExplorerDelegate CreateDelegate { get; set; }

	public static GetExplorerDelegate CurrentDelegate { get; set; }

	public static IExplorer GetCurrent(params dynamic[] user)
	{
		return CurrentDelegate(user);
	}
}
