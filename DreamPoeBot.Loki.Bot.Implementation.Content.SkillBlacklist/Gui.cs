using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Bot.Implementation.Content.SkillBlacklist;

public partial class Gui : UserControl, IComponentConnector, IStyleConnector
{
	[CompilerGenerated]
	private sealed class Class507
	{
		public string string_0;

		internal bool method_0(SkillName skillName_0)
		{
			return skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class Class508
	{
		public ushort ushort_0;

		internal bool method_0(SkillId skillId_0)
		{
			return skillId_0.Id == ushort_0;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class Class509
	{
		public static readonly Class509 Class9 = new Class509();

		public static Func<Skill, bool> Method9__9_0;

		public static Func<Skill, ushort> Method9__9_1;

		public static Func<Skill, string> Method9__9_2;

		public static Func<Skill, bool> Method9__10_0;

		public static Func<Skill, ushort> Method9__10_1;

		public static Func<Skill, string> Method9__10_2;

		public static Func<KeyValuePair<ushort, string>, PlayerSkillWrapper> Method9__12_0;

		internal bool method_0(Skill skill_0)
		{
			return skill_0.ActiveSkill != null;
		}

		internal ushort method_1(Skill skill_0)
		{
			return skill_0.Id;
		}

		internal string method_2(Skill skill_0)
		{
			return skill_0.DisplayString;
		}

		internal bool method_3(Skill skill_0)
		{
			return skill_0.ActiveSkill != null;
		}

		internal ushort method_4(Skill skill_0)
		{
			return skill_0.Id;
		}

		internal string method_5(Skill skill_0)
		{
			return skill_0.DisplayStringNoId;
		}

		internal PlayerSkillWrapper method_6(KeyValuePair<ushort, string> keyValuePair_0)
		{
			return new PlayerSkillWrapper
			{
				Text = keyValuePair_0.Value,
				Id = keyValuePair_0.Key
			};
		}
	}

	[CompilerGenerated]
	private sealed class Class510
	{
		public string string_0;

		internal bool method_0(SkillName skillName_0)
		{
			return skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class Class511
	{
		public ushort ushort_0;

		internal bool method_0(SkillId skillId_0)
		{
			return skillId_0.Id == ushort_0;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private DreamPoeBot.Loki.Bot.SkillBlacklist skillBlacklist_0;

	public Gui(DreamPoeBot.Loki.Bot.SkillBlacklist owner)
	{
		InitializeComponent();
		skillBlacklist_0 = owner;
	}

	private DataGridRow method_0(object object_0)
	{
		DependencyObject dependencyObject = object_0 as DependencyObject;
		while (dependencyObject != null && !(dependencyObject is DataGridRow))
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
		}
		return dependencyObject as DataGridRow;
	}

	private static T smethod_0<T>(Visual visual_0) where T : Visual
	{
		T val = null;
		int childrenCount = VisualTreeHelper.GetChildrenCount(visual_0);
		for (int i = 0; i < childrenCount; i++)
		{
			Visual visual = (Visual)VisualTreeHelper.GetChild(visual_0, i);
			val = visual as T;
			if (val == null)
			{
				val = smethod_0<T>(visual);
			}
			if (val != null)
			{
				break;
			}
		}
		return val;
	}

	public static DataGridRow GetRow(DataGrid dataGrid, int index)
	{
		if (dataGrid == null)
		{
			return null;
		}
		if (index >= 0 && index < dataGrid.Items.Count)
		{
			DataGridRow dataGridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(index);
			if (dataGridRow == null)
			{
				dataGrid.UpdateLayout();
				dataGrid.ScrollIntoView(dataGrid.Items[index]);
				dataGridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(index);
			}
			return dataGridRow;
		}
		return null;
	}

	public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
	{
		if (dataGrid == null)
		{
			return null;
		}
		if (rowContainer == null)
		{
			return null;
		}
		if (column >= 0 && column < dataGrid.Columns.Count)
		{
			DataGridCellsPresenter dataGridCellsPresenter = smethod_0<DataGridCellsPresenter>(rowContainer);
			DataGridCell dataGridCell = (DataGridCell)dataGridCellsPresenter.ItemContainerGenerator.ContainerFromIndex(column);
			if (dataGridCell == null)
			{
				dataGrid.UpdateLayout();
				dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
				dataGridCell = (DataGridCell)dataGridCellsPresenter.ItemContainerGenerator.ContainerFromIndex(column);
			}
			return dataGridCell;
		}
		return null;
	}

	private void method_1DeleteName(object sender, RoutedEventArgs e)
	{
		if (!(sender is Button))
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillName_Click] btn == null");
			return;
		}
		DataGridRow dataGridRow = method_0(sender);
		if (dataGridRow != null)
		{
			DataGridCell cell = GetCell(SkillNameBlacklistDataGrid, dataGridRow, 1);
			if (cell != null)
			{
				if (cell.Content is TextBlock textBlock && textBlock.Text != null)
				{
					string string_0 = textBlock.Text;
					ObservableCollection<SkillName> blacklistedSkillNames = SkillBlacklistSettings.Instance.BlacklistedSkillNames;
					SkillName skillName = blacklistedSkillNames.FirstOrDefault((SkillName skillName_0) => skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase));
					if (skillName == null)
					{
						ilog_0.ErrorFormat("[SkillBlacklist.ButtonDeleteSkillName_Click] Could not find an SkillName object with Name [{0}].", (object)string_0);
					}
					else if (!blacklistedSkillNames.Remove(skillName))
					{
						ilog_0.ErrorFormat("[SkillBlacklist.ButtonDeleteSkillName_Click] Could not remove the SkillName object from the ObservableCollection for [{0}].", (object)string_0);
					}
				}
			}
			else
			{
				ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillName_Click] idCell == null");
			}
		}
		else
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillName_Click] row == null");
		}
	}

	private void method_2DeleteId(object sender, RoutedEventArgs e)
	{
		if (!(sender is Button))
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillId_Click] btn == null");
			return;
		}
		DataGridRow dataGridRow = method_0(sender);
		if (dataGridRow != null)
		{
			DataGridCell cell = GetCell(SkillBlacklistDataGrid, dataGridRow, 1);
			ushort ushort_0;
			if (cell == null)
			{
				ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillId_Click] idCell == null");
			}
			else if (cell.Content is TextBlock textBlock && textBlock.Text != null && ushort.TryParse(textBlock.Text, out ushort_0))
			{
				SkillId skillId = SkillBlacklistSettings.Instance.BlacklistedSkillIds.FirstOrDefault((SkillId skillId_0) => skillId_0.Id == ushort_0);
				if (skillId == null)
				{
					ilog_0.ErrorFormat("[SkillBlacklist.ButtonDeleteSkillId_Click] Could not find an SkillId object with Id [{0}].", (object)ushort_0);
				}
				else if (!SkillBlacklistSettings.Instance.BlacklistedSkillIds.Remove(skillId))
				{
					ilog_0.ErrorFormat("[SkillBlacklist.ButtonDeleteSkillId_Click] Could not remove the SkillId object from the ObservableCollection for [{0}].", (object)ushort_0);
				}
			}
		}
		else
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonDeleteSkillId_Click] row == null");
		}
	}

	private Dictionary<ushort, string> method_3()
	{
		if (LokiPoe.IsInGame)
		{
			return LokiPoe.ObjectManager.Me.AvailableSkills.Where((Skill skill_0) => skill_0.ActiveSkill != null).ToDictionary((Skill skill_0) => skill_0.Id, (Skill skill_0) => skill_0.DisplayString);
		}
		return null;
	}

	private Dictionary<ushort, string> method_4()
	{
		if (LokiPoe.IsInGame)
		{
			IEnumerable<Skill> source = LokiPoe.ObjectManager.Me.AvailableSkills.Where((Skill x) => x.ActiveSkill != null);
			return source.ToDictionary((Skill x) => x.Id, (Skill x) => x.DisplayStringNoId);
		}
		return null;
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		Dictionary<ushort, string> dictionary = method_4();
		if (dictionary != null)
		{
			for (int i = 0; i < SkillBlacklistDataGrid.Items.Count; i++)
			{
				DataGridRow row = GetRow(SkillBlacklistDataGrid, i);
				if (row == null)
				{
					ilog_0.Error((object)"[SkillBlacklist.ButtonRefreshBlacklist_Click] row == null");
					continue;
				}
				DataGridCell cell = GetCell(SkillBlacklistDataGrid, row, 1);
				if (cell == null)
				{
					ilog_0.Error((object)"[SkillBlacklist.ButtonRefreshBlacklist_Click] idCell == null");
					continue;
				}
				DataGridCell cell2 = GetCell(SkillBlacklistDataGrid, row, 2);
				if (cell2 == null)
				{
					ilog_0.Error((object)"[SkillBlacklist.ButtonRefreshBlacklist_Click] skillCell == null");
					continue;
				}
				TextBlock textBlock = cell.Content as TextBlock;
				if (textBlock != null && textBlock.Text != null && ushort.TryParse(textBlock.Text, out var result))
				{
					if (!dictionary.TryGetValue(result, out var value))
					{
						cell2.Content = "<missing>";
					}
					else
					{
						cell2.Content = value;
					}
				}
				else if (textBlock != null && !string.IsNullOrEmpty(textBlock.Text))
				{
					cell2.Content = "<invalid>";
				}
				else
				{
					cell2.Content = "";
				}
			}
		}
		else
		{
			ilog_0.WarnFormat("[SkillBlacklist.ButtonRefreshBlacklist_Click] !IsInGame", Array.Empty<object>());
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		SkillBlacklistSettings.Instance.PlayerSkillStrings.Clear();
		Dictionary<ushort, string> dictionary = method_3();
		if (dictionary != null)
		{
			foreach (KeyValuePair<ushort, string> item in dictionary)
			{
				SkillBlacklistSettings.Instance.PlayerSkillStrings.Add(new PlayerSkillWrapper
				{
					Id = item.Key,
					Text = item.Value
				});
			}
			return;
		}
		ilog_0.WarnFormat("[SkillBlacklist.ButtonRefreshSkills_Click] !IsInGame", Array.Empty<object>());
	}

	private void method_5AddName(object sender, RoutedEventArgs e)
	{
		if (!(sender is Button))
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillName_Click] btn == null");
			return;
		}
		DataGridRow dataGridRow = method_0(sender);
		if (dataGridRow == null)
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillName_Click] row == null");
			return;
		}
		DataGridCell cell = GetCell(SkillBlacklistDataGrid, dataGridRow, 2);
		if (cell == null)
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillName_Click] idCell == null");
		}
		else if (cell.Content is TextBlock textBlock && textBlock.Text != null)
		{
			int num = textBlock.Text.IndexOf(']');
			int num2 = textBlock.Text.IndexOf('(');
			if (num != -1 && num2 != -1 && num < num2)
			{
				num++;
				string string_0 = textBlock.Text.Substring(num, num2 - num).Trim();
				if (SkillBlacklistSettings.Instance.BlacklistedSkillNames.FirstOrDefault((SkillName skillName_0) => skillName_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase)) == null)
				{
					SkillBlacklistSettings.Instance.BlacklistedSkillNames.Add(new SkillName
					{
						Name = string_0
					});
				}
				else
				{
					ilog_0.Warn((object)"[SkillBlacklist.ButtonBlacklistSkillName_Click] This skill name is already blacklisted!");
				}
			}
			else
			{
				ilog_0.ErrorFormat("[SkillBlacklist.ButtonBlacklistSkillName_Click] Could not parse the text [{0}]", (object)textBlock.Text);
			}
		}
		else
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillName_Click] idCellContent == null || idCellContent.Text == null");
		}
	}

	private void method_6AddId(object sender, RoutedEventArgs e)
	{
		if (sender is Button)
		{
			DataGridRow dataGridRow = method_0(sender);
			if (dataGridRow == null)
			{
				ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillId_Click] row == null");
				return;
			}
			DataGridCell cell = GetCell(SkillBlacklistDataGrid, dataGridRow, 2);
			if (cell == null)
			{
				ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillId_Click] idCell == null");
			}
			else if (cell.Content is TextBlock textBlock && textBlock.Text != null)
			{
				int num = textBlock.Text.IndexOf('[');
				int num2 = textBlock.Text.IndexOf(']');
				if (num != -1 && num2 != -1 && num < num2)
				{
					num++;
					string text = textBlock.Text.Substring(num, num2 - num);
					if (ushort.TryParse(text, out var ushort_0))
					{
						if (SkillBlacklistSettings.Instance.BlacklistedSkillIds.FirstOrDefault((SkillId skillId_0) => skillId_0.Id == ushort_0) == null)
						{
							SkillBlacklistSettings.Instance.BlacklistedSkillIds.Add(new SkillId
							{
								Id = ushort_0
							});
							button_1_Click(null, null);
						}
						else
						{
							ilog_0.Warn((object)"[SkillBlacklist.ButtonBlacklistSkillId_Click] This skill is already blacklisted!");
						}
					}
					else
					{
						ilog_0.ErrorFormat("[SkillBlacklist.ButtonBlacklistSkillId_Click] Could not parse the text [{0}]", (object)text);
					}
				}
				else
				{
					ilog_0.ErrorFormat("[SkillBlacklist.ButtonBlacklistSkillId_Click] Could not parse the text [{0}]", (object)textBlock.Text);
				}
			}
			else
			{
				ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillId_Click] idCellContent == null || idCellContent.Text == null");
			}
		}
		else
		{
			ilog_0.Error((object)"[SkillBlacklist.ButtonBlacklistSkillId_Click] btn == null");
		}
	}
}
