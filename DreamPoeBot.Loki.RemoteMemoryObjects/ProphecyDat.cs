namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ProphecyDat : RemoteMemoryObject
{
	private string id;

	private string predictionText;

	private string name;

	private string flavourText;

	public int Index { get; internal set; }

	public string Id
	{
		get
		{
			if (id == null)
			{
				return id = base.M.ReadStringU(base.M.ReadLong(base.Address), 255);
			}
			return id;
		}
	}

	public string PredictionText
	{
		get
		{
			if (predictionText == null)
			{
				return predictionText = base.M.ReadStringU(base.M.ReadLong(base.Address + 8L), 255);
			}
			return predictionText;
		}
	}

	public int ProphecyId => base.M.ReadInt(base.Address + 16L);

	public string Name
	{
		get
		{
			if (name == null)
			{
				return name = base.M.ReadStringU(base.M.ReadLong(base.Address + 20L));
			}
			return name;
		}
	}

	public string FlavourText
	{
		get
		{
			if (flavourText == null)
			{
				return flavourText = base.M.ReadStringU(base.M.ReadLong(base.Address + 28L), 255);
			}
			return flavourText;
		}
	}

	public long ProphecyChainPtr => base.M.ReadLong(base.Address + 68L);

	public int ProphecyChainPosition => base.M.ReadInt(base.Address + 76L);

	public bool IsEnabled => base.M.ReadByte(base.Address + 80L) > 0;

	public int SealCost => base.M.ReadInt(base.Address + 81L);

	public override string ToString()
	{
		return Name + ", " + PredictionText;
	}
}
