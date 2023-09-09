using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class BotManagerGui : UserControl, IComponentConnector
{
	private sealed class Class1
	{
		public string string_0;

		internal bool method_0(IBot ibot_0)
		{
			return ibot_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class2
	{
		public string string_0;

		internal bool method_0(IBot ibot_0)
		{
			return ibot_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class3
	{
		public static readonly Class3 class9 = new Class3();

		internal bool method_0(IBot ibot_0)
		{
			return !string.IsNullOrEmpty(ibot_0.Name);
		}
	}

	private sealed class Class4
	{
		public BotManagerGui botManagerGui_0;

		public BotChangedEventArgs botChangedEventArgs_0;

		internal void method_0()
		{
			botManagerGui_0.BotsComboBox.SelectedItem = botChangedEventArgs_0.New;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public BotManagerGui()
	{
		InitializeComponent();
		base.Dispatcher.Invoke(method_1);
		BotManager.OnBotChanged += method_0;
	}

	private void method_0(object sender, BotChangedEventArgs e)
	{
		Class4 @class = new Class4();
		@class.botManagerGui_0 = this;
		@class.botChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void comboBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IBot bot2 = (BotManager.Current = BotsComboBox.SelectedItem as IBot);
			if (bot2 != null)
			{
				GuiSettings.Instance.LastBot = bot2.Name;
			}
			ilog_0.DebugFormat("Current 'Bot' set to {0}.", (object)((bot2 != null) ? bot2.Name : "(null)"));
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void method_1()
	{
		List<IBot> list = BotManager.Bots.Where(Class3.class9.method_0).ToList();
		BotsComboBox.ItemsSource = list;
		if (!CommandLine.Arguments.Exists("bot"))
		{
			if (!string.IsNullOrEmpty(GuiSettings.Instance.LastBot))
			{
				Class2 @class = new Class2();
				@class.string_0 = GuiSettings.Instance.LastBot;
				IBot bot = list.FirstOrDefault(@class.method_0);
				if (bot != null)
				{
					BotsComboBox.SelectedItem = bot;
				}
			}
		}
		else
		{
			Class1 class2 = new Class1();
			class2.string_0 = CommandLine.Arguments.Single("bot");
			IBot bot2 = list.FirstOrDefault(class2.method_0);
			if (bot2 != null)
			{
				BotsComboBox.SelectedItem = bot2;
			}
		}
		if (BotsComboBox.SelectedItem == null)
		{
			BotsComboBox.SelectedItem = list.FirstOrDefault();
		}
	}
}
