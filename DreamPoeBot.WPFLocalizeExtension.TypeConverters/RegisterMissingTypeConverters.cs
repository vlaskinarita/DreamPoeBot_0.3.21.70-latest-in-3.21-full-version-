using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal static class RegisterMissingTypeConverters
{
	private static bool bool_0;

	public static void Register()
	{
		if (!bool_0)
		{
			TypeDescriptor.AddAttributes(typeof(BitmapSource), new TypeConverterAttribute(typeof(BitmapSourceTypeConverter)));
			bool_0 = true;
		}
	}
}
