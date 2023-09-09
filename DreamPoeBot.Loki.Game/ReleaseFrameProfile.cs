using System.Diagnostics;
using System.Text;

namespace DreamPoeBot.Loki.Game;

public class ReleaseFrameProfile
{
	public string Caller { get; set; }

	public uint StartFrame { get; set; }

	public uint FinishtFrame { get; set; }

	public Stopwatch FuncTimer { get; set; }

	public Stopwatch TotalTimer { get; set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[ReleaseFrameProfile]");
		stringBuilder.AppendLine($"\tCaller: {Caller}");
		stringBuilder.AppendLine($"\tStartFrame: {StartFrame} | FinishtFrame: {FinishtFrame} | Total: {FinishtFrame - StartFrame}");
		stringBuilder.AppendLine($"\tFuncTimer: {FuncTimer.Elapsed}");
		stringBuilder.AppendLine($"\tTotalTimer: {TotalTimer.Elapsed}");
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}
}
