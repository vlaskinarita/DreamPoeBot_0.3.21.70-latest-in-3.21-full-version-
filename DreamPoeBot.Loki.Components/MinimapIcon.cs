using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class MinimapIcon : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct175
	{
		private long vTable;

		public long metadata;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private long intptr_0;

		public long intptr_2MinimapIcon;

		private long intptr_1;

		private int unusedInt1;

		public byte byte_4IsVisible;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;
	}

	private PerFrameCachedValue<Struct175> perFrameCachedValue_1;

	private Struct175 Struct175_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct175>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public DatMinimapIconWrapper Minimapicon => Dat.smethod_60(Struct175_0.intptr_2MinimapIcon, bool_0: true);

	public bool IsVisible => Struct175_0.byte_4IsVisible == 0;

	public string Metadata
	{
		get
		{
			long num = base.M.ReadLong(Struct175_0.metadata + 8L);
			NativeStringWCustom nativeString = base.M.IntptrToNativeStringWCustom(num + 8L);
			return Containers.StdStringWCustom(nativeString);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "MinimapIcon Component"));
		stringBuilder.AppendLine($"IsVisible: {IsVisible}");
		DatMinimapIconWrapper minimapicon = Minimapicon;
		if (minimapicon != null)
		{
			stringBuilder.AppendLine($"MinimapIcon Name: {minimapicon.Name}");
			stringBuilder.AppendLine($"Metadata: {Metadata}");
		}
		return stringBuilder.ToString();
	}

	private Struct175 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct175>(base.Address);
	}
}
