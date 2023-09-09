using System;
using System.Windows.Markup;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class SimpleProvideValueServiceProvider : IServiceProvider, IProvideValueTarget
{
	public object TargetObject { get; private set; }

	public object TargetProperty { get; private set; }

	public Type TargetPropertyType { get; private set; }

	public int TargetPropertyIndex { get; private set; }

	public TargetInfo EndPoint { get; private set; }

	public object GetService(Type service)
	{
		if (service == typeof(IProvideValueTarget))
		{
			return this;
		}
		return null;
	}

	public SimpleProvideValueServiceProvider(object targetObject, object targetProperty, Type targetPropertyType, int targetPropertyIndex)
	{
		TargetObject = targetObject;
		TargetProperty = targetProperty;
		TargetPropertyType = targetPropertyType;
		TargetPropertyIndex = targetPropertyIndex;
	}

	public SimpleProvideValueServiceProvider(object targetObject, object targetProperty, Type targetPropertyType, int targetPropertyIndex, TargetInfo endPoint)
	{
		TargetObject = targetObject;
		TargetProperty = targetProperty;
		TargetPropertyType = targetPropertyType;
		TargetPropertyIndex = targetPropertyIndex;
		EndPoint = endPoint;
	}

	public SimpleProvideValueServiceProvider(TargetInfo info)
	{
		TargetObject = info.TargetObject;
		TargetProperty = info.TargetProperty;
		TargetPropertyType = info.TargetPropertyType;
		TargetPropertyIndex = info.TargetPropertyIndex;
	}

	public SimpleProvideValueServiceProvider(TargetInfo info, TargetInfo endPoint)
	{
		TargetObject = info.TargetObject;
		TargetProperty = info.TargetProperty;
		TargetPropertyType = info.TargetPropertyType;
		TargetPropertyIndex = info.TargetPropertyIndex;
		EndPoint = endPoint;
	}
}
