using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

[MarkupExtensionReturnType(typeof(object))]
internal abstract class NestedMarkupExtension : MarkupExtension, INestedMarkupExtension, IDisposable
{
	internal static class Class71
	{
		private static List<WeakReference> list_0 = new List<WeakReference>();

		private static object object_0 = new object();

		internal static void smethod_0(NestedMarkupExtension nestedMarkupExtension_0, EndpointReachedEventArgs endpointReachedEventArgs_0)
		{
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target == null)
					{
						list_0.Remove(item);
					}
					else
					{
						((NestedMarkupExtension)target).method_1(nestedMarkupExtension_0, endpointReachedEventArgs_0);
					}
				}
			}
		}

		internal static void smethod_1(NestedMarkupExtension nestedMarkupExtension_0)
		{
			if (nestedMarkupExtension_0 == null)
			{
				return;
			}
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target == null)
					{
						list_0.Remove(item);
						continue;
					}
					if (target == nestedMarkupExtension_0)
					{
						return;
					}
					foreach (TargetInfo item2 in ((NestedMarkupExtension)target).method_0())
					{
						if (nestedMarkupExtension_0.IsConnected(item2))
						{
							list_0.Remove(item);
							break;
						}
					}
				}
				list_0.Add(new WeakReference(nestedMarkupExtension_0));
			}
		}

		internal static void smethod_2(NestedMarkupExtension nestedMarkupExtension_0)
		{
			if (nestedMarkupExtension_0 == null)
			{
				return;
			}
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target != null)
					{
						if ((NestedMarkupExtension)target == nestedMarkupExtension_0)
						{
							list_0.Remove(item);
						}
					}
					else
					{
						list_0.Remove(item);
					}
				}
			}
		}
	}

	private sealed class Class72
	{
		public object object_0;

		internal TargetInfo method_0(KeyValuePair<Tuple<object, int>, Type> keyValuePair_0)
		{
			return new TargetInfo(object_0, keyValuePair_0.Key.Item1, keyValuePair_0.Value, keyValuePair_0.Key.Item2);
		}
	}

	private sealed class Class73
	{
		public TargetInfo targetInfo_0;

		internal bool method_0(KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>> keyValuePair_0)
		{
			return keyValuePair_0.Key.Target == targetInfo_0.TargetObject;
		}
	}

	[Serializable]
	private sealed class Class74
	{
		public static readonly Class74 Class9 = new Class74();

		public static Func<KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>>, WeakReference> Method9__5_1;

		public static Func<KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>>, WeakReference> Method9__7_1;

		internal WeakReference method_0(KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal WeakReference method_1(KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}
	}

	private sealed class Class75
	{
		public object object_0;

		internal bool method_0(KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>> keyValuePair_0)
		{
			return keyValuePair_0.Key.Target == object_0;
		}
	}

	private sealed class Class76
	{
		public TargetInfo targetInfo_0;

		internal bool method_0(TargetPath targetPath_0)
		{
			return targetPath_0.EndPoint.Equals(targetInfo_0);
		}
	}

	private sealed class Class77
	{
		public object object_0;

		internal bool method_0(TargetPath targetPath_0)
		{
			return targetPath_0.EndPoint.TargetObject == object_0;
		}
	}

	private readonly Dictionary<WeakReference, Dictionary<Tuple<object, int>, Type>> dictionary_0 = new Dictionary<WeakReference, Dictionary<Tuple<object, int>, Type>>();

	protected Action OnFirstTarget;

	private List<TargetInfo> method_0()
	{
		List<TargetInfo> list = new List<TargetInfo>();
		foreach (KeyValuePair<WeakReference, Dictionary<Tuple<object, int>, Type>> item in dictionary_0)
		{
			Class72 @class = new Class72();
			@class.object_0 = item.Key.Target;
			if (@class.object_0 != null)
			{
				list.AddRange(item.Value.Select(@class.method_0));
			}
		}
		return list;
	}

	public List<TargetPath> GetTargetPropertyPaths()
	{
		List<TargetPath> list = new List<TargetPath>();
		foreach (TargetInfo item2 in method_0())
		{
			if (item2.IsEndpoint)
			{
				TargetPath item = new TargetPath(item2);
				list.Add(item);
				continue;
			}
			foreach (TargetPath targetPropertyPath in ((INestedMarkupExtension)item2.TargetObject).GetTargetPropertyPaths())
			{
				targetPropertyPath.AddStep(item2);
				list.Add(targetPropertyPath);
			}
		}
		return list;
	}

	public abstract object FormatOutput(TargetInfo endPoint, TargetInfo info);

	public bool IsConnected(TargetInfo info)
	{
		Class73 @class = new Class73();
		@class.targetInfo_0 = info;
		WeakReference weakReference = dictionary_0.Where(@class.method_0).Select(Class74.Class9.method_0).FirstOrDefault();
		if (weakReference != null)
		{
			Tuple<object, int> key = new Tuple<object, int>(@class.targetInfo_0.TargetProperty, @class.targetInfo_0.TargetPropertyIndex);
			return dictionary_0[weakReference].ContainsKey(key);
		}
		return false;
	}

	protected virtual void OnServiceProviderChanged(IServiceProvider serviceProvider)
	{
	}

	public sealed override object ProvideValue(IServiceProvider serviceProvider)
	{
		Class75 @class = new Class75();
		if (serviceProvider == null)
		{
			return this;
		}
		OnServiceProviderChanged(serviceProvider);
		if (!(serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget provideValueTarget))
		{
			return this;
		}
		TargetInfo endPoint = null;
		@class.object_0 = provideValueTarget.TargetObject;
		object targetProperty = provideValueTarget.TargetProperty;
		int num = -1;
		Type type;
		if (!(serviceProvider is SimpleProvideValueServiceProvider))
		{
			if (!(targetProperty is PropertyInfo))
			{
				if (!(targetProperty is DependencyProperty))
				{
					return this;
				}
				type = ((DependencyProperty)targetProperty).PropertyType;
			}
			else
			{
				PropertyInfo propertyInfo = (PropertyInfo)targetProperty;
				type = propertyInfo.PropertyType;
				if (propertyInfo.GetIndexParameters().Count() > 0)
				{
					throw new InvalidOperationException("Indexers are not supported!");
				}
			}
		}
		else
		{
			type = ((SimpleProvideValueServiceProvider)serviceProvider).TargetPropertyType;
			num = ((SimpleProvideValueServiceProvider)serviceProvider).TargetPropertyIndex;
			endPoint = ((SimpleProvideValueServiceProvider)serviceProvider).EndPoint;
		}
		if (!(@class.object_0 is DependencyObject) && !(targetProperty is PropertyInfo))
		{
			return this;
		}
		if (@class.object_0 is DictionaryEntry)
		{
			return null;
		}
		WeakReference weakReference = dictionary_0.Where(@class.method_0).Select(Class74.Class9.method_1).FirstOrDefault();
		if (weakReference == null)
		{
			if (dictionary_0.Count == 0 && OnFirstTarget != null)
			{
				OnFirstTarget();
			}
			weakReference = new WeakReference(@class.object_0);
			dictionary_0.Add(weakReference, new Dictionary<Tuple<object, int>, Type>());
			ObjectDependencyManager.AddObjectDependency(weakReference, this);
		}
		Tuple<object, int> key = new Tuple<object, int>(targetProperty, num);
		if (!dictionary_0[weakReference].ContainsKey(key))
		{
			dictionary_0[weakReference].Add(key, type);
		}
		Class71.smethod_1(this);
		TargetInfo targetInfo = new TargetInfo(@class.object_0, targetProperty, type, num);
		object obj;
		if (targetInfo.IsEndpoint)
		{
			EndpointReachedEventArgs endpointReachedEventArgs = new EndpointReachedEventArgs(targetInfo);
			Class71.smethod_0(this, endpointReachedEventArgs);
			obj = endpointReachedEventArgs.EndpointValue;
		}
		else
		{
			obj = FormatOutput(endPoint, targetInfo);
		}
		if (!typeof(IList).IsAssignableFrom(type))
		{
			if (obj != null && type.IsAssignableFrom(obj.GetType()))
			{
				return obj;
			}
			if (type.IsValueType)
			{
				return Activator.CreateInstance(type);
			}
			return null;
		}
		return obj;
	}

	protected void UpdateNewValue()
	{
		UpdateNewValue(null);
	}

	public object UpdateNewValue(TargetPath targetPath)
	{
		if (targetPath == null)
		{
			foreach (TargetPath targetPropertyPath in GetTargetPropertyPaths())
			{
				UpdateNewValue(targetPropertyPath);
			}
			return null;
		}
		TargetInfo nextStep = targetPath.GetNextStep();
		object obj = FormatOutput(targetPath.EndPoint, nextStep);
		SetPropertyValue(obj, nextStep, forceNull: false);
		if (nextStep.IsEndpoint)
		{
			return obj;
		}
		return ((INestedMarkupExtension)nextStep.TargetObject).UpdateNewValue(targetPath);
	}

	public static void SetPropertyValue(object value, TargetInfo info, bool forceNull)
	{
		if (value == null && !forceNull)
		{
			return;
		}
		if (info.TargetPropertyType.IsValueType && value == null)
		{
			value = Activator.CreateInstance(info.TargetPropertyType);
		}
		if (info.TargetProperty is DependencyProperty)
		{
			((DependencyObject)info.TargetObject).SetValue((DependencyProperty)info.TargetProperty, value);
			return;
		}
		PropertyInfo propertyInfo = (PropertyInfo)info.TargetProperty;
		if (typeof(IList).IsAssignableFrom(info.TargetPropertyType) && value != null && !info.TargetPropertyType.IsAssignableFrom(value.GetType()))
		{
			if (info.TargetPropertyIndex >= 0)
			{
				IList list = (IList)propertyInfo.GetValue(info.TargetObject, null);
				if (list.Count > info.TargetPropertyIndex)
				{
					list[info.TargetPropertyIndex] = value;
				}
			}
		}
		else
		{
			propertyInfo.SetValue(info.TargetObject, value, null);
		}
	}

	public static object GetPropertyValue(TargetInfo info)
	{
		if (info.TargetProperty is DependencyProperty)
		{
			return ((DependencyObject)info.TargetObject).GetValue((DependencyProperty)info.TargetProperty);
		}
		if (!(info.TargetProperty is PropertyInfo))
		{
			return null;
		}
		PropertyInfo propertyInfo = (PropertyInfo)info.TargetProperty;
		if (info.TargetPropertyIndex >= 0 && typeof(IList).IsAssignableFrom(info.TargetPropertyType))
		{
			IList list = (IList)propertyInfo.GetValue(info.TargetObject, null);
			if (list.Count > info.TargetPropertyIndex)
			{
				return list[info.TargetPropertyIndex];
			}
		}
		return ((PropertyInfo)info.TargetProperty).GetValue(info.TargetObject, null);
	}

	protected T GetValue<T>(object value, PropertyInfo property, int index)
	{
		return GetValue<T>(value, property, index, null);
	}

	protected T GetValue<T>(object value, PropertyInfo property, int index, TargetInfo endPoint)
	{
		if (value is T)
		{
			return (T)value;
		}
		if (!(property == null))
		{
			if (!(value is MarkupExtension))
			{
				return default(T);
			}
			object obj = ((MarkupExtension)value).ProvideValue(new SimpleProvideValueServiceProvider(this, property, property.PropertyType, index, endPoint));
			if (obj != null)
			{
				return (T)obj;
			}
			return default(T);
		}
		return default(T);
	}

	protected abstract bool UpdateOnEndpoint(TargetInfo endpoint);

	protected TargetPath GetPathToEndpoint(TargetInfo endpoint)
	{
		Class76 @class = new Class76();
		@class.targetInfo_0 = endpoint;
		return GetTargetPropertyPaths().Where(@class.method_0).FirstOrDefault();
	}

	protected bool IsEndpointObject(object obj)
	{
		Class77 @class = new Class77();
		@class.object_0 = obj;
		return GetTargetPropertyPaths().Where(@class.method_0).Count() > 0;
	}

	private void method_1(NestedMarkupExtension nestedMarkupExtension_0, EndpointReachedEventArgs endpointReachedEventArgs_0)
	{
		if (!endpointReachedEventArgs_0.Handled)
		{
			TargetPath pathToEndpoint = GetPathToEndpoint(endpointReachedEventArgs_0.Endpoint);
			if (pathToEndpoint != null && (this == nestedMarkupExtension_0 || UpdateOnEndpoint(pathToEndpoint.EndPoint)))
			{
				endpointReachedEventArgs_0.EndpointValue = UpdateNewValue(pathToEndpoint);
				endpointReachedEventArgs_0.Handled = true;
			}
		}
	}

	public void Dispose()
	{
		Class71.smethod_2(this);
		dictionary_0.Clear();
	}
}
