using System;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class SafeTargetInfo : TargetInfo
{
	private WeakReference weakReference_0;

	public WeakReference TargetObjectReference { get; private set; }

	public SafeTargetInfo(object targetObject, object targetProperty, Type targetPropertyType, int targetPropertyIndex)
		: base(null, targetProperty, targetPropertyType, targetPropertyIndex)
	{
		TargetObjectReference = new WeakReference(targetObject);
	}

	public static SafeTargetInfo FromTargetInfo(TargetInfo targetInfo)
	{
		return new SafeTargetInfo(targetInfo.TargetObject, targetInfo.TargetProperty, targetInfo.TargetPropertyType, targetInfo.TargetPropertyIndex);
	}
}
