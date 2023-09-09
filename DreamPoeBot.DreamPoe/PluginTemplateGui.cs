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

public partial class PluginTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IPlugin iplugin_0;

	public PluginTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IPlugin iplugin_1)
	{
		iplugin_0 = iplugin_1;
		PluginBindingWrapper source = new PluginBindingWrapper(iplugin_0);
		PluginTemplateGuiPluginGuideHyperlink.Tag = iplugin_0;
		if (iplugin_0 is IUrlProvider urlProvider)
		{
			if (string.IsNullOrEmpty(urlProvider.Url))
			{
				PluginTemplateGuiPluginGuideTextBlock.Visibility = Visibility.Collapsed;
			}
			else
			{
				PluginTemplateGuiPluginGuideTextBlock.Visibility = Visibility.Visible;
			}
		}
		else
		{
			PluginTemplateGuiPluginGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		Binding binding = new Binding("IsEnabled")
		{
			Mode = BindingMode.TwoWay,
			Source = source,
			Converter = null
		};
		PluginTemplateGuiPluginEnabledCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding("Author")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		PluginTemplateGuiPluginAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Version")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		PluginTemplateGuiPluginVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Description")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		PluginTemplateGuiPluginDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			PluginTemplateGuiContentUserControl.Content = iplugin_0.Control;
		}
		catch (Exception ex)
		{
			PluginTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)"Could not create the GUI!", ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (PluginTemplateGuiPluginGuideHyperlink.Tag is IUrlProvider urlProvider)
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
