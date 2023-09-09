using System;
using System.Windows;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal class TargetInfo
{
	public object TargetObject { get; private set; }

	public object TargetProperty { get; private set; }

	public Type TargetPropertyType { get; private set; }

	public int TargetPropertyIndex { get; private set; }

	public bool IsDependencyObject => TargetObject is DependencyObject;

	public bool IsEndpoint => !(TargetObject is INestedMarkupExtension);

	public override bool Equals(object obj)
	{
		if (obj is TargetInfo)
		{
			TargetInfo targetInfo = (TargetInfo)obj;
			if (targetInfo.TargetObject == TargetObject && targetInfo.TargetProperty == TargetProperty)
			{
				return targetInfo.TargetPropertyIndex == TargetPropertyIndex;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Tuple.Create(TargetObject, TargetProperty, TargetPropertyIndex).GetHashCode();
	}

	public TargetInfo(object targetObject, object targetProperty, Type targetPropertyType, int targetPropertyIndex)
	{
		TargetObject = targetObject;
		TargetProperty = targetProperty;
		TargetPropertyType = targetPropertyType;
		TargetPropertyIndex = targetPropertyIndex;
	}
}
