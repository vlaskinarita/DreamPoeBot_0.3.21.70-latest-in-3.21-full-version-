using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Controllers;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Filedata
{
	private readonly int unusedInt1;

	private readonly int unusedInt2;

	public readonly long fileAddress;

	private readonly long unusedLong;
}
