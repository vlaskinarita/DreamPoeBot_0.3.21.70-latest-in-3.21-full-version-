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

public partial class BotTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IBot ibot_0;

	public BotTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IBot ibot_1)
	{
		ibot_0 = ibot_1;
		BotBindingWrapper source = new BotBindingWrapper(ibot_0);
		BotTemplateGuiBotGuideHyperlink.Tag = ibot_0;
		if (!(ibot_0 is IUrlProvider urlProvider))
		{
			BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else if (string.IsNullOrEmpty(urlProvider.Url))
		{
			BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else
		{
			BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Visible;
		}
		Binding binding = new Binding("IsActive")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotActiveCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding("Author")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Version")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Description")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			BotTemplateGuiContentUserControl.Content = ibot_0.Control;
		}
		catch (Exception ex)
		{
			BotTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)"Could not create the GUI!", ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (BotTemplateGuiBotGuideHyperlink.Tag is IUrlProvider urlProvider)
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
