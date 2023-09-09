using System.Windows.Controls;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.Loki.Bot;

public interface IConfigurable
{
	UserControl Control { get; }

	JsonSettings Settings { get; }
}
