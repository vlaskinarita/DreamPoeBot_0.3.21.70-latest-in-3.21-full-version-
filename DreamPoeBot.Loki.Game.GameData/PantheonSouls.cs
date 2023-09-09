namespace DreamPoeBot.Loki.Game.GameData;

public class PantheonSouls
{
	public string Id { get; }

	public string CapturedMonsterName { get; }

	public bool IsUnlocked { get; }

	public DatWorldAreaWrapper UnlockArea { get; }

	public PantheonSouls(string id, string capturedMonsterName, bool isUnlocked, DatWorldAreaWrapper unlockArea)
	{
		Id = id;
		CapturedMonsterName = capturedMonsterName;
		IsUnlocked = isUnlocked;
		UnlockArea = unlockArea;
	}
}
