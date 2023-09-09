using System.Collections.Generic;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class DiagnosticElement : RemoteMemoryObject
{
	public string Text => base.M.ReadNativeString(base.Address + 448L);

	public unsafe List<float> Values
	{
		get
		{
			List<float> list = new List<float>();
			Struct248 @struct = base.M.FastIntPtrToStruct<Struct248>(base.Address);
			float* ptr = @struct.struct249_0.float_0;
			for (int i = 0; i < 80; i++)
			{
				list.Add(ptr[i]);
			}
			return list;
		}
	}
}
