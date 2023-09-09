#define DEBUG
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace DreamPoeBot.Loki;

[SuppressUnmanagedCodeSecurity]
public static class MarshalCache<T>
{
	internal unsafe delegate void* GetUnsafePtrDelegate(ref T value);

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		internal bool _003C_002Ecctor_003Eb__7_0(FieldInfo m)
		{
			return smethod_1((MemberInfo)m, smethod_0(typeof(MarshalAsAttribute).TypeHandle), bool_0: true).Any();
		}

		static Type smethod_0(RuntimeTypeHandle runtimeTypeHandle_0)
		{
			return Type.GetTypeFromHandle(runtimeTypeHandle_0);
		}

		static object[] smethod_1(MemberInfo memberInfo_0, Type type_0, bool bool_0)
		{
			return memberInfo_0.GetCustomAttributes(type_0, bool_0);
		}
	}

	public static int Size;

	public static uint SizeU;

	public static Type RealType;

	public static TypeCode TypeCode;

	public static bool TypeRequiresMarshal;

	public static bool IsIntPtr;

	internal static readonly GetUnsafePtrDelegate GetUnsafePtr;

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
			Size = smethod_5(type);
			RealType = type;
			TypeCode = smethod_1(type);
		}
		else
		{
			Size = smethod_5(smethod_0(typeof(T).TypeHandle));
			RealType = smethod_0(typeof(T).TypeHandle);
		}
		IsIntPtr = smethod_2(RealType, smethod_0(typeof(IntPtr).TypeHandle));
		SizeU = (uint)Size;
		Type type2 = smethod_0(typeof(T).TypeHandle);
		Debug.Write("[MarshalCache] " + (((object)type2 != null) ? smethod_6((object)type2) : null) + " Size: " + SizeU);
		TypeRequiresMarshal = RealType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any((FieldInfo m) => _003C_003Ec.smethod_1((MemberInfo)m, _003C_003Ec.smethod_0(typeof(MarshalAsAttribute).TypeHandle), bool_0: true).Any());
		DynamicMethod dynamicMethod = new DynamicMethod(string.Format("GetPinnedPtr<{0}>", typeof(T).FullName.Replace(".", "<>")), typeof(void*), new Type[1] { typeof(T).MakeByRefType() }, typeof(MarshalCache<>).Module);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Conv_U);
		iLGenerator.Emit(OpCodes.Ret);
		GetUnsafePtr = (GetUnsafePtrDelegate)dynamicMethod.CreateDelegate(typeof(GetUnsafePtrDelegate));
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

	static int smethod_5(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	static string smethod_6(object object_0)
	{
		return object_0.ToString();
	}
}
