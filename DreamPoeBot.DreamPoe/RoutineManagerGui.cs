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

public partial class RoutineManagerGui : UserControl, IComponentConnector
{
	private sealed class Class13
	{
		public string string_0;

		internal bool method_0(IRoutine iroutine_0)
		{
			return iroutine_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class14
	{
		public string string_0;

		internal bool method_0(IRoutine iroutine_0)
		{
			return iroutine_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class15
	{
		public static readonly Class15 Class9 = new Class15();

		internal bool method_0(IRoutine iroutine_0)
		{
			return !string.IsNullOrEmpty(iroutine_0.Name);
		}
	}

	private sealed class Class16
	{
		public RoutineManagerGui routineManagerGui_0;

		public RoutineChangedEventArgs routineChangedEventArgs_0;

		internal void method_0()
		{
			routineManagerGui_0.RoutinesComboBox.SelectedItem = routineChangedEventArgs_0.New;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool bool_0;

	public RoutineManagerGui()
	{
		InitializeComponent();
		base.Dispatcher.Invoke(method_1);
		RoutineManager.OnRoutineChanged += method_0;
	}

	private void method_0(object sender, RoutineChangedEventArgs e)
	{
		Class16 @class = new Class16();
		@class.routineManagerGui_0 = this;
		@class.routineChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void comboBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IRoutine routine2 = (RoutineManager.Current = RoutinesComboBox.SelectedItem as IRoutine);
			if (routine2 != null)
			{
				GuiSettings.Instance.LastRoutine = routine2.Name;
			}
			ilog_0.DebugFormat("Current 'Routine' set to {0}.", (object)((routine2 != null) ? routine2.Name : "(null)"));
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred:", ex);
		}
	}

	private void method_1()
	{
		List<IRoutine> list = RoutineManager.Routines.Where(Class15.Class9.method_0).ToList();
		RoutinesComboBox.ItemsSource = list;
		if (!CommandLine.Arguments.Exists("routine"))
		{
			if (!string.IsNullOrEmpty(GuiSettings.Instance.LastRoutine))
			{
				Class14 @class = new Class14();
				@class.string_0 = GuiSettings.Instance.LastRoutine;
				IRoutine routine = list.FirstOrDefault(@class.method_0);
				if (routine != null)
				{
					RoutinesComboBox.SelectedItem = routine;
				}
			}
		}
		else
		{
			Class13 class2 = new Class13();
			class2.string_0 = CommandLine.Arguments.Single("routine");
			IRoutine routine2 = list.FirstOrDefault(class2.method_0);
			if (routine2 != null)
			{
				RoutinesComboBox.SelectedItem = routine2;
			}
		}
		if (RoutinesComboBox.SelectedItem == null)
		{
			RoutinesComboBox.SelectedItem = list.FirstOrDefault();
		}
	}
}
