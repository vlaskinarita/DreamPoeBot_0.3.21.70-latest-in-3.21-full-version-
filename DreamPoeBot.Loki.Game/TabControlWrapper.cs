using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Loki.Game.Std;
using log4net;

namespace DreamPoeBot.Loki.Game;

public class TabControlWrapper : RemoteMemoryObject
{
	internal class ClassTabData
	{
		public long IntPtr_0 { get; }

		public long IntPtr_1 { get; }

		public string Name { get; }

		internal ClassTabData(Struct110 entry)
		{
			IntPtr_0 = entry.intptr_0;
			IntPtr_1 = entry.intptr_1;
			Name = Containers.StdStringWCustom(entry.nativeStringW_0);
		}

		public new virtual bool Equals(object obj)
		{
			if (obj is ClassTabData classTabData && IntPtr_1 == classTabData.IntPtr_1 && IntPtr_0 == classTabData.IntPtr_0)
			{
				return Name.Equals(classTabData.Name);
			}
			return false;
		}

		public bool method_0(ClassTabData class258_0)
		{
			if (class258_0 != null && IntPtr_1 == class258_0.IntPtr_1 && IntPtr_0 == class258_0.IntPtr_0)
			{
				return Name.Equals(class258_0.Name);
			}
			return false;
		}

		public new virtual int GetHashCode()
		{
			return IntPtr_0.GetHashCode() ^ IntPtr_1.GetHashCode() ^ Name.GetHashCode();
		}
	}

	private sealed class Class259
	{
		public static readonly Class259 Class9 = new Class259();

		public static Func<Struct110, ClassTabData> Method9__45_0;

		public static Func<ClassTabData, string> Method9__47_0;

		internal ClassTabData method_0(Struct110 struct110_0)
		{
			return new ClassTabData(struct110_0);
		}

		internal string method_1(ClassTabData class258_0)
		{
			return class258_0.Name;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct110
	{
		public readonly long intptr_0;

		public readonly long intptr_1;

		public readonly NativeStringWCustom nativeStringW_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct111
	{
		private readonly long vtable;

		private readonly long intptr_0;

		private readonly long intptr_1;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly long intptr_4;

		private readonly long intptr_5;

		private readonly long intptr_6;

		private readonly long intptr_7;

		private readonly long intptr_8;

		private readonly long intptr_9;

		private readonly long intptr_10;

		public readonly NativeVector List_0;

		public readonly int CurrentTabIndex;

		public readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		public readonly int int_1;

		public readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private TabControlType _tabControlType { get; set; }

	public int CurrentTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Struct111_0.CurrentTabIndex;
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType != TabControlType.ExpeditionDealer)
				{
					if (_tabControlType != TabControlType.BloodCrucible)
					{
						return Struct111_0.CurrentTabIndex;
					}
					return -1;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash;
		}
	}

	public string CurrentTabName
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Class258_0?.Name;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType != TabControlType.Social)
				{
					if (_tabControlType == TabControlType.ExpeditionDealer)
					{
						return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
					}
					return Class258_0?.Name;
				}
				return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName;
		}
	}

	public bool IsOnFirstTab
	{
		get
		{
			if (CurrentTabIndex == 0)
			{
				return true;
			}
			if (_tabControlType != 0)
			{
				return false;
			}
			if (LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
			{
				IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
				int i;
				for (i = CurrentTabIndex - 1; i >= 0; i--)
				{
					StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
					if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	public bool IsOnLastTab
	{
		get
		{
			if (CurrentTabIndex == LastTabIndex)
			{
				return true;
			}
			if (_tabControlType == TabControlType.Stash)
			{
				if (LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
				{
					IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
					int i;
					for (i = CurrentTabIndex + 1; i <= LastTabIndex; i++)
					{
						StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
						if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public int LastTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_0.Count - 1;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType != TabControlType.Social)
				{
					if (_tabControlType == TabControlType.ExpeditionDealer)
					{
						return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
					}
					return List_0.Count - 1;
				}
				return (int)GameController.Instance.Game.IngameState.IngameUi.SocialPannel.TotalStashes - 1;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
			}
			return (int)GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.TotalStashes - 1;
		}
	}

	public List<string> TabNames
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
				}
				return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.AllStashNames;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType == TabControlType.ExpeditionDealer)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
				}
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.AllStashNames;
		}
	}

	public bool IsTabsMenuVisible
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerElement.IsVisible;
			}
			return false;
		}
	}

	internal byte Byte_0 => Struct111_0.byte_0;

	internal int Int32_0 => Struct111_0.int_1;

	internal byte Byte_1 => Struct111_0.byte_4;

	internal ClassTabData Class258_0 => GetTabDataByIndex(CurrentTabIndex);

	internal List<Struct110> List_0 => Containers.StdStructTab110Vector<Struct110>(Struct111_0.List_0);

	private List<ClassTabData> List_1 => List_0.Select(Class259.Class9.method_0).ToList();

	public Struct111 Struct111_0 => base.M.FastIntPtrToStruct<Struct111>(base.Address + 2408L);

	public TabControlWrapper(TabControlType type)
	{
		_tabControlType = type;
	}

	internal void SpecialSetMousePosition(Vector2i pos)
	{
		MouseManager.SetMousePosition(pos, useRandomPos: false);
	}

	internal TabControlWrapper(long control, TabControlType type)
		: base(control)
	{
		_tabControlType = type;
	}

	public bool IsTabVisible(string name)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabName == name;
		}
		if (_tabControlType == TabControlType.Parchase)
		{
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName == name;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (_tabControlType != TabControlType.ExpeditionDealer)
			{
				return CurrentTabName == name;
			}
			return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
		}
		return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName == name;
	}

	public bool IsTabVisible(int index)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabIndex == index;
		}
		if (_tabControlType == TabControlType.Parchase)
		{
			if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash == index;
			}
			return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash == index;
		}
		if (_tabControlType == TabControlType.ExpeditionDealer)
		{
			return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
		}
		return CurrentTabIndex == index;
	}

	public SwitchToTabResult NextTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (Hooking.IsInstalled)
			{
				HookManager.ResetKeyState();
				int currentTabIndex = CurrentTabIndex;
				if (currentTabIndex == LastTabIndex)
				{
					return SwitchToTabResult.NoMoreTabs;
				}
				LokiPoe.Input.SimulateKeyEvent(Keys.Right);
				Thread.Sleep(25);
				if (CurrentTabIndex != currentTabIndex)
				{
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult PreviousTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (Hooking.IsInstalled)
		{
			HookManager.ResetKeyState();
			int currentTabIndex = CurrentTabIndex;
			if (currentTabIndex != 0)
			{
				LokiPoe.Input.SimulateKeyEvent(Keys.Left);
				Thread.Sleep(25);
				if (CurrentTabIndex == currentTabIndex)
				{
					return SwitchToTabResult.Failed;
				}
				return SwitchToTabResult.None;
			}
			return SwitchToTabResult.NoMoreTabs;
		}
		return SwitchToTabResult.ProcessHookManagerNotEnabled;
	}

	public SwitchToTabResult SwitchToTabKeyboard(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (index >= 0 && index <= LastTabIndex)
			{
				if (CurrentTabIndex < index)
				{
					while (true)
					{
						if (CurrentTabIndex != index)
						{
							SwitchToTabResult switchToTabResult = NextTabKeyboard();
							Thread.Sleep(15);
							if (CurrentTabIndex == index)
							{
								break;
							}
							if (switchToTabResult != 0)
							{
								return switchToTabResult;
							}
							continue;
						}
						return SwitchToTabResult.None;
					}
					return SwitchToTabResult.None;
				}
				SwitchToTabResult switchToTabResult2;
				do
				{
					if (CurrentTabIndex != index)
					{
						switchToTabResult2 = PreviousTabKeyboard();
						Thread.Sleep(15);
						if (CurrentTabIndex == index)
						{
							return SwitchToTabResult.None;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				while (switchToTabResult2 == SwitchToTabResult.None);
				return switchToTabResult2;
			}
			return SwitchToTabResult.Failed;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult SwitchToTabKeyboard(string name)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (!TabNames.Contains(name))
			{
				return SwitchToTabResult.Failed;
			}
			ClassTabData tabDataByName = GetTabDataByName(name);
			if (tabDataByName != null)
			{
				int indexByTabData = GetIndexByTabData(tabDataByName);
				if (indexByTabData == -1)
				{
					return SwitchToTabResult.TabNotFound;
				}
				if (CurrentTabIndex >= indexByTabData)
				{
					SwitchToTabResult switchToTabResult;
					do
					{
						if (CurrentTabIndex != indexByTabData)
						{
							switchToTabResult = PreviousTabKeyboard();
							Thread.Sleep(15);
							if (CurrentTabIndex == indexByTabData)
							{
								return SwitchToTabResult.None;
							}
							continue;
						}
						return SwitchToTabResult.None;
					}
					while (switchToTabResult == SwitchToTabResult.None);
					return switchToTabResult;
				}
				SwitchToTabResult switchToTabResult2;
				do
				{
					if (CurrentTabIndex != indexByTabData)
					{
						switchToTabResult2 = NextTabKeyboard();
						Thread.Sleep(15);
						if (CurrentTabIndex == indexByTabData)
						{
							return SwitchToTabResult.None;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				while (switchToTabResult2 == SwitchToTabResult.None);
				return switchToTabResult2;
			}
			return SwitchToTabResult.TabNotFound;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult SwitchToTabMouse(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (Hooking.IsInstalled)
			{
				HookManager.ResetKeyState();
				ClassTabData tabDataByIndex = GetTabDataByIndex(index);
				if (tabDataByIndex != null)
				{
					return SwitchToTabMouse(tabDataByIndex.Name);
				}
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult SwitchToTabMouse(string name)
	{
		if (_tabControlType != TabControlType.World)
		{
			if (_tabControlType != TabControlType.Social)
			{
				if (Hooking.IsInstalled)
				{
					HookManager.ResetKeyState();
					if (!TabNames.Contains(name))
					{
						return SwitchToTabResult.TabNotFound;
					}
					int num = 0;
					while (GameController.Instance.Game.IngameState.IngameUi.StashPannel.IsTabListButtonVisible && !IsTabsMenuVisible)
					{
						Vector2i pos = GameController.Instance.Game.IngameState.IngameUi.StashPannel.TabListButton.CenterClickLocation();
						SpecialSetMousePosition(pos);
						Thread.Sleep(50);
						MouseManager.ClickLMB(pos.X, pos.Y);
						Thread.Sleep(50);
						if (IsTabsMenuVisible || num >= 3)
						{
							break;
						}
						num++;
					}
					Vector2i pos2;
					if (IsTabsMenuVisible)
					{
						Element element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightButtonContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
						if (element == null)
						{
							return SwitchToTabResult.UnableToFindTabInScrollView;
						}
						int num2 = 0;
						while (true)
						{
							num2++;
							float num3 = element.Parent.Parent.Y + element.Parent.Parent.Height;
							if (num2 >= 50)
							{
								break;
							}
							if (num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset <= 0f)
							{
								MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollUp));
								Thread.Sleep(5);
								MouseManager.ClickLMB();
								Thread.Sleep(5);
								continue;
							}
							if (!(num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset > GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerHeight))
							{
								break;
							}
							MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollDown));
							Thread.Sleep(5);
							MouseManager.ClickLMB();
							Thread.Sleep(5);
						}
						pos2 = element.CenterClickLocation() + new Vector2i(0, (int)(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset * element.Scale));
					}
					else
					{
						Element element2 = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
						if (element2 == null)
						{
							return SwitchToTabResult.TabNotFound;
						}
						pos2 = element2.CenterClickLocation();
					}
					SpecialSetMousePosition(pos2);
					Thread.Sleep(10);
					MouseManager.ClickLMB(pos2.X, pos2.Y);
					Thread.Sleep(50);
					if (!(CurrentTabName == name))
					{
						return SwitchToTabResult.Failed;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.ProcessHookManagerNotEnabled;
			}
			return SwitchToTabResult.NotSupported;
		}
		return SwitchToTabResult.NotSupported;
	}

	public OpenPremiumStashSettingResult OpenPremiumStashSetting(string name)
	{
		string name2;
		uint num = default(uint);
		int num3 = default(int);
		Element element = default(Element);
		Vector2i vector2i = default(Vector2i);
		Vector2i pos = default(Vector2i);
		while (true)
		{
			name2 = name;
			while (true)
			{
				if (_tabControlType != TabControlType.World)
				{
					while (true)
					{
						if (_tabControlType != TabControlType.Social)
						{
							while (true)
							{
								if (Hooking.IsInstalled)
								{
									while (true)
									{
										HookManager.ResetKeyState();
										if (TabNames.Contains(name2))
										{
											while (true)
											{
												SwitchToTabResult switchToTabResult = SwitchToTabKeyboard(name2);
												while (true)
												{
													IL_011e:
													if (switchToTabResult != 0)
													{
														while (true)
														{
															switch (switchToTabResult)
															{
															case SwitchToTabResult.None:
																goto end_IL_00eb;
															case SwitchToTabResult.ProcessHookManagerNotEnabled:
																goto IL_0266;
															case SwitchToTabResult.Failed:
																goto IL_0268;
															case SwitchToTabResult.UiNotOpen:
																goto IL_026a;
															case SwitchToTabResult.TabListNotOpen:
																goto IL_026c;
															case SwitchToTabResult.TabNotFound:
																goto IL_026e;
															case SwitchToTabResult.FailedToOpenTabList:
																goto IL_0270;
															case SwitchToTabResult.UnableToFindTabInScrollView:
																goto IL_0272;
															case SwitchToTabResult.NoMoreTabs:
																goto IL_0275;
															case SwitchToTabResult.NotSupported:
																goto IL_0278;
															}
															int num2 = ((int)num * -495840246) ^ -753771377;
															while (true)
															{
																switch ((num = (uint)num2 ^ 0x9E0B2F10u) % 43u)
																{
																case 19u:
																	num2 = (int)(num * 1853014738) ^ -1495172914;
																	continue;
																case 13u:
																	break;
																case 31u:
																	goto IL_011e;
																case 30u:
																	goto end_IL_011e;
																case 10u:
																	goto end_IL_0123;
																case 40u:
																	goto end_IL_0132;
																case 6u:
																	goto end_IL_014c;
																case 38u:
																	goto end_IL_0155;
																case 2u:
																case 3u:
																	goto end_IL_0160;
																case 9u:
																	goto IL_0174;
																case 14u:
																	goto IL_0176;
																case 23u:
																	goto IL_0178;
																case 25u:
																	goto IL_017a;
																case 5u:
																	goto end_IL_00eb;
																case 27u:
																	goto IL_0183;
																case 29u:
																	goto IL_018f;
																case 7u:
																	goto IL_019b;
																case 22u:
																	goto IL_019d;
																case 15u:
																	goto IL_01a4;
																case 1u:
																	goto IL_01d4;
																case 16u:
																	goto IL_01dd;
																case 0u:
																	goto IL_01e5;
																case 4u:
																	goto IL_021a;
																case 26u:
																	goto IL_0229;
																case 18u:
																	goto IL_0243;
																case 17u:
																	goto IL_024a;
																case 32u:
																case 42u:
																	goto IL_024e;
																default:
																	goto IL_0257;
																case 39u:
																	goto IL_0259;
																case 12u:
																	goto IL_025b;
																case 34u:
																	goto IL_0262;
																case 37u:
																	goto IL_0264;
																case 36u:
																	goto IL_0266;
																case 11u:
																	goto IL_0268;
																case 28u:
																	goto IL_026a;
																case 24u:
																	goto IL_026c;
																case 33u:
																	goto IL_026e;
																case 21u:
																	goto IL_0270;
																case 41u:
																	goto IL_0272;
																case 20u:
																	goto IL_0275;
																case 8u:
																	goto IL_0278;
																}
																break;
															}
															continue;
															IL_0268:
															return OpenPremiumStashSettingResult.Failed;
															IL_0266:
															return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
															IL_0278:
															return OpenPremiumStashSettingResult.NotSupported;
															IL_0275:
															return OpenPremiumStashSettingResult.NoMoreTabs;
															IL_0272:
															return OpenPremiumStashSettingResult.UnableToFindTabInScrollView;
															IL_0270:
															return OpenPremiumStashSettingResult.FailedToOpenTabList;
															IL_026e:
															return OpenPremiumStashSettingResult.TabNotFound;
															IL_026c:
															return OpenPremiumStashSettingResult.TabListNotOpen;
															IL_026a:
															return OpenPremiumStashSettingResult.UiNotOpen;
															continue;
															end_IL_00eb:
															break;
														}
													}
													Thread.Sleep(100);
													goto IL_0183;
													IL_0264:
													return OpenPremiumStashSettingResult.Failed;
													IL_0262:
													return OpenPremiumStashSettingResult.None;
													IL_0183:
													if (LokiPoe.InGameState.StashUi.StashTabInfo.IsNormalTab)
													{
														goto IL_018f;
													}
													goto IL_019d;
													IL_018f:
													if (!LokiPoe.InGameState.StashUi.StashTabInfo.IsPremium)
													{
														goto IL_019b;
													}
													goto IL_019d;
													IL_019b:
													return OpenPremiumStashSettingResult.NotPremiumStash;
													IL_019d:
													num3 = 0;
													goto IL_024e;
													IL_024e:
													if (num3 <= 3)
													{
														goto IL_01a4;
													}
													goto IL_025b;
													IL_01a4:
													element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name2);
													goto IL_01d4;
													IL_01d4:
													if (!(element == null))
													{
														goto IL_01dd;
													}
													goto IL_0259;
													IL_01dd:
													vector2i = element.CenterClickLocation();
													goto IL_01e5;
													IL_01e5:
													pos = new Vector2i(vector2i.X + (int)GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabContainerXOffset, vector2i.Y);
													goto IL_021a;
													IL_021a:
													SpecialSetMousePosition(pos);
													Thread.Sleep(100);
													goto IL_0229;
													IL_0229:
													MouseManager.ClickRMB(vector2i.X, vector2i.Y);
													Thread.Sleep(100);
													goto IL_0243;
													IL_0243:
													if (!LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
													{
														goto IL_024a;
													}
													goto IL_0257;
													IL_024a:
													num3++;
													goto IL_024e;
													IL_0257:
													return OpenPremiumStashSettingResult.None;
													IL_0259:
													return OpenPremiumStashSettingResult.TabNotFound;
													IL_025b:
													if (LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
													{
														goto IL_0262;
													}
													goto IL_0264;
													continue;
													end_IL_011e:
													break;
												}
												continue;
												end_IL_0123:
												break;
											}
											continue;
										}
										goto IL_017a;
										IL_017a:
										return OpenPremiumStashSettingResult.Failed;
										continue;
										end_IL_0132:
										break;
									}
									continue;
								}
								goto IL_0178;
								IL_0178:
								return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
								continue;
								end_IL_014c:
								break;
							}
							continue;
						}
						goto IL_0174;
						IL_0174:
						return OpenPremiumStashSettingResult.NotSupported;
						continue;
						end_IL_0155:
						break;
					}
					continue;
				}
				goto IL_0176;
				IL_0176:
				return OpenPremiumStashSettingResult.NotSupported;
				continue;
				end_IL_0160:
				break;
			}
		}
	}

	private bool IsRemoveOnly(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.RemoveOnly) == InventoryTabFlags.RemoveOnly;
	}

	private bool IsHidden(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.Hidden) == InventoryTabFlags.Hidden;
	}

	private int GetIndexByTabData(ClassTabData class258_0)
	{
		if (class258_0 == null)
		{
			return -1;
		}
		List<ClassTabData> list_ = List_1;
		for (int i = 0; i < list_.Count; i++)
		{
			if (list_[i].IntPtr_0 == class258_0.IntPtr_0 && list_[i].IntPtr_1 == class258_0.IntPtr_1 && list_[i].Name == class258_0.Name)
			{
				return i;
			}
		}
		return -1;
	}

	private ClassTabData GetTabDataByIndex(int index)
	{
		List<ClassTabData> list_ = List_1;
		if (index >= 0 && index < list_.Count)
		{
			return list_[index];
		}
		return null;
	}

	private ClassTabData GetTabDataByName(string name)
	{
		return List_1.FirstOrDefault((ClassTabData x) => x.Name.Equals(name));
	}
}
