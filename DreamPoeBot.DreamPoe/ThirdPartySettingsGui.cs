using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class ThirdPartySettingsGui : UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class18
	{
		public static readonly Class18 Class9 = new Class18();

		internal ThirdPartyInstanceWrapper method_0(ThirdPartyInstance thirdPartyInstance_0)
		{
			return new ThirdPartyInstanceWrapper(thirdPartyInstance_0);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool bool_0;

	public ThirdPartySettingsGui()
	{
		InitializeComponent();
		InstanceDataGrid.ItemsSource = ThirdPartyLoader.Instances.Select(Class18.Class9.method_0).ToList();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		if (sender is Button button && button.Tag is ThirdPartyInstanceWrapper thirdPartyInstanceWrapper)
		{
			ThirdPartyInstance instance = ThirdPartyLoader.GetInstance(thirdPartyInstanceWrapper.ThirdPartyInstance_0.Name);
			if (instance != null && !(instance.CompiledAssembly != thirdPartyInstanceWrapper.CompiledAssembly))
			{
				ilog_0.Warn((object)"Under construction...");
			}
			else
			{
				button.IsEnabled = false;
			}
		}
	}
}
