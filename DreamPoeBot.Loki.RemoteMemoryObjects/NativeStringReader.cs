using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class NativeStringReader : RemoteMemoryObject
{
	public string Value => ReadString(base.Address);

	public static string ReadString(long address)
	{
		Memory memory = GameController.Instance.Memory;
		memory.ReadUInt(address + 8L);
		uint num = memory.ReadUInt(address + 16L);
		if (num >= 8)
		{
			long addr = memory.ReadLong(address);
			return memory.ReadStringU(addr);
		}
		return memory.ReadStringU(address);
	}
}
