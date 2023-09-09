using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Common.Controls;

namespace DreamPoeBot.DreamPoe;

[TemplatePart(Name = "PART_IncreaseTime", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_Hours", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_DecrementTime", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_Minutes", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_Seconds", Type = typeof(TextBox))]
public class TimePicker : Control
{
	public static class MathUtil
	{
		public static int IncrementDecrementNumber(string num, int minValue, int maxVal, bool increment)
		{
			int num2 = ValidateNumber(num, minValue, maxVal);
			if (increment)
			{
				return Math.Min(num2 + 1, maxVal);
			}
			return Math.Max(num2 - 1, 0);
		}

		public static int ValidateNumber(string newNum, int minValue, int maxValue)
		{
			if (!int.TryParse(newNum, out var result))
			{
				return 0;
			}
			return ValidateNumber(result, minValue, maxValue);
		}

		public static int ValidateNumber(int newNum, int minValue, int maxValue)
		{
			newNum = Math.Max(newNum, minValue);
			newNum = Math.Min(newNum, maxValue);
			return newNum;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class Class19
	{
		public static readonly Class19 Class9 = new Class19();

		internal void method_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			timePicker.int_3 = timePicker.MinTime.Hours;
			timePicker.int_4 = timePicker.MinTime.Minutes;
			timePicker.int_5 = timePicker.MinTime.Seconds;
			timePicker.CoerceValue(SelectedTimeProperty);
		}

		internal void method_1(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			timePicker.int_0 = timePicker.MaxTime.Hours;
			timePicker.int_1 = timePicker.MaxTime.Minutes;
			timePicker.int_2 = timePicker.MaxTime.Seconds;
			timePicker.CoerceValue(SelectedTimeProperty);
		}

		internal void method_2(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			int num = MathUtil.ValidateNumber(timePicker.SelectedHour, timePicker.int_3, timePicker.int_0);
			if (num != timePicker.SelectedHour)
			{
				timePicker.SelectedHour = num;
			}
			smethod_6(timePicker);
		}

		internal void method_3(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			int num = MathUtil.ValidateNumber(timePicker.SelectedMinute, timePicker.int_4, timePicker.int_1);
			if (num != timePicker.SelectedMinute)
			{
				timePicker.SelectedMinute = num;
			}
			smethod_6(timePicker);
		}

		internal void method_4(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			int num = MathUtil.ValidateNumber(timePicker.SelectedSecond, timePicker.int_5, timePicker.int_2);
			if (num != timePicker.SelectedSecond)
			{
				timePicker.SelectedSecond = num;
			}
			smethod_6(timePicker);
		}
	}

	private int int_0 = 23;

	private int int_1 = 59;

	private int int_2 = 59;

	private int int_3;

	private int int_4;

	private int int_5;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	public static readonly DependencyProperty MinTimeProperty;

	public static readonly DependencyProperty MaxTimeProperty;

	public static readonly DependencyProperty SelectedTimeProperty;

	public static readonly DependencyProperty SelectedHourProperty;

	public static readonly DependencyProperty SelectedMinuteProperty;

	public static readonly DependencyProperty SelectedSecondProperty;

	public static readonly RoutedEvent SelectedTimeChangedEvent;

	private bool bool_0;

	public TimeSpan MinTime
	{
		get
		{
			return (TimeSpan)GetValue(MinTimeProperty);
		}
		set
		{
			SetValue(MinTimeProperty, value);
		}
	}

	public TimeSpan MaxTime
	{
		get
		{
			return (TimeSpan)GetValue(MaxTimeProperty);
		}
		set
		{
			SetValue(MaxTimeProperty, value);
		}
	}

	public TimeSpan SelectedTime
	{
		get
		{
			return (TimeSpan)GetValue(SelectedTimeProperty);
		}
		set
		{
			SetValue(SelectedTimeProperty, value);
		}
	}

	public int SelectedHour
	{
		get
		{
			return (int)GetValue(SelectedHourProperty);
		}
		set
		{
			SetValue(SelectedHourProperty, value);
		}
	}

	public int SelectedMinute
	{
		get
		{
			return (int)GetValue(SelectedMinuteProperty);
		}
		set
		{
			SetValue(SelectedMinuteProperty, value);
		}
	}

	public int SelectedSecond
	{
		get
		{
			return (int)GetValue(SelectedSecondProperty);
		}
		set
		{
			SetValue(SelectedSecondProperty, value);
		}
	}

	public event TimeSelectedChangedEventHandler SelectedTimeChanged
	{
		add
		{
			method_10(SelectedTimeChangedEvent, (Delegate)value);
		}
		remove
		{
			method_11(SelectedTimeChangedEvent, (Delegate)value);
		}
	}

	public static bool SetupSelectedTimeBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource)
	{
		TimePicker timePicker = Wpf.FindControlByName<TimePicker>(xamlRoot, controlName);
		if (timePicker == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = null
		};
		timePicker.SetBinding(SelectedTimeProperty, binding);
		return true;
	}

	private static object smethod_0(DependencyObject dependencyObject_0, object object_0)
	{
		TimePicker timePicker = (TimePicker)dependencyObject_0;
		TimeSpan timeSpan = (TimeSpan)object_0;
		if (!(timeSpan < timePicker.MinTime))
		{
			if (!(timeSpan > timePicker.MaxTime))
			{
				return timeSpan;
			}
			return timePicker.MaxTime;
		}
		return timePicker.MinTime;
	}

	private static void smethod_1(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		TimePicker timePicker = (TimePicker)dependencyObject_0;
		TimeSpan timeSpan = (TimeSpan)dependencyPropertyChangedEventArgs_0.NewValue;
		TimeSpan timeSpan_ = (TimeSpan)dependencyPropertyChangedEventArgs_0.OldValue;
		if (!timePicker.bool_0)
		{
			timePicker.method_7();
			if (timePicker.SelectedHour != timeSpan.Hours)
			{
				timePicker.SelectedHour = timeSpan.Hours;
			}
			if (timePicker.SelectedMinute != timeSpan.Minutes)
			{
				timePicker.SelectedMinute = timeSpan.Minutes;
			}
			if (timePicker.SelectedSecond != timeSpan.Seconds)
			{
				timePicker.SelectedSecond = timeSpan.Seconds;
			}
			timePicker.method_8();
			timePicker.method_9(timePicker.SelectedTime, timeSpan_);
		}
	}

	public TimePicker()
	{
		SelectedTime = DateTime.Now.TimeOfDay;
	}

	static TimePicker()
	{
		MinTimeProperty = DependencyProperty.Register("MinTime", typeof(TimeSpan), typeof(TimePicker), new UIPropertyMetadata(TimeSpan.MinValue, delegate(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker5 = (TimePicker)dependencyObject_0;
			timePicker5.int_3 = timePicker5.MinTime.Hours;
			timePicker5.int_4 = timePicker5.MinTime.Minutes;
			timePicker5.int_5 = timePicker5.MinTime.Seconds;
			timePicker5.CoerceValue(SelectedTimeProperty);
		}));
		MaxTimeProperty = DependencyProperty.Register("MaxTime", typeof(TimeSpan), typeof(TimePicker), new UIPropertyMetadata(TimeSpan.MaxValue, delegate(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker4 = (TimePicker)dependencyObject_0;
			timePicker4.int_0 = timePicker4.MaxTime.Hours;
			timePicker4.int_1 = timePicker4.MaxTime.Minutes;
			timePicker4.int_2 = timePicker4.MaxTime.Seconds;
			timePicker4.CoerceValue(SelectedTimeProperty);
		}));
		SelectedTimeProperty = DependencyProperty.Register("SelectedTime", typeof(TimeSpan), typeof(TimePicker), new UIPropertyMetadata(new TimeSpan(0, 0, 0), smethod_1, smethod_0));
		SelectedHourProperty = DependencyProperty.Register("SelectedHour", typeof(int), typeof(TimePicker), new UIPropertyMetadata(0, delegate(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker3 = (TimePicker)dependencyObject_0;
			int num3 = MathUtil.ValidateNumber(timePicker3.SelectedHour, timePicker3.int_3, timePicker3.int_0);
			if (num3 != timePicker3.SelectedHour)
			{
				timePicker3.SelectedHour = num3;
			}
			smethod_6(timePicker3);
		}));
		SelectedMinuteProperty = DependencyProperty.Register("SelectedMinute", typeof(int), typeof(TimePicker), new UIPropertyMetadata(0, delegate(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker2 = (TimePicker)dependencyObject_0;
			int num2 = MathUtil.ValidateNumber(timePicker2.SelectedMinute, timePicker2.int_4, timePicker2.int_1);
			if (num2 != timePicker2.SelectedMinute)
			{
				timePicker2.SelectedMinute = num2;
			}
			smethod_6(timePicker2);
		}));
		SelectedSecondProperty = DependencyProperty.Register("SelectedSecond", typeof(int), typeof(TimePicker), new UIPropertyMetadata(0, delegate(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
		{
			TimePicker timePicker = (TimePicker)dependencyObject_0;
			int num = MathUtil.ValidateNumber(timePicker.SelectedSecond, timePicker.int_5, timePicker.int_2);
			if (num != timePicker.SelectedSecond)
			{
				timePicker.SelectedSecond = num;
			}
			smethod_6(timePicker);
		}));
		SelectedTimeChanged = EventManager.RegisterRoutedEvent("SelectedTimeChanged", RoutingStrategy.Bubble, typeof(TimeSelectedChangedEventHandler), typeof(TimePicker));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
	}

	public override void OnApplyTemplate()
	{
		textBox_0 = GetTemplateChild("PART_Hours") as TextBox;
		textBox_0.PreviewTextInput += textBox_0_PreviewTextInput;
		textBox_0.KeyUp += textBox_0_KeyUp;
		textBox_0.GotFocus += textBox_2_GotMouseCapture;
		textBox_0.GotMouseCapture += textBox_2_GotMouseCapture;
		textBox_1 = GetTemplateChild("PART_Minutes") as TextBox;
		textBox_1.PreviewTextInput += textBox_1_PreviewTextInput;
		textBox_1.KeyUp += textBox_1_KeyUp;
		textBox_1.GotFocus += textBox_2_GotMouseCapture;
		textBox_1.GotMouseCapture += textBox_2_GotMouseCapture;
		textBox_2 = GetTemplateChild("PART_Seconds") as TextBox;
		textBox_2.PreviewTextInput += textBox_2_PreviewTextInput;
		textBox_2.KeyUp += textBox_2_KeyUp;
		textBox_2.GotFocus += textBox_2_GotMouseCapture;
		textBox_2.GotMouseCapture += textBox_2_GotMouseCapture;
		(GetTemplateChild("PART_IncreaseTime") as ButtonBase).Click += method_2;
		(GetTemplateChild("PART_DecrementTime") as ButtonBase).Click += method_1;
	}

	private void textBox_2_GotMouseCapture(object sender, RoutedEventArgs e)
	{
		(textBox_3 = (TextBox)sender).SelectAll();
	}

	private void textBox_0_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		smethod_5(textBox_0);
		string string_ = smethod_3(textBox_0, e.Text);
		method_4(string_);
		smethod_4(textBox_0, textBox_1);
		e.Handled = true;
	}

	private void textBox_1_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		smethod_5(textBox_1);
		string string_ = smethod_3(textBox_1, e.Text);
		method_5(string_);
		smethod_4(textBox_1, textBox_2);
		e.Handled = true;
	}

	private void textBox_2_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		smethod_5(textBox_2);
		string string_ = smethod_3(textBox_2, e.Text);
		method_6(string_);
		smethod_4(textBox_2, null);
		e.Handled = true;
	}

	private bool method_0(Key key_0)
	{
		if (key_0 == Key.Up)
		{
			method_3(bool_1: true);
		}
		else
		{
			if (key_0 != Key.Down)
			{
				return false;
			}
			method_3(bool_1: false);
		}
		return true;
	}

	private void textBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		smethod_2(textBox_0, null, textBox_1, e.Key);
		if (!method_0(e.Key))
		{
			method_4(textBox_0.Text);
		}
	}

	private void textBox_1_KeyUp(object sender, KeyEventArgs e)
	{
		smethod_2(textBox_1, textBox_0, textBox_2, e.Key);
		if (!method_0(e.Key))
		{
			method_5(textBox_1.Text);
		}
	}

	private void textBox_2_KeyUp(object sender, KeyEventArgs e)
	{
		smethod_2(textBox_2, textBox_1, null, e.Key);
		if (!method_0(e.Key))
		{
			method_6(textBox_2.Text);
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		method_3(bool_1: false);
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		method_3(bool_1: true);
	}

	private void method_3(bool bool_1)
	{
		if (textBox_0 == textBox_3)
		{
			SelectedHour = MathUtil.IncrementDecrementNumber(textBox_0.Text, int_3, int_0, bool_1);
		}
		else if (textBox_1 != textBox_3)
		{
			SelectedSecond = MathUtil.IncrementDecrementNumber(textBox_2.Text, int_5, int_2, bool_1);
		}
		else
		{
			SelectedMinute = MathUtil.IncrementDecrementNumber(textBox_1.Text, int_4, int_1, bool_1);
		}
	}

	private int method_4(string string_0)
	{
		return SelectedHour = MathUtil.ValidateNumber(string_0, int_3, int_0);
	}

	private int method_5(string string_0)
	{
		return SelectedMinute = MathUtil.ValidateNumber(string_0, int_4, int_1);
	}

	private int method_6(string string_0)
	{
		return SelectedSecond = MathUtil.ValidateNumber(string_0, int_5, int_2);
	}

	private static void smethod_2(TextBox textBox_4, TextBox textBox_5, TextBox textBox_6, Key key_0)
	{
		if (key_0 == Key.Left && textBox_5 != null && textBox_4.CaretIndex == 0)
		{
			textBox_5.Focus();
		}
		else if (key_0 == Key.Right && textBox_6 != null && textBox_4.CaretIndex == textBox_4.Text.Length)
		{
			textBox_6.Focus();
		}
	}

	private static string smethod_3(TextBox textBox_4, string string_0)
	{
		if (textBox_4.Text.Length == 2)
		{
			if (textBox_4.CaretIndex == 0)
			{
				return string_0 + textBox_4.Text[1];
			}
			return textBox_4.Text[0] + string_0;
		}
		if (textBox_4.CaretIndex == 0)
		{
			return string_0 + textBox_4.Text;
		}
		return textBox_4.Text + string_0;
	}

	private static void smethod_4(TextBox textBox_4, TextBox textBox_5)
	{
		if (textBox_4.CaretIndex == 1 && textBox_5 != null)
		{
			textBox_5.Focus();
		}
		else if (textBox_4.CaretIndex == 0)
		{
			textBox_4.CaretIndex++;
		}
	}

	private static void smethod_5(TextBox textBox_4)
	{
		if (textBox_4.SelectionLength > 0)
		{
			textBox_4.Text = textBox_4.Text.Remove(textBox_4.SelectionStart, textBox_4.SelectionLength);
		}
	}

	private static void smethod_6(TimePicker timePicker_0)
	{
		if (!timePicker_0.bool_0)
		{
			TimeSpan timeSpan = new TimeSpan(timePicker_0.SelectedHour, timePicker_0.SelectedMinute, timePicker_0.SelectedSecond);
			if (timePicker_0.SelectedTime != timeSpan)
			{
				timePicker_0.SelectedTime = timeSpan;
			}
		}
	}

	private void method_7()
	{
		bool_0 = true;
	}

	private void method_8()
	{
		bool_0 = false;
	}

	private void method_9(TimeSpan timeSpan_0, TimeSpan timeSpan_1)
	{
		TimeSelectedChangedRoutedEventArgs routedEventArgs_ = new TimeSelectedChangedRoutedEventArgs(SelectedTimeChanged)
		{
			NewTime = timeSpan_0,
			OldTime = timeSpan_1
		};
		method_12((RoutedEventArgs)routedEventArgs_);
	}

	void method_10(RoutedEvent routedEvent_0, Delegate delegate_0)
	{
		AddHandler(routedEvent_0, delegate_0);
	}

	void method_11(RoutedEvent routedEvent_0, Delegate delegate_0)
	{
		RemoveHandler(routedEvent_0, delegate_0);
	}

	void method_12(RoutedEventArgs routedEventArgs_0)
	{
		RaiseEvent(routedEventArgs_0);
	}
}
