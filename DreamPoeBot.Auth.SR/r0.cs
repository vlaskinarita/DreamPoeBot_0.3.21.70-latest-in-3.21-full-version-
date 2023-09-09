using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace DreamPoeBot.Auth.SR;

[Serializable]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DebuggerStepThrough]
[DataContract(Name = "r0", Namespace = "http://schemas.datacontract.org/2004/07/")]
[KnownType(typeof(d0))]
internal class r0 : INotifyPropertyChanged, IExtensibleDataObject
{
	[NonSerialized]
	private ExtensionDataObject extensionDataObject_0;

	[OptionalField]
	private string BodyField;

	[OptionalField]
	private bool SuccessField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataObject_0;
		}
		set
		{
			extensionDataObject_0 = value;
		}
	}

	[DataMember]
	public string Body
	{
		get
		{
			return BodyField;
		}
		set
		{
			if (BodyField != value)
			{
				BodyField = value;
				RaisePropertyChanged("Body");
			}
		}
	}

	[DataMember]
	public bool Success
	{
		get
		{
			return SuccessField;
		}
		set
		{
			if (!SuccessField.Equals(value))
			{
				SuccessField = value;
				RaisePropertyChanged("Success");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
