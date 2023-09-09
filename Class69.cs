using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class Class69<T, U>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly T gparam_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly U gparam_1;

	public T p => gparam_0;

	public U mo => gparam_1;

	[DebuggerHidden]
	public Class69(T p, U mo)
	{
		gparam_0 = p;
		gparam_1 = mo;
	}

	[DebuggerHidden]
	public new bool Equals(object obj)
	{
		if (obj is Class69<T, U> @class && EqualityComparer<T>.Default.Equals(gparam_0, @class.gparam_0))
		{
			return EqualityComparer<U>.Default.Equals(gparam_1, @class.gparam_1);
		}
		return false;
	}

	[DebuggerHidden]
	public new int GetHashCode()
	{
		return (-1967295504 + EqualityComparer<T>.Default.GetHashCode(gparam_0)) * -1521134295 + EqualityComparer<U>.Default.GetHashCode(gparam_1);
	}

	[DebuggerHidden]
	public new string ToString()
	{
		IFormatProvider iformatProvider_ = null;
		string string_ = "{{ p = {0}, mo = {1} }}";
		object[] array = new object[2];
		int num = 0;
		T val = gparam_0;
		object obj = ((default(T) != null || (val = val) != null) ? val.ToString() : null);
		array[num] = obj;
		int num2 = 1;
		U val2 = gparam_1;
		object obj2 = ((default(U) != null || (val2 = val2) != null) ? val2.ToString() : null);
		array[num2] = obj2;
		return smethod_0(iformatProvider_, string_, array);
	}

	static string smethod_0(IFormatProvider iformatProvider_0, string string_0, object[] object_0)
	{
		return string.Format(iformatProvider_0, string_0, object_0);
	}
}
