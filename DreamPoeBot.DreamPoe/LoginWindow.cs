using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class LoginWindow : UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class31
	{
		public static readonly Class31 Class9 = new Class31();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}
	}

	private sealed class Class32
	{
		public LoginWindow loginWindow_0;

		public LoginWindow loginWindow_1;

		internal void method_0()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.AuthLoginButton.IsEnabled = true;
			loginWindow_0.KeyTextBox.IsEnabled = true;
			loginWindow_1.AuthRegionComboBox.IsEnabled = true;
		}

		internal void method_1()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.mainWindow_0.method_17();
		}

		internal void method_2()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.AuthLoginButton.IsEnabled = true;
			loginWindow_0.KeyTextBox.IsEnabled = true;
			loginWindow_1.AuthRegionComboBox.IsEnabled = true;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private bool bool_0;

	internal MetroProgressBar metroProgressBar_0;

	public LoginWindow(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			((ProgressBar)(object)metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)metroProgressBar_0).Visibility = Visibility.Hidden;
			AuthLoginButton.IsEnabled = true;
			KeyTextBox.IsEnabled = true;
			AuthRegionComboBox.IsEnabled = true;
			if (CommandLine.Arguments.Exists("authkey"))
			{
				GlobalSettings.Instance.AuthKeys = CommandLine.Arguments.Single("authkey");
			}
			KeyTextBox.Text = GlobalSettings.Instance.AuthKeys;
			if (string.IsNullOrEmpty(KeyTextBox.Text))
			{
				Keyboard.Focus(KeyTextBox);
				return;
			}
			Keyboard.Focus(AuthLoginButton);
			if (GlobalSettings.Instance.AutoAuthLogin || CommandLine.Arguments.Exists("autoauthlogin"))
			{
				method_1();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class31.Class9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			GlobalSettings.Instance.AuthKeys = KeyTextBox.Text;
			GlobalSettings.Instance.Save();
			if (string.IsNullOrEmpty(GlobalSettings.Instance.AuthKeys))
			{
				MessageBox.Show(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:AuthLoginErrorEmpty"), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>("Loki.Globalization:Localization:Title")), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			else
			{
				method_1();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class31.Class9.method_1);
		}
	}

	private void method_0(object object_0)
	{
		Class32 @class = new Class32();
		@class.loginWindow_1 = this;
		@class.loginWindow_0 = (LoginWindow)object_0;
		try
		{
			GlobalSettings.Instance.AuthKey = "";
			string[] array = GlobalSettings.Instance.AuthKeys.Split(new char[7] { ' ', '\t', '\n', '\r', '-', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
			int num = 0;
			string text;
			while (true)
			{
				if (num < array.Length)
				{
					text = array[num];
					if (Class104.smethod_4(GlobalSettings.Instance.AuthRegion, text))
					{
						break;
					}
					ilog_0.Info((object)"AttemptLogin failed for the current key, waiting 1s then trying next one...");
					Thread.Sleep(1000);
					num++;
					continue;
				}
				ilog_0.ErrorFormat("There was an error authenticating your key with the server. Please try again or use a different key.{0}{0}{1}", (object)Environment.NewLine, (object)Class104.string_0);
				@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_0));
				MessageBox.Show(string.Format("{0}{1}{1}{2}{1}{1}{3}", "There was an error authenticating your key with the server", Environment.NewLine, "Pls visit DreamPoeBot.com and make sure your key is valid, and it has some time in it.", "For any problems, pls contact Alcor75#7103 on Discord."), "Authentication Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			GlobalSettings.Instance.AuthKey = text;
			Class104.smethod_5();
			@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_1));
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_2));
			MessageBox.Show(string.Format("{0}{1}{1}{2}", "AuthError: Pls contact Alcor75#7103 on Discord", Environment.NewLine, Class104.string_0), "Unexpected Exception!", MessageBoxButton.OK, MessageBoxImage.Hand);
		}
	}

	private void method_1()
	{
		((ProgressBar)(object)metroProgressBar_0).IsIndeterminate = true;
		((UIElement)(object)metroProgressBar_0).Visibility = Visibility.Visible;
		AuthLoginButton.IsEnabled = false;
		KeyTextBox.IsEnabled = false;
		AuthRegionComboBox.IsEnabled = false;
		new Thread(method_0).Start(this);
	}

	private void method_2(object sender, KeyEventArgs e)
	{
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		KeyTextBox.Focus();
	}
}
