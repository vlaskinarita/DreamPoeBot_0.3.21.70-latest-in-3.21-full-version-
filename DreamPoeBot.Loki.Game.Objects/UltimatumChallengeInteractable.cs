using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.Objects;

public class UltimatumChallengeInteractable : NetworkObject
{
	public enum BeginTrialResult
	{
		None,
		UiNotVisible,
		OptionNotSelected,
		ProcessHookManagerNotEnabled
	}

	public enum SelectOptionResult
	{
		None,
		UiNotVisible,
		OptionNotPresent,
		OptionElementNotFound,
		ProcessHookManagerNotEnabled
	}

	internal UltimatumChallengeElement Ui
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (label == null)
			{
				return null;
			}
			return label.GetObjectAt<UltimatumChallengeElement>(0);
		}
	}

	public bool IsInterfaceVisible => Ui.IsVisible;

	public string TrialTitle => Ui.Title;

	public Item RewardItem => Ui.RewardItem.FirstOrDefault();

	public List<DatUltimatumModifiersWrapper> Options
	{
		get
		{
			List<DatUltimatumModifiersWrapper> list = new List<DatUltimatumModifiersWrapper>();
			List<KeyValuePair<long, long>> list2 = Containers.StdIntPtr_IntPtrVector(Ui.OptionsVector);
			foreach (KeyValuePair<long, long> item in list2)
			{
				list.Add(new DatUltimatumModifiersWrapper(item.Key));
			}
			return list;
		}
	}

	public DatUltimatumModifiersWrapper SelectedOption
	{
		get
		{
			int selectedOption = Ui.SelectedOption;
			List<DatUltimatumModifiersWrapper> options = Options;
			if (selectedOption != -1)
			{
				return options[selectedOption];
			}
			return null;
		}
	}

	internal List<string> ActiveStage
	{
		get
		{
			List<string> list = new List<string>();
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (!(component == null))
			{
				foreach (StateMachine.StageState stageState in component.StageStates)
				{
					list.Add(string.Format("{0} {1}", stageState.Name, stageState.IsActive ? "Active" : "Unactive"));
				}
				return list;
			}
			return list;
		}
	}

	public bool IsTrialActive
	{
		get
		{
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (component == null)
			{
				return false;
			}
			return component.Encounter_Started;
		}
	}

	public bool IsTrialCompleted
	{
		get
		{
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (component == null)
			{
				return false;
			}
			return component.Encounter_Finished;
		}
	}

	internal UltimatumChallengeInteractable(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public BeginTrialResult BeginTrial()
	{
		if (!Hooking.IsInstalled)
		{
			return BeginTrialResult.ProcessHookManagerNotEnabled;
		}
		if (Ui.IsVisible)
		{
			if (Ui.SelectedOption != -1)
			{
				Vector2i pos = LokiPoe.ElementClickLocation(Ui.BeginButton);
				MouseManager.SetMousePosition(pos);
				Thread.Sleep(100);
				MouseManager.ClickLMB(pos.X, pos.Y);
				Thread.Sleep(200);
				return BeginTrialResult.None;
			}
			return BeginTrialResult.OptionNotSelected;
		}
		return BeginTrialResult.UiNotVisible;
	}

	public SelectOptionResult SelectOption(DatUltimatumModifiersWrapper option)
	{
		if (Hooking.IsInstalled)
		{
			if (Ui.IsVisible)
			{
				if (!Options.All((DatUltimatumModifiersWrapper x) => x.Id != option.Id))
				{
					if (Ui.OptionElementsDictionary.TryGetValue(option.Address, out var value))
					{
						Vector2i pos = LokiPoe.ElementClickLocation(value);
						MouseManager.SetMousePosition(pos);
						Thread.Sleep(100);
						MouseManager.ClickLMB(pos.X, pos.Y);
						Thread.Sleep(200);
						return SelectOptionResult.None;
					}
					return SelectOptionResult.OptionElementNotFound;
				}
				return SelectOptionResult.OptionNotPresent;
			}
			return SelectOptionResult.UiNotVisible;
		}
		return SelectOptionResult.ProcessHookManagerNotEnabled;
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Ultimatum:]");
		stringBuilder.AppendLine($"\tIsActive: {IsTrialActive}");
		stringBuilder.AppendLine($"\tIsCompleted: {IsTrialCompleted}");
		stringBuilder.AppendLine(string.Format("\tUser Interface: {0}, IsVisible: {1}", Ui.Address.ToString("X"), Ui.IsVisible));
		stringBuilder.AppendLine($"\t[ActiveStage]");
		foreach (string item in ActiveStage)
		{
			stringBuilder.AppendLine($"\t\t{item}");
		}
		stringBuilder.AppendLine($"\t[Options]");
		foreach (DatUltimatumModifiersWrapper option in Options)
		{
			stringBuilder.AppendLine($"\t\t{option.Text} [Id: {option.Id}]");
		}
		stringBuilder.AppendLine(string.Format("\tSelected Option: {0}", (SelectedOption == null) ? "None" : (SelectedOption.Text + " [Id: " + SelectedOption.Id + "]")));
		return stringBuilder.ToString();
	}
}
