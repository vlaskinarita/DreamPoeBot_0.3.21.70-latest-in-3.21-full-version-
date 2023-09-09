using System.Collections.Generic;

namespace DreamPoeBot.Loki.Common;

public class IndexedList<T> : List<T>
{
	private int int_0;

	public bool IsCyclic { get; set; }

	public int Index
	{
		get
		{
			method_0();
			return int_0;
		}
		set
		{
			int_0 = value;
			method_0();
		}
	}

	public bool IsAtEnd
	{
		get
		{
			if (!IsCyclic)
			{
				return Index == base.Count - 1;
			}
			return false;
		}
	}

	public T CurrentOrDefault
	{
		get
		{
			if (base.Count > 0)
			{
				return base[Index];
			}
			return default(T);
		}
	}

	public T Current => base[Index];

	public IndexedList()
	{
	}

	public IndexedList(bool isCyclic = false)
	{
		IsCyclic = isCyclic;
	}

	public IndexedList(int capacity, bool isCyclic = false)
		: base(capacity)
	{
		IsCyclic = isCyclic;
	}

	public IndexedList(IEnumerable<T> collection, bool isCyclic = false)
		: base(collection)
	{
		IsCyclic = isCyclic;
	}

	public bool Next()
	{
		int index = Index;
		Index++;
		if (!IsCyclic)
		{
			return Index == index + 1;
		}
		return true;
	}

	public bool Previous()
	{
		int index = Index;
		Index--;
		if (IsCyclic)
		{
			return true;
		}
		return Index == index - 1;
	}

	private void method_0()
	{
		if (int_0 == 0 || (int_0 >= 0 && int_0 < base.Count))
		{
			return;
		}
		if (base.Count != 0)
		{
			if (!IsCyclic)
			{
				int_0 = smethod_0(0, base.Count - 1, int_0);
				return;
			}
			if (int_0 >= 0)
			{
				int_0 %= base.Count;
				return;
			}
			int num = -int_0 - 1;
			num %= base.Count;
			int_0 = base.Count - 1 - num;
		}
		else
		{
			int_0 = 0;
		}
	}

	private static int smethod_0(int int_1, int int_2, int int_3)
	{
		if (int_3 < int_1)
		{
			return int_1;
		}
		if (int_3 > int_2)
		{
			return int_2;
		}
		return int_3;
	}
}
