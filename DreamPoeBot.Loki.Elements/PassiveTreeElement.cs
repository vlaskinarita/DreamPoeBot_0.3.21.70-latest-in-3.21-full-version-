using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class PassiveTreeElement : Element
{
	public class AscendencyUi
	{
		internal long IntPtr_0 => GameController.Instance.Game.IngameState.IngameUi.TreePanel.IntPtr_3_AscendUi;

		public bool IsOpened => LokiPoe.Class112InGameUi.smethod_15IsVisible(IntPtr_0);

		public bool IsUnlocked => LokiPoe.Class112InGameUi.smethod_15IsVisible(GameController.Instance.Game.IngameState.IngameUi.TreePanel.IntPtr_IsAscendUiUnlocked);
	}

	public class MasteryUiElemet : Element
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct MasteryUiElemetStruct
		{
			private long intptr_vTable;

			private long intptr_1;

			public long intptr_2ThisPassivePointStruct;

			private long intptr_3PassiveIds;

			private int int_1PassiveCount;

			private int int_2;

			private long intptr_4UnknownIds;

			private int int_1UnknownCount;

			private int int_3;

			private long intptr_4;

			public NativeVector PassiveSkillMasteryEffectsListStructureVector;

			private long intptr_6;

			private long intptr_7;

			public NativeVector SelectButtoncontrolsListVector;

			private long intptr_8;

			private long intptr_9;

			private long intptr_10;

			private long intptr_11;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct PassiveSkillMasteryEffectsListStructure
		{
			public long PassiveSkillMasteryEffectsStructData;

			private long PassiveSkillMasteryEffectsFile;

			private int int_1;

			private int int_2;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct PassiveSkillMasteryEffectsStruct
		{
			public long intptr_Id;

			public int int_1Hash;

			private int int_2Stats_Count;

			private int int_3;

			private long intptr_4Stats;

			private int StatValue1;

			private int StatValue2;

			private int StatValue3;

			private long intptr_8AchievementsData;

			private long intptr_9AchievementsFile;
		}

		private MasteryUiElemetStruct MasteryUiElemetStruct_0 => LokiPoe.Memory.FastIntPtrToStruct<MasteryUiElemetStruct>(base.Address + 552L);

		public long PassivePointAddress => MasteryUiElemetStruct_0.intptr_2ThisPassivePointStruct;

		public List<PassiveSkillMasteryEffectsStruct> PassiveSkillMasteryEffects
		{
			get
			{
				List<PassiveSkillMasteryEffectsStruct> list = new List<PassiveSkillMasteryEffectsStruct>();
				int size = MarshalCache<PassiveSkillMasteryEffectsListStructure>.Size;
				NativeVector passiveSkillMasteryEffectsListStructureVector = MasteryUiElemetStruct_0.PassiveSkillMasteryEffectsListStructureVector;
				for (long num = passiveSkillMasteryEffectsListStructureVector.First; num != passiveSkillMasteryEffectsListStructureVector.Last; num += size)
				{
					PassiveSkillMasteryEffectsListStructure passiveSkillMasteryEffectsListStructure = LokiPoe.Memory.FastIntPtrToStruct<PassiveSkillMasteryEffectsListStructure>(num);
					list.Add(LokiPoe.Memory.FastIntPtrToStruct<PassiveSkillMasteryEffectsStruct>(passiveSkillMasteryEffectsListStructure.PassiveSkillMasteryEffectsStructData));
				}
				return list;
			}
		}

		public List<MasteryButtonContainer> ButtonsContainers
		{
			get
			{
				List<MasteryButtonContainer> list = new List<MasteryButtonContainer>();
				NativeVector selectButtoncontrolsListVector = MasteryUiElemetStruct_0.SelectButtoncontrolsListVector;
				for (long num = selectButtoncontrolsListVector.First; num != selectButtoncontrolsListVector.Last; num += 8L)
				{
					list.Add(LokiPoe.Memory.GetObject<MasteryButtonContainer>(LokiPoe.Memory.ReadLong(num)));
				}
				return list;
			}
		}
	}

	public class MasteryButtonContainer : Element
	{
		public Vector2i MasteryButtonCenterClickLocation()
		{
			float num = base.X * base.Scale;
			float num2 = base.Y * base.Scale;
			Element element = base.Children[0];
			num += element.X * element.Scale;
			num2 += element.Y * element.Scale;
			Element element2 = element.Children[1];
			num += (element2.X + element2.Width / 4f) * element2.Scale;
			num2 += (element2.Y + element2.Height) * element2.Scale;
			return new Vector2i((int)num, (int)num2);
		}
	}

	public Element SkillsPassiveMap => base.Children[1];

	public Element RefundPassivesButtonElement => base.Children[3].Children[0].Children[3];

	public Element ApplyButtonElement => base.Children[3].Children[1].Children[0];

	public Element CancelButtonElement => base.Children[3].Children[1].Children[1];

	public Element ResetAllPassivesElement => base.Children[3].Children[2];

	public MasteryUiElemet MasteryUi
	{
		get
		{
			MasteryUiElemet @object = LokiPoe.Memory.GetObject<MasteryUiElemet>(IntPtr_MasteryUi);
			if (!(@object == null))
			{
				return @object;
			}
			return null;
		}
	}

	internal long IntPtr_Main => base.Address;

	internal long IntPtr_2_SkillsPassiveMap => SkillsPassiveMap.Address;

	public long IntPtr_3_AscendUi => LokiPoe.Memory.ReadLong(IntPtr_2_SkillsPassiveMap + 5392L);

	public long IntPtr_MasteryUi => LokiPoe.Memory.ReadLong(IntPtr_2_SkillsPassiveMap + 5568L);

	public long IntPtr_IsAscendUiUnlocked => LokiPoe.Memory.ReadLong(IntPtr_2_SkillsPassiveMap + 5392L + 16L);

	public Dictionary<int, long> Dictionary_0Passive => Containers.StdInt_LongHashMap<int, long>(LokiPoe.Memory.FastIntPtrToStruct<NativeHashMap>(IntPtr_2_SkillsPassiveMap + 4792L));

	internal Dictionary<int, long> Dictionary_1Ascend => Containers.StdInt_LongHashMap<int, long>(LokiPoe.Memory.FastIntPtrToStruct<NativeHashMap>(IntPtr_3_AscendUi + 4792L));

	private float Zoom
	{
		get
		{
			Element @object = LokiPoe.Memory.GetObject<Element>(IntPtr_2_SkillsPassiveMap);
			if (!(@object == null))
			{
				return @object.Scale;
			}
			return 0f;
		}
	}

	public bool IsMaxZoomIn
	{
		get
		{
			if (Zoom != 0f)
			{
				return (double)Zoom > 0.24;
			}
			return false;
		}
	}

	public bool IsMaxZoomOut
	{
		get
		{
			if (Zoom != 0f)
			{
				return (double)Zoom < 0.09;
			}
			return false;
		}
	}

	public bool IsApplyEnabled => ApplyButtonElement.IsEnable;

	public bool IsApplyVisible => ApplyButtonElement.IsVisible;

	public bool IsCancelEnabled => CancelButtonElement.IsEnable;

	public bool IsCancelVisible => CancelButtonElement.IsVisible;

	public bool IsRefundPassivesEnabled => RefundPassivesButtonElement.IsEnable;

	public bool IsRefundPassivesVisible => RefundPassivesButtonElement.IsVisible;

	public bool IsResetAllPassivesEnabled => ResetAllPassivesElement.IsEnable;

	public bool IsResetAllPassivesVisible => ResetAllPassivesElement.IsVisible;

	public Dictionary<DatPassiveSkillWrapper, Element> PasDict
	{
		get
		{
			Dictionary<DatPassiveSkillWrapper, Element> dictionary = new Dictionary<DatPassiveSkillWrapper, Element>();
			Dat.BuildPassinveLookupTable();
			foreach (KeyValuePair<int, long> item in Dictionary_0Passive)
			{
				DatPassiveSkillWrapper key = Dat.dictionary_IdToPassiveSkillWrapper[item.Key];
				Element elementAt = GetElementAt(item.Value);
				dictionary.Add(key, elementAt);
			}
			return dictionary;
		}
	}

	public Vector2i ClickLocationFor(long intPtr)
	{
		Element elementAt = GetElementAt(intPtr);
		return LokiPoe.ElementClickLocation(elementAt);
	}

	public Element GetElementAt(long intPtr)
	{
		return base.M.GetObject<Element>(intPtr);
	}
}
