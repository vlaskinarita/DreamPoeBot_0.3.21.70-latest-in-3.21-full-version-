using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace DreamPoeBot.Loki.Common;

public static class Wpf
{
	public static T FindControlByName<T>(DependencyObject root, string name) where T : class
	{
		return smethod_0(root, name) as T;
	}

	private static DependencyObject smethod_0(DependencyObject dependencyObject_0, string string_0)
	{
		if (dependencyObject_0 == null)
		{
			return null;
		}
		DependencyObject dependencyObject = LogicalTreeHelper.FindLogicalNode(dependencyObject_0, string_0);
		if (dependencyObject != null)
		{
			return dependencyObject;
		}
		IEnumerable children = LogicalTreeHelper.GetChildren(dependencyObject_0);
		if (children != null)
		{
			IEnumerator enumerator = children.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				dependencyObject = smethod_0(current as DependencyObject, string_0);
				if (dependencyObject != null)
				{
					return dependencyObject;
				}
			}
		}
		return null;
	}

	public static bool SetupTextBoxBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		TextBox textBox = FindControlByName<TextBox>(xamlRoot, controlName);
		if (textBox == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = converter
		};
		textBox.SetBinding(TextBox.TextProperty, binding);
		return true;
	}

	public static bool SetupCheckBoxBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		CheckBox checkBox = FindControlByName<CheckBox>(xamlRoot, controlName);
		if (checkBox == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = converter
		};
		checkBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		return true;
	}

	public static bool SetupLabelBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		Label label = FindControlByName<Label>(xamlRoot, controlName);
		if (label == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = converter
		};
		label.SetBinding(ContentControl.ContentProperty, binding);
		return true;
	}

	public static bool SetupListBoxItemsBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		ListBox listBox = FindControlByName<ListBox>(xamlRoot, controlName);
		if (listBox != null)
		{
			Binding binding = new Binding(bindingName)
			{
				Mode = bindingMode,
				Source = bindingSource,
				Converter = converter
			};
			listBox.SetBinding(ItemsControl.ItemsSourceProperty, binding);
			return true;
		}
		return false;
	}

	public static bool SetupListBoxSelectedItemBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		ListBox listBox = FindControlByName<ListBox>(xamlRoot, controlName);
		if (listBox != null)
		{
			Binding binding = new Binding(bindingName)
			{
				Mode = bindingMode,
				Source = bindingSource,
				Converter = converter
			};
			listBox.SetBinding(Selector.SelectedItemProperty, binding);
			return true;
		}
		return false;
	}

	public static bool SetupComboBoxItemsBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		ComboBox comboBox = FindControlByName<ComboBox>(xamlRoot, controlName);
		if (comboBox == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = converter
		};
		comboBox.SetBinding(ItemsControl.ItemsSourceProperty, binding);
		return true;
	}

	public static bool SetupComboBoxSelectedItemBinding(DependencyObject xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
	{
		ComboBox comboBox = FindControlByName<ComboBox>(xamlRoot, controlName);
		if (comboBox == null)
		{
			return false;
		}
		Binding binding = new Binding(bindingName)
		{
			Mode = bindingMode,
			Source = bindingSource,
			Converter = converter
		};
		comboBox.SetBinding(Selector.SelectedItemProperty, binding);
		return true;
	}
}
