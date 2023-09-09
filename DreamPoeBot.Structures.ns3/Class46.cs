using System;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace DreamPoeBot.Structures.ns3;

internal static class Class46
{
	[CompilerGenerated]
	private sealed class Class47
	{
		public Action<Class41> action_0;

		internal object method_0(Class41 class41_0)
		{
			action_0(class41_0);
			return null;
		}
	}

	public static void smethod_0(Action<Class41> action_0)
	{
		smethod_2((Func<Class41, object>)delegate(Class41 class41_0)
		{
			action_0(class41_0);
			return null;
		});
	}

	public static object smethod_1(Func<Class41, object> func_0)
	{
		return smethod_2(func_0);
	}

	public static T smethod_2<T>(Func<Class41, T> func_0)
	{
		try
		{
			Class41 @class = new Class41();
			bool flag = false;
			try
			{
				T result = func_0(@class);
				@class.method_2();
				flag = true;
				return result;
			}
			catch (EndpointNotFoundException)
			{
				@class.method_1();
				return smethod_2(func_0);
			}
			catch (CommunicationException)
			{
				@class.method_1();
				return smethod_2(func_0);
			}
			catch (TimeoutException)
			{
				@class.method_1();
				return smethod_2(func_0);
			}
			catch (Exception)
			{
				@class.method_1();
				throw;
			}
			finally
			{
				if (!flag && @class.CommunicationState_0 != CommunicationState.Closed)
				{
					@class.method_1();
				}
			}
		}
		catch
		{
			return default(T);
		}
	}
}
