using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DreamPoeBot.Common;
using DreamPoeBot.Framework;
using DreamPoeBot.Framework.Enums;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki;

[SuppressUnmanagedCodeSecurity]
public class Memory : IDisposable
{
	public struct ListDoublePointerIntNode
	{
		public long PreviousPtr;

		public long NextPtr;

		public long Ptr2_Key;

		public long Ptr1_Unused;

		public int Value;
	}

	public abstract class Reader
	{
		public abstract T Read<T>(long address, bool isRelative = false) where T : struct;

		public virtual T[] ReadArray<T>(long address, int size) where T : struct
		{
			T[] array = new T[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = Read<T>(address + i * MarshalCache<T>.Size);
			}
			return array;
		}
	}

	private readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private int _pId;

	public readonly long AddressOfProcess;

	public readonly int SizeOfProcess;

	public readonly long EndOfProcess;

	private readonly Dictionary<string, int> modules;

	private bool closed;

	public Offsets offsets;

	public IntPtr procHandle;

	public long procHandleAsLong;

	public string DebugStr = "";

	private int _actorStruct137Size = -1;

	internal static readonly Dictionary<string, int> StructureSizesDictionary = new Dictionary<string, int>();

	public Process Process { get; }

	private int ActorStruct137Size
	{
		get
		{
			if (_actorStruct137Size == -1)
			{
				_actorStruct137Size = MarshalCache<Actor.ActorStruct137>.Size;
			}
			return _actorStruct137Size;
		}
	}

	public Memory(Offsets offs, int pId)
	{
		try
		{
			offsets = offs;
			_pId = pId;
			Process = Process.GetProcessById(pId);
			ProcessModule mainModule = Process.MainModule;
			AddressOfProcess = mainModule.BaseAddress.ToInt64();
			SizeOfProcess = mainModule.ModuleMemorySize;
			EndOfProcess = AddressOfProcess + SizeOfProcess;
			procHandle = WinApi.OpenProcess(Process, ProcessAccessFlags.All);
			procHandleAsLong = procHandle.ToInt64();
			modules = new Dictionary<string, int>();
		}
		catch (Win32Exception innerException)
		{
			throw new Exception("You should run program as an administrator", innerException);
		}
	}

	public void Dispose()
	{
		Close();
	}

	~Memory()
	{
		Close();
	}

	public bool IsStaticMemoryLocation(long address)
	{
		if (address > AddressOfProcess)
		{
			return address < EndOfProcess;
		}
		return false;
	}

	public int ReadInt(long addr)
	{
		return BitConverter.ToInt32(ReadMem(addr, 4), 0);
	}

	public int[] ReadArrayInt(long start, int count)
	{
		List<int> list = new List<int>();
		if (start == 0L)
		{
			return list.ToArray();
		}
		byte[] value = ReadMem(start, count * 4);
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			num++;
			if (num > 100000)
			{
				break;
			}
			list.Add(BitConverter.ToInt32(value, i * 4));
		}
		return list.ToArray();
	}

	public int ReadInt(long addr, params long[] offsets)
	{
		long num = ReadLong(addr);
		long num2 = num;
		for (int i = 0; i < offsets.Length; i++)
		{
			if (num2 == 0L)
			{
				break;
			}
			long num3 = offsets[i];
			num2 = ReadLong(num2 + num3);
		}
		return (int)num2;
	}

	public float ReadFloat(long addr)
	{
		return BitConverter.ToSingle(ReadMem(addr, 4), 0);
	}

	public long ReadLong(long addr)
	{
		return BitConverter.ToInt64(ReadMem(addr, 8), 0);
	}

	public ulong ReadULong(long addr)
	{
		return BitConverter.ToUInt64(ReadMem(addr, 8), 0);
	}

	public long ReadLong(long addr, params long[] offsets)
	{
		long num = ReadLong(addr);
		long num2 = num;
		for (int i = 0; i < offsets.Length; i++)
		{
			if (num2 == 0L)
			{
				break;
			}
			long num3 = offsets[i];
			num2 = ReadLong(num2 + num3);
		}
		return num2;
	}

	public uint ReadUInt(long addr)
	{
		return BitConverter.ToUInt32(ReadMem(addr, 4), 0);
	}

	public ushort ReadUShort(long addr)
	{
		return BitConverter.ToUInt16(ReadMem(addr, 2), 0);
	}

	public short ReadShort(long addr)
	{
		return BitConverter.ToInt16(ReadMem(addr, 2), 0);
	}

	public string ReadString(long addr, int length = 512, bool replaceNull = true)
	{
		if (addr <= 65536L && addr >= -1L)
		{
			return string.Empty;
		}
		string @string = Encoding.ASCII.GetString(ReadMem(addr, length));
		if (!replaceNull)
		{
			return @string;
		}
		return RTrimNull(@string);
	}

	private static string RTrimNull(string text)
	{
		int num = text.IndexOf('\0');
		if (num <= 0)
		{
			return text;
		}
		return text.Substring(0, num);
	}

	public string ReadNativeString(long addr)
	{
		uint num = ReadUInt(addr + 16L);
		if (8 > num)
		{
			return ReadStringU(addr);
		}
		long addr2 = ReadLong(addr);
		return ReadStringU(addr2);
	}

	public NativeVector ReadNativeVector(long addr)
	{
		NativeVector result = default(NativeVector);
		byte[] value = ReadMem(addr, 24);
		result.First = BitConverter.ToInt64(value, 0);
		result.Last = BitConverter.ToInt64(value, 8);
		result.End = BitConverter.ToInt64(value, 16);
		return result;
	}

	public string ReadStringU(long addr, int length = 512, bool replaceNull = true)
	{
		if (addr <= 65536L && addr >= -1L)
		{
			return string.Empty;
		}
		byte[] array = ReadMem(addr, length);
		if (array.Length != 0)
		{
			if (array[0] == 0 && array[1] == 0)
			{
				return string.Empty;
			}
			string @string = Encoding.Unicode.GetString(array);
			if (replaceNull)
			{
				return RTrimNull(@string);
			}
			return @string;
		}
		return string.Empty;
	}

	public byte ReadByte(long addr)
	{
		return ReadBytes(addr, 1)[0];
	}

	public byte[] ReadBytes(long addr, int length)
	{
		if (addr == 0L)
		{
			return new byte[length];
		}
		return ReadMem(addr, length);
	}

	private void Close()
	{
		if (!closed)
		{
			closed = true;
			WinApi.CloseHandle(procHandle);
		}
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe bool IsValidAddress(long addr)
	{
		byte[] array = new byte[1];
		fixed (byte* ret = array)
		{
			if (!WinApi.ex_read_bytes(procHandleAsLong, addr, 1, ret))
			{
				return false;
			}
			if (array.Length != 1)
			{
				return false;
			}
		}
		return true;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (!WinApi.ex_read_bytes(procHandleAsLong, addr, count, ret))
			{
			}
			return array;
		}
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadServerDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_server_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadRitualDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_ritual_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadDelveDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_delve_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadWaypointDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_waypoint_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadIncursionDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_incursion_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal unsafe byte[] ReadBlightDataMem(long addr, int count)
	{
		byte[] array = new byte[count];
		fixed (byte* ret = array)
		{
			if (WinApi.ex_read_blight_data_bytes(procHandleAsLong, addr, count, ret))
			{
				return array;
			}
		}
		return array;
	}

	[SuppressUnmanagedCodeSecurity]
	internal Dictionary<int, long> ReadObjectsDataMem(long addr, uint count)
	{
		Dictionary<int, long> result = new Dictionary<int, long>();
		WinApi.ex_read_objects_data_bytes(addr);
		return result;
	}

	public bool WriteVector2(long addr, Vector2 data)
	{
		byte[] bytes = BitConverter.GetBytes(data.X);
		byte[] bytes2 = BitConverter.GetBytes(data.Y);
		byte[] array = new byte[bytes.Length + bytes2.Length];
		Array.Copy(bytes, 0, array, 0, bytes.Length);
		Array.Copy(bytes2, 0, array, bytes.Length, bytes2.Length);
		return WriteMem(addr, array);
	}

	public bool WriteVector2i(long addr, Vector2i data)
	{
		byte[] bytes = BitConverter.GetBytes(data.X);
		byte[] bytes2 = BitConverter.GetBytes(data.Y);
		byte[] array = new byte[bytes.Length + bytes2.Length];
		Array.Copy(bytes, 0, array, 0, bytes.Length);
		Array.Copy(bytes2, 0, array, bytes.Length, bytes2.Length);
		return WriteMem(addr, array);
	}

	public bool WriteByte(long addr, byte data)
	{
		return WriteMem(addr, new byte[1] { data });
	}

	public bool WriteShort(long addr, short data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool WriteInt(long addr, int data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool WriteuInt(long addr, uint data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool WriteFloat(long addr, float data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool Writelong(long addr, long data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool Writeulong(long addr, ulong data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		return WriteMem(addr, bytes);
	}

	public bool WriteMem(long addr, byte[] data)
	{
		return WinApi.WriteProcessMemory(procHandle, (IntPtr)addr, data);
	}

	public List<T> ReadStructsArray<T>(long startAddress, long endAddress, int structSize, int maxCountLimit) where T : RemoteMemoryObject, new()
	{
		List<T> list = new List<T>();
		long num = endAddress - startAddress;
		if (num >= 0L && num / structSize <= maxCountLimit)
		{
			int num2 = 0;
			for (long num3 = startAddress; num3 < endAddress; num3 += structSize)
			{
				num2++;
				if (num2 > 100000)
				{
					break;
				}
				list.Add(GameController.Instance.Game.GetObject<T>(num3));
			}
			return list;
		}
		return list;
	}

	internal LokiPoe.TerrainData.TileStructure[] ReadTerrainStructsArray<T>(long startAddress, int length) where T : struct
	{
		int num = 0;
		string key = "LokiPoe.TerrainData.TileStructure";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = 56;
			StructureSizesDictionary.Add(key, 56);
		}
		List<LokiPoe.TerrainData.TileStructure> list = new List<LokiPoe.TerrainData.TileStructure>();
		long num2 = startAddress + length * num;
		int num3 = 0;
		for (long num4 = startAddress; num4 < num2; num4 += num)
		{
			num3++;
			if (num3 > 1000000)
			{
				break;
			}
			list.Add(FastIntPtrToStruct<LokiPoe.TerrainData.TileStructure>(num4, num));
		}
		return list.ToArray();
	}

	internal Struct242[] ReadStructure242StructsArray<T>(long startAddress, long endAddress, int maxCountLimit = 500) where T : struct
	{
		int num = 0;
		string key = "Structures.ns19.Struct242";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<Struct242>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		List<Struct242> list = new List<Struct242>();
		long num2 = endAddress - startAddress;
		if (num2 >= 0L && num2 / num <= maxCountLimit)
		{
			int num3 = 0;
			for (long num4 = startAddress; num4 < endAddress; num4 += num)
			{
				num3++;
				if (num3 > 1000000)
				{
					break;
				}
				list.Add(FastIntPtrToStruct<Struct242>(num4, num));
			}
			return list.ToArray();
		}
		return list.ToArray();
	}

	internal Struct243[] ReadStructure243StructsArray<T>(long startAddress, long endAddress, int maxCountLimit = 500) where T : struct
	{
		int num = 0;
		string key = "Structures.ns19.Struct243";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<Struct243>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		List<Struct243> list = new List<Struct243>();
		long num2 = endAddress - startAddress;
		if (num2 >= 0L && num2 / num <= maxCountLimit)
		{
			int num3 = 0;
			for (long num4 = startAddress; num4 < endAddress; num4 += num)
			{
				num3++;
				if (num3 > 1000000)
				{
					break;
				}
				list.Add(FastIntPtrToStruct<Struct243>(num4, num));
			}
			return list.ToArray();
		}
		return list.ToArray();
	}

	public Vector3 ReadVector3(long address)
	{
		byte[] value = ReadMem(address, 12);
		float x = BitConverter.ToSingle(value, 0);
		float y = BitConverter.ToSingle(value, 4);
		float z = BitConverter.ToSingle(value, 8);
		return new Vector3(x, y, z);
	}

	public Vector2 ReadVector2(long address)
	{
		byte[] value = ReadMem(address, 8);
		float x = BitConverter.ToSingle(value, 0);
		float y = BitConverter.ToSingle(value, 4);
		return new Vector2(x, y);
	}

	public Vector2i ReadVector2i(long address)
	{
		byte[] value = ReadMem(address, 8);
		int x = BitConverter.ToInt32(value, 0);
		int y = BitConverter.ToInt32(value, 4);
		return new Vector2i(x, y);
	}

	public List<T> ReadDoublePtrVectorClasses<T>(long address, bool noNullPointers = false) where T : RemoteMemoryObject, new()
	{
		byte[] value = ReadMem(address, 24);
		long num = BitConverter.ToInt64(value, 0);
		long num2 = BitConverter.ToInt64(value, 16);
		int num3 = (int)(num2 - num);
		byte[] value2 = ReadBytes(num, num3);
		List<T> list = new List<T>();
		for (int i = 0; i < num3; i += 16)
		{
			long num4 = BitConverter.ToInt64(value2, i);
			if (!(num4 == 0L && noNullPointers))
			{
				list.Add(GameController.Instance.Game.GetObject<T>(num4));
			}
		}
		return list;
	}

	public List<long> ReadPointersArray(long startAddress, long endAddress, int offset = 8)
	{
		List<long> list = new List<long>();
		int num = (int)(endAddress - startAddress);
		int num2 = num / offset;
		if (num2 > 100000)
		{
			return list;
		}
		byte[] value = ReadMem(startAddress, num);
		for (int i = 0; i < num2; i++)
		{
			list.Add(BitConverter.ToInt64(value, 8 * i));
		}
		return list;
	}

	public List<long> ReadFirstPointerArray_Count(long startAddress, int count)
	{
		List<long> list = new List<long>();
		byte[] value = ReadMem(startAddress, count * 16);
		for (int i = 0; i < count * 16; i += 16)
		{
			list.Add(BitConverter.ToInt64(value, i));
		}
		return list;
	}

	public List<long> ReadSecondPointerArray_Count(long startAddress, int count)
	{
		List<long> list = new List<long>();
		byte[] value = ReadMem(startAddress, count * 16);
		for (int i = 0; i < count * 16; i += 16)
		{
			list.Add(BitConverter.ToInt64(value, i + 8));
		}
		return list;
	}

	public NativeStringWCustom IntptrToNativeStringWCustom(long pointer)
	{
		int num = 0;
		string key = "Game.Std.NativeStringWCustom";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<NativeStringWCustom>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		byte[] data = ReadBytes(pointer, num);
		return IntptrToStructNativeStringWCustom(data);
	}

	public unsafe NativeStringWCustom IntptrToStructNativeStringWCustom(byte[] data)
	{
		fixed (byte* ptr = &data[0])
		{
			return *(NativeStringWCustom*)ptr;
		}
	}

	public T[] IntptrToStructArray<T>(long start, int count, int structureSize) where T : unmanaged
	{
		List<T> list = new List<T>();
		byte[] sourceArray = ReadMem(start, count * structureSize);
		for (long num = 0L; num < count; num++)
		{
			byte[] array = new byte[structureSize];
			Array.Copy(sourceArray, num * structureSize, array, 0L, structureSize);
			list.Add(IntptrToStruct<T>(array));
			if (list.Count > 10000)
			{
				break;
			}
		}
		return list.ToArray();
	}

	public T[] IntptrToStructArray<T>(NativeVector vector, int structuresize) where T : unmanaged
	{
		List<T> list = new List<T>();
		long first = vector.First;
		long last = vector.Last;
		for (long num = first; num < last; num += structuresize)
		{
			byte[] data = ReadBytes(num, structuresize);
			list.Add(IntptrToStruct<T>(data));
			if (list.Count > 10000)
			{
				break;
			}
		}
		return list.ToArray();
	}

	public unsafe T ReadUsingPointer<T>(byte[] data) where T : unmanaged
	{
		fixed (byte* ptr = &data[0])
		{
			return *(T*)ptr;
		}
	}

	public unsafe T IntptrToStruct<T>(byte[] data) where T : unmanaged
	{
		fixed (byte* ptr = &data[0])
		{
			return *(T*)ptr;
		}
	}

	public List<Tuple<long, int>> ReadDoublePointerIntList(long address)
	{
		List<Tuple<long, int>> list = new List<Tuple<long, int>>();
		long num = ReadLong(address + 8L);
		ListDoublePointerIntNode listDoublePointerIntNode = ReadDoublePointerIntListNode(num);
		list.Add(new Tuple<long, int>(listDoublePointerIntNode.Ptr2_Key, listDoublePointerIntNode.Value));
		int num2 = 0;
		for (long nextPtr = listDoublePointerIntNode.NextPtr; nextPtr != 0L; nextPtr = listDoublePointerIntNode.NextPtr)
		{
			num2++;
			if (num2 > 1000000)
			{
				break;
			}
			listDoublePointerIntNode = ReadDoublePointerIntListNode(nextPtr);
			list.Add(new Tuple<long, int>(listDoublePointerIntNode.Ptr2_Key, listDoublePointerIntNode.Value));
			if (nextPtr == num)
			{
				break;
			}
		}
		if (list.Count > 0)
		{
			list.RemoveAt(list.Count - 1);
			list.RemoveAt(0);
		}
		return list;
	}

	private unsafe ListDoublePointerIntNode ReadDoublePointerIntListNode(long pointer)
	{
		int num = 0;
		string key = "ListDoublePointerIntNode";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<ListDoublePointerIntNode>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		byte[] array = ReadBytes(pointer, num);
		ListDoublePointerIntNode result;
		fixed (byte* ptr = &array[0])
		{
			result = *(ListDoublePointerIntNode*)ptr;
		}
		return result;
	}

	public T GetObject<T>(long address) where T : RemoteMemoryObject, new()
	{
		return new T
		{
			Address = address
		};
	}

	public long[] FindPatterns(params Pattern[] patterns)
	{
		byte[] exeImage = ReadBytes(AddressOfProcess, 33554432);
		long[] address = new long[patterns.Length];
		Parallel.For(0, patterns.Length, delegate(int iPattern)
		{
			Pattern pattern = patterns[iPattern];
			byte[] bytes = pattern.Bytes;
			int num = bytes.Length;
			bool flag = false;
			for (int i = 0; i < exeImage.Length - num; i++)
			{
				if (CompareData(pattern, exeImage, i))
				{
					flag = true;
					address[iPattern] = i;
					DebugStr = DebugStr + "Pattern " + iPattern + " is found at " + (AddressOfProcess + i).ToString("X") + " offset: " + i.ToString("X") + Environment.NewLine;
					break;
				}
			}
			if (!flag)
			{
				DebugStr = DebugStr + "Pattern " + iPattern + " is not found!" + Environment.NewLine;
			}
		});
		return address;
	}

	private bool CompareData(Pattern pattern, byte[] data, int offset)
	{
		bool flag = false;
		for (int i = 0; i < pattern.Bytes.Length; i++)
		{
			if (pattern.Mask[i] == 'x' && pattern.Bytes[i] != data[offset + i])
			{
				flag = true;
				break;
			}
		}
		return !flag;
	}

	internal unsafe Entity.EntityStructure FastIntPtrToEntityStructure(long ptr)
	{
		int num = 0;
		string key = "Entity.EntityStructure";
		if (!StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = MarshalCache<Entity.EntityStructure>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		else
		{
			num = value;
		}
		byte[] array = ReadBytes(ptr, num);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Entity.EntityStructure*)ptr2;
		}
	}

	internal unsafe Entity.EntityDataStructure FastIntPtrToEntityDataStructure(long ptr)
	{
		int num = 0;
		string key = "Entity.EntityDataStructure";
		if (!StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = MarshalCache<Entity.EntityDataStructure>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		else
		{
			num = value;
		}
		byte[] array = ReadBytes(ptr, num);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Entity.EntityDataStructure*)ptr2;
		}
	}

	internal unsafe Entity.EntityComponentStructure FastIntPtrToEntityComponentStructure(long ptr)
	{
		int num = 0;
		string key = "Entity.EntityComponentStructure";
		if (!StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = MarshalCache<Entity.EntityComponentStructure>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		else
		{
			num = value;
		}
		byte[] array = ReadBytes(ptr, num);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Entity.EntityComponentStructure*)ptr2;
		}
	}

	internal unsafe Actor.ActorStruct137 FastIntPtrToStruct137(long ptr)
	{
		int actorStruct137Size = ActorStruct137Size;
		byte[] array = ReadBytes(ptr, actorStruct137Size);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Actor.ActorStruct137*)ptr2;
		}
	}

	internal unsafe Positioned.Struct196 FastIntPtrToStruct196(long ptr)
	{
		int num = 0;
		string key = "Components.Positioned.Struct196";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<Positioned.Struct196>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		byte[] array = ReadBytes(ptr, num);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Positioned.Struct196*)ptr2;
		}
	}

	internal unsafe Life.Struct169 FastIntPtrToStruct169(long ptr)
	{
		int num = 0;
		string key = "Components.Life.Struct169";
		if (StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<Life.Struct169>.Size;
			StructureSizesDictionary.Add(key, num);
		}
		byte[] array = ReadBytes(ptr, num);
		fixed (byte* ptr2 = &array[0])
		{
			return *(Life.Struct169*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStruct<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			string fullName = typeof(T).FullName;
			if (!string.IsNullOrEmpty(fullName))
			{
				if (!StructureSizesDictionary.TryGetValue(fullName, out var value))
				{
					structSize = MarshalCache<T>.Size;
					StructureSizesDictionary.Add(fullName, structSize);
				}
				else
				{
					structSize = value;
				}
			}
		}
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadBytes(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructServerData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadServerDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructRitualData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadRitualDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructDelveData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadDelveDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructWaypointData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadWaypointDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructIncursionData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadIncursionDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}

	internal unsafe T FastIntPtrToStructBlightData<T>(long ptr, int structSize = 0) where T : unmanaged
	{
		if (structSize == 0)
		{
			structSize = MarshalCache<T>.Size;
		}
		byte[] array = ReadBlightDataMem(ptr, structSize);
		fixed (byte* ptr2 = &array[0])
		{
			return *(T*)ptr2;
		}
	}
}
