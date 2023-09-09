using DreamPoeBot.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class TriggerableBlockage : NetworkObject
{
	public bool IsOpened
	{
		get
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage component = base._entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();
			if (component == null)
			{
				return true;
			}
			return component.IsOpened;
		}
	}

	public Vector2i BoundsMin
	{
		get
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage component = base._entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();
			if (component == null)
			{
				return Vector2i.Zero;
			}
			return component.BoundsMin;
		}
	}

	public Vector2i BoundsMax
	{
		get
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage component = base._entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();
			if (!(component == null))
			{
				return component.BoundsMax;
			}
			return Vector2i.Zero;
		}
	}

	public Vector2i Size
	{
		get
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage component = base._entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();
			if (component == null)
			{
				return Vector2i.Zero;
			}
			return component.Size;
		}
	}

	public byte[] OpenedOverlayNavData
	{
		get
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage component = base._entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();
			if (component == null)
			{
				return new byte[0];
			}
			return component.NavData;
		}
	}

	internal TriggerableBlockage(EntityWrapper entry)
		: base(entry)
	{
	}
}
