using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;

namespace DreamPoeBot.Loki.Game;

public class WindowControlWrapper : RemoteMemoryObject
{
	public string Title => "";

	internal WindowControlWrapper(long control)
		: base(control)
	{
	}

	public CloseWindowResult Close(bool actuallyClose = true)
	{
		if (!Hooking.IsInstalled)
		{
			return CloseWindowResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		return CloseWindowResult.None;
	}
}
