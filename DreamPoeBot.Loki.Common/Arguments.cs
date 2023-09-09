using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace DreamPoeBot.Loki.Common;

public class Arguments
{
	private readonly Dictionary<string, Collection<string>> dictionary_0;

	private readonly IEnumerable<string> originalArguments;

	private string string_0;

	public int Count => dictionary_0.Count;

	public Collection<string> this[string parameter]
	{
		get
		{
			if (!dictionary_0.ContainsKey(parameter))
			{
				return null;
			}
			return dictionary_0[parameter];
		}
	}

	public IEnumerable<string> GetOriginalArguments => originalArguments;

	private static string[] smethod_0(string string_1)
	{
		StringBuilder stringBuilder = new StringBuilder(string_1);
		bool flag = false;
		for (int i = 0; i < stringBuilder.Length; i++)
		{
			if (stringBuilder[i] == '"')
			{
				flag = !flag;
			}
			if (stringBuilder[i] == ' ' && !flag)
			{
				stringBuilder[i] = '\n';
			}
		}
		string[] array = stringBuilder.ToString().Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = smethod_1(array[j]);
		}
		return array;
	}

	private static string smethod_1(string string_1)
	{
		int num = string_1.IndexOf('"');
		int num2 = string_1.LastIndexOf('"');
		while (num != num2)
		{
			string_1 = string_1.Remove(num, 1);
			string_1 = string_1.Remove(num2 - 1, 1);
			num = string_1.IndexOf('"');
			num2 = string_1.LastIndexOf('"');
		}
		return string_1;
	}

	public Arguments(IEnumerable<string> arguments)
	{
		originalArguments = arguments;
		dictionary_0 = new Dictionary<string, Collection<string>>();
		Regex regex = new Regex("^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		foreach (string argument in arguments)
		{
			string[] array = regex.Split(argument, 3);
			switch (array.Length)
			{
			case 1:
				method_2(array[0]);
				break;
			case 2:
				method_1();
				string_0 = array[1];
				break;
			case 3:
			{
				method_1();
				string text = smethod_1(array[2]);
				method_0(array[1], text.Split(','));
				break;
			}
			}
		}
		method_1();
	}

	private void method_0(string string_1, IEnumerable<string> ienumerable_0)
	{
		foreach (string item in ienumerable_0)
		{
			method_3(string_1, item);
		}
	}

	private void method_1()
	{
		if (string_0 != null)
		{
			method_4(string_0, "true");
			string_0 = null;
		}
	}

	private void method_2(string string_1)
	{
		if (string_0 != null)
		{
			string_1 = smethod_1(string_1);
			method_3(string_0, string_1);
			string_0 = null;
		}
	}

	private void method_3(string string_1, string string_2)
	{
		if (!dictionary_0.ContainsKey(string_1))
		{
			dictionary_0.Add(string_1, new Collection<string>());
		}
		dictionary_0[string_1].Add(string_2);
	}

	private void method_4(string string_1, string string_2)
	{
		if (dictionary_0.ContainsKey(string_1))
		{
			throw new ArgumentException($"Argument {string_1} has already been defined");
		}
		dictionary_0.Add(string_1, new Collection<string>());
		dictionary_0[string_1].Add(string_2);
	}

	private void method_5(string string_1)
	{
		if (dictionary_0.ContainsKey(string_1))
		{
			dictionary_0.Remove(string_1);
		}
	}

	public bool IsTrue(string argument)
	{
		method_6(argument);
		return this[argument]?[0].Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;
	}

	private void method_6(string string_1)
	{
		if (this[string_1] != null && this[string_1].Count > 1)
		{
			throw new ArgumentException($"{string_1} has been specified more than once, expecting single value");
		}
	}

	public string Single(string argument)
	{
		method_6(argument);
		if (this[argument] != null && !IsTrue(argument))
		{
			return this[argument][0];
		}
		return null;
	}

	public bool Exists(string argument)
	{
		if (this[argument] != null)
		{
			return this[argument].Count > 0;
		}
		return false;
	}
}
