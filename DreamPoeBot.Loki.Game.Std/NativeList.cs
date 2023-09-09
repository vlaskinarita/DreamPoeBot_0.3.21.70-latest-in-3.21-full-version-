using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeList
{
	public readonly long Head;

	public readonly uint Size;

	public readonly int unusedInt0;

	public override string ToString()
	{
		return string.Format("Head: 0x{0}, Size: 0x{1}", Head.ToString("X"), Size);
	}
}
