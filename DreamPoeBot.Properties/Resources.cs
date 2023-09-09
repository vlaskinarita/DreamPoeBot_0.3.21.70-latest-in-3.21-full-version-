using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DreamPoeBot.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("DreamPoeBot.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string BlightStashTabLayout => ResourceManager.GetString("BlightStashTabLayout", resourceCulture);

	internal static string CurrencyStashTabLayout => ResourceManager.GetString("CurrencyStashTabLayout", resourceCulture);

	internal static string DivinationCardStashTabLayout => ResourceManager.GetString("DivinationCardStashTabLayout", resourceCulture);

	internal static string FragmentStashTabLayout => ResourceManager.GetString("FragmentStashTabLayout", resourceCulture);

	internal static string PantheonSouls => ResourceManager.GetString("PantheonSouls", resourceCulture);

	internal static string StatDescription => ResourceManager.GetString("StatDescription", resourceCulture);

	internal Resources()
	{
	}
}
