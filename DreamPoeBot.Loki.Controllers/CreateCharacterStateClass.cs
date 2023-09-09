namespace DreamPoeBot.Loki.Controllers;

public class CreateCharacterStateClass : GameState
{
	public bool IsCreateCharacterStateActive => base.M.ReadByte(base.Address + 345L) == 1;

	public long baseAddress => base.Address;

	public Element UI => ReadObject<Element>(base.Address + 64L);
}
