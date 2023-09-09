using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class TypeLoader<T> : List<T>
{
	[Serializable]
	[CompilerGenerated]
	private sealed class Class400
	{
		public static readonly Class400 Method9 = new Class400();

		public static Func<object[]> Method9__3_0;

		public static Func<Type, bool> Method9__4_0;

		internal object[] method_0()
		{
			return null;
		}

		internal bool method_1(Type type_0)
		{
			return smethod_1(type_0, smethod_0(typeof(T).TypeHandle));
		}

		static Type smethod_0(RuntimeTypeHandle runtimeTypeHandle_0)
		{
			return Type.GetTypeFromHandle(runtimeTypeHandle_0);
		}

		static bool smethod_1(Type type_0, Type type_1)
		{
			return type_0 == type_1;
		}
	}

	[CompilerGenerated]
	private sealed class Class401
	{
		public Type type_0;

		internal bool method_0(T gparam_0)
		{
			return smethod_1(smethod_0(gparam_0.GetType()), smethod_0(type_0));
		}

		static string smethod_0(Type type_1)
		{
			return type_1.FullName;
		}

		static bool smethod_1(string string_0, string string_1)
		{
			return string_0.Equals(string_1);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly Assembly assembly_0;

	private Func<object[]> func_0;

	public TypeLoader(Assembly asm = null, Func<object[]> constructorArguments = null)
	{
		assembly_0 = asm;
		if (constructorArguments == null)
		{
			func_0 = () => null;
		}
		else
		{
			func_0 = constructorArguments;
		}
		Reload();
	}

	private void method_0(params Assembly[] assembly_1)
	{
		foreach (Assembly assembly_2 in assembly_1)
		{
			try
			{
				Type[] array = smethod_0(assembly_2);
				foreach (Type type_ in array)
				{
					if (!smethod_1(type_) && (smethod_3(type_, smethod_2(typeof(T).TypeHandle)) || smethod_4(type_).Any((Type type_0) => Class400.smethod_1(type_0, Class400.smethod_0(typeof(T).TypeHandle)))) && !this.Any((T gparam_0) => Class401.smethod_1(Class401.smethod_0(gparam_0.GetType()), Class401.smethod_0(type_))))
					{
						Add((T)smethod_6(type_, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, (Binder)null, func_0(), smethod_5()));
					}
				}
			}
			catch (ReflectionTypeLoadException ex)
			{
				smethod_8(ilog_0, "Skipping type processing of [{0}] due to an exception. {1}", (object)smethod_7(assembly_2), (object)ex);
				if (smethod_9(ex) != null)
				{
					Exception[] array2 = smethod_9(ex);
					foreach (Exception exception_ in array2)
					{
						smethod_10(ilog_0, (object)"LoaderExceptions: ", exception_);
					}
				}
			}
			catch (Exception ex2)
			{
				smethod_8(ilog_0, "Skipping type processing of [{0}] due to an exception. {1}", (object)smethod_7(assembly_2), (object)ex2);
				if (smethod_11(ex2) != null)
				{
					smethod_10(ilog_0, (object)"InnerException: ", smethod_11(ex2));
				}
			}
		}
	}

	public void Reload()
	{
		Clear();
		if (smethod_12(assembly_0, (Assembly)null))
		{
			method_0(smethod_14(smethod_13()));
			return;
		}
		method_0(assembly_0);
	}

	static Type[] smethod_0(Assembly assembly_1)
	{
		return assembly_1.GetTypes();
	}

	static bool smethod_1(Type type_0)
	{
		return type_0.IsAbstract;
	}

	static Type smethod_2(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	static bool smethod_3(Type type_0, Type type_1)
	{
		return type_0.IsSubclassOf(type_1);
	}

	static Type[] smethod_4(Type type_0)
	{
		return type_0.GetInterfaces();
	}

	static CultureInfo smethod_5()
	{
		return CultureInfo.InvariantCulture;
	}

	static object smethod_6(Type type_0, BindingFlags bindingFlags_0, Binder binder_0, object[] object_0, CultureInfo cultureInfo_0)
	{
		return Activator.CreateInstance(type_0, bindingFlags_0, binder_0, object_0, cultureInfo_0);
	}

	static string smethod_7(Assembly assembly_1)
	{
		return assembly_1.FullName;
	}

	static void smethod_8(ILog ilog_1, string string_0, object object_0, object object_1)
	{
		ilog_1.WarnFormat(string_0, object_0, object_1);
	}

	static Exception[] smethod_9(ReflectionTypeLoadException reflectionTypeLoadException_0)
	{
		return reflectionTypeLoadException_0.LoaderExceptions;
	}

	static void smethod_10(ILog ilog_1, object object_0, Exception exception_0)
	{
		ilog_1.Warn(object_0, exception_0);
	}

	static Exception smethod_11(Exception exception_0)
	{
		return exception_0.InnerException;
	}

	static bool smethod_12(Assembly assembly_1, Assembly assembly_2)
	{
		return assembly_1 == assembly_2;
	}

	static AppDomain smethod_13()
	{
		return AppDomain.CurrentDomain;
	}

	static Assembly[] smethod_14(AppDomain appDomain_0)
	{
		return appDomain_0.GetAssemblies();
	}
}
