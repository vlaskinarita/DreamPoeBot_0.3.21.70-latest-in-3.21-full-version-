using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeVector
{
	public long First;

	public long Last;

	public long End;

	public override string ToString()
	{
		return string.Format("First: 0x{0}, Last: 0x{1}, End: 0x{2}", First.ToString("X"), Last.ToString("X"), End.ToString("X"));
	}
}
