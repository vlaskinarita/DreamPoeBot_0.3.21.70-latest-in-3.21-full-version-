using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot;

public class GuiSettings : JsonSettings
{
	private static GuiSettings guiSettings_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private string string_4;

	private string string_5;

	private string string_6;

	private List<string> _enabledPlugins;

	private ObservableCollection<StringEntry> disabledPlugiList;

	private ObservableCollection<StringEntry> observableCollection_1;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	public static GuiSettings Instance
	{
		get
		{
			GuiSettings result;
			if ((result = guiSettings_0) == null)
			{
				result = (guiSettings_0 = new GuiSettings());
			}
			return result;
		}
	}

	[DefaultValue(true)]
	public bool CompileAsynchronously
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (!value.Equals(bool_3))
			{
				bool_3 = value;
				NotifyPropertyChanged(() => CompileAsynchronously);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool ExitOnLoadErrors
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (!value.Equals(bool_2))
			{
				bool_2 = value;
				NotifyPropertyChanged(() => ExitOnLoadErrors);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool ExitOnCompileErrors
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (!value.Equals(bool_1))
			{
				bool_1 = value;
				NotifyPropertyChanged(() => ExitOnCompileErrors);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool NoHideOnMinimize
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (!value.Equals(bool_4))
			{
				bool_4 = value;
				NotifyPropertyChanged(() => NoHideOnMinimize);
				Save();
			}
		}
	}

	[DefaultValue(0)]
	public int WindowX
	{
		get
		{
			return int_2;
		}
		set
		{
			if (!value.Equals(int_2))
			{
				int_2 = value;
				NotifyPropertyChanged(() => WindowX);
			}
		}
	}

	[DefaultValue(0)]
	public int WindowY
	{
		get
		{
			return int_3;
		}
		set
		{
			if (!value.Equals(int_3))
			{
				int_3 = value;
				NotifyPropertyChanged(() => WindowY);
			}
		}
	}

	[DefaultValue(627)]
	public int WindowWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (!value.Equals(int_0))
			{
				int_0 = value;
				NotifyPropertyChanged(() => WindowWidth);
			}
		}
	}

	[DefaultValue(477)]
	public int WindowHeight
	{
		get
		{
			return int_1;
		}
		set
		{
			if (!value.Equals(int_1))
			{
				int_1 = value;
				NotifyPropertyChanged(() => WindowHeight);
			}
		}
	}

	[DefaultValue(0)]
	public int SettingsWindowX
	{
		get
		{
			return int_6;
		}
		set
		{
			if (!value.Equals(int_6))
			{
				int_6 = value;
				NotifyPropertyChanged(() => SettingsWindowX);
			}
		}
	}

	[DefaultValue(0)]
	public int SettingsWindowY
	{
		get
		{
			return int_7;
		}
		set
		{
			if (!value.Equals(int_7))
			{
				int_7 = value;
				NotifyPropertyChanged(() => SettingsWindowY);
			}
		}
	}

	[DefaultValue(627)]
	public int SettingsWindowWidth
	{
		get
		{
			return int_4;
		}
		set
		{
			if (!value.Equals(int_4))
			{
				int_4 = value;
				NotifyPropertyChanged(() => SettingsWindowWidth);
			}
		}
	}

	[DefaultValue(477)]
	public int SettingsWindowHeight
	{
		get
		{
			return int_5;
		}
		set
		{
			if (!value.Equals(int_5))
			{
				int_5 = value;
				NotifyPropertyChanged(() => SettingsWindowHeight);
			}
		}
	}

	[DefaultValue("124*")]
	public string TopRowDefinitionHeight
	{
		get
		{
			return string_1;
		}
		set
		{
			if (!value.Equals(string_1))
			{
				string_1 = value;
				NotifyPropertyChanged(() => TopRowDefinitionHeight);
			}
		}
	}

	[DefaultValue("292*")]
	public string BottomRowDefinitionHeight
	{
		get
		{
			return string_2;
		}
		set
		{
			if (!value.Equals(string_2))
			{
				string_2 = value;
				NotifyPropertyChanged(() => BottomRowDefinitionHeight);
			}
		}
	}

	[DefaultValue("Auto")]
	public string SplitterRowDefinitionHeight
	{
		get
		{
			return string_3;
		}
		set
		{
			if (!value.Equals(string_3))
			{
				string_3 = value;
				NotifyPropertyChanged(() => SplitterRowDefinitionHeight);
			}
		}
	}

	[DefaultValue("NullBot")]
	public string LastBot
	{
		get
		{
			return string_4;
		}
		set
		{
			if (!value.Equals(string_4))
			{
				string_4 = value;
				NotifyPropertyChanged(() => LastBot);
			}
		}
	}

	[DefaultValue("ExampleRoutine")]
	public string LastRoutine
	{
		get
		{
			return string_5;
		}
		set
		{
			if (!value.Equals(string_5))
			{
				string_5 = value;
				NotifyPropertyChanged(() => LastRoutine);
			}
		}
	}

	[DefaultValue("ExampleMover")]
	public string LastMover
	{
		get
		{
			return string_6;
		}
		set
		{
			if (!value.Equals(string_6))
			{
				string_6 = value;
				NotifyPropertyChanged(() => LastMover);
			}
		}
	}

	public List<string> EnabledPlugins
	{
		get
		{
			return _enabledPlugins;
		}
		set
		{
			if (!value.Equals(_enabledPlugins))
			{
				_enabledPlugins = value;
				NotifyPropertyChanged(() => EnabledPlugins);
			}
		}
	}

	public ObservableCollection<StringEntry> ContentOrder
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			if (value != null && !value.Equals(observableCollection_1))
			{
				observableCollection_1 = value;
				NotifyPropertyChanged(() => ContentOrder);
				Save();
			}
		}
	}

	public ObservableCollection<StringEntry> DisabledContent
	{
		get
		{
			return disabledPlugiList;
		}
		set
		{
			if (!value.Equals(disabledPlugiList))
			{
				disabledPlugiList = value;
				NotifyPropertyChanged(() => DisabledContent);
			}
		}
	}

	[DefaultValue(16)]
	public int MemoryPullInterval
	{
		get
		{
			return int_1;
		}
		set
		{
			if (!value.Equals(int_1))
			{
				int_1 = value;
				NotifyPropertyChanged(() => MemoryPullInterval);
				Save();
			}
		}
	}

	public GuiSettings()
		: base(JsonSettings.GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "Gui")))
	{
		if (_enabledPlugins == null)
		{
			_enabledPlugins = new List<string> { "CommonEvents", "DevTab", "ObjectExplorer", "ItemFilterEditor", "ExamplePlugin" };
		}
		if (observableCollection_1 == null)
		{
			observableCollection_1 = new ObservableCollection<StringEntry>();
			observableCollection_1.Add(new StringEntry
			{
				Name = "CommonEvents"
			});
		}
		if (disabledPlugiList == null)
		{
			disabledPlugiList = new ObservableCollection<StringEntry>();
			disabledPlugiList.Add(new StringEntry
			{
				Name = "ExampleDisabledPlugin"
			});
		}
	}

	public void LoadRowDefinitions(RowDefinition topRowDefinition, RowDefinition splitterRowDefinition, RowDefinition bottomRowDefinition)
	{
		GridLengthConverter gridLengthConverter = new GridLengthConverter();
		topRowDefinition.Height = (GridLength)gridLengthConverter.ConvertFromString(TopRowDefinitionHeight);
		splitterRowDefinition.Height = (GridLength)gridLengthConverter.ConvertFromString(SplitterRowDefinitionHeight);
		bottomRowDefinition.Height = (GridLength)gridLengthConverter.ConvertFromString(BottomRowDefinitionHeight);
	}

	public void SaveRowDefinitions(RowDefinition topRowDefinition, RowDefinition splitterRowDefinition, RowDefinition bottomRowDefinition)
	{
		GridLengthConverter gridLengthConverter = new GridLengthConverter();
		TopRowDefinitionHeight = gridLengthConverter.ConvertToString(topRowDefinition.Height);
		SplitterRowDefinitionHeight = gridLengthConverter.ConvertToString(splitterRowDefinition.Height);
		BottomRowDefinitionHeight = gridLengthConverter.ConvertToString(bottomRowDefinition.Height);
	}
}
