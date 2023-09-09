namespace DreamPoeBot.Loki.Controllers;

public class AreaLoadingState : GameState
{
	public bool IsLoading => base.M.ReadLong(base.Address + 200L) == 1L;

	public string AreaName => base.M.ReadNativeString(base.Address + 936L);

	public uint TotalLoadingScreenTimeMs => base.M.ReadUInt(base.Address + 872L);

	public float TotalLoadingScreenTimeMsFloat => base.M.ReadFloat(base.Address + 880L);

	public override string ToString()
	{
		return $"{AreaName}, IsLoading: {IsLoading}";
	}
}
