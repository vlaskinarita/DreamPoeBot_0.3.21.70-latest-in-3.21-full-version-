using System.Windows.Controls;
using System.Windows.Markup;

namespace DreamPoeBot.DreamPoe;

public partial class CurrentConfigurationGui : UserControl, IComponentConnector
{
	private bool bool_0;

	public CurrentConfigurationGui(object context)
	{
		InitializeComponent();
		base.DataContext = context;
	}
}
