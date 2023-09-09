using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeMap
{
	public long Head;

	public uint Size;

	public override string ToString()
	{
		return string.Format("Head: 0x{0}, Size: 0x{1}", Head.ToString("X"), Size);
	}
}
