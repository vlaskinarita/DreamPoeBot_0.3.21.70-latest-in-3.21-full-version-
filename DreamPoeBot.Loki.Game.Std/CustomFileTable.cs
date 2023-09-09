using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CustomFileTable
{
	public readonly long header;

	public readonly long dataAddress;

	private readonly int unusedInt1;

	private readonly int unusedInt2;

	private readonly int unusedInt3;

	private readonly int unusedInt4;

	public readonly int datalenght;

	private readonly int unusedInt5;

	public override string ToString()
	{
		return $"Address: {dataAddress} | lenght: {datalenght} | header: {header}";
	}
}
