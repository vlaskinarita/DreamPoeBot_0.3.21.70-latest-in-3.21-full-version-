using System;
using System.Collections.Generic;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class TargetPath
{
	private Stack<TargetInfo> Stack_0 { get; set; }

	public TargetInfo EndPoint { get; private set; }

	public void AddStep(TargetInfo info)
	{
		Stack_0.Push(info);
	}

	public TargetInfo GetNextStep()
	{
		if (Stack_0.Count <= 0)
		{
			return EndPoint;
		}
		return Stack_0.Pop();
	}

	public TargetInfo ShowNextStep()
	{
		if (Stack_0.Count <= 0)
		{
			return EndPoint;
		}
		return Stack_0.Peek();
	}

	public TargetPath(TargetInfo endPoint)
	{
		if (!endPoint.IsEndpoint)
		{
			throw new ArgumentException("A path endpoint cannot be another INestedMarkupExtension.");
		}
		EndPoint = endPoint;
		Stack_0 = new Stack<TargetInfo>();
	}
}
