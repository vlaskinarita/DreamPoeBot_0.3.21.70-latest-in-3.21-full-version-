using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class RoutineTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IRoutine iroutine_0;

	public RoutineTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IRoutine iroutine_1)
	{
		iroutine_0 = iroutine_1;
		RoutineBindingWrapper source = new RoutineBindingWrapper(iroutine_0);
		RoutineTemplateGuiRoutineGuideHyperlink.Tag = iroutine_0;
		if (!(iroutine_0 is IUrlProvider urlProvider))
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else if (!string.IsNullOrEmpty(urlProvider.Url))
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Visible;
		}
		else
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		Binding binding = new Binding("IsActive")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineActiveCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding("Author")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Version")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Description")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			RoutineTemplateGuiContentUserControl.Content = iroutine_0.Control;
		}
		catch (Exception ex)
		{
			RoutineTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)"Could not create the GUI!", ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (RoutineTemplateGuiRoutineGuideHyperlink.Tag is IUrlProvider urlProvider)
		{
			try
			{
				Process.Start(urlProvider.Url);
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"An exception occurred.", ex);
			}
		}
	}
}
