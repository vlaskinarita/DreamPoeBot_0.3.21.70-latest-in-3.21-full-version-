using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class EnumComboBox : ComboBox
{
	public static DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(Type), typeof(EnumComboBox), new PropertyMetadata(smethod_0));

	[Category("Common")]
	public Type Type
	{
		get
		{
			return (Type)GetValue(TypeProperty);
		}
		set
		{
			SetValue(TypeProperty, value);
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyObject_0 is EnumComboBox enumComboBox)
		{
			enumComboBox.method_0(enumComboBox.Type);
		}
	}

	private void method_0(Type type_0)
	{
		try
		{
			List<object> list = new List<object>();
			Enum.GetValues(type_0);
			FieldInfo[] fields = type_0.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.IsSpecialName)
				{
					BrowsableAttribute browsableAttribute = fieldInfo.GetCustomAttributes(inherit: false).OfType<BrowsableAttribute>().FirstOrDefault();
					if (browsableAttribute == null || browsableAttribute.Browsable)
					{
						list.Add(fieldInfo.GetValue(0));
					}
				}
			}
			base.ItemsSource = list;
		}
		catch
		{
		}
	}
}
