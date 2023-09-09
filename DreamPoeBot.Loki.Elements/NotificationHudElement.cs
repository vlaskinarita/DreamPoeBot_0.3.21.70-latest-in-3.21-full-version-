using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class NotificationHudElement : Element
{
	public class NotificationInfo
	{
		private NotificationHudElement hud;

		private Element element;

		private LokiPoe.InGameState.NotificationType? _notificationTypeEnum;

		private string _type;

		public bool IsVisible
		{
			get
			{
				if (hud.AcceptElement(element) != null && hud.AcceptElement(element).IsVisible)
				{
					return true;
				}
				if (!(hud.DeclineElement(element) != null))
				{
					return false;
				}
				return hud.DeclineElement(element).IsVisible;
			}
		}

		public string Type
		{
			get
			{
				if (_type == null)
				{
					if (element == null)
					{
						return "";
					}
					string text = hud.NotificationType(element);
					if (string.IsNullOrEmpty(text))
					{
						return "";
					}
					_type = text;
				}
				if (_type != null)
				{
					return _type;
				}
				return "";
			}
		}

		public string AccountName
		{
			get
			{
				if (!(element == null))
				{
					return hud.AccountName(element);
				}
				return "";
			}
		}

		public string CharName
		{
			get
			{
				if (!(element == null))
				{
					return hud.CharName(element);
				}
				return "";
			}
		}

		public string CharLevel
		{
			get
			{
				if (!(element == null))
				{
					return hud.CharLevel(element);
				}
				return "";
			}
		}

		public string CharArea
		{
			get
			{
				if (!(element == null))
				{
					return hud.CharArea(element);
				}
				return "";
			}
		}

		public Vector2i AcceptPos
		{
			get
			{
				if (!(element == null))
				{
					return hud.AcceptPosition(hud.AcceptElement(element));
				}
				return Vector2i.Zero;
			}
		}

		public Vector2i DeclinePos
		{
			get
			{
				if (!(element == null))
				{
					return hud.DeclinePosition(hud.DeclineElement(element));
				}
				return Vector2i.Zero;
			}
		}

		public string GuildName
		{
			get
			{
				if (!LokiPoe.InGameState.NotificationHud.smethod_3(Type, out var string_))
				{
					return "";
				}
				return string_;
			}
		}

		public LokiPoe.InGameState.NotificationType NotificationTypeEnum
		{
			get
			{
				if (!_notificationTypeEnum.HasValue)
				{
					if (Type.Equals("generic"))
					{
						_notificationTypeEnum = LokiPoe.InGameState.NotificationType.Info;
					}
					else if (Type.Equals(LokiPoe.InGameState.NotificationHud.LocalCache.TradeRequestNotification, StringComparison.OrdinalIgnoreCase))
					{
						_notificationTypeEnum = LokiPoe.InGameState.NotificationType.Trade;
					}
					else if (!Type.Equals(LokiPoe.InGameState.NotificationHud.LocalCache.PartyInviteNotification, StringComparison.OrdinalIgnoreCase))
					{
						if (!Type.Equals(LokiPoe.InGameState.NotificationHud.LocalCache.FriendInviteNotification, StringComparison.OrdinalIgnoreCase))
						{
							if (Type.Equals(LokiPoe.InGameState.NotificationHud.LocalCache.PvPNotificationStatusMessageYou, StringComparison.OrdinalIgnoreCase))
							{
								_notificationTypeEnum = LokiPoe.InGameState.NotificationType.SoloPvP;
							}
							else if (GuildName != "")
							{
								_notificationTypeEnum = LokiPoe.InGameState.NotificationType.Guild;
							}
						}
						else
						{
							_notificationTypeEnum = LokiPoe.InGameState.NotificationType.Friend;
						}
					}
					else
					{
						_notificationTypeEnum = LokiPoe.InGameState.NotificationType.Party;
					}
				}
				if (!_notificationTypeEnum.HasValue)
				{
					return LokiPoe.InGameState.NotificationType.Unknown;
				}
				return _notificationTypeEnum.Value;
			}
		}

		public NotificationInfo(NotificationHudElement _hud, Element ele)
		{
			hud = _hud;
			element = ele;
		}

		internal bool GetGuildName(string string_0, out string string_1)
		{
			string_1 = "";
			int num = string_0.IndexOf('"');
			if (num == -1)
			{
				return false;
			}
			int num2 = string_0.LastIndexOf('"');
			if (num2 == -1)
			{
				return false;
			}
			if (num == num2)
			{
				return false;
			}
			if (!string_0.Substring(0, num).Trim().Equals(LokiPoe.InGameState.NotificationHud.LocalCache.GuildInviteNotification, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			string_1 = string_0.Substring(num + 1, num2 - (num + 1));
			return true;
		}
	}

	public List<NotificationInfo> NotificationList
	{
		get
		{
			List<NotificationInfo> list = new List<NotificationInfo>();
			foreach (Element child in base.Children)
			{
				if (child.ChildCount >= 2L)
				{
					NotificationInfo item = new NotificationInfo(this, child);
					list.Add(item);
				}
			}
			return list;
		}
	}

	private string NotificationType(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return "generic";
		}
		if (element?.Children[0]?.Children[1] == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(element.Children[0].Children[1].Text))
		{
			if (element.Children[0].Children[1].IsVisible)
			{
				return element.Children[0].Children[1].Text;
			}
			return null;
		}
		return null;
	}

	private string AccountName(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return "";
		}
		if (element?.Children[0]?.Children[0]?.Children[1] == null)
		{
			return "";
		}
		if (!string.IsNullOrEmpty(element.Children[0].Children[0].Children[1].Text))
		{
			return element.Children[0].Children[0].Children[1].Text;
		}
		return "";
	}

	private string CharName(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return "";
		}
		if (!(element?.Children[1]?.Children[0]?.Children[0]?.Children[0] == null))
		{
			if (string.IsNullOrEmpty(element.Children[1].Children[0].Children[0].Children[0].Text))
			{
				return "";
			}
			return element.Children[1].Children[0].Children[0].Children[0].Text;
		}
		return "";
	}

	private string CharLevel(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return "";
		}
		if (element?.Children[1]?.Children[0]?.Children[0]?.Children[1] == null)
		{
			return "";
		}
		if (string.IsNullOrEmpty(element.Children[1].Children[0].Children[0].Children[1].Text))
		{
			return "";
		}
		return element.Children[1].Children[0].Children[0].Children[1].Text;
	}

	private string CharArea(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return "";
		}
		if (!(element?.Children[1]?.Children[0]?.Children[0]?.Children[2] == null))
		{
			if (string.IsNullOrEmpty(element.Children[1].Children[0].Children[0].Children[2].Text))
			{
				return "";
			}
			return element.Children[1].Children[0].Children[0].Children[2].Text;
		}
		return "";
	}

	public Element AcceptElement(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return null;
		}
		if (!(element?.Children[2]?.Children[0]?.Children[0] == null))
		{
			return element.Children[2].Children[0].Children[0];
		}
		return null;
	}

	private Vector2i AcceptPosition(Element element)
	{
		return LokiPoe.ElementClickLocation(element);
	}

	public Element DeclineElement(Element element)
	{
		if (element.ChildCount == 2L)
		{
			return element.Children[1];
		}
		if (!(element?.Children[2]?.Children[1]?.Children[0] == null))
		{
			return element.Children[2].Children[1].Children[0];
		}
		return null;
	}

	private Vector2i DeclinePosition(Element element)
	{
		return LokiPoe.ElementClickLocation(element);
	}
}
