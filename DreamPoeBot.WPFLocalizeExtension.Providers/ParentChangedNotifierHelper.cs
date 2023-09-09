using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal static class ParentChangedNotifierHelper
{
	private sealed class Class85<T>
	{
		public Action<DependencyObject> action_0;

		public DependencyObject dependencyObject_0;

		public Dictionary<DependencyObject, ParentChangedNotifier> dictionary_0;

		public Action action_1;

		internal void method_0()
		{
			action_0(dependencyObject_0);
			if (dictionary_0.ContainsKey(dependencyObject_0))
			{
				dictionary_0[dependencyObject_0].Dispose();
				dictionary_0.Remove(dependencyObject_0);
			}
		}
	}

	private sealed class Class86<T>
	{
		public DependencyProperty dependencyProperty_0;

		internal T method_0(DependencyObject dependencyObject_0)
		{
			object obj = smethod_0(dependencyObject_0, dependencyProperty_0);
			if (!(obj is T))
			{
				return default(T);
			}
			return (T)obj;
		}

		static object smethod_0(DependencyObject dependencyObject_0, DependencyProperty dependencyProperty_1)
		{
			return dependencyObject_0.GetValue(dependencyProperty_1);
		}
	}

	public static T GetValueOrRegisterParentNotifier<T>(this DependencyObject target, Func<DependencyObject, T> GetFunction, Action<DependencyObject> ParentChangedAction, Dictionary<DependencyObject, ParentChangedNotifier> parentNotifiers)
	{
		Class85<T> @class = new Class85<T>();
		@class.action_0 = ParentChangedAction;
		@class.dependencyObject_0 = target;
		@class.dictionary_0 = parentNotifiers;
		T val = default(T);
		if (@class.dependencyObject_0 != null)
		{
			DependencyObject dependencyObject = @class.dependencyObject_0;
			while (val == null)
			{
				val = GetFunction(dependencyObject);
				if (val != null && @class.dictionary_0.ContainsKey(@class.dependencyObject_0))
				{
					@class.dictionary_0[@class.dependencyObject_0].Dispose();
					@class.dictionary_0.Remove(@class.dependencyObject_0);
				}
				if ((!(dependencyObject is Visual) && !(dependencyObject is Visual3D) && !(dependencyObject is FrameworkContentElement)) || dependencyObject is Window)
				{
					break;
				}
				DependencyObject dependencyObject2 = null;
				if (!(dependencyObject is FrameworkContentElement))
				{
					try
					{
						dependencyObject2 = LogicalTreeHelper.GetParent(dependencyObject);
					}
					catch
					{
						dependencyObject2 = null;
					}
				}
				else
				{
					dependencyObject2 = ((FrameworkContentElement)dependencyObject).Parent;
				}
				if (dependencyObject2 == null)
				{
					try
					{
						dependencyObject2 = VisualTreeHelper.GetParent(dependencyObject);
					}
					catch
					{
						return val;
					}
				}
				if (dependencyObject2 == null && dependencyObject is FrameworkElement)
				{
					dependencyObject2 = ((FrameworkElement)dependencyObject).Parent;
				}
				if (val != null || dependencyObject2 != null)
				{
					dependencyObject = dependencyObject2;
					continue;
				}
				if (dependencyObject is FrameworkElement && !@class.dictionary_0.ContainsKey(@class.dependencyObject_0))
				{
					Dictionary<DependencyObject, ParentChangedNotifier> dictionary_ = @class.dictionary_0;
					DependencyObject dependencyObject_ = @class.dependencyObject_0;
					FrameworkElement element = (FrameworkElement)dependencyObject;
					Action onParentChanged;
					if ((onParentChanged = @class.action_1) == null)
					{
						onParentChanged = (@class.action_1 = @class.method_0);
					}
					dictionary_.Add(dependencyObject_, new ParentChangedNotifier(element, onParentChanged));
				}
				break;
			}
		}
		return val;
	}

	public static T GetValue<T>(this DependencyObject target, Func<DependencyObject, T> GetFunction)
	{
		T val = default(T);
		if (target != null)
		{
			DependencyObject dependencyObject = target;
			while (val == null)
			{
				val = GetFunction(dependencyObject);
				if (!(dependencyObject is Visual) && !(dependencyObject is Visual3D) && !(dependencyObject is FrameworkContentElement))
				{
					break;
				}
				DependencyObject dependencyObject2 = null;
				if (dependencyObject is FrameworkContentElement)
				{
					dependencyObject2 = ((FrameworkContentElement)dependencyObject).Parent;
				}
				else
				{
					try
					{
						dependencyObject2 = VisualTreeHelper.GetParent(dependencyObject);
					}
					catch
					{
						return val;
					}
				}
				if (dependencyObject2 == null && dependencyObject is FrameworkElement)
				{
					dependencyObject2 = ((FrameworkElement)dependencyObject).Parent;
				}
				if (val == null && dependencyObject2 == null)
				{
					break;
				}
				dependencyObject = dependencyObject2;
			}
		}
		return val;
	}

	public static T GetValueOrRegisterParentNotifier<T>(this DependencyObject target, DependencyProperty property, Action<DependencyObject> ParentChangedAction, Dictionary<DependencyObject, ParentChangedNotifier> parentNotifiers)
	{
		Class86<T> @class = new Class86<T>();
		@class.dependencyProperty_0 = property;
		return target.GetValueOrRegisterParentNotifier(@class.method_0, ParentChangedAction, parentNotifiers);
	}
}
