using System;

namespace DreamPoeBot.Loki.Common;

public static class CommandLine
{
	public static Arguments Arguments { get; private set; } = new Arguments(Environment.GetCommandLineArgs());

}
