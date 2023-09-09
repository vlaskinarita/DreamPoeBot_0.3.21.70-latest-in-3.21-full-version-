using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class AtlasRegions : UniversalFileWrapper<AtlasRegion>
{
	private Dictionary<int, AtlasRegion> _atlasRegionsDictionary;

	public AtlasRegions(Memory m, long address)
		: base(m, address)
	{
	}

	public AtlasRegion GetAtlasRegion(int index)
	{
		if (_atlasRegionsDictionary == null)
		{
			CheckCache();
			List<AtlasRegion> entriesList = base.EntriesList;
			_atlasRegionsDictionary = new Dictionary<int, AtlasRegion>();
			try
			{
				int key = 1;
				foreach (AtlasRegion item in entriesList)
				{
					_atlasRegionsDictionary.Add(key, item);
				}
			}
			catch (Exception)
			{
				_atlasRegionsDictionary = null;
				throw;
			}
		}
		if (!_atlasRegionsDictionary.ContainsKey(index))
		{
			return null;
		}
		return _atlasRegionsDictionary[index];
	}
}
