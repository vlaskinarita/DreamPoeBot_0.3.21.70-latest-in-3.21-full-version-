using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class GrandHeistContractElement : Element
{
	public class Job
	{
		private Element _element;

		public HeistJobs HeistJob
		{
			get
			{
				string value = LokiPoe.Memory.ReadString(LokiPoe.Memory.ReadLong(_element.Address + 1096L, default(long)));
				if (Enum.TryParse<HeistJobs>(value, out var result))
				{
					return result;
				}
				return HeistJobs.None;
			}
		}

		public int Level => LokiPoe.Memory.ReadInt(_element.Address + 1112L);

		public bool Assigned => (ulong)LokiPoe.Memory.ReadLong(_element.Address + 1120L) > 0uL;

		public Job(Element element)
		{
			_element = element;
		}
	}

	public enum HeistJobs
	{
		Lockpicking,
		BruteForce,
		Perception,
		Demolition,
		CounterThaumaturge,
		TrapDisarmament,
		Agility,
		Deception,
		Engineering,
		None
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ChronicleofAtzoatlStructure
	{
		public long vTable;

		public long intptr_Owner;

		public long intptr_0;

		public int AreaLevel;

		public int int_0;

		public IncursionTemple.Struct_rooms Rooms;
	}

	public Element ContractFeesElement
	{
		get
		{
			if (base.ChildCount < 2L)
			{
				return null;
			}
			return base.Children[1];
		}
	}

	public Element ConfirmPlanElement
	{
		get
		{
			if (base.ChildCount < 6L)
			{
				return null;
			}
			return base.Children[5];
		}
	}

	public Element ItemElement
	{
		get
		{
			if (base.ChildCount < 7L)
			{
				return null;
			}
			return base.Children[6];
		}
	}

	public Element AgentsElement
	{
		get
		{
			if (base.ChildCount < 1L)
			{
				return null;
			}
			return base.Children[0].Children[0].Children[0].Children[0].Children[5];
		}
	}

	private int TravelFee
	{
		get
		{
			string text = ContractFeesElement.Children[1].Children[3].Children[0].Children[1].Children[0].Text;
			if (int.TryParse(text, out var result))
			{
				return result;
			}
			return 0;
		}
	}

	private int HiringFee
	{
		get
		{
			string text = ContractFeesElement.Children[1].Children[3].Children[1].Children[1].Children[0].Text;
			if (!int.TryParse(text, out var result))
			{
				return 0;
			}
			return result;
		}
	}

	private int TheRingCutFee
	{
		get
		{
			string text = ContractFeesElement.Children[1].Children[3].Children[2].Children[1].Children[0].Text;
			if (int.TryParse(text, out var result))
			{
				return result;
			}
			return 0;
		}
	}

	private int TotalFee
	{
		get
		{
			string text = ContractFeesElement.Children[1].Children[3].Children[3].Children[1].Children[0].Text;
			if (int.TryParse(text, out var result))
			{
				return result;
			}
			return 0;
		}
	}
}
