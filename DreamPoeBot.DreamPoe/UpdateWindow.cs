using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class UpdateWindow : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private readonly string string_0;

	private bool bool_0;

	public UpdateWindow(MainWindow mainWindow, string filter)
	{
		try
		{
			mainWindow_0 = mainWindow;
			string_0 = filter;
			InitializeComponent();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void YesButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			mainWindow_0.method_13(string_0);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void NoButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			mainWindow_0.method_11();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = "";
			using (WebClient webClient = new WebClient())
			{
				text = webClient.DownloadString("http://51.75.249.226:8100/GetDPBChangelog");
			}
			text = text.TrimStart('"').TrimEnd('"');
			text = text.Replace("\\u000d", "\r").Replace("\\u000a", "\n");
			ChangelogTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("[Grid_Loaded] An exception occurred: {0}.", (object)ex);
			ChangelogTextBox.Document.Blocks.Add(new Paragraph(new Run("<Unknown>")));
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		YesButton.Focus();
	}
}
