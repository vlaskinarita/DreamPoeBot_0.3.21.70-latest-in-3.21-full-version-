namespace DreamPoeBot.Loki.Controllers;

public class GameState : RemoteMemoryObject
{
	private GameStateEnum stateName = GameStateEnum.None;

	public GameStateEnum StateName
	{
		get
		{
			if (stateName == GameStateEnum.None)
			{
				return stateName = (GameStateEnum)base.M.ReadByte(base.Address + 11L);
			}
			return stateName;
		}
	}

	public override string ToString()
	{
		return StateName.ToString();
	}
}
