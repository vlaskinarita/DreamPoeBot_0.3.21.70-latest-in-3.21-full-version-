using System;
using System.IO;
using DreamPoeBot.Loki.Common;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Framework.Helpers;

public static class Misc
{
	private class SelectedProfile
	{
		public string Name { get; set; }
	}

	private static readonly string RandomSelectedProfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "State");

	private static readonly ILog Ilog = Logger.GetLoggerInstanceForType();

	private static string LoadProfile()
	{
		string text = Path.Combine(RandomSelectedProfilePath, "RandomSelectedProfile.json");
		if (!File.Exists(text))
		{
			return "";
		}
		string text2 = File.ReadAllText(text);
		SelectedProfile selectedProfile = JsonConvert.DeserializeObject<SelectedProfile>(text2);
		if (selectedProfile == null)
		{
			Ilog.ErrorFormat("Failed to deserialize file \"" + text + "\" to SelectedProfile Class.", Array.Empty<object>());
			return "";
		}
		return selectedProfile.Name;
	}

	private static void SaveProfile(string profile)
	{
		SelectedProfile selectedProfile = new SelectedProfile();
		selectedProfile.Name = profile;
		string contents = JsonConvert.SerializeObject((object)selectedProfile);
		if (!Directory.Exists(RandomSelectedProfilePath))
		{
			Ilog.ErrorFormat(" Directory \"State\" dosent exist. Creating...", Array.Empty<object>());
			Directory.CreateDirectory(RandomSelectedProfilePath);
		}
		string path = Path.Combine(RandomSelectedProfilePath, "RandomSelectedProfile.json");
		File.WriteAllText(path, contents);
	}
}
