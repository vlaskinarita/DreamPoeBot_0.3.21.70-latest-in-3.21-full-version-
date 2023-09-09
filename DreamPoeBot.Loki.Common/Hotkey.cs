using System;
using System.Windows.Forms;

namespace DreamPoeBot.Loki.Common;

public class Hotkey : IEquatable<Hotkey>
{
	public Action<Hotkey> Callback { get; set; }

	public int Id { get; private set; }

	public Keys Key { get; private set; }

	public ModifierKeys ModifierKeys { get; private set; }

	public string Name { get; private set; }

	internal bool IsRegistered { get; set; }

	internal Hotkey(string name, Keys key, ModifierKeys modifierKeys, int id, Action<Hotkey> callback)
	{
		Name = name;
		Key = key;
		ModifierKeys = modifierKeys;
		Id = id;
		Callback = callback;
	}

	public override string ToString()
	{
		return Name + " [" + method_0() + "]";
	}

	private string method_0()
	{
		string text = "";
		if (ModifierKeys.HasFlag(ModifierKeys.Control))
		{
			text += "Ctrl + ";
		}
		if (ModifierKeys.HasFlag(ModifierKeys.Alt))
		{
			text += "Alt + ";
		}
		if (ModifierKeys.HasFlag(ModifierKeys.Shift))
		{
			text += "Shift + ";
		}
		return text + Key;
	}

	public bool Equals(Hotkey other)
	{
		if (other != null)
		{
			if (Id != other.Id)
			{
				return false;
			}
			return string.Equals(Name, other.Name);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this != obj)
			{
				if (obj.GetType() != GetType())
				{
					return false;
				}
				return Equals((Hotkey)obj);
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Id * 397) ^ ((Name != null) ? Name.GetHashCode() : 0);
	}

	public static bool operator ==(Hotkey left, Hotkey right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Hotkey left, Hotkey right)
	{
		return !object.Equals(left, right);
	}
}
