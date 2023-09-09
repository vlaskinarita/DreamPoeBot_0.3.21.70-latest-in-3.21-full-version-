namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class NullExtension : NestedMarkupExtension
{
	public override object FormatOutput(TargetInfo endPoint, TargetInfo info)
	{
		return null;
	}

	protected override bool UpdateOnEndpoint(TargetInfo endpoint)
	{
		return false;
	}
}
