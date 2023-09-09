namespace DreamPoeBot.Loki.Controllers;

public class LoginStateClass : GameState
{
	private Element Ui => ReadObject<Element>(base.Address + 192L);

	private Element Ui1 => ReadObject<Element>(base.Address + 200L);

	private Element Ui2 => ReadObject<Element>(base.Address + 208L);

	private Element Ui3 => ReadObject<Element>(base.Address + 288L);
}
