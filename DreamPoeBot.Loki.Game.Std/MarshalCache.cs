#define DEBUG
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

public static class MarshalCache<T>
{
	public unsafe delegate void* GetUnsafePtrDelegate(ref T value);

	public static int Size;

	public static Type RealType;

	public static TypeCode TypeCode;

	public static bool TypeRequiresMarshal;

	public static readonly GetUnsafePtrDelegate GetUnsafePtr;

	unsafe static MarshalCache()
	{
		TypeCode = smethod_1(smethod_0(typeof(T).TypeHandle));
		if (smethod_2(smethod_0(typeof(T).TypeHandle), smethod_0(typeof(bool).TypeHandle)))
		{
			Size = 1;
			RealType = smethod_0(typeof(T).TypeHandle);
		}
		else if (smethod_3(smethod_0(typeof(T).TypeHandle)))
		{
			Type type = smethod_4(smethod_0(typeof(T).TypeHandle));
			Size = GetSizeOf(type);
			RealType = type;
			TypeCode = smethod_1(type);
		}
		else
		{
			Size = GetSizeOf(smethod_0(typeof(T).TypeHandle));
			RealType = smethod_0(typeof(T).TypeHandle);
		}
		TypeRequiresMarshal = RequiresMarshal(RealType);
		DynamicMethod dynamicMethod = smethod_10(smethod_7("GetPinnedPtr<", smethod_6(smethod_5(smethod_0(typeof(T).TypeHandle)), ".", "<>"), ">"), smethod_0(typeof(void*).TypeHandle), new Type[1] { smethod_8(smethod_0(typeof(T).TypeHandle)) }, smethod_9(smethod_0(typeof(MarshalCache<>).TypeHandle)));
		ILGenerator ilgenerator_ = smethod_11(dynamicMethod);
		smethod_12(ilgenerator_, OpCodes.Ldarg_0);
		smethod_12(ilgenerator_, OpCodes.Conv_U);
		smethod_12(ilgenerator_, OpCodes.Ret);
		GetUnsafePtr = (GetUnsafePtrDelegate)smethod_13((MethodInfo)dynamicMethod, smethod_0(typeof(GetUnsafePtrDelegate).TypeHandle));
	}

	private static int GetSizeOf(Type t)
	{
		try
		{
			return smethod_14(t);
		}
		catch
		{
			int num = 0;
			FieldInfo[] array = smethod_15(t, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in array)
			{
				object[] array2 = smethod_16((MemberInfo)fieldInfo, smethod_0(typeof(FixedBufferAttribute).TypeHandle), bool_0: false);
				if (array2.Length != 0)
				{
					FixedBufferAttribute fixedBufferAttribute_ = array2[0] as FixedBufferAttribute;
					num += GetSizeOf(smethod_17(fixedBufferAttribute_)) * smethod_18(fixedBufferAttribute_);
				}
				num += GetSizeOf(smethod_19(fieldInfo));
			}
			return num;
		}
	}

	private static bool RequiresMarshal(Type t)
	{
		FieldInfo[] array = smethod_15(t, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		int num = 0;
		FieldInfo fieldInfo;
		while (true)
		{
			if (num < array.Length)
			{
				fieldInfo = array[num];
				bool flag;
				if (flag = smethod_16((MemberInfo)fieldInfo, smethod_0(typeof(MarshalAsAttribute).TypeHandle), bool_0: true).Any())
				{
					break;
				}
				if (!smethod_2(t, smethod_0(typeof(IntPtr).TypeHandle)) && !smethod_2(t, smethod_0(typeof(string).TypeHandle)))
				{
					if (smethod_1(t) == TypeCode.Object)
					{
						flag |= RequiresMarshal(smethod_19(fieldInfo));
					}
					if (flag)
					{
						smethod_22(smethod_21(smethod_20((MemberInfo)smethod_19(fieldInfo)), " requires marshaling."));
						return true;
					}
				}
				num++;
				continue;
			}
			return false;
		}
		smethod_22(smethod_21(smethod_20((MemberInfo)smethod_19(fieldInfo)), " requires marshaling."));
		return true;
	}

	static Type smethod_0(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	static TypeCode smethod_1(Type type_0)
	{
		return Type.GetTypeCode(type_0);
	}

	static bool smethod_2(Type type_0, Type type_1)
	{
		return type_0 == type_1;
	}

	static bool smethod_3(Type type_0)
	{
		return type_0.IsEnum;
	}

	static Type smethod_4(Type type_0)
	{
		return type_0.GetEnumUnderlyingType();
	}

	static string smethod_5(Type type_0)
	{
		return type_0.FullName;
	}

	static string smethod_6(string string_0, string string_1, string string_2)
	{
		return string_0.Replace(string_1, string_2);
	}

	static string smethod_7(string string_0, string string_1, string string_2)
	{
		return string_0 + string_1 + string_2;
	}

	static Type smethod_8(Type type_0)
	{
		return type_0.MakeByRefType();
	}

	static Module smethod_9(Type type_0)
	{
		return type_0.Module;
	}

	static DynamicMethod smethod_10(string string_0, Type type_0, Type[] type_1, Module module_0)
	{
		return new DynamicMethod(string_0, type_0, type_1, module_0);
	}

	static ILGenerator smethod_11(DynamicMethod dynamicMethod_0)
	{
		return dynamicMethod_0.GetILGenerator();
	}

	static void smethod_12(ILGenerator ilgenerator_0, OpCode opCode_0)
	{
		ilgenerator_0.Emit(opCode_0);
	}

	static Delegate smethod_13(MethodInfo methodInfo_0, Type type_0)
	{
		return methodInfo_0.CreateDelegate(type_0);
	}

	static int smethod_14(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	static FieldInfo[] smethod_15(Type type_0, BindingFlags bindingFlags_0)
	{
		return type_0.GetFields(bindingFlags_0);
	}

	static object[] smethod_16(MemberInfo memberInfo_0, Type type_0, bool bool_0)
	{
		return memberInfo_0.GetCustomAttributes(type_0, bool_0);
	}

	static Type smethod_17(FixedBufferAttribute fixedBufferAttribute_0)
	{
		return fixedBufferAttribute_0.ElementType;
	}

	static int smethod_18(FixedBufferAttribute fixedBufferAttribute_0)
	{
		return fixedBufferAttribute_0.Length;
	}

	static Type smethod_19(FieldInfo fieldInfo_0)
	{
		return fieldInfo_0.FieldType;
	}

	static string smethod_20(MemberInfo memberInfo_0)
	{
		return memberInfo_0.Name;
	}

	static string smethod_21(string string_0, string string_1)
	{
		return string_0 + string_1;
	}

	static void smethod_22(string string_0)
	{
		Debug.WriteLine(string_0);
	}
}
