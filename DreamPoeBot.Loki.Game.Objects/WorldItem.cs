using System;
using System.Linq;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class WorldItem : NetworkObject
{
	private sealed class Class304
	{
		public uint uint_0;

		internal bool method_0(Player player_0)
		{
			return player_0.Components.PlayerComponent.AllocatedLootId == uint_0;
		}
	}

	public class WorldItemLabelClass
	{
		private ItemsOnGroundLabelElement _itemsOnGroundLabelElement;

		private WorldItem _worldItem;

		public Vector2 Coordinate => new Vector2(_itemsOnGroundLabelElement.Label.X * _itemsOnGroundLabelElement.Label.Scale, _itemsOnGroundLabelElement.Label.Y * _itemsOnGroundLabelElement.Label.Scale);

		public Vector2 Size => new Vector2(_itemsOnGroundLabelElement.Label.Width * _itemsOnGroundLabelElement.Label.Scale, _itemsOnGroundLabelElement.Label.Height * _itemsOnGroundLabelElement.Label.Scale);

		public WorldItem OwnerWorldItem => _worldItem;

		public bool IsLabelVisible => _itemsOnGroundLabelElement.Label.IsVisible;

		public WorldItemLabelClass(WorldItem worldItem, ItemsOnGroundLabelElement itemsOnGroundLabelElement)
		{
			_itemsOnGroundLabelElement = itemsOnGroundLabelElement;
			_worldItem = worldItem;
		}

		public void HideLabel()
		{
			if (_itemsOnGroundLabelElement.Label.IsVisibleLocal)
			{
				_itemsOnGroundLabelElement.Label.ToggleVisibility();
			}
		}

		public void ShowLabel()
		{
			if (!_itemsOnGroundLabelElement.Label.IsVisibleLocal)
			{
				_itemsOnGroundLabelElement.Label.ToggleVisibility();
			}
		}
	}

	public bool HasVisibleHighlightLabel => LokiPoe.Input.HasVisibleHighlightLabel(this);

	public DateTime DroppedTime
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return DateTime.MinValue;
			}
			return worldItemComponent.DroppedTime;
		}
	}

	public TimeSpan AllocatedToOtherTime
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return TimeSpan.MinValue;
			}
			return TimeSpan.FromMilliseconds(worldItemComponent.AllocatedToOtherTime);
		}
	}

	public DateTime PublicTime
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return DateTime.MinValue;
			}
			return worldItemComponent.PublicTime;
		}
	}

	public bool HasAllocation
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return false;
			}
			return worldItemComponent.AllocatedToPlayer != 0;
		}
	}

	public Player AllocatedToPlayer
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return null;
			}
			Class304 @class = new Class304();
			@class.uint_0 = worldItemComponent.AllocatedToPlayer;
			if (@class.uint_0 != 0)
			{
				return LokiPoe.ObjectManager.Objects.OfType<Player>().FirstOrDefault(@class.method_0);
			}
			return new Player(LokiPoe.ObjectManager.Me._entity);
		}
	}

	public bool IsAllocatedToOther
	{
		get
		{
			if (!HasAllocation)
			{
				return false;
			}
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (worldItemComponent == null)
			{
				return false;
			}
			return worldItemComponent.AllocatedToSomeoneElse;
		}
	}

	public Item Item
	{
		get
		{
			DreamPoeBot.Loki.Components.WorldItem worldItemComponent = base.Components.WorldItemComponent;
			if (!(worldItemComponent == null))
			{
				return new Item(worldItemComponent.ItemEntity.Address, worldItemComponent.ItemEntity.Id, base.Entity.Id);
			}
			return null;
		}
	}

	public WorldItemLabelClass WorldItemLabel
	{
		get
		{
			long baseAddress = base._entity.Address;
			if (baseAddress == 0L)
			{
				return null;
			}
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => (object)x != null && x.ItemOnGround?.Address == baseAddress);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			return new WorldItemLabelClass(this, itemsOnGroundLabelElement);
		}
	}

	public WorldItem(EntityWrapper entity)
		: base(entity)
	{
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[WorldItem:]");
		stringBuilder.AppendLine(string.Format($"\t[HasVisibleHighlightLabel] {HasVisibleHighlightLabel}"));
		stringBuilder.AppendLine(string.Format("\t[DroppedTime] " + DroppedTime.ToString()));
		stringBuilder.AppendLine(string.Format("\t[PublicTime] " + PublicTime.ToString()));
		stringBuilder.AppendLine(string.Format($"\t[HasAllocation] {HasAllocation}"));
		stringBuilder.AppendLine(string.Format("\t[AllocatedToOtherTime] " + AllocatedToOtherTime.ToString()));
		stringBuilder.AppendLine(string.Format($"\t[IsAllocatedToOther] {IsAllocatedToOther}"));
		if (AllocatedToPlayer != null)
		{
			stringBuilder.AppendLine(string.Format("\t[AllocatedToPlayer] " + AllocatedToPlayer.Name));
		}
		WorldItemLabelClass worldItemLabel = WorldItemLabel;
		if (worldItemLabel == null)
		{
			stringBuilder.AppendLine($"\t[WorldItemLabel] null");
		}
		else
		{
			stringBuilder.AppendLine($"\t[WorldItemLabel:] (Retrived screen relative coord and size)");
			stringBuilder.AppendLine(string.Format($"\t\t[Coordinate] {worldItemLabel.Coordinate.X},{worldItemLabel.Coordinate.Y}"));
			stringBuilder.AppendLine(string.Format($"\t\t[Size] {worldItemLabel.Size.X},{worldItemLabel.Size.Y}"));
			stringBuilder.AppendLine(string.Format($"\t\t[IsLabelVisible] {worldItemLabel.IsLabelVisible}"));
		}
		if (Item != null)
		{
			stringBuilder.AppendLine($"\t[Item:]");
			stringBuilder.AppendLine(Item.Dump());
		}
		else
		{
			stringBuilder.AppendLine($"\t[Item:] null");
		}
		return stringBuilder.ToString();
	}

	public static bool GetClickableHighlightLabelDimensions(NetworkObject obj, out Vector2 coords, out Vector2 size, bool onlyVisible = true)
	{
		coords = Vector2.Zero;
		size = Vector2.Zero;
		long baseAddress = obj._entity.Address;
		if (baseAddress != 0L)
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => (object)x != null && x.ItemOnGround?.Address == baseAddress);
			if (itemsOnGroundLabelElement == null)
			{
				return false;
			}
			if (onlyVisible && !itemsOnGroundLabelElement.Label.IsVisible)
			{
				return false;
			}
			coords = new Vector2(itemsOnGroundLabelElement.Label.X * itemsOnGroundLabelElement.Label.Scale, itemsOnGroundLabelElement.Label.Y * itemsOnGroundLabelElement.Label.Scale);
			size = new Vector2(itemsOnGroundLabelElement.Label.Width * itemsOnGroundLabelElement.Label.Scale, itemsOnGroundLabelElement.Label.Height * itemsOnGroundLabelElement.Label.Scale);
			return true;
		}
		return false;
	}
}
