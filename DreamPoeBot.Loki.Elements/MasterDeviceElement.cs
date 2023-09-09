using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class MasterDeviceElement : Element
{
	internal class CraftingOptionListEntry
	{
		private Memory M;

		private long _elementPtr;

		private long _datCraftingBenchOptionWrapperPtr;

		private CrafingOption _crafingOption;

		private long _mainElement;

		private int _index;

		internal CrafingOption CrafingOption
		{
			get
			{
				if (_crafingOption == null)
				{
					_crafingOption = new CrafingOption(M, M.GetObject<Element>(_elementPtr), _index, M.GetObject<Element>(_mainElement));
				}
				return _crafingOption;
			}
		}

		public CraftingOptionListEntry(Memory m, long element, long craftingOptionPtr, int index, long mainElement)
		{
			M = m;
			_elementPtr = element;
			_datCraftingBenchOptionWrapperPtr = craftingOptionPtr;
			_index = index;
			_mainElement = mainElement;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct CraftingOptionListStruct
	{
		public long intptr_ElementAndCraftingOptionPtr;

		public long intptr_vTablePtr;
	}

	internal class CrafingOption
	{
		private Memory M;

		internal Element _element;

		internal Element _mainElement;

		private int _index;

		private string _optionName;

		public string OptionName
		{
			get
			{
				if (string.IsNullOrEmpty(_optionName) && _element != null)
				{
					_optionName = _element.Children[0].Text;
				}
				return _optionName;
			}
		}

		public int ChaosCost
		{
			get
			{
				string text = _element.Children[2].Text;
				if (text == null)
				{
					return 0;
				}
				string text2 = "cost:";
				string text3 = "x     ";
				string value = text.TrimStart(text2.ToCharArray()).TrimEnd(text3.ToCharArray());
				return Convert.ToInt32(value);
			}
		}

		public bool IsEnabled => _element.ChildCount == 3L;

		public bool IsSelected => M.ReadByte(_mainElement.Address + 872L) == _index;

		internal CrafingOption(Memory m, Element element, int index, Element mainElement)
		{
			M = m;
			_element = element;
			_index = index;
			_mainElement = mainElement;
		}
	}

	private Element CraftingElement => base.Children[2].Children[0].Children[0];

	private Element CraftingElementScrollBar => CraftingElement.Children[2];

	internal Element ScrollUp => CraftingElementScrollBar.Children[0];

	internal Element ScrollDown => CraftingElementScrollBar.Children[1];

	private Element CraftingElementOptions => CraftingElement.Children[1];

	internal List<CrafingOption> CraftingOptionsList
	{
		get
		{
			List<CrafingOption> list = new List<CrafingOption>();
			int num = 0;
			foreach (Element child in CraftingElementOptions.Children)
			{
				CrafingOption item = new CrafingOption(base.M, child, num, CraftingElement);
				list.Add(item);
				num++;
			}
			return list;
		}
	}

	internal float CraftingElementYOffset => base.M.ReadFloat(CraftingElement.Address + 172L);

	private int SelectedOptionIndex => base.M.ReadByte(CraftingElement.Address + 872L);

	internal Element AdditionalModifiers => base.Children[1];

	internal Element ActivateElement => base.Children[5].Children[1].Children[0];

	public Element AtlasElement => base.Children[5].Children[5].Children[0];

	public Element KiracMissionElement => base.Children[5].Children[5].Children[1].Children[0];

	public bool IsFiveSlotDevice
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return false;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return false;
			}
			if (!base.Children[5].Children[7].IsVisible)
			{
				return base.Children[5].Children[8].IsVisible;
			}
			return false;
		}
	}

	public Inventory Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return null;
			}
			return GetObject<Inventory>(base.Children[5].Children[7].Address);
		}
	}

	public Element Slot1Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return null;
			}
			return base.Children[5].Children[8];
		}
	}

	public Element Slot2Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return base.Children[5].Children[9];
			}
			return null;
		}
	}

	public Element Slot3Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return null;
			}
			return base.Children[5].Children[10];
		}
	}

	public Element Slot4Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return base.Children[5].Children[11];
			}
			return null;
		}
	}

	public Element Slot5Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MasterDevicePannel == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible)
			{
				return base.Children[5].Children[12];
			}
			return null;
		}
	}

	public MavenButtonElement TheSearingExarchButtonElement => GetObject<MavenButtonElement>(base.Children[5].Children[2].Children[0].Address);

	public MavenButtonElement TheMavenButtonElement => GetObject<MavenButtonElement>(base.Children[5].Children[2].Children[1].Address);

	public MavenButtonElement TheEaterOfWorldsButtonElement => GetObject<MavenButtonElement>(base.Children[5].Children[2].Children[2].Address);

	public bool IsTheMavenInvitationVisible => TheMavenButtonElement.IsButtonVisible;

	public bool IsTheMavenInvitationClicked => TheMavenButtonElement.IsClicked;

	public bool IsTheMavenInvitationEnabled => TheMavenButtonElement.IsEnabled;

	public string IsTheMavenInvitationTooltipText => TheMavenButtonElement.TooltipText;

	public bool IsTheSearingExarchInvitationVisible => TheSearingExarchButtonElement.IsButtonVisible;

	public bool IsTheSearingExarchInvitationClicked => TheSearingExarchButtonElement.IsClicked;

	public bool IsTheSearingExarchInvitationEnabled => TheSearingExarchButtonElement.IsEnabled;

	public string IsTheSearingExarchInvitationTooltipText => TheSearingExarchButtonElement.TooltipText;

	public bool IsTheEaterOfWorldsInvitationVisible => TheEaterOfWorldsButtonElement.IsButtonVisible;

	public bool IsTheEaterOfWorldsInvitationClicked => TheEaterOfWorldsButtonElement.IsClicked;

	public bool IsTheEaterOfWorldsInvitationEnabled => TheEaterOfWorldsButtonElement.IsEnabled;

	public string IsTheEaterOfWorldsInvitationTooltipText => TheEaterOfWorldsButtonElement.TooltipText;

	private Element MasterMissionElement => base.Children[5]?.Children[3]?.Children[0];

	public Element EinharMissionElement => MasterMissionElement?.Children[0];

	public Element AlvaMissionElement => MasterMissionElement?.Children[1];

	public Element NikoMissionElement => MasterMissionElement?.Children[2];

	public Element JunMissionElement => MasterMissionElement?.Children[3];

	public Element ZanaMissionElement => null;

	public int SelectedMasterMission
	{
		get
		{
			if (MasterMissionElement == null)
			{
				return 8;
			}
			return base.M.ReadInt(MasterMissionElement.Address + 664L);
		}
	}
}
