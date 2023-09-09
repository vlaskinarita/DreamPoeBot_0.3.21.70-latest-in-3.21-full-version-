namespace DreamPoeBot.Common;

public interface IMemoryObject
{
	long BaseAddress { get; }

	bool UpdatePointer(long ptr);
}
