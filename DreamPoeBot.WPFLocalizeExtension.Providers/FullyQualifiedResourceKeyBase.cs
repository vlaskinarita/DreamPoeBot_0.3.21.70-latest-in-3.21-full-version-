namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal abstract class FullyQualifiedResourceKeyBase
{
	public static implicit operator string(FullyQualifiedResourceKeyBase fullyQualifiedResourceKey)
	{
		return fullyQualifiedResourceKey?.ToString();
	}
}
