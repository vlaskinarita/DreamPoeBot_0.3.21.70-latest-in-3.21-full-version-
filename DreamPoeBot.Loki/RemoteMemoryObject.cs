using System;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki;

public abstract class RemoteMemoryObject : IEquatable<RemoteMemoryObject>
{
	public long Address { get; set; }

	public TheGame Game => GameController.Instance.Game;

	public Memory M => GameController.Instance.Memory;

	protected Offsets Offsets => M.offsets;

	public virtual bool IsValid => Address > 0L;

	public RemoteMemoryObject()
	{
	}

	public RemoteMemoryObject(long address)
	{
		Address = address;
	}

	public bool Equals(RemoteMemoryObject other)
	{
		if (other != null)
		{
			if (!(this == other))
			{
				return Address == other.Address;
			}
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		RemoteMemoryObject remoteMemoryObject = obj as RemoteMemoryObject;
		if (!(remoteMemoryObject != null))
		{
			return false;
		}
		return remoteMemoryObject.Address == Address;
	}

	public T ReadObjectAt<T>(int offset) where T : RemoteMemoryObject, new()
	{
		return ReadObject<T>(Address + offset);
	}

	public Skill ReadObjectSkill(long addressPointer, Actor actor)
	{
		return new Skill(M.ReadLong(addressPointer), actor);
	}

	public T ReadObject<T>(long addressPointer) where T : RemoteMemoryObject, new()
	{
		return new T
		{
			Address = M.ReadLong(addressPointer)
		};
	}

	public T CreateObject<T>(long addressPointer) where T : RemoteMemoryObject, new()
	{
		return new T
		{
			Address = addressPointer
		};
	}

	public T GetObjectAt<T>(int offset) where T : RemoteMemoryObject, new()
	{
		return GetObject<T>(Address + offset);
	}

	public T GetObjectAt<T>(long offset) where T : RemoteMemoryObject, new()
	{
		return GetObject<T>(Address + offset);
	}

	public T GetObject<T>(long address) where T : RemoteMemoryObject, new()
	{
		return new T
		{
			Address = address
		};
	}

	public T AsObject<T>() where T : RemoteMemoryObject, new()
	{
		return new T
		{
			Address = Address
		};
	}

	public static bool operator ==(RemoteMemoryObject lhs, RemoteMemoryObject rhs)
	{
		if ((object)lhs != null && lhs.Address != 0L)
		{
			if ((object)rhs != null && rhs.Address != 0L)
			{
				return lhs.Address == rhs.Address;
			}
			return false;
		}
		if ((object)rhs != null && rhs.Address != 0L)
		{
			return false;
		}
		return true;
	}

	public static bool operator !=(RemoteMemoryObject lhs, RemoteMemoryObject rhs)
	{
		return !(lhs == rhs);
	}

	public bool UpdatePointer(long ptr)
	{
		if (Address == ptr)
		{
			return false;
		}
		Address = ptr;
		OnPointerChanged();
		return true;
	}

	protected virtual void OnPointerChanged()
	{
	}
}
