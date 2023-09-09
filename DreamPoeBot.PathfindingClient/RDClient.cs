using System;
using System.ServiceModel;
using System.Timers;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.PathfindingClient;

public static class RDClient
{
	private static readonly string address = "net.pipe://localhost/Alcor75RDServer";

	internal static Timer aTimer = new Timer();

	private static NetNamedPipeBinding Binding { get; set; }

	private static EndpointAddress Ep { get; set; }

	public static IContract Channel { get; set; }

	public static string Name { get; set; }

	public static void Initialize()
	{
		Binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
		Binding.ReceiveTimeout = TimeSpan.MaxValue;
		Binding.MaxConnections = 20000;
		Binding.MaxBufferPoolSize = 51224576L;
		Binding.MaxBufferSize = 51224576;
		Binding.MaxReceivedMessageSize = 51224576L;
		Ep = new EndpointAddress(address);
		Channel = ChannelFactory<IContract>.CreateChannel(Binding, Ep);
		Name = "DreamBot" + LokiPoe.Random.Next(10000, int.MaxValue);
		Channel.Handshake(Name);
		aTimer.Elapsed += OnTimedEvent;
		aTimer.Interval = 120000.0;
		aTimer.Enabled = true;
	}

	private static void OnTimedEvent(object sender, ElapsedEventArgs e)
	{
		Channel?.Ping(Name);
	}

	public static void Disconnect()
	{
		Channel?.Disconnect(Name);
	}
}
