using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class TheGame : RemoteMemoryObject
{
	public IngameState IngameState => GameStateController.IngameState;

	private IngameState IngameStateReal
	{
		get
		{
			if (!GameController.UseGameStateController)
			{
				return ReadObject<IngameState>(base.Address + 56L);
			}
			return GameStateController.IngameState;
		}
	}

	public TheGame()
	{
		base.Address = 0L;
	}

	public void RefreshTheGameState()
	{
		base.Address = base.M.ReadLong(base.Offsets.Base + base.M.AddressOfProcess, 8L, 248L);
	}
}
