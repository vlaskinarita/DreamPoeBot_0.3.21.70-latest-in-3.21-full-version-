using System.Runtime.InteropServices;

namespace DreamPoeBot.Structures.ns19;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Struct253WorldItemComp
{
	internal readonly long intptr_0;

	internal readonly long intptr_1;

	public new string ToString()
	{
		return $"VTable: 0x{intptr_0:X} | ParentObjectPtr: 0x{intptr_1:X}";
	}
}
