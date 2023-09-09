using System.ComponentModel;

namespace DreamPoeBot.Auth;

public enum Region
{
	[Description("- Best Latency -")]
	BestLatency,
	[Description("Europe")]
	Europe,
	[Description("North America")]
	NorthAmerica,
	[Description("China")]
	China,
	[Description("Southeast Asia")]
	SoutheastAsia
}
