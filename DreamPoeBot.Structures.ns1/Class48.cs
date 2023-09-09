using System;
using DreamPoeBot.Auth.SR;

namespace DreamPoeBot.Structures.ns1;

internal class Class48 : IDisposable
{
	private readonly TimeSpan timeSpan_0;

	private readonly AClient aclient_0;

	public Class48(AClient client, TimeSpan timeout)
	{
		aclient_0 = client;
		timeSpan_0 = client.Endpoint.Binding.SendTimeout;
		client.Endpoint.Binding.SendTimeout = timeout;
	}

	public void Dispose()
	{
		aclient_0.Endpoint.Binding.SendTimeout = timeSpan_0;
	}
}
