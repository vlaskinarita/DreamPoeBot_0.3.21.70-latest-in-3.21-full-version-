using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class Class70<T, U, V>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly T gparam_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly U gparam_1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly V gparam_2;

	public T Process => gparam_0;

	public U Path => gparam_1;

	public V CommandLine => gparam_2;

	[DebuggerHidden]
	public Class70(T Process, U Path, V CommandLine)
	{
		gparam_0 = Process;
		gparam_1 = Path;
		gparam_2 = CommandLine;
	}

	[DebuggerHidden]
	public new bool Equals(object obj)
	{
		if (obj is Class70<T, U, V> @class && EqualityComparer<T>.Default.Equals(gparam_0, @class.gparam_0) && EqualityComparer<U>.Default.Equals(gparam_1, @class.gparam_1))
		{
			return EqualityComparer<V>.Default.Equals(gparam_2, @class.gparam_2);
		}
		return false;
	}

	[DebuggerHidden]
	public new int GetHashCode()
	{
		return ((2107583924 + EqualityComparer<T>.Default.GetHashCode(gparam_0)) * -1521134295 + EqualityComparer<U>.Default.GetHashCode(gparam_1)) * -1521134295 + EqualityComparer<V>.Default.GetHashCode(gparam_2);
	}

	[DebuggerHidden]
	public new string ToString()
	{
		IFormatProvider iformatProvider_ = null;
		string string_ = "{{ Process = {0}, Path = {1}, CommandLine = {2} }}";
		object[] array = new object[3];
		int num = 0;
		T val = gparam_0;
		object obj = ((default(T) != null || (val = val) != null) ? val.ToString() : null);
		array[num] = obj;
		int num2 = 1;
		U val2 = gparam_1;
		object obj2 = ((default(U) != null || (val2 = val2) != null) ? val2.ToString() : null);
		array[num2] = obj2;
		int num3 = 2;
		V val3 = gparam_2;
		object obj3 = ((default(V) != null || (val3 = val3) != null) ? val3.ToString() : null);
		array[num3] = obj3;
		return smethod_0(iformatProvider_, string_, array);
	}

	static string smethod_0(IFormatProvider iformatProvider_0, string string_0, object[] object_0)
	{
		return string.Format(iformatProvider_0, string_0, object_0);
	}
}
