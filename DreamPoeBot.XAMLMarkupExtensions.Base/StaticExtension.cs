using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Markup;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

[DefaultProperty("Member")]
[ContentProperty("Member")]
[MarkupExtensionReturnType(typeof(Type))]
internal class StaticExtension : NestedMarkupExtension, INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private Type type_0;

	private string string_0 = "";

	private object object_0;

	public Type MemberType
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
				RaisePropertyChanged("MemberType");
			}
		}
	}

	public string Member
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				string_0 = value;
				RaisePropertyChanged("Member");
			}
		}
	}

	public object Result
	{
		get
		{
			return object_0;
		}
		set
		{
			if (object_0 != value)
			{
				object_0 = value;
				RaisePropertyChanged("Result");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
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
		[CompilerGenerated]
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

	public StaticExtension()
	{
	}

	public StaticExtension(string member)
		: this()
	{
		Member = member;
	}

	protected override void OnServiceProviderChanged(IServiceProvider serviceProvider)
	{
		if (string_0 != null && !(string_0.Trim() == ""))
		{
			string text = string_0;
			int num = text.LastIndexOf('.');
			if (num != -1)
			{
				IXamlTypeResolver xamlTypeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
				string text2 = text.Substring(0, num);
				if (xamlTypeResolver == null)
				{
					try
					{
						type_0 = Type.GetType(text2, throwOnError: false);
					}
					catch
					{
						Result = null;
						return;
					}
				}
				else
				{
					type_0 = xamlTypeResolver.Resolve(text2);
				}
				text = text.Substring(num + 1);
			}
			else if (type_0 == null)
			{
				Result = null;
				return;
			}
			if (!(type_0 == null) && !(text.Trim() == ""))
			{
				PropertyInfo property = type_0.GetProperty(text, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (property != null)
				{
					if (!property.CanRead)
					{
						throw new InvalidOperationException("No static get accessor for property " + text + ".");
					}
					Result = property.GetValue(null, null);
					return;
				}
				FieldInfo field = type_0.GetField(string_0, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (field == null)
				{
					throw new InvalidOperationException("No static property or field " + text + " available in " + type_0.FullName);
				}
				Result = field.GetValue(null);
			}
			else
			{
				Result = null;
			}
			return;
		}
		throw new InvalidOperationException("The member property must be set!");
	}

	public override object FormatOutput(TargetInfo endPoint, TargetInfo info)
	{
		return Result;
	}

	protected override bool UpdateOnEndpoint(TargetInfo endpoint)
	{
		return false;
	}
}
