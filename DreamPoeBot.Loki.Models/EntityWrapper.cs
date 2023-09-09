using DreamPoeBot.Loki.Components;

namespace DreamPoeBot.Loki.Models;

public class EntityWrapper : Entity
{
	private readonly bool _isInList = true;

	public bool IsAlive => GetComponent<Life>().Health > 0;

	public EntityWrapper()
	{
	}

	public EntityWrapper(long address)
		: base(address)
	{
	}

	public override bool Equals(object obj)
	{
		EntityWrapper entityWrapper = obj as EntityWrapper;
		if (!(entityWrapper != null))
		{
			return false;
		}
		return entityWrapper.Id == base.Id;
	}

	public override int GetHashCode()
	{
		return base.Id.GetHashCode();
	}

	public override string ToString()
	{
		return "EntityWrapper: " + base.Metadata;
	}
}
