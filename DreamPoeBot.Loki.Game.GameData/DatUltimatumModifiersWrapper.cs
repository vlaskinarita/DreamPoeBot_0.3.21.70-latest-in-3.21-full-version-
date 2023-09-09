using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatUltimatumModifiersWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct UltimatumModifiersStruct
	{
		public long intptr_Id;

		private int int_0;

		private int int_1;

		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private int int_2;

		private byte byte_0;

		public long intptr_Text;

		public long intptr_ARTPath;

		private int int_3;

		private int int_4;

		private int int_5;

		private long intptr_Key2;

		private int int_6;

		private int int_7;

		private int int_8;

		private int int_9;

		private int int_10;

		private int int_11;

		private int int_12;

		private int int_13;

		private int int_14;

		private int int_15;

		private int int_16;

		public long intptr_Description;

		private int int_17;

		private int int_18;

		private long intptr_Key6;

		private int int_19;

		private int int_20;

		private byte byte_1;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;
	}

	public string Id { get; set; }

	public string Text { get; set; }

	public string Description { get; set; }

	public string ARTPath { get; set; }

	internal Memory M => GameController.Instance.Memory;

	internal UltimatumModifiersStruct ultimatumModifiersStruct { get; set; }

	internal long Address { get; private set; }

	public DatUltimatumModifiersWrapper(long address)
	{
		Address = address;
		ultimatumModifiersStruct = M.FastIntPtrToStruct<UltimatumModifiersStruct>(address);
		Id = M.ReadStringU(ultimatumModifiersStruct.intptr_Id);
		Text = M.ReadStringU(ultimatumModifiersStruct.intptr_Text);
		Description = M.ReadStringU(ultimatumModifiersStruct.intptr_Description);
		ARTPath = M.ReadStringU(ultimatumModifiersStruct.intptr_ARTPath);
	}
}
