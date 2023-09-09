using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Quality : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct200
	{
		public Struct253 struct253_0;

		public long intptr_SubStructure;

		public int itemQuality;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct201
	{
		public long intptr_0;

		public long intptr_1;

		public int maxQuality;
	}

	private PerFrameCachedValue<Struct200> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct201> perFrameCachedValue_2;

	public int ItemQuality => Struct200_0.itemQuality;

	public int MaxQuality => Struct201_0.maxQuality;

	internal Struct200 Struct200_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct200>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct201 Struct201_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct201>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	public Quality()
	{
	}

	public Quality(long address)
	{
		base.Address = address;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}] QualityComponent"));
		stringBuilder.AppendLine($"\tQuality: {ItemQuality}");
		stringBuilder.AppendLine($"\tMaxQuality: {MaxQuality}");
		return stringBuilder.ToString();
	}

	private Struct200 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct200>(base.Address);
	}

	private Struct201 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct201>(Struct200_0.intptr_SubStructure);
	}
}
