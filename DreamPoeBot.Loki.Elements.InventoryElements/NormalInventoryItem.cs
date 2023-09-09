using System;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class NormalInventoryItem : Element
{
	public virtual int InventPosX
	{
		get
		{
			if (base.X == 0f)
			{
				return 0;
			}
			return (int)(base.X / 78f);
		}
	}

	public virtual int InventPosY
	{
		get
		{
			if (base.Y == 0f)
			{
				return 0;
			}
			return (int)(base.Y / 78f);
		}
	}

	public Item InnerItem => ReadObject<Item>(base.Address + 880L);

	public Element ToolTip => ReadObject<Element>(base.Address + 1032L);

	public int StaskSize
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Children[0].Text))
			{
				return Convert.ToInt32(base.Children[0].Text);
			}
			return 0;
		}
	}

	public Vector2i LocationTopLeft => new Vector2i(InventPosX, InventPosY);

	public Vector2i LocationBottomRight
	{
		get
		{
			Base baseComponent = InnerItem.Components.BaseComponent;
			if (baseComponent == null)
			{
				return LocationTopLeft;
			}
			return new Vector2i(LocationTopLeft.X + baseComponent.Size.X, LocationTopLeft.Y + baseComponent.Size.Y);
		}
	}

	public int LocalId => base.M.ReadInt(base.Address + 776L);
}
