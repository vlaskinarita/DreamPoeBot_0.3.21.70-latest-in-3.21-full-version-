using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DreamPoeBot.DreamPoe;

public partial class PremiumContentManagerGui : UserControl, IComponentConnector
{
	public PremiumContentManagerGui(object context)
	{
		InitializeComponent();
		base.DataContext = context;
	}

	private void ToggleSwitch_OnClick(object sender, RoutedEventArgs e)
	{
		if (((FrameworkElement)sender).DataContext is PremiumContentClass premiumContentClass)
		{
			premiumContentClass.Enabled = !premiumContentClass.Enabled;
		}
	}
}
