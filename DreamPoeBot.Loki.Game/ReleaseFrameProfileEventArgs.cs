using System;
using System.Runtime.CompilerServices;

namespace DreamPoeBot.Loki.Game;

public class ReleaseFrameProfileEventArgs : EventArgs
{
	[CompilerGenerated]
	private ReleaseFrameProfile releaseFrameProfile_0;

	public ReleaseFrameProfile Profile { get; internal set; }

	internal ReleaseFrameProfileEventArgs(ReleaseFrameProfile profile)
	{
		Profile = profile;
	}

	internal ReleaseFrameProfileEventArgs()
	{
	}
}
