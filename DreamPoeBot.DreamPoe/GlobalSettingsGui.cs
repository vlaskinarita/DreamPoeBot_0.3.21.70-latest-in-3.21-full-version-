using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.WPFLocalizeExtension.Engine;

namespace DreamPoeBot.DreamPoe;

public partial class GlobalSettingsGui : UserControl, IComponentConnector
{
	public GlobalSettingsGui(object context)
	{
		InitializeComponent();
		base.DataContext = context;
	}

	private void comboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}
}
