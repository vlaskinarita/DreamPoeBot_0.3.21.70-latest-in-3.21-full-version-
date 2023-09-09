using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class WorldDescription : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct300
	{
		public Struct253 struct253_0;

		public long intPtr1;

		public long intPtr2;

		public long intPtr3;

		public long intPtr4;

		public long intPtr5;

		public long intPtr6;

		public long intPtr7;

		public long intPtr8;

		public long intPtr9;

		public long intPtr10;

		public long intPtr11;

		public long intPtr12;

		public long intPtr13;

		public long intPtr14;

		public long intPtr15;

		public long intPtr16;

		public long intPtr17;

		public NativeStringWCustom StringWCustom5;

		public NativeStringWCustom StringWCustom6;

		public NativeStringWCustom StringWCustom7;

		public NativeStringWCustom Title;

		public NativeStringWCustom Text;
	}

	private PerFrameCachedValue<Struct300> perFrameCachedValue_1;

	public string Title => Containers.StdStringWCustom(Struct300_0.Title);

	public string Text => Containers.StdStringWCustom(Struct300_0.Text);

	internal Struct300 Struct300_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct300>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct300 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct300>(base.Address);
	}
}
