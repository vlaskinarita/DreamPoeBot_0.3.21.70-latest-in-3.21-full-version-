using System;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.Bot;

public class PerFrameLecker : IDisposable
{
	public uint PreviousFrameCount;

	public bool CanRelease
	{
		get
		{
			uint frameCount = GameController.Instance.Game.IngameState.ServerData.FrameCount;
			if (frameCount < PreviousFrameCount + 10)
			{
				return false;
			}
			PreviousFrameCount = frameCount;
			return true;
		}
	}

	public void Dispose()
	{
	}
}
