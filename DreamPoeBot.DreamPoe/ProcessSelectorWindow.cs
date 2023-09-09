using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Structures.ns11;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class ProcessSelectorWindow : UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class34
	{
		public static readonly Class34 Class9 = new Class34();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}

		internal void method_2()
		{
			Application.Current.Shutdown();
		}

		internal void method_3()
		{
			Application.Current.Shutdown();
		}

		internal void method_4()
		{
			Application.Current.Shutdown();
		}

		internal void method_5()
		{
			Application.Current.Shutdown();
		}
	}

	private sealed class Class35
	{
		public string string_0;

		public Process process_0;

		public ProcessSelectorWindow processSelectorWindow_0;

		internal void method_0()
		{
			ListBoxItem listBoxItem = new ListBoxItem();
			listBoxItem.Content = string_0 + " [PID: " + process_0.Id + "]";
			listBoxItem.Tag = process_0;
			ListBoxItem newItem = listBoxItem;
			processSelectorWindow_0.ProcessesListBox.Items.Add(newItem);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private DispatcherTimer dispatcherTimer_0;

	private bool bool_0;

	public ProcessSelectorWindow(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (ProcessesListBox.SelectedIndex != -1 && ProcessesListBox.SelectedItem is ListBoxItem listBoxItem)
			{
				mainWindow_0.method_15(listBoxItem.Tag as Process);
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_1);
		}
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			method_0();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_2);
		}
	}

	private void method_0()
	{
		ProcessesListBox.Items.Clear();
		RefreshButton.IsEnabled = false;
		ActivateButton.IsEnabled = false;
		ThreadPool.QueueUserWorkItem(method_2);
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		try
		{
			RefreshButton.IsEnabled = false;
			SelectButton.IsEnabled = false;
			ActivateButton.IsEnabled = false;
			dispatcherTimer_0 = new DispatcherTimer();
			dispatcherTimer_0.Tick += dispatcherTimer_0_Tick;
			dispatcherTimer_0.Interval = new TimeSpan(0, 0, 1);
			dispatcherTimer_0.Start();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_3);
		}
	}

	private void dispatcherTimer_0_Tick(object sender, EventArgs e)
	{
		dispatcherTimer_0.Stop();
		ThreadPool.QueueUserWorkItem(method_4);
	}

	private void listBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			if (ProcessesListBox.SelectedIndex == -1)
			{
				SelectButton.IsEnabled = false;
				return;
			}
			SelectButton.IsEnabled = true;
			ActivateButton.IsEnabled = true;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_4);
		}
	}

	private void button_2_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (ProcessesListBox.SelectedIndex != -1 && ProcessesListBox.SelectedItem is ListBoxItem listBoxItem && listBoxItem.Tag is Process process)
			{
				Interop.SwitchToThisWindow(process.MainWindowHandle, turnOn: true);
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"An exception occurred.", ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class34.Class9.method_5);
		}
	}

	private void listBox_0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		button_0_Click(sender, e);
	}

	private void method_2(object object_0)
	{
		foreach (KeyValuePair<Process, string> item in Class98.Dictionary_0)
		{
			Class35 @class = new Class35();
			@class.processSelectorWindow_0 = this;
			@class.process_0 = item.Key;
			@class.string_0 = item.Value;
			base.Dispatcher.BeginInvoke(new Action(@class.method_0));
		}
		base.Dispatcher.BeginInvoke(new Action(method_3));
	}

	private void method_3()
	{
		RefreshButton.IsEnabled = true;
		if (ProcessesListBox.Items.Count < 1)
		{
			SelectButton.IsEnabled = false;
			ActivateButton.IsEnabled = false;
			RefreshButton.Focus();
			Keyboard.Focus(RefreshButton);
		}
		else
		{
			ProcessesListBox.SelectedItem = ProcessesListBox.Items[0];
			SelectButton.IsEnabled = true;
			ActivateButton.IsEnabled = true;
			SelectButton.Focus();
			Keyboard.Focus(SelectButton);
		}
	}

	private void method_4(object object_0)
	{
		base.Dispatcher.Invoke(method_5);
	}

	private void method_5()
	{
		if (!mainWindow_0.method_16())
		{
			method_0();
		}
	}
}
