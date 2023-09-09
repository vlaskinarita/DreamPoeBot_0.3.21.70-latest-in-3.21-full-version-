using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public class NewSettingsWindow : MetroWindow, IComponentConnector
{
	private sealed class Class10
	{
		public NewSettingsWindow newSettingsWindow_0;

		public IPlugin iplugin_0;

		public string string_0;

		internal void method_0()
		{
			newSettingsWindow_0.method_6(iplugin_0);
			if (GuiSettings.Instance.EnabledPlugins.Contains(string_0))
			{
				GuiSettings.Instance.EnabledPlugins.Remove(string_0);
			}
			Configuration.Instance.SaveAll();
		}
	}

	private sealed class Class11
	{
		public NewSettingsWindow newSettingsWindow_0;

		public IPlugin iplugin_0;

		public string string_0;

		internal void method_0()
		{
			newSettingsWindow_0.method_6(iplugin_0);
			if (!GuiSettings.Instance.EnabledPlugins.Contains(string_0))
			{
				GuiSettings.Instance.EnabledPlugins.Add(string_0);
			}
			Configuration.Instance.SaveAll();
		}
	}

	[Serializable]
	private sealed class Class12
	{
		public static readonly Class12 Class9 = new Class12();

		internal bool method_0(IBot ibot_0)
		{
			return !string.IsNullOrEmpty(ibot_0.Name);
		}

		internal string method_1(IBot ibot_0)
		{
			return ibot_0.Name;
		}

		internal bool method_2(IRoutine iroutine_0)
		{
			return !string.IsNullOrEmpty(iroutine_0.Name);
		}

		internal string method_3(IRoutine iroutine_0)
		{
			return iroutine_0.Name;
		}

		internal bool method_4(IPlugin iplugin_0)
		{
			return !string.IsNullOrEmpty(iplugin_0.Name);
		}

		internal string method_5(IPlugin iplugin_0)
		{
			return iplugin_0.Name;
		}

		internal bool method_6(IContent icontent_0)
		{
			return !string.IsNullOrEmpty(icontent_0.Name);
		}

		internal string method_7(IContent icontent_0)
		{
			return icontent_0.Name;
		}

		internal bool method_8(IPlayerMover iplayerMover_0)
		{
			return !string.IsNullOrEmpty(iplayerMover_0.Name);
		}

		internal string method_9(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.Name;
		}

		internal bool method_10(IContent icontent_0)
		{
			return icontent_0.Name.Equals("EXtensions");
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private readonly BotTemplateGui botTemplateGui_0;

	private readonly RoutineTemplateGui routineTemplateGui_0;

	private readonly MoverTemplateGui moverTemplateGui_0;

	private readonly PluginTemplateGui pluginTemplateGui_0;

	private readonly ContentTemplateGui contentTemplateGui_0;

	private Dictionary<IBot, BotForegroundBindingHelper> dictionary_0 = new Dictionary<IBot, BotForegroundBindingHelper>();

	private Dictionary<IRoutine, RoutineForegroundBindingHelper> dictionary_1 = new Dictionary<IRoutine, RoutineForegroundBindingHelper>();

	private Dictionary<IPlayerMover, MoverForegroundBindingHelper> dictionary_2 = new Dictionary<IPlayerMover, MoverForegroundBindingHelper>();

	private Dictionary<IPlugin, PluginForegroundBindingHelper> dictionary_3 = new Dictionary<IPlugin, PluginForegroundBindingHelper>();

	private GlobalSettingsWrapper globalSettingsWrapper_0;

	private CurrentConfigurationSettingsWrapper currentConfigurationSettingsWrapper_0;

	private GuiSettingsWrapper guiSettingsWrapper_0;

	private ThirdPartyWrapper thirdPartyWrapper_0;

	private PremiumContentManagerWrapper premiumContentManagerWrapper_0;

	private BotManagerWrapper botManagerWrapper_0;

	private RoutineManagerWrapper routineManagerWrapper_0;

	private MoverManagerWrapper moverManagerWrapper_0;

	internal TreeView NewSettingsTreeView;

	internal GridSplitter NewSettingsGridSplitter;

	internal UserControl NewSettingsContentUserControl;

	private bool _contentLoaded;

	public NewSettingsWindow(MainWindow mainWindow)
	{
		mainWindow_0 = mainWindow;
		InitializeComponent();
		((FrameworkElement)this).SetBinding(Window.LeftProperty, (BindingBase)new Binding("SettingsWindowX")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(Window.TopProperty, (BindingBase)new Binding("SettingsWindowY")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.WidthProperty, (BindingBase)new Binding("SettingsWindowWidth")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.HeightProperty, (BindingBase)new Binding("SettingsWindowHeight")
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		botTemplateGui_0 = new BotTemplateGui();
		routineTemplateGui_0 = new RoutineTemplateGui();
		moverTemplateGui_0 = new MoverTemplateGui();
		pluginTemplateGui_0 = new PluginTemplateGui();
		contentTemplateGui_0 = new ContentTemplateGui();
		PluginManager.OnPluginEnabled += method_8;
		PluginManager.OnPluginDisabled += method_7;
		BotManager.OnBotChanged += method_5;
		RoutineManager.OnRoutineChanged += method_3;
		PlayerMoverManager.OnPlayerMoverChanged += method_2;
	}

	private void method_0()
	{
		foreach (KeyValuePair<IRoutine, RoutineForegroundBindingHelper> item in dictionary_1)
		{
			item.Value.Update();
		}
	}

	private void method_1()
	{
		foreach (KeyValuePair<IPlayerMover, MoverForegroundBindingHelper> item in dictionary_2)
		{
			item.Value.Update();
		}
	}

	private void method_2(object sender, PlayerMoverChangedEventArgs e)
	{
		((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(method_1));
	}

	private void method_3(object sender, RoutineChangedEventArgs e)
	{
		((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(method_0));
	}

	private void method_4()
	{
		foreach (KeyValuePair<IBot, BotForegroundBindingHelper> item in dictionary_0)
		{
			item.Value.Update();
		}
	}

	private void method_5(object sender, BotChangedEventArgs e)
	{
		((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(method_4));
	}

	private void method_6(IPlugin iplugin_0)
	{
		if (dictionary_3.TryGetValue(iplugin_0, out var value))
		{
			value.Update();
		}
	}

	private void method_7(IPlugin iplugin_0)
	{
		Class10 @class = new Class10();
		@class.newSettingsWindow_0 = this;
		@class.iplugin_0 = iplugin_0;
		if (@class.iplugin_0 != null)
		{
			@class.string_0 = @class.iplugin_0.Name;
			((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(@class.method_0));
		}
	}

	private void method_8(IPlugin iplugin_0)
	{
		Class11 @class = new Class11();
		@class.newSettingsWindow_0 = this;
		@class.iplugin_0 = iplugin_0;
		if (@class.iplugin_0 != null)
		{
			@class.string_0 = @class.iplugin_0.Name;
			((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(@class.method_0));
		}
	}

	private void method_9(object sender, CancelEventArgs e)
	{
		Configuration.Instance.SaveAll();
		((UIElement)this).Visibility = Visibility.Collapsed;
		e.Cancel = true;
	}

	private string GetProducerFromName(string name)
	{
		switch (name)
		{
		default:
		{
			uint num = Class37.smethod_0(name);
			if (num <= 1362938492)
			{
				if (num > 734743310)
				{
					if (num <= 889009852)
					{
						if (num != 751401973)
						{
							if (num == 786658466)
							{
								if (name == "Monoliths")
								{
									goto IL_0358;
								}
							}
							else if (num == 889009852 && name == "Chicken")
							{
								goto IL_0358;
							}
						}
						else if (name == "Incursion")
						{
							goto IL_0358;
						}
					}
					else if (num == 942817328)
					{
						if (name == "AutoPassives")
						{
							goto IL_0358;
						}
					}
					else if (num != 1346174759)
					{
						if (num == 1362938492 && name == "Breaches")
						{
							goto IL_0358;
						}
					}
					else if (name == "Abyss")
					{
						goto IL_0358;
					}
				}
				else if (num <= 539747502)
				{
					if (num != 287647614)
					{
						if (num == 431371766)
						{
							if (!(name != "QuestBot"))
							{
								goto IL_0358;
							}
						}
						else if (num == 539747502 && !(name != "DumpTab"))
						{
							goto IL_0326;
						}
					}
					else if (!(name != "OldRoutine"))
					{
						goto IL_02be;
					}
				}
				else if (num != 573075685)
				{
					if (num != 609453195)
					{
						if (num == 734743310 && !(name != "AutoLoginEx"))
						{
							goto IL_0358;
						}
					}
					else if (!(name != "EXtensions"))
					{
						goto IL_0358;
					}
				}
				else if (name == "ObjectExplorer")
				{
					goto IL_0326;
				}
			}
			else if (num <= 3056377330u)
			{
				if (num <= 2102247843)
				{
					if (num != 1618316065)
					{
						if (num == 1671601186)
						{
							if (!(name != "ExternalCommunication"))
							{
								goto IL_0326;
							}
						}
						else if (num == 2102247843 && !(name != "Overlay"))
						{
							goto IL_0326;
						}
					}
					else if (!(name != "OldGrindBot"))
					{
						goto IL_02be;
					}
				}
				else if (num != 2184141939u)
				{
					if (num == 2744387449u)
					{
						if (!(name != "ChaosRecipe"))
						{
							goto IL_0358;
						}
					}
					else if (num == 3056377330u && !(name != "MapBot"))
					{
						goto IL_0358;
					}
				}
				else if (!(name != "AutoLogin"))
				{
					goto IL_02be;
				}
			}
			else if (num > 4165132789u)
			{
				if (num == 4178269565u)
				{
					if (!(name != "SkillBlacklist"))
					{
						goto IL_0358;
					}
				}
				else if (num != 4198156159u)
				{
					if (num == 4263613000u && !(name != "AreaVisualizer"))
					{
						goto IL_0326;
					}
				}
				else if (name == "PythonExample")
				{
					goto IL_0326;
				}
			}
			else if (num == 3391351259u)
			{
				if (!(name != "DevTab"))
				{
					goto IL_0326;
				}
			}
			else if (num == 3696246797u)
			{
				if (!(name != "AutoFlask"))
				{
					goto IL_0358;
				}
			}
			else if (num == 4165132789u && !(name != "GemLeveler"))
			{
				goto IL_0358;
			}
			return "Community";
		}
		case "PatherExplorer":
			return "Dev";
		case "NullBot":
		case "ExamplePlugin":
		case "ExampleRoutine":
		case "ExampleMover":
		case "PremiumContentManager":
			{
				return "Official";
			}
			IL_0358:
			return "Official";
			IL_0326:
			return "Dev";
			IL_02be:
			return "Community";
		}
	}

	private string GetMoverProducerFromName(string string_0)
	{
		if (string_0 == "ExampleMover")
		{
			return "Official";
		}
		if (string_0 != "OldCoroutinePlayerMover")
		{
			return "Community";
		}
		return "Dev";
	}

	private string method_12(string string_0)
	{
		return "       " + string_0;
	}

	internal void method_13()
	{
		dictionary_0 = new Dictionary<IBot, BotForegroundBindingHelper>();
		dictionary_1 = new Dictionary<IRoutine, RoutineForegroundBindingHelper>();
		dictionary_3 = new Dictionary<IPlugin, PluginForegroundBindingHelper>();
		dictionary_2 = new Dictionary<IPlayerMover, MoverForegroundBindingHelper>();
		NewSettingsTreeView.Items.Clear();
		NewSettingsTreeView.Tag = new TreeViewItemTag();
		TreeViewItem treeViewItem_ = method_15("Program");
		method_15("Content");
		method_15("Bots");
		method_15("Routines");
		method_15("PlayerMovers");
		method_15("Plugins");
		NewSettingsWindow newSettingsWindow_ = mainWindow_0.NewSettingsWindow_0;
		GlobalSettingsWrapper object_;
		if ((object_ = globalSettingsWrapper_0) == null)
		{
			object_ = (globalSettingsWrapper_0 = new GlobalSettingsWrapper());
		}
		newSettingsWindow_.method_14(out var treeViewItem_2, object_, "Global", treeViewItem_);
		NewSettingsWindow newSettingsWindow_2 = mainWindow_0.NewSettingsWindow_0;
		CurrentConfigurationSettingsWrapper object_2;
		if ((object_2 = currentConfigurationSettingsWrapper_0) == null)
		{
			object_2 = (currentConfigurationSettingsWrapper_0 = new CurrentConfigurationSettingsWrapper());
		}
		newSettingsWindow_2.method_14(out treeViewItem_2, object_2, "Configuration", treeViewItem_);
		NewSettingsWindow newSettingsWindow_3 = mainWindow_0.NewSettingsWindow_0;
		GuiSettingsWrapper object_3;
		if ((object_3 = guiSettingsWrapper_0) == null)
		{
			object_3 = (guiSettingsWrapper_0 = new GuiSettingsWrapper());
		}
		newSettingsWindow_3.method_14(out treeViewItem_2, object_3, "Gui", treeViewItem_);
		NewSettingsWindow newSettingsWindow_4 = mainWindow_0.NewSettingsWindow_0;
		ThirdPartyWrapper object_4;
		if ((object_4 = thirdPartyWrapper_0) == null)
		{
			object_4 = (thirdPartyWrapper_0 = new ThirdPartyWrapper());
		}
		newSettingsWindow_4.method_14(out treeViewItem_2, object_4, "ThirdParty", treeViewItem_);
		NewSettingsWindow newSettingsWindow_5 = mainWindow_0.NewSettingsWindow_0;
		PremiumContentManagerWrapper object_5;
		if ((object_5 = premiumContentManagerWrapper_0) == null)
		{
			object_5 = (premiumContentManagerWrapper_0 = new PremiumContentManagerWrapper());
		}
		newSettingsWindow_5.method_14(out treeViewItem_2, object_5, "Premium", treeViewItem_);
		List<IBot> list = BotManager.Bots.Where(Class12.Class9.method_0).OrderBy(Class12.Class9.method_1).ToList();
		List<IRoutine> list2 = RoutineManager.Routines.Where(Class12.Class9.method_2).OrderBy(Class12.Class9.method_3).ToList();
		List<IPlugin> list3 = PluginManager.Plugins.Where(Class12.Class9.method_4).OrderBy(Class12.Class9.method_5).ToList();
		List<IContent> list4 = ContentManager.Contents.Where(Class12.Class9.method_6).OrderBy(Class12.Class9.method_7).ToList();
		List<IPlayerMover> list5 = PlayerMoverManager.PlayerMovers.Where(Class12.Class9.method_8).OrderBy(Class12.Class9.method_9).ToList();
		bool flag = true;
		TreeViewItem treeViewItem_3 = method_15("Content");
		string[] array = new string[3] { "Official", "Community", "Dev" };
		foreach (string text in array)
		{
			foreach (IContent item in list4)
			{
				if (item.Name != "EXtensions" && GetProducerFromName(item.Name) == text && item.Control != null)
				{
					if (flag)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, null, "[" + text + "]", treeViewItem_3);
						flag = false;
					}
					mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, item, method_12(item.Name), treeViewItem_3);
				}
			}
			flag = true;
		}
		bool flag2 = true;
		TreeViewItem treeViewItem_4 = method_15("Bots");
		NewSettingsWindow newSettingsWindow_6 = mainWindow_0.NewSettingsWindow_0;
		BotManagerWrapper object_6;
		if ((object_6 = botManagerWrapper_0) == null)
		{
			object_6 = (botManagerWrapper_0 = new BotManagerWrapper());
		}
		newSettingsWindow_6.method_14(out treeViewItem_2, object_6, " -> Manager <-", treeViewItem_4);
		string[] array2 = new string[3] { "Official", "Community", "Dev" };
		foreach (string text2 in array2)
		{
			foreach (IBot item2 in list)
			{
				if (GetProducerFromName(item2.Name) == text2)
				{
					if (flag2)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, null, "[" + text2 + "]", treeViewItem_4);
						flag2 = false;
					}
					if (item2.Control != null)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, item2, method_12(item2.Name), treeViewItem_4);
					}
				}
			}
			if (!(text2 != "Official"))
			{
				IContent content = list4.FirstOrDefault(Class12.Class9.method_10);
				if (content != null)
				{
					if (content.Control == null)
					{
						continue;
					}
					mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, content, method_12("Cross-bot Settings"), treeViewItem_4);
				}
			}
			flag2 = true;
		}
		bool flag3 = true;
		TreeViewItem treeViewItem_5 = method_15("Routines");
		NewSettingsWindow newSettingsWindow_7 = mainWindow_0.NewSettingsWindow_0;
		RoutineManagerWrapper object_7;
		if ((object_7 = routineManagerWrapper_0) == null)
		{
			object_7 = (routineManagerWrapper_0 = new RoutineManagerWrapper());
		}
		newSettingsWindow_7.method_14(out treeViewItem_2, object_7, " -> Manager <-", treeViewItem_5);
		string[] array3 = new string[3] { "Official", "Community", "Dev" };
		foreach (string text3 in array3)
		{
			foreach (IRoutine item3 in list2)
			{
				if (GetProducerFromName(item3.Name) == text3 && item3.Control != null)
				{
					if (flag3)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, null, "[" + text3 + "]", treeViewItem_5);
						flag3 = false;
					}
					mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, item3, method_12(item3.Name), treeViewItem_5);
				}
			}
			flag3 = true;
		}
		bool flag4 = true;
		TreeViewItem treeViewItem_6 = method_15("Plugins");
		string[] array4 = new string[3] { "Official", "Community", "Dev" };
		foreach (string text4 in array4)
		{
			foreach (IPlugin item4 in list3)
			{
				if (GetProducerFromName(item4.Name) == text4)
				{
					_ = item4.Control;
					if (flag4)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, null, "[" + text4 + "]", treeViewItem_6);
						flag4 = false;
					}
					mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, item4, method_12(item4.Name), treeViewItem_6);
				}
			}
			flag4 = true;
		}
		bool flag5 = true;
		TreeViewItem treeViewItem_7 = method_15("PlayerMovers");
		NewSettingsWindow newSettingsWindow_8 = mainWindow_0.NewSettingsWindow_0;
		MoverManagerWrapper object_8;
		if ((object_8 = moverManagerWrapper_0) == null)
		{
			object_8 = (moverManagerWrapper_0 = new MoverManagerWrapper());
		}
		newSettingsWindow_8.method_14(out treeViewItem_2, object_8, " -> Manager <-", treeViewItem_7);
		string[] array5 = new string[3] { "Official", "Community", "Dev" };
		foreach (string text5 in array5)
		{
			foreach (IPlayerMover item5 in list5)
			{
				if (GetMoverProducerFromName(item5.Name) == text5 && item5.Control != null)
				{
					if (flag5)
					{
						mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, null, "[" + text5 + "]", treeViewItem_7);
						flag5 = false;
					}
					mainWindow_0.NewSettingsWindow_0.method_14(out treeViewItem_2, item5, method_12(item5.Name), treeViewItem_7);
				}
			}
			flag5 = true;
		}
	}

	internal bool method_14(out TreeViewItem treeViewItem_0, object object_0, string string_0, TreeViewItem treeViewItem_1)
	{
		treeViewItem_0 = new TreeViewItem
		{
			Header = string_0,
			Tag = new TreeViewItemTag
			{
				Object = object_0
			}
		};
		if (object_0 is IPlugin plugin)
		{
			if (!dictionary_3.TryGetValue(plugin, out var value))
			{
				value = new PluginForegroundBindingHelper(plugin);
				Binding binding2 = (value._binding = new Binding("ForegroundColor")
				{
					Mode = BindingMode.OneWay,
					Source = value,
					Converter = null
				});
				treeViewItem_0.SetBinding(Control.ForegroundProperty, binding2);
				dictionary_3.Add(plugin, value);
			}
			else
			{
				treeViewItem_0.SetBinding(Control.ForegroundProperty, value._binding);
			}
		}
		if (object_0 is IBot bot)
		{
			if (!dictionary_0.TryGetValue(bot, out var value2))
			{
				value2 = new BotForegroundBindingHelper(bot);
				Binding binding4 = (value2._binding = new Binding("ForegroundColor")
				{
					Mode = BindingMode.OneWay,
					Source = value2,
					Converter = null
				});
				treeViewItem_0.SetBinding(Control.ForegroundProperty, binding4);
				dictionary_0.Add(bot, value2);
			}
			else
			{
				treeViewItem_0.SetBinding(Control.ForegroundProperty, value2._binding);
			}
		}
		if (object_0 is IPlayerMover playerMover)
		{
			if (!dictionary_2.TryGetValue(playerMover, out var value3))
			{
				value3 = new MoverForegroundBindingHelper(playerMover);
				Binding binding6 = (value3._binding = new Binding("ForegroundColor")
				{
					Mode = BindingMode.OneWay,
					Source = value3,
					Converter = null
				});
				treeViewItem_0.SetBinding(Control.ForegroundProperty, binding6);
				dictionary_2.Add(playerMover, value3);
			}
			else
			{
				treeViewItem_0.SetBinding(Control.ForegroundProperty, value3._binding);
			}
		}
		if (object_0 is IRoutine routine)
		{
			if (dictionary_1.TryGetValue(routine, out var value4))
			{
				treeViewItem_0.SetBinding(Control.ForegroundProperty, value4._binding);
			}
			else
			{
				value4 = new RoutineForegroundBindingHelper(routine);
				Binding binding8 = (value4._binding = new Binding("ForegroundColor")
				{
					Mode = BindingMode.OneWay,
					Source = value4,
					Converter = null
				});
				treeViewItem_0.SetBinding(Control.ForegroundProperty, binding8);
				dictionary_1.Add(routine, value4);
			}
		}
		Dictionary<string, TreeViewItem> mapping = (treeViewItem_1.Tag as TreeViewItemTag).Mapping;
		if (mapping.ContainsKey(string_0))
		{
			ilog_0.ErrorFormat("[AddToCategory] An existing header with the name [{0}] already exists!", (object)string_0);
			return false;
		}
		mapping.Add(string_0, treeViewItem_0);
		treeViewItem_1.Items.Add(treeViewItem_0);
		return true;
	}

	internal TreeViewItem method_15(params string[] string_0)
	{
		TreeViewItem treeViewItem = null;
		TreeViewItem value = null;
		foreach (string text in string_0)
		{
			Dictionary<string, TreeViewItem> dictionary = ((treeViewItem == null) ? (NewSettingsTreeView.Tag as TreeViewItemTag).Mapping : (treeViewItem.Tag as TreeViewItemTag).Mapping);
			if (!dictionary.TryGetValue(text, out value))
			{
				value = new TreeViewItem
				{
					Header = text,
					Tag = new TreeViewItemTag()
				};
				dictionary.Add(text, value);
				if (treeViewItem == null)
				{
					NewSettingsTreeView.Items.Add(value);
				}
				else
				{
					treeViewItem.Items.Add(value);
				}
			}
			treeViewItem = value;
		}
		return value;
	}

	private void method_16(object sender, RoutedPropertyChangedEventArgs<object> e)
	{
		if (!(e.NewValue is TreeViewItem treeViewItem))
		{
			NewSettingsContentUserControl.Content = null;
			return;
		}
		Configuration.Instance.SaveAll();
		object @object = (treeViewItem.Tag as TreeViewItemTag).Object;
		if (@object is IConfigurable configurable)
		{
			if (@object is IBot ibot_)
			{
				botTemplateGui_0.method_0(ibot_);
				NewSettingsContentUserControl.Content = botTemplateGui_0;
			}
			else if (!(@object is IRoutine iroutine_))
			{
				if (!(@object is IPlayerMover iplayerMover_))
				{
					if (!(@object is IPlugin iplugin_))
					{
						if (!(@object is IContent icontent_))
						{
							try
							{
								NewSettingsContentUserControl.Content = configurable.Control;
								return;
							}
							catch (Exception ex)
							{
								NewSettingsContentUserControl.Content = null;
								ilog_0.Error((object)"Could not access the GUI!", ex);
								return;
							}
						}
						contentTemplateGui_0.method_0(icontent_);
						NewSettingsContentUserControl.Content = contentTemplateGui_0;
					}
					else
					{
						pluginTemplateGui_0.method_0(iplugin_);
						NewSettingsContentUserControl.Content = pluginTemplateGui_0;
					}
				}
				else
				{
					moverTemplateGui_0.method_0(iplayerMover_);
					NewSettingsContentUserControl.Content = moverTemplateGui_0;
				}
			}
			else
			{
				routineTemplateGui_0.method_0(iroutine_);
				NewSettingsContentUserControl.Content = routineTemplateGui_0;
			}
		}
		else
		{
			NewSettingsContentUserControl.Content = null;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/DreamPoeBot;component/dreampoe/newsettingswindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		default:
			_contentLoaded = true;
			break;
		case 1:
			((Window)(object)(NewSettingsWindow)target).Closing += method_9;
			break;
		case 2:
			NewSettingsTreeView = (TreeView)target;
			NewSettingsTreeView.SelectedItemChanged += method_16;
			break;
		case 3:
			NewSettingsGridSplitter = (GridSplitter)target;
			break;
		case 4:
			NewSettingsContentUserControl = (UserControl)target;
			break;
		}
	}
}
