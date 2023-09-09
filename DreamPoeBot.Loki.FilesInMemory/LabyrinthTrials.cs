using System.Linq;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class LabyrinthTrials : UniversalFileWrapper<LabyrinthTrial>
{
	public static string[] LabyrinthTrialAreaIds = new string[18]
	{
		"1_1_7_1", "1_2_5_1", "1_2_6_2", "1_3_3_1", "1_3_6", "1_3_15", "2_6_7_1", "2_7_4", "2_7_5_2", "2_8_5",
		"2_9_7", "2_10_9", "EndGame_Labyrinth_trials_spikes", "EndGame_Labyrinth_trials_spinners", "EndGame_Labyrinth_trials_sawblades_#", "EndGame_Labyrinth_trials_lava_#", "EndGame_Labyrinth_trials_roombas", "EndGame_Labyrinth_trials_arrows"
	};

	public LabyrinthTrials(Memory m, long address)
		: base(m, address)
	{
	}

	public LabyrinthTrial GetLabyrinthTrialByAreaId(string id)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Area.Id == id);
	}

	public LabyrinthTrial GetLabyrinthTrialById(int index)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Id == index);
	}

	public LabyrinthTrial GetLabyrinthTrialByArea(WorldArea area)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Area == area);
	}
}
