using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal interface IDictionaryEventListener
{
	void ResourceChanged(DependencyObject sender, DictionaryEventArgs e);
}
