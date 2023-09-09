using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DreamPoeBot.Loki;

public abstract class FileInMemory
{
	public Memory M { get; }

	public long Address { get; }

	private int NumberOfRecords => M.ReadInt(Address + 48L, 64L);

	protected FileInMemory(Memory m, long address)
	{
		M = m;
		Address = address;
	}

	protected IEnumerable<long> RecordAddresses()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		long firstRec = M.ReadLong(Address + 48L, default(long));
		long num = M.ReadLong(Address + 48L, 8L);
		int cnt = NumberOfRecords;
		while (true)
		{
			if (firstRec == 0L || num == 0L || cnt == 0)
			{
				if (stopwatch.ElapsedMilliseconds > 15000L)
				{
					break;
				}
				firstRec = M.ReadLong(Address + 48L, default(long));
				num = M.ReadLong(Address + 48L, 8L);
				cnt = NumberOfRecords;
				continue;
			}
			long recLen = (num - firstRec) / cnt;
			for (int i = 0; i < cnt; i++)
			{
				yield return firstRec + i * recLen;
			}
			yield break;
		}
		throw new Exception("Unable to collect Records for address: " + Address.ToString("X"));
	}
}
