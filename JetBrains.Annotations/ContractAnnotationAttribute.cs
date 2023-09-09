using System;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ContractAnnotationAttribute : Attribute
{
	public string FDT { get; private set; }

	public bool ForceFullStates { get; private set; }

	public ContractAnnotationAttribute([NotNull] string fdt)
		: this(fdt, forceFullStates: false)
	{
	}

	public ContractAnnotationAttribute([NotNull] string fdt, bool forceFullStates)
	{
		FDT = fdt;
		ForceFullStates = forceFullStates;
	}
}
