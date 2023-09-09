using System;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Game;

public class MemoryObject : IEquatable<MemoryObject>, IMemoryObject
{
	public long BaseAddress { get; private set; }

	public virtual bool IsValid => (ulong)BaseAddress > 0uL;

	public bool Equals(MemoryObject other)
	{
		if (other != null)
		{
			if (!object.Equals(this, other))
			{
				return BaseAddress.Equals(other.BaseAddress);
			}
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((MemoryObject)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return BaseAddress.GetHashCode();
	}

	public static bool operator !=(MemoryObject left, MemoryObject right)
	{
		return !object.Equals(left, right);
	}

	protected MemoryObject(long ptr)
	{
		BaseAddress = ptr;
	}

	public bool UpdatePointer(long ptr)
	{
		if (BaseAddress == ptr)
		{
			return false;
		}
		BaseAddress = ptr;
		OnPointerChanged();
		return true;
	}

	protected virtual void OnPointerChanged()
	{
	}
}
