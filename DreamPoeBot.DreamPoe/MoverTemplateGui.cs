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

public partial class MoverTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IPlayerMover iplayerMover_0;

	private bool bool_0;

	public MoverTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IPlayerMover iplayerMover_1)
	{
		iplayerMover_0 = iplayerMover_1;
		MoverBindingWrapper source = new MoverBindingWrapper(iplayerMover_0);
		MoverTemplateGuiMoverGuideHyperlink.Tag = iplayerMover_0;
		if (!(iplayerMover_0 is IUrlProvider urlProvider))
		{
			MoverTemplateGuiMoverGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else if (string.IsNullOrEmpty(urlProvider.Url))
		{
			MoverTemplateGuiMoverGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else
		{
			MoverTemplateGuiMoverGuideTextBlock.Visibility = Visibility.Visible;
		}
		Binding binding = new Binding("IsActive")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		MoverTemplateGuiMoverActiveCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding("Author")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		MoverTemplateGuiMoverAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Version")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		MoverTemplateGuiMoverVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding("Description")
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		MoverTemplateGuiMoverDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			MoverTemplateGuiContentUserControl.Content = iplayerMover_0.Control;
		}
		catch (Exception ex)
		{
			MoverTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)"Could not create the GUI!", ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (MoverTemplateGuiMoverGuideHyperlink.Tag is IUrlProvider urlProvider)
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
