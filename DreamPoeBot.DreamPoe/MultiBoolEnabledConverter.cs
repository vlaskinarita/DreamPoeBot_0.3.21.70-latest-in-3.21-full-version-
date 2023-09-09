using System;
using System.Globalization;
using System.Windows.Data;

namespace DreamPoeBot.DreamPoe;

public class MultiBoolEnabledConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool)values[0] && (bool)values[1];
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
