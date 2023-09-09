using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class DiagnosticElementNew
{
	[StructLayout(LayoutKind.Sequential, Size = 4476)]
	[UnsafeValueType]
	public struct RowGraphData
	{
		public unsafe fixed float data[1119];
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct GraphData
	{
		public SimpleGraphData data0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct SimpleGraphData
	{
		public float float0;

		public float cpuTime;

		public float gpuTime;

		public float latency;

		public float frameTime;

		public float float5;

		public float float6;

		public float float7;

		public float float8;

		public float float9;

		public float float10;

		public float float11;

		public float float12;

		public float float13;
	}

	private Memory M = GameController.Instance.Memory;

	public unsafe List<float> LatencyValues
	{
		get
		{
			List<float> list = new List<float>();
			RowGraphData rowGraphData = M.FastIntPtrToStruct<RowGraphData>(M.AddressOfProcess + M.offsets.DiagnosticElementOffset);
			float* ptr = rowGraphData.data;
			for (int i = 3; i < 1119; i += 14)
			{
				list.Add(ptr[i]);
			}
			return list;
		}
	}

	public unsafe List<float> FrameTimeValues
	{
		get
		{
			List<float> list = new List<float>();
			RowGraphData rowGraphData = M.FastIntPtrToStruct<RowGraphData>(M.AddressOfProcess + M.offsets.DiagnosticElementOffset);
			float* ptr = rowGraphData.data;
			for (int i = 4; i < 1119; i += 14)
			{
				list.Add(ptr[i]);
			}
			return list;
		}
	}

	public unsafe List<float> FPSValues
	{
		get
		{
			List<float> list = new List<float>();
			RowGraphData rowGraphData = M.FastIntPtrToStruct<RowGraphData>(M.AddressOfProcess + M.offsets.DiagnosticElementOffset);
			float* ptr = rowGraphData.data;
			for (int i = 4; i < 1119; i += 14)
			{
				list.Add(1000f / ptr[i]);
			}
			return list;
		}
	}
}
