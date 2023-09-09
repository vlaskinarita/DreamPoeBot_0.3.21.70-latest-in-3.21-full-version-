using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Controllers;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SmallFileTable
{
	public readonly byte I0;

	public readonly byte I1;

	public readonly byte I2;

	public readonly byte I3;

	public readonly byte I4;

	public readonly byte I5;

	public readonly byte I6;

	public readonly byte I7;

	public Filedata D0;

	public Filedata D1;

	public Filedata D2;

	public Filedata D3;

	public Filedata D4;

	public Filedata D5;

	public Filedata D6;

	public Filedata D7;
}
