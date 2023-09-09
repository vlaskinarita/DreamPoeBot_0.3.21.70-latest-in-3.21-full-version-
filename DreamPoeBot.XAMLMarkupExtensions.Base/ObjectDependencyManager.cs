using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal static class ObjectDependencyManager
{
	private static Dictionary<object, List<WeakReference>> dictionary_0 = new Dictionary<object, List<WeakReference>>();

	[MethodImpl(MethodImplOptions.Synchronized)]
	public static bool AddObjectDependency(WeakReference weakRefDp, object objToHold)
	{
		CleanUp();
		if (objToHold == null)
		{
			throw new ArgumentNullException("objToHold", "The objToHold cannot be null");
		}
		if (!(objToHold.GetType() == typeof(WeakReference)))
		{
			if (weakRefDp.Target != objToHold)
			{
				bool result = false;
				if (dictionary_0.ContainsKey(objToHold))
				{
					List<WeakReference> list = dictionary_0[objToHold];
					if (!list.Contains(weakRefDp))
					{
						list.Add(weakRefDp);
						result = true;
					}
				}
				else
				{
					List<WeakReference> value = new List<WeakReference> { weakRefDp };
					dictionary_0.Add(objToHold, value);
					result = true;
				}
				return result;
			}
			throw new InvalidOperationException("The WeakReference.Target cannot be the same as objToHold");
		}
		throw new ArgumentException("objToHold cannot be type of WeakReference", "objToHold");
	}

	public static void CleanUp()
	{
		CleanUp(null);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public static void CleanUp(object objToRemove)
	{
		if (objToRemove == null)
		{
			List<object> list = new List<object>();
			foreach (KeyValuePair<object, List<WeakReference>> item in dictionary_0)
			{
				for (int num = item.Value.Count - 1; num >= 0; num--)
				{
					if (item.Value[num].Target == null)
					{
						item.Value.RemoveAt(num);
					}
				}
				if (item.Value.Count == 0)
				{
					list.Add(item.Key);
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				dictionary_0.Remove(list[num2]);
			}
			list.Clear();
		}
		else if (!dictionary_0.Remove(objToRemove))
		{
			throw new Exception("Key was not found!");
		}
	}
}
