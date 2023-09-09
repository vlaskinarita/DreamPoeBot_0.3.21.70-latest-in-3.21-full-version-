using System.Collections;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Framework;

public class WaitRender : YieldBase
{
	public long HowManyRenderCountWait { get; }

	public WaitRender(long howManyRenderCountWait = 1L)
	{
		HowManyRenderCountWait = howManyRenderCountWait;
		base.Current = GetEnumerator();
	}

	public sealed override IEnumerator GetEnumerator()
	{
		long wait = GameController.Instance.RenderCount + HowManyRenderCountWait;
		while (GameController.Instance.RenderCount < wait)
		{
			yield return null;
		}
	}
}
