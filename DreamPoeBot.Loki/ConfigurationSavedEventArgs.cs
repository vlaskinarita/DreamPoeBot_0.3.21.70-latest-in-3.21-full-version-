using System;

namespace DreamPoeBot.Loki;

public class ConfigurationSavedEventArgs : EventArgs
{
	public Configuration Configuration { get; internal set; }

	internal ConfigurationSavedEventArgs(Configuration configuration)
	{
		Configuration = configuration;
	}

	internal ConfigurationSavedEventArgs()
	{
	}
}
