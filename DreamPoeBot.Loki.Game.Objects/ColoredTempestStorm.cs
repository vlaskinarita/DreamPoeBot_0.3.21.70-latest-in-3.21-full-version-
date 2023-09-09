namespace DreamPoeBot.Loki.Game.Objects;

public class ColoredTempestStorm : NetworkObject
{
	private static readonly string string_2 = smethod_0("blue");

	private static readonly string string_3 = smethod_0("green");

	private static readonly string string_4 = smethod_0("orange");

	private static readonly string string_5 = smethod_0("pink");

	private static readonly string string_6 = smethod_0("purple");

	private static readonly string string_7 = smethod_0("red");

	private static readonly string string_8 = smethod_0("teal");

	private static readonly string string_9 = smethod_0("white");

	private static readonly string string_10 = smethod_0("yellow");

	public TempestColors Color { get; private set; }

	public override string Name => "ColoredTempestStorm (" + Color.ToString() + ")";

	private static string smethod_0(string string_11)
	{
		return $"metadata/effects/environment/tempest_league/basic_colour/{string_11}/tempeststorm";
	}

	internal ColoredTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
		Color = TempestColors.Unknown;
		string text = base.Type.ToLowerInvariant();
		if (text.Equals(string_2))
		{
			Color = TempestColors.Blue;
		}
		else if (text.Equals(string_3))
		{
			Color = TempestColors.Green;
		}
		else if (text.Equals(string_4))
		{
			Color = TempestColors.Orange;
		}
		else if (text.Equals(string_5))
		{
			Color = TempestColors.Pink;
		}
		else if (text.Equals(string_6))
		{
			Color = TempestColors.Purple;
		}
		else if (text.Equals(string_7))
		{
			Color = TempestColors.Red;
		}
		else if (text.Equals(string_8))
		{
			Color = TempestColors.Teal;
		}
		else if (text.Equals(string_9))
		{
			Color = TempestColors.White;
		}
		else if (text.Equals(string_10))
		{
			Color = TempestColors.Yellow;
		}
	}
}
