using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal class DefaultConverter : IValueConverter
{
	private static Dictionary<Type, TypeConverter> dictionary_0 = new Dictionary<Type, TypeConverter>();

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return null;
		}
		object obj = null;
		Type type = value.GetType();
		if (!targetType.Equals(typeof(object)) && !type.Equals(targetType))
		{
			RegisterMissingTypeConverters.Register();
			if (!dictionary_0.ContainsKey(targetType))
			{
				TypeConverter value2 = TypeDescriptor.GetConverter(targetType);
				if (targetType == typeof(Thickness))
				{
					value2 = new ThicknessConverter();
				}
				dictionary_0.Add(targetType, value2);
			}
			TypeConverter typeConverter = dictionary_0[targetType];
			if (typeConverter != null && typeConverter.CanConvertFrom(type))
			{
				try
				{
					return typeConverter.ConvertFrom(value);
				}
				catch
				{
					return null;
				}
			}
			return null;
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return Convert(value, targetType, parameter, culture);
	}
}
