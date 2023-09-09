namespace DreamPoeBot.Loki.Controllers;

public class EscapeStateClass : GameState
{
	public bool IsEscapeStateActive => (ulong)base.M.ReadLong(base.Address + 896L) > 0uL;

	public long baseAddress => base.Address;

	private long escape_Options_address => base.M.ReadLong(base.Address + 896L);

	public Element ExitToLogin => ReadObject<Element>(escape_Options_address + 16L);

	public Element ExitToCharSelection => ReadObject<Element>(escape_Options_address + 24L);

	public Element ExitPathOfExile => ReadObject<Element>(escape_Options_address + 32L);

	public Element Options => ReadObject<Element>(escape_Options_address + 40L);

	public Element ResumeGame => ReadObject<Element>(escape_Options_address + 48L);

	public Element MicrotransactionShop => ReadObject<Element>(escape_Options_address + 56L);
}
