using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.WPFLocalizeExtension.Engine;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class LanguageSelection : UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class30
	{
		public static readonly Class30 Class9 = new Class30();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	public LanguageSelection(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class30.Class9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			GlobalSettings.Instance.AutoLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
			GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
			mainWindow_0.method_10();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class30.Class9.method_1);
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		ChooseLanguageButton.Focus();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
