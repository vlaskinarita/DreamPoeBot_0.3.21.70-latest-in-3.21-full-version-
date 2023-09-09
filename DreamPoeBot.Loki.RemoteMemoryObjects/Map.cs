using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Map : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructMapsFile
	{
		public long BaseItemTypesKey;

		public long pointer_1;

		public long Regular_WorldAreasKey;

		public long Regular_WorldAreasData;

		public long Unique_WorldAreasKey;

		public long Unique_WorldAreasData;

		public long MapUpgrade_BaseItemTypesKey;

		public long MapUpgrade_BaseItemTypesData;

		public int int_1;

		public int int_2;

		public long MonsterPacksKeys;

		public long AchievementsKeys;

		public long pointer_5;

		public long pointer_6;

		public long pointer_7;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public int int_7;

		public int int_8;

		public long pointer_8;

		public long pointer_9;

		public int mapSeries;

		public byte byte_0;

		public byte byte_1;
	}

	private string _name;

	private string _metadata;

	private string _nameUnique;

	private string _metadataUnique;

	private int _serie = -1;

	public string Name
	{
		get
		{
			if (string.IsNullOrEmpty(_name))
			{
				BuildCache();
			}
			return _name;
		}
	}

	public string NameUnique
	{
		get
		{
			if (string.IsNullOrEmpty(_nameUnique))
			{
				BuildCache();
			}
			return _nameUnique;
		}
	}

	public string Metadata
	{
		get
		{
			if (string.IsNullOrEmpty(_metadata))
			{
				BuildCache();
			}
			return _metadata;
		}
	}

	public string MetadataUnique
	{
		get
		{
			if (string.IsNullOrEmpty(_metadataUnique))
			{
				BuildCache();
			}
			return _metadataUnique;
		}
	}

	public int Series
	{
		get
		{
			if (_serie == -1)
			{
				BuildCache();
			}
			return _serie;
		}
	}

	private void BuildCache()
	{
		StructMapsFile structMapsFile = base.M.FastIntPtrToStruct<StructMapsFile>(base.Address);
		_name = base.M.ReadStringU(base.M.ReadLong(structMapsFile.Regular_WorldAreasData + 8L));
		_metadata = base.M.ReadStringU(base.M.ReadLong(structMapsFile.Regular_WorldAreasData));
		_nameUnique = base.M.ReadStringU(base.M.ReadLong(structMapsFile.Unique_WorldAreasData + 8L));
		_metadataUnique = base.M.ReadStringU(base.M.ReadLong(structMapsFile.Unique_WorldAreasData));
		_serie = structMapsFile.mapSeries;
	}

	public override string ToString()
	{
		return $"Serie {Series}, Name: {Name}, Metadata: {Metadata}, NameUnique: {NameUnique}, MetadataUnique: {MetadataUnique}";
	}
}
