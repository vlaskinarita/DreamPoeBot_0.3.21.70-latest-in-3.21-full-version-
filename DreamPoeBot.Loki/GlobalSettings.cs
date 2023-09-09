using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using DreamPoeBot.Auth;
using DreamPoeBot.DreamPoe;
using DreamPoeBot.Framework.Helpers;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki;

public class GlobalSettings : JsonSettings
{
	private List<PremiumContentClass> premiumContent;

	private string _customRDServerName;

	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForType();

	public static Crypto Crypto = new Crypto(Encoding.ASCII.GetBytes("o6806642kbM7c5"));

	private static GlobalSettings globalSettings_0;

	private string string_1;

	private bool bool_1;

	private List<Region> list_0;

	private Region region_0;

	private bool bool_2;

	private string string_2;

	private string string_3;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool _randomizeProfileSelection;

	private string _lastUsedConfiguration;

	private string _profilesFolderPath;

	private string _profileBaseName;

	private string _blacklistedProfileWords;

	private bool bool_6;

	private string string_5;

	private bool bool_7;

	private string string_6;

	private bool bool_8;

	private Keys keys_0;

	private ModifierKeys modifierKeys_0;

	private bool bool_9;

	private Keys keys_1;

	private ModifierKeys modifierKeys_1;

	private bool bool_10;

	private Keys keys_2;

	private ModifierKeys modifierKeys_2;

	private bool bool_11;

	private Keys keys_3;

	private ModifierKeys modifierKeys_3;

	private bool bool_12;

	private Keys keys_4;

	private ModifierKeys modifierKeys_4;

	private bool bool_13;

	private Keys keys_5;

	private ModifierKeys modifierKeys_5;

	private bool bool_14;

	private Keys keys_6;

	private ModifierKeys modifierKeys_6;

	private bool bool_15;

	private Keys keys_7;

	private ModifierKeys modifierKeys_7;

	private bool bool_16;

	private bool debugLastTask;

	private bool debugTicks;

	private bool bool_18;

	private bool bool_19;

	private int int_0;

	private bool bool_20;

	private bool bool_21;

	private int int_1;

	private bool _humanLikeMouse;

	private int _humanLikeMouseMaxStep;

	private bool _isBackgroundFpsActive;

	private int _backgroundFps;

	private bool _minimizeGameOnHook;

	private bool _enableMouseDegudOnHook;

	private bool _stopRenderOnHook;

	public static GlobalSettings Instance
	{
		get
		{
			GlobalSettings result;
			if ((result = globalSettings_0) == null)
			{
				result = (globalSettings_0 = new GlobalSettings());
			}
			return result;
		}
	}

	[DefaultValue(false)]
	public bool HumanLikeMouse
	{
		get
		{
			return _humanLikeMouse;
		}
		set
		{
			if (!value.Equals(_humanLikeMouse))
			{
				_humanLikeMouse = value;
				NotifyPropertyChanged(() => HumanLikeMouse);
				Save();
			}
		}
	}

	[DefaultValue(7)]
	public int HumanLikeMouseMaxStep
	{
		get
		{
			return _humanLikeMouseMaxStep;
		}
		set
		{
			if (!value.Equals(_humanLikeMouseMaxStep))
			{
				_humanLikeMouseMaxStep = value;
				NotifyPropertyChanged(() => HumanLikeMouseMaxStep);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool IsBackgroundFpsActive
	{
		get
		{
			return _isBackgroundFpsActive;
		}
		set
		{
			if (!value)
			{
				LokiPoe.ClientFunctions.SetBackgroundFps(20, force: true);
			}
			if (!value.Equals(_isBackgroundFpsActive))
			{
				_isBackgroundFpsActive = value;
				NotifyPropertyChanged(() => IsBackgroundFpsActive);
				Save();
			}
		}
	}

	[DefaultValue(33)]
	public int BackgroundFps
	{
		get
		{
			return _backgroundFps;
		}
		set
		{
			if (!value.Equals(_backgroundFps))
			{
				if (IsBackgroundFpsActive && BotManager.IsRunning)
				{
					LokiPoe.ClientFunctions.SetBackgroundFps(_backgroundFps = value);
				}
				_backgroundFps = value;
				NotifyPropertyChanged(() => BackgroundFps);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool StopRenderOnHook
	{
		get
		{
			return _stopRenderOnHook;
		}
		set
		{
			if (!value.Equals(_stopRenderOnHook))
			{
				_stopRenderOnHook = value;
				NotifyPropertyChanged(() => StopRenderOnHook);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool MinimizeGameOnHook
	{
		get
		{
			return _minimizeGameOnHook;
		}
		set
		{
			if (!value.Equals(_minimizeGameOnHook))
			{
				_minimizeGameOnHook = value;
				NotifyPropertyChanged(() => MinimizeGameOnHook);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool EnableMouseDegudOnHook
	{
		get
		{
			return _enableMouseDegudOnHook;
		}
		set
		{
			if (!value.Equals(_enableMouseDegudOnHook))
			{
				_enableMouseDegudOnHook = value;
				NotifyPropertyChanged(() => EnableMouseDegudOnHook);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool DontAutoFocusGameWindow
	{
		get
		{
			return bool_20;
		}
		set
		{
			if (!value.Equals(bool_20))
			{
				bool_20 = value;
				NotifyPropertyChanged(() => DontAutoFocusGameWindow);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool DontAutoFocusBotWindow
	{
		get
		{
			return bool_21;
		}
		set
		{
			if (!value.Equals(bool_21))
			{
				bool_21 = value;
				NotifyPropertyChanged(() => DontAutoFocusBotWindow);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool HookCompatibility0
	{
		get
		{
			return bool_18;
		}
		set
		{
			if (!value.Equals(bool_18))
			{
				bool_18 = value;
				NotifyPropertyChanged(() => HookCompatibility0);
				ilog_1.WarnFormat("[HookCompatibility0] Please restart the bot for the changes to take effect.", Array.Empty<object>());
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool HookCompatibility1
	{
		get
		{
			return bool_19;
		}
		set
		{
			if (!value.Equals(bool_19))
			{
				bool_19 = value;
				NotifyPropertyChanged(() => HookCompatibility1);
				Save();
			}
		}
	}

	[DefaultValue(8)]
	public int HookCompatibilityDepth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (!value.Equals(int_0))
			{
				int_0 = value;
				NotifyPropertyChanged(() => HookCompatibilityDepth);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool DebugTicks
	{
		get
		{
			return debugTicks;
		}
		set
		{
			if (!value.Equals(debugTicks))
			{
				debugTicks = value;
				NotifyPropertyChanged(() => DebugTicks);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool DebugLastTask
	{
		get
		{
			return debugLastTask;
		}
		set
		{
			if (!value.Equals(debugLastTask))
			{
				debugLastTask = value;
				NotifyPropertyChanged(() => DebugLastTask);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool AllowExternalAccess
	{
		get
		{
			return bool_16;
		}
		set
		{
			if (!value.Equals(bool_16))
			{
				bool_16 = value;
				NotifyPropertyChanged(() => AllowExternalAccess);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool StartStopBotEnabled
	{
		get
		{
			return bool_8;
		}
		set
		{
			if (!value.Equals(bool_8))
			{
				bool_8 = value;
				NotifyPropertyChanged(() => StartStopBotEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.S)]
	public Keys StartStopBotKey
	{
		get
		{
			return keys_0;
		}
		set
		{
			if (!value.Equals(keys_0))
			{
				keys_0 = value;
				NotifyPropertyChanged(() => StartStopBotKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys StartStopBotMod
	{
		get
		{
			return modifierKeys_0;
		}
		set
		{
			if (!value.Equals(modifierKeys_0))
			{
				modifierKeys_0 = value;
				NotifyPropertyChanged(() => StartStopBotMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool FocusBotWindowEnabled
	{
		get
		{
			return bool_9;
		}
		set
		{
			if (!value.Equals(bool_9))
			{
				bool_9 = value;
				NotifyPropertyChanged(() => FocusBotWindowEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.W)]
	public Keys FocusBotWindowKey
	{
		get
		{
			return keys_1;
		}
		set
		{
			if (!value.Equals(keys_1))
			{
				keys_1 = value;
				NotifyPropertyChanged(() => FocusBotWindowKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys FocusBotWindowMod
	{
		get
		{
			return modifierKeys_1;
		}
		set
		{
			if (!value.Equals(modifierKeys_1))
			{
				modifierKeys_1 = value;
				NotifyPropertyChanged(() => FocusBotWindowMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool DebugMouseCursorPosEnabled
	{
		get
		{
			return bool_10;
		}
		set
		{
			if (!value.Equals(bool_10))
			{
				bool_10 = value;
				NotifyPropertyChanged(() => DebugMouseCursorPosEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.X)]
	public Keys DebugMouseCursorPosKey
	{
		get
		{
			return keys_2;
		}
		set
		{
			if (!value.Equals(keys_2))
			{
				keys_2 = value;
				NotifyPropertyChanged(() => DebugMouseCursorPosKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys DebugMouseCursorPosMod
	{
		get
		{
			return modifierKeys_2;
		}
		set
		{
			if (!value.Equals(modifierKeys_2))
			{
				modifierKeys_2 = value;
				NotifyPropertyChanged(() => DebugMouseCursorPosMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool DisablePHMEnabled
	{
		get
		{
			return bool_11;
		}
		set
		{
			if (!value.Equals(bool_11))
			{
				bool_11 = value;
				NotifyPropertyChanged(() => DisablePHMEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.D)]
	public Keys DisablePHMKey
	{
		get
		{
			return keys_3;
		}
		set
		{
			if (!value.Equals(keys_3))
			{
				keys_3 = value;
				NotifyPropertyChanged(() => DisablePHMKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys DisablePHMMod
	{
		get
		{
			return modifierKeys_3;
		}
		set
		{
			if (!value.Equals(modifierKeys_3))
			{
				modifierKeys_3 = value;
				NotifyPropertyChanged(() => DisablePHMMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool EnablePHMEnabled
	{
		get
		{
			return bool_12;
		}
		set
		{
			if (!value.Equals(bool_12))
			{
				bool_12 = value;
				NotifyPropertyChanged(() => EnablePHMEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.E)]
	public Keys EnablePHMKey
	{
		get
		{
			return keys_4;
		}
		set
		{
			if (!value.Equals(keys_4))
			{
				keys_4 = value;
				NotifyPropertyChanged(() => EnablePHMKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys EnablePHMMod
	{
		get
		{
			return modifierKeys_4;
		}
		set
		{
			if (!value.Equals(modifierKeys_4))
			{
				modifierKeys_4 = value;
				NotifyPropertyChanged(() => EnablePHMMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool ResetPHMEnabled
	{
		get
		{
			return bool_13;
		}
		set
		{
			if (!value.Equals(bool_13))
			{
				bool_13 = value;
				NotifyPropertyChanged(() => ResetPHMEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.R)]
	public Keys ResetPHMKey
	{
		get
		{
			return keys_5;
		}
		set
		{
			if (!value.Equals(keys_5))
			{
				keys_5 = value;
				NotifyPropertyChanged(() => ResetPHMKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys ResetPHMMod
	{
		get
		{
			return modifierKeys_5;
		}
		set
		{
			if (!value.Equals(modifierKeys_5))
			{
				modifierKeys_5 = value;
				NotifyPropertyChanged(() => ResetPHMMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool DumpTGTEnabled
	{
		get
		{
			return bool_14;
		}
		set
		{
			if (!value.Equals(bool_14))
			{
				bool_14 = value;
				NotifyPropertyChanged(() => DumpTGTEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.T)]
	public Keys DumpTGTKey
	{
		get
		{
			return keys_6;
		}
		set
		{
			if (!value.Equals(keys_6))
			{
				keys_6 = value;
				NotifyPropertyChanged(() => DumpTGTKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys DumpTGTMod
	{
		get
		{
			return modifierKeys_6;
		}
		set
		{
			if (!value.Equals(modifierKeys_6))
			{
				modifierKeys_6 = value;
				NotifyPropertyChanged(() => DumpTGTMod);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool DumpFrameUnderCursorEnabled
	{
		get
		{
			return bool_15;
		}
		set
		{
			if (!value.Equals(bool_15))
			{
				bool_15 = value;
				NotifyPropertyChanged(() => DumpFrameUnderCursorEnabled);
				Save();
			}
		}
	}

	[DefaultValue(Keys.A)]
	public Keys DumpFrameUnderCursorKey
	{
		get
		{
			return keys_7;
		}
		set
		{
			if (!value.Equals(keys_7))
			{
				keys_7 = value;
				NotifyPropertyChanged(() => DumpFrameUnderCursorKey);
				Save();
			}
		}
	}

	[DefaultValue(ModifierKeys.Alt | ModifierKeys.Shift)]
	public ModifierKeys DumpFrameUnderCursorMod
	{
		get
		{
			return modifierKeys_7;
		}
		set
		{
			if (!value.Equals(modifierKeys_7))
			{
				modifierKeys_7 = value;
				NotifyPropertyChanged(() => DumpFrameUnderCursorMod);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool AutoChooseConfig
	{
		get
		{
			return bool_7;
		}
		set
		{
			if (!value.Equals(bool_7))
			{
				bool_7 = value;
				NotifyPropertyChanged(() => AutoChooseConfig);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool AutoChooseLanguage
	{
		get
		{
			return bool_6;
		}
		set
		{
			if (!value.Equals(bool_6))
			{
				bool_6 = value;
				NotifyPropertyChanged(() => AutoChooseLanguage);
				Save();
			}
		}
	}

	[DefaultValue("")]
	public string BuddyUpdaterName
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value != null && !value.Equals(string_1))
			{
				string_1 = value;
				NotifyPropertyChanged(() => BuddyUpdaterName);
				Save();
			}
		}
	}

	[DefaultValue("")]
	public string AutoLanguage
	{
		get
		{
			return string_5;
		}
		set
		{
			if (value != null && !value.Equals(string_5))
			{
				string_5 = value;
				NotifyPropertyChanged(() => AutoLanguage);
				Save();
			}
		}
	}

	[DefaultValue("en")]
	public string LastUsedLanguage
	{
		get
		{
			return string_6;
		}
		set
		{
			if (value != null && !value.Equals(string_6))
			{
				string_6 = value;
				NotifyPropertyChanged(() => LastUsedLanguage);
				Save();
			}
		}
	}

	[JsonIgnore]
	public bool RandomizeProfileSelectionFalse => !RandomizeProfileSelection;

	[DefaultValue(false)]
	public bool RandomizeProfileSelection
	{
		get
		{
			return _randomizeProfileSelection;
		}
		set
		{
			if (!value.Equals(_randomizeProfileSelection))
			{
				_randomizeProfileSelection = value;
				NotifyPropertyChanged(() => RandomizeProfileSelection);
				NotifyPropertyChanged(() => RandomizeProfileSelectionFalse);
				Save();
			}
		}
	}

	[JsonIgnore]
	public string RandomProfileSelected
	{
		get
		{
			return Misc.LoadProfile();
		}
		set
		{
			if (value != null)
			{
				Misc.SaveProfile(value);
				NotifyPropertyChanged(() => RandomProfileSelected);
			}
		}
	}

	[DefaultValue("")]
	public string ProfilesFolderPath
	{
		get
		{
			return _profilesFolderPath;
		}
		set
		{
			if (value != null && !value.Equals(_profilesFolderPath))
			{
				_profilesFolderPath = value;
				NotifyPropertyChanged(() => ProfilesFolderPath);
				Save();
			}
		}
	}

	[DefaultValue("")]
	public string ProfileBaseName
	{
		get
		{
			return _profileBaseName;
		}
		set
		{
			if (value != null && !value.Equals(_profileBaseName))
			{
				_profileBaseName = value;
				NotifyPropertyChanged(() => ProfileBaseName);
				Save();
			}
		}
	}

	[DefaultValue("")]
	public string BlacklistedProfileWords
	{
		get
		{
			return _blacklistedProfileWords;
		}
		set
		{
			if (value != null && !value.Equals(_blacklistedProfileWords))
			{
				_blacklistedProfileWords = value;
				NotifyPropertyChanged(() => BlacklistedProfileWords);
				Save();
			}
		}
	}

	[DefaultValue("")]
	public string LastUsedConfiguration
	{
		get
		{
			return _lastUsedConfiguration;
		}
		set
		{
			if (value != null && !value.Equals(_lastUsedConfiguration))
			{
				_lastUsedConfiguration = value;
				NotifyPropertyChanged(() => LastUsedConfiguration);
				Save();
			}
		}
	}

	[DefaultValue(true)]
	public bool AutoAuthLogin
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (!value.Equals(bool_2))
			{
				bool_2 = value;
				NotifyPropertyChanged(() => AutoAuthLogin);
				Save();
			}
		}
	}

	[DefaultValue(Region.BestLatency)]
	public Region AuthRegion
	{
		get
		{
			return region_0;
		}
		set
		{
			if (!value.Equals(region_0))
			{
				region_0 = value;
				NotifyPropertyChanged(() => AuthRegion);
				ilog_1.InfoFormat("[AuthRegion] {0}.", (object)region_0);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool DisableUpdateCheck
	{
		get
		{
			return bool_5;
		}
		set
		{
			if (!value.Equals(bool_5))
			{
				bool_5 = value;
				NotifyPropertyChanged(() => DisableUpdateCheck);
				Save();
			}
		}
	}

	[DefaultValue("")]
	[JsonIgnore]
	public string AuthKey
	{
		get
		{
			return string_2;
		}
		set
		{
			if (value != null && !value.Equals(string_2))
			{
				string_2 = value;
				NotifyPropertyChanged(() => AuthKey);
			}
		}
	}

	[DefaultValue("")]
	public string AuthKeys
	{
		get
		{
			return string_3;
		}
		set
		{
			if (value != null && !value.Equals(string_3))
			{
				string_3 = value;
				NotifyPropertyChanged(() => AuthKeys);
			}
		}
	}

	[DefaultValue(true)]
	public bool LogoutPoeOnAuthIssue
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (!value.Equals(bool_3))
			{
				bool_3 = value;
				NotifyPropertyChanged(() => LogoutPoeOnAuthIssue);
				Save();
			}
		}
	}

	[DefaultValue(false)]
	public bool TerminatePoeOnAuthIssue
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (!value.Equals(bool_4))
			{
				bool_4 = value;
				NotifyPropertyChanged(() => TerminatePoeOnAuthIssue);
				Save();
			}
		}
	}

	[DefaultValue(20)]
	public int MemoryPullInterval
	{
		get
		{
			return int_1;
		}
		set
		{
			if (!value.Equals(int_1))
			{
				int_1 = value;
				NotifyPropertyChanged(() => MemoryPullInterval);
				Save();
			}
		}
	}

	public List<PremiumContentClass> PremiumContent
	{
		get
		{
			return premiumContent;
		}
		set
		{
			premiumContent = value;
			NotifyPropertyChanged(() => PremiumContent);
			Save();
		}
	}

	[DefaultValue("Alcor75RDServer")]
	public string CustomRDServerName
	{
		get
		{
			return _customRDServerName;
		}
		set
		{
			if (value != null && !value.Equals(_customRDServerName))
			{
				_customRDServerName = value;
				NotifyPropertyChanged(() => CustomRDServerName);
				Save();
			}
		}
	}

	public GlobalSettings()
		: base(JsonSettings.GetSettingsFilePath("Global", CommandLine.Arguments.Exists("global_override") ? CommandLine.Arguments.Single("global_override") : "GlobalSettings.json"))
	{
		if (string.IsNullOrEmpty(_lastUsedConfiguration))
		{
			_lastUsedConfiguration = "Default";
		}
		if (PremiumContent == null)
		{
			PremiumContent = new List<PremiumContentClass>();
		}
	}

	[OnSerializing]
	internal void method_0(StreamingContext streamingContext_0)
	{
		if (!string.IsNullOrEmpty(AuthKeys))
		{
			AuthKeys = Crypto.EncryptStringAes(AuthKeys, "ebseckey");
		}
	}

	[OnSerialized]
	internal void method_1(StreamingContext streamingContext_0)
	{
		if (!string.IsNullOrEmpty(AuthKeys))
		{
			AuthKeys = Crypto.DecryptStringAes(AuthKeys, "ebseckey");
		}
	}

	[OnDeserialized]
	internal void method_2(StreamingContext streamingContext_0)
	{
		method_1(streamingContext_0);
	}
}
