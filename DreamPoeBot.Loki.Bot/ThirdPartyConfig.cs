using System.Collections.Generic;

namespace DreamPoeBot.Loki.Bot;

public class ThirdPartyConfig
{
	public string AssemblyName { get; set; } = "";


	public List<string> FileList { get; set; } = new List<string>();


	public List<string> Dependencies { get; set; } = new List<string>();


	public List<string> References { get; set; } = new List<string>();


	public bool Validate()
	{
		bool result = false;
		if (AssemblyName == null)
		{
			AssemblyName = "";
			result = true;
		}
		if (FileList == null)
		{
			FileList = new List<string>();
			result = true;
		}
		if (Dependencies == null)
		{
			Dependencies = new List<string>();
			result = true;
		}
		if (References == null)
		{
			References = new List<string>();
			result = true;
		}
		return result;
	}
}
