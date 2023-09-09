using System;
using System.Linq;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class FQAssemblyDictionaryKey : FullyQualifiedResourceKeyBase
{
	[Serializable]
	private sealed class Class84
	{
		public static readonly Class84 Class9 = new Class84();

		public static Func<string, bool> Method9__10_0;

		internal bool method_0(string string_0)
		{
			return !string.IsNullOrEmpty(string_0);
		}
	}

	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	public string Key => string_0;

	public string Assembly => string_1;

	public string Dictionary => string_2;

	public FQAssemblyDictionaryKey(string key, string assembly = null, string dictionary = null)
	{
		string_0 = key;
		string_1 = assembly;
		string_2 = dictionary;
	}

	public override string ToString()
	{
		return string.Join(":", new string[3] { Assembly, Dictionary, Key }.Where(Class84.Class9.method_0).ToArray());
	}
}
