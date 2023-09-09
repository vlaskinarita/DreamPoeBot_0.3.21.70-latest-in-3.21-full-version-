using System.ComponentModel;
using System.Windows;
using DreamPoeBot.WPFLocalizeExtension.Extensions;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class LocProxy : FrameworkElement
{
	private LocExtension locExtension_0;

	public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(object), typeof(LocProxy), new PropertyMetadata(smethod_0));

	public static DependencyProperty PrependTypeProperty = DependencyProperty.Register("PrependType", typeof(bool), typeof(LocProxy), new PropertyMetadata(false, smethod_0));

	public static DependencyProperty SeparatorProperty = DependencyProperty.Register("Separator", typeof(string), typeof(LocProxy), new PropertyMetadata("_", smethod_0));

	public static DependencyPropertyKey ResultProperty = DependencyProperty.RegisterReadOnly("Result", typeof(string), typeof(LocProxy), new PropertyMetadata(""));

	[Category("Common")]
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

	[Category("Common")]
	public bool PrependType
	{
		get
		{
			return (bool)GetValue(PrependTypeProperty);
		}
		set
		{
			SetValue(PrependTypeProperty, value);
		}
	}

	[Category("Common")]
	public string Separator
	{
		get
		{
			return (string)GetValue(SeparatorProperty);
		}
		set
		{
			SetValue(SeparatorProperty, value);
		}
	}

	[Category("Common")]
	public string Result
	{
		get
		{
			return ((string)GetValue(ResultProperty.DependencyProperty)) ?? Source.ToString();
		}
		set
		{
			SetValue(ResultProperty, value);
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (!(dependencyObject_0 is LocProxy locProxy))
		{
			return;
		}
		object source = locProxy.Source;
		if (source != null)
		{
			string text = source.ToString();
			if (locProxy.PrependType)
			{
				text = source.GetType().Name + locProxy.Separator + text;
			}
			locProxy.locExtension_0.Key = text;
		}
	}

	public LocProxy()
	{
		locExtension_0 = new LocExtension();
		locExtension_0.SetBinding(this, GetType().GetProperty("Result"));
	}
}
