using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal class ThicknessConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		Thickness thickness = default(Thickness);
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		uint num2 = default(uint);
		while (true)
		{
			double result4 = 0.0;
			while (true)
			{
				IL_00da:
				if (value is string)
				{
					while (true)
					{
						IL_00c1:
						string[] array = ((string)value).Split(",".ToCharArray());
						while (true)
						{
							IL_00b9:
							int num = array.Length;
							while (true)
							{
								switch (num)
								{
								case 1:
									goto IL_00f4;
								case 2:
									goto IL_0113;
								case 4:
									goto IL_0144;
								case 3:
									goto end_IL_009b;
								}
								int num3 = ((int)num2 * -1079935410) ^ -261584113;
								while (true)
								{
									switch ((num2 = (uint)num3 ^ 0x39F66A01u) % 15u)
									{
									case 6u:
										num3 = ((int)num2 * -1815931804) ^ -1896706486;
										continue;
									case 9u:
										break;
									case 13u:
										goto IL_00b9;
									case 4u:
										goto IL_00c1;
									case 1u:
										goto IL_00da;
									case 10u:
									case 12u:
										goto end_IL_00da;
									case 2u:
										goto IL_00f4;
									case 14u:
										goto IL_0113;
									case 8u:
										goto IL_0144;
									case 7u:
										goto IL_0156;
									case 3u:
										goto IL_0168;
									case 11u:
										goto IL_018c;
									default:
										goto end_IL_009b;
									}
									break;
								}
								continue;
								IL_0113:
								double.TryParse(array[0], NumberStyles.Any, culture, out result);
								double.TryParse(array[1], NumberStyles.Any, culture, out result2);
								thickness = new Thickness(result, result2, result, result2);
								break;
								IL_00f4:
								double.TryParse(array[0], NumberStyles.Any, culture, out result);
								thickness = new Thickness(result);
								break;
								IL_0144:
								double.TryParse(array[0], NumberStyles.Any, culture, out result);
								goto IL_0156;
								IL_0156:
								double.TryParse(array[1], NumberStyles.Any, culture, out result2);
								goto IL_0168;
								IL_0168:
								double.TryParse(array[2], NumberStyles.Any, culture, out result3);
								double.TryParse(array[3], NumberStyles.Any, culture, out result4);
								goto IL_018c;
								IL_018c:
								thickness = new Thickness(result, result2, result3, result4);
								break;
								continue;
								end_IL_009b:
								break;
							}
							break;
						}
						break;
					}
				}
				return thickness;
				continue;
				end_IL_00da:
				break;
			}
		}
	}
}
