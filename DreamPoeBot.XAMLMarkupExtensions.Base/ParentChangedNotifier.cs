using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class ParentChangedNotifier : DependencyObject, IDisposable
{
	public static DependencyProperty ParentProperty = DependencyProperty.RegisterAttached("Parent", typeof(DependencyObject), typeof(ParentChangedNotifier), new PropertyMetadata(smethod_0));

	private static Dictionary<FrameworkElement, List<Action>> dictionary_0 = new Dictionary<FrameworkElement, List<Action>>();

	private FrameworkElement frameworkElement_0;

	public static FrameworkElement GetParent(FrameworkElement element)
	{
		return (FrameworkElement)element.GetValue(ParentProperty);
	}

	public static void SetParent(FrameworkElement element, FrameworkElement value)
	{
		element.SetValue(ParentProperty, value);
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (!(dependencyObject_0 is FrameworkElement key) || !dictionary_0.ContainsKey(key))
		{
			return;
		}
		List<Action> list = new List<Action>(dictionary_0[key]);
		foreach (Action item in list)
		{
			item();
		}
		list.Clear();
	}

	public ParentChangedNotifier(FrameworkElement element, Action onParentChanged)
	{
		frameworkElement_0 = element;
		if (onParentChanged != null)
		{
			if (!dictionary_0.ContainsKey(element))
			{
				dictionary_0.Add(element, new List<Action>());
			}
			dictionary_0[element].Add(onParentChanged);
		}
		Binding binding = new Binding("Parent");
		binding.RelativeSource = new RelativeSource();
		binding.RelativeSource.Mode = RelativeSourceMode.FindAncestor;
		binding.RelativeSource.AncestorType = typeof(FrameworkElement);
		BindingOperations.SetBinding(element, ParentProperty, binding);
	}

	public void Dispose()
	{
		FrameworkElement frameworkElement = frameworkElement_0;
		if (frameworkElement == null)
		{
			return;
		}
		try
		{
			frameworkElement.ClearValue(ParentProperty);
			if (dictionary_0.ContainsKey(frameworkElement))
			{
				dictionary_0[frameworkElement].Clear();
				dictionary_0.Remove(frameworkElement);
			}
		}
		finally
		{
			frameworkElement_0 = null;
		}
	}
}
