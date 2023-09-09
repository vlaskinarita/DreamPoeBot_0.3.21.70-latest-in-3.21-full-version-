using System;

namespace DreamPoeBot.Loki.Bot;

public class StopReasonData
{
	public object Context { get; private set; }

	public string Id { get; private set; }

	public string Reason { get; private set; }

	public StopReasonData(string id, string reason = "", object context = null)
	{
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentException("Cannot be null or empty", "id");
		}
		if (reason == null)
		{
			reason = "";
		}
		Id = id;
		Reason = reason;
		Context = context;
	}
}
