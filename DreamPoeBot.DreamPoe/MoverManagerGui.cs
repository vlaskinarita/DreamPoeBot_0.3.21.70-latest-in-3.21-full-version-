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

public partial class MoverManagerGui : UserControl, IComponentConnector
{
	private sealed class Class6
	{
		public string string_0;

		internal bool method_0(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class7
	{
		public string string_0;

		internal bool method_0(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class8
	{
		public static readonly Class8 Class9 = new Class8();

		internal bool method_0(IPlayerMover iplayerMover_0)
		{
			return !string.IsNullOrEmpty(iplayerMover_0.Name);
		}
	}

	private sealed class Class9
	{
		public MoverManagerGui moverManagerGui_0;

		public PlayerMoverChangedEventArgs playerMoverChangedEventArgs_0;

		internal void method_0()
		{
			moverManagerGui_0.MoversComboBox.SelectedItem = playerMoverChangedEventArgs_0.New;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool bool_0;

	public MoverManagerGui()
	{
		InitializeComponent();
		base.Dispatcher.Invoke(method_1);
		PlayerMoverManager.OnPlayerMoverChanged += method_0;
	}

	private void method_0(object sender, PlayerMoverChangedEventArgs e)
	{
		Class9 @class = new Class9();
		@class.moverManagerGui_0 = this;
		@class.playerMoverChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void comboBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IPlayerMover playerMover2 = (PlayerMoverManager.Current = MoversComboBox.SelectedItem as IPlayerMover);
			if (playerMover2 != null)
			{
				GuiSettings.Instance.LastMover = playerMover2.Name;
			}
			ilog_0.DebugFormat("Current 'PlayerMover' set to {0}.", (object)((playerMover2 != null) ? playerMover2.Name : "(null)"));
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void method_1()
	{
		List<IPlayerMover> list = PlayerMoverManager.PlayerMovers.Where(Class8.Class9.method_0).ToList();
		MoversComboBox.ItemsSource = list;
		if (!CommandLine.Arguments.Exists("mover"))
		{
			if (!string.IsNullOrEmpty(GuiSettings.Instance.LastMover))
			{
				Class7 @class = new Class7();
				@class.string_0 = GuiSettings.Instance.LastMover;
				IPlayerMover playerMover = list.FirstOrDefault(@class.method_0);
				if (playerMover != null)
				{
					MoversComboBox.SelectedItem = playerMover;
				}
			}
		}
		else
		{
			Class6 class2 = new Class6();
			class2.string_0 = CommandLine.Arguments.Single("mover");
			IPlayerMover playerMover2 = list.FirstOrDefault(class2.method_0);
			if (playerMover2 != null)
			{
				MoversComboBox.SelectedItem = playerMover2;
			}
		}
		if (MoversComboBox.SelectedItem == null)
		{
			MoversComboBox.SelectedItem = list.FirstOrDefault();
		}
	}
}
