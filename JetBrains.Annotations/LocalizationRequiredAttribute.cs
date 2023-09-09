using System;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public sealed class LocalizationRequiredAttribute : Attribute
{
	[UsedImplicitly]
	public bool Required { get; private set; }

	public LocalizationRequiredAttribute()
		: this(required: true)
	{
	}

	public LocalizationRequiredAttribute(bool required)
	{
		Required = required;
	}

	public override bool Equals(object obj)
	{
		if (obj is LocalizationRequiredAttribute localizationRequiredAttribute)
		{
			return localizationRequiredAttribute.Required == Required;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return method_0();
	}

	int method_0()
	{
		return base.GetHashCode();
	}
}
