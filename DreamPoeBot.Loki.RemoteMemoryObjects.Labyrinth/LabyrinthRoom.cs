using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects.Labyrinth;

public class LabyrinthRoom
{
	public class LabyrinthSecret
	{
		public string SecretName { get; internal set; }

		public string Name { get; internal set; }

		public override string ToString()
		{
			return SecretName;
		}
	}

	public class LabyrinthSection
	{
		public string SectionType { get; internal set; }

		public List<LabyrinthSectionOverrides> Overrides { get; internal set; } = new List<LabyrinthSectionOverrides>();


		public LabyrinthSectionAreas SectionAreas { get; internal set; }

		internal LabyrinthSection(Memory M, long addr)
		{
			SectionType = M.ReadStringU(M.ReadLong(addr + 8L, default(long)));
			int num = M.ReadInt(addr + 92L);
			long startAddress = M.ReadLong(addr + 100L);
			List<long> list = M.ReadSecondPointerArray_Count(startAddress, num);
			for (int i = 0; i < num; i++)
			{
				LabyrinthSectionOverrides labyrinthSectionOverrides = new LabyrinthSectionOverrides();
				long num2 = list[i];
				labyrinthSectionOverrides.OverrideName = M.ReadStringU(M.ReadLong(num2));
				labyrinthSectionOverrides.Name = M.ReadStringU(M.ReadLong(num2 + 8L));
				Overrides.Add(labyrinthSectionOverrides);
			}
			SectionAreas = new LabyrinthSectionAreas();
			long num3 = M.ReadLong(addr + 76L);
			SectionAreas.Name = M.ReadStringU(M.ReadLong(num3));
			int count = M.ReadInt(num3 + 8L);
			long startAddress2 = M.ReadLong(num3 + 16L);
			SectionAreas.NormalAreasPtrs = M.ReadSecondPointerArray_Count(startAddress2, count);
			int count2 = M.ReadInt(num3 + 24L);
			long startAddress3 = M.ReadLong(num3 + 32L);
			SectionAreas.CruelAreasPtrs = M.ReadSecondPointerArray_Count(startAddress3, count2);
			int count3 = M.ReadInt(num3 + 40L);
			long startAddress4 = M.ReadLong(num3 + 48L);
			SectionAreas.MercilesAreasPtrs = M.ReadSecondPointerArray_Count(startAddress4, count3);
			int count4 = M.ReadInt(num3 + 56L);
			long startAddress5 = M.ReadLong(num3 + 64L);
			SectionAreas.EndgameAreasPtrs = M.ReadSecondPointerArray_Count(startAddress5, count4);
		}

		public override string ToString()
		{
			string text = "";
			if (Overrides.Count > 0)
			{
				text = "Overrides: " + string.Join(", ", Overrides.Select((LabyrinthSectionOverrides x) => x.ToString()).ToArray());
			}
			return "SectionType: " + SectionType + ", " + text;
		}
	}

	public class LabyrinthSectionAreas
	{
		internal List<long> NormalAreasPtrs = new List<long>();

		internal List<long> CruelAreasPtrs = new List<long>();

		internal List<long> MercilesAreasPtrs = new List<long>();

		internal List<long> EndgameAreasPtrs = new List<long>();

		private List<WorldArea> normalAreas;

		private List<WorldArea> cruelAreas;

		private List<WorldArea> mercilesAreas;

		private List<WorldArea> endgameAreas;

		public string Name { get; internal set; }

		public List<WorldArea> NormalAreas
		{
			get
			{
				if (normalAreas == null)
				{
					normalAreas = NormalAreasPtrs.Select((long x) => GameController.Instance.Files.WorldAreas.GetByAddress(x)).ToList();
				}
				return normalAreas;
			}
		}

		public List<WorldArea> CruelAreas
		{
			get
			{
				if (cruelAreas == null)
				{
					cruelAreas = CruelAreasPtrs.Select((long x) => GameController.Instance.Files.WorldAreas.GetByAddress(x)).ToList();
				}
				return cruelAreas;
			}
		}

		public List<WorldArea> MercilesAreas
		{
			get
			{
				if (mercilesAreas == null)
				{
					mercilesAreas = MercilesAreasPtrs.Select((long x) => GameController.Instance.Files.WorldAreas.GetByAddress(x)).ToList();
				}
				return mercilesAreas;
			}
		}

		public List<WorldArea> EndgameAreas
		{
			get
			{
				if (endgameAreas == null)
				{
					endgameAreas = EndgameAreasPtrs.Select((long x) => GameController.Instance.Files.WorldAreas.GetByAddress(x)).ToList();
				}
				return endgameAreas;
			}
		}
	}

	public class LabyrinthSectionOverrides
	{
		public string Name { get; internal set; }

		public string OverrideName { get; internal set; }

		public override string ToString()
		{
			return OverrideName;
		}
	}

	private long Address;

	private Memory M;

	public int Id { get; internal set; }

	public LabyrinthSecret Secret1 { get; internal set; }

	public LabyrinthSecret Secret2 { get; internal set; }

	public LabyrinthRoom[] Connections { get; internal set; }

	public LabyrinthSection Section { get; internal set; }

	internal LabyrinthRoom(Memory m, long address)
	{
		M = m;
		Address = address;
		Secret1 = ReadSecret(M.ReadLong(Address + 64L));
		Secret2 = ReadSecret(M.ReadLong(Address + 80L));
		Section = ReadSection(M.ReadLong(Address + 48L));
		List<long> source = M.ReadPointersArray(Address, Address + 32L);
		Connections = source.Select((long x) => (x != 0L) ? LabyrinthData.GetRoomById(x) : null).ToArray();
	}

	internal LabyrinthSection ReadSection(long addr)
	{
		if (addr == 0L)
		{
			return null;
		}
		return new LabyrinthSection(M, addr);
	}

	private LabyrinthSecret ReadSecret(long addr)
	{
		M.ReadLong(addr);
		if (addr != 0L)
		{
			LabyrinthSecret labyrinthSecret = new LabyrinthSecret();
			labyrinthSecret.SecretName = M.ReadStringU(M.ReadLong(addr));
			labyrinthSecret.Name = M.ReadStringU(M.ReadLong(addr + 8L));
			return labyrinthSecret;
		}
		return null;
	}

	public override string ToString()
	{
		string text = "";
		List<LabyrinthRoom> list = Connections.Where((LabyrinthRoom r) => r != null).ToList();
		if (list.Count > 0)
		{
			text = "LinkedWith: " + string.Join(", ", list.Select((LabyrinthRoom x) => x.Id.ToString()).ToArray());
		}
		return $"Id: {Id}, " + string.Format("Secret1: {0}, Secret2: {1}, {2}, Section: {3}", (Secret1 == null) ? "None" : Secret1.SecretName, (Secret2 == null) ? "None" : Secret2.SecretName, text, Section);
	}
}
