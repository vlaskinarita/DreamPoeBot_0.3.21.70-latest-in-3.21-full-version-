using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeListNode<TValue> where TValue : unmanaged
{
	public readonly long Next;

	public readonly long Prev;

	public readonly TValue Value;
}
