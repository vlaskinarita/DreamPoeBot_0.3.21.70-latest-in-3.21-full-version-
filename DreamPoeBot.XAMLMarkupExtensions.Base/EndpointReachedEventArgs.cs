using System;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class EndpointReachedEventArgs : EventArgs
{
	public TargetInfo Endpoint { get; private set; }

	public object EndpointValue { get; set; }

	public bool Handled { get; set; }

	public EndpointReachedEventArgs(TargetInfo endPoint)
	{
		Endpoint = endPoint;
		EndpointValue = null;
	}
}
