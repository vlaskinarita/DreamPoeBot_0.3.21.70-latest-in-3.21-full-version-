using System.Linq;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Bot;

public static class LatencyTracker
{
	public const int MinBound = 1;

	public const int MaxBound = 5000;

	public static int Current => smethod_0((int)LokiPoe.InGameState.DebugOverlay.LatencyValues.Last());

	public static int Lowest => smethod_0((int)LokiPoe.InGameState.DebugOverlay.LatencyValues.Min());

	public static int Average => smethod_0((int)LokiPoe.InGameState.DebugOverlay.LatencyValues.Average());

	public static int Highest => smethod_0((int)LokiPoe.InGameState.DebugOverlay.LatencyValues.Max());

	private static int smethod_0(int int_0)
	{
		if (int_0 < 1)
		{
			return 1;
		}
		if (int_0 <= 5000)
		{
			return int_0;
		}
		return 5000;
	}
}
