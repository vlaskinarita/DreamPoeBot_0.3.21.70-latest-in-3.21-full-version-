using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeMapNode<TNodeKey, TNodeValue> where TNodeKey : struct where TNodeValue : unmanaged
{
	public readonly long Left;

	public readonly long Parent;

	public readonly long Right;

	public readonly byte Color;

	public readonly byte IsNil;

	private readonly byte byte_0;

	private readonly byte byte_1;

	public readonly TNodeKey Key;

	public readonly TNodeValue Value;
}
