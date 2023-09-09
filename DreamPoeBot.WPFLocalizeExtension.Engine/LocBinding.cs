using System.Windows;
using System.Windows.Data;
using DreamPoeBot.WPFLocalizeExtension.Extensions;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class LocBinding : FrameworkElement
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(object), typeof(LocBinding), new FrameworkPropertyMetadata(smethod_0)
	{
		BindsTwoWayByDefault = true,
		DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
	});

	private LocExtension locExtension_0;

	public object Source
	{
		get
		{
			return GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public LocExtension Target
	{
		get
		{
			return locExtension_0;
		}
		set
		{
			locExtension_0 = value;
			if (locExtension_0 != null && Source != null)
			{
				locExtension_0.Key = Source.ToString();
			}
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyObject_0 is LocBinding locBinding && dependencyPropertyChangedEventArgs_0.Property == SourceProperty && locBinding.Source != locBinding.locExtension_0 && locBinding.locExtension_0 != null && locBinding.Source != null)
		{
			locBinding.locExtension_0.Key = locBinding.Source.ToString();
		}
	}
}
