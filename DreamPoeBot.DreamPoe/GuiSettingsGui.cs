using System.Windows.Controls;
using System.Windows.Markup;

namespace DreamPoeBot.DreamPoe;

public partial class GuiSettingsGui : UserControl, IComponentConnector
{
	private bool bool_0;

	public GuiSettingsGui(object context)
	{
		InitializeComponent();
		base.DataContext = context;
	}
}
