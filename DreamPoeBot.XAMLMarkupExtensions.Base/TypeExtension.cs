using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Markup;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

[ContentProperty("Type")]
[DefaultProperty("Type")]
[MarkupExtensionReturnType(typeof(Type))]
internal class TypeExtension : NestedMarkupExtension, INotifyPropertyChanged
{
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private Type type_0;

	private string string_0 = "";

	public Type Type
	{
		get
		{
			return type_0;
		}
		set
		{
			if (type_0 != value)
			{
				type_0 = value;
				RaisePropertyChanged("Type");
			}
		}
	}

	public string TypeName
	{
		get
		{
			return string_0;
		}
		set
		{
			if (!(string_0 != value))
			{
				return;
			}
			string_0 = value;
			if (type_0 != null)
			{
				try
				{
					Type = Type.GetType(string_0, throwOnError: false);
				}
				catch
				{
					Type = null;
				}
			}
			RaisePropertyChanged("TypeName");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while (propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while (propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected void RaisePropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public TypeExtension()
	{
	}

	public TypeExtension(string type)
		: this()
	{
		TypeName = type;
	}

	protected override void OnServiceProviderChanged(IServiceProvider serviceProvider)
	{
		if (string_0 == null || string_0.Trim() == "")
		{
			return;
		}
		if (!(serviceProvider.GetService(typeof(IXamlTypeResolver)) is IXamlTypeResolver xamlTypeResolver))
		{
			try
			{
				Type = Type.GetType(string_0, throwOnError: false);
				return;
			}
			catch
			{
				Type = null;
				return;
			}
		}
		Type = xamlTypeResolver.Resolve(string_0);
	}

	public override object FormatOutput(TargetInfo endPoint, TargetInfo info)
	{
		return type_0;
	}

	protected override bool UpdateOnEndpoint(TargetInfo endpoint)
	{
		return false;
	}
}
