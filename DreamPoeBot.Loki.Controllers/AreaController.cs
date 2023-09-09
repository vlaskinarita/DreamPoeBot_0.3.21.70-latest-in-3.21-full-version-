using System;
using DreamPoeBot.Loki.Bot.Pathfinding;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.PathfindingClient;

namespace DreamPoeBot.Loki.Controllers;

public class AreaController
{
	public AreaInstance CurrentArea { get; private set; }

	public event Action<AreaController> OnAreaChange;

	public AreaController()
	{
		RDClient.Initialize();
	}

	public void RefreshState()
	{
		IngameData data = GameController.Instance.Game.IngameState.Data;
		AreaTemplate currentArea = GameController.Instance.Game.IngameState.Data.CurrentArea;
		AreaMap currentAreaMap = GameController.Instance.Game.IngameState.CurrentAreaMap;
		uint currentAreaHash = GameController.Instance.Game.IngameState.Data.CurrentAreaHash;
		uint num = default(uint);
		while (true)
		{
			IL_00e3:
			if (CurrentArea != null)
			{
				goto IL_00bd;
			}
			goto IL_00cd;
			IL_00cd:
			while (true)
			{
				IL_00cd_2:
				CurrentArea = new AreaInstance(currentArea, currentAreaMap, currentAreaHash, data.CurrentAreaLevel);
				while (true)
				{
					ExilePather.Reload();
					while (true)
					{
						Action<AreaController> onAreaChange = this.OnAreaChange;
						if (onAreaChange != null)
						{
							onAreaChange(this);
							switch ((num = (num * 2555354822u) ^ 0x7D31D9D9u ^ 0x9F051CA2u) % 8u)
							{
							case 3u:
								break;
							default:
								return;
							case 2u:
								goto end_IL_0063;
							case 0u:
								goto end_IL_00b5;
							case 5u:
								goto IL_00cd_2;
							case 4u:
							case 6u:
								goto IL_00e3;
							case 1u:
								return;
							case 7u:
								return;
							}
							continue;
						}
						return;
						continue;
						end_IL_0063:
						break;
					}
					continue;
					end_IL_00b5:
					break;
				}
				break;
			}
			goto IL_00bd;
			IL_00bd:
			if (currentAreaHash == CurrentArea.Hash)
			{
				break;
			}
			goto IL_00cd;
		}
	}
}
