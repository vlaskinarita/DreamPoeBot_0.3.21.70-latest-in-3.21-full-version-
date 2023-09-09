using System.Collections;

namespace DreamPoeBot.Framework;

public abstract class YieldBase : IEnumerator, IEnumerable
{
	public object Current { get; protected set; }

	public bool MoveNext()
	{
		if (Current != null)
		{
			return ((IEnumerator)Current).MoveNext();
		}
		return false;
	}

	public void Reset()
	{
	}

	public abstract IEnumerator GetEnumerator();
}
