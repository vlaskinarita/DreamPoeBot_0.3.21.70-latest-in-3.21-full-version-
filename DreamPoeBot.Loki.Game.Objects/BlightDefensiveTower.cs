using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class BlightDefensiveTower : Monster
{
	public int Tier
	{
		get
		{
			string text = Name;
			uint num = default(uint);
			char c = default(char);
			while (text != null)
			{
				while (true)
				{
					int length = text.Length;
					while (true)
					{
						IL_02c8:
						switch (length)
						{
						case 20:
							break;
						case 21:
							goto IL_02ac;
						default:
							goto IL_02b6;
						case 13:
							goto IL_0320;
						case 16:
							goto IL_0335;
						case 12:
							goto IL_033f;
						case 18:
							goto IL_0369;
						case 9:
							goto IL_03ca;
						case 14:
							goto IL_03df;
						case 11:
							goto IL_0420;
						case 19:
							goto IL_04ed;
						case 22:
							goto IL_05b4;
						case 23:
							goto IL_05fa;
						case 10:
						case 15:
						case 17:
							goto end_IL_0318;
						}
						goto IL_0070;
						IL_02b6:
						int num2 = ((int)num * -979303902) ^ -717152594;
						goto IL_00a5;
						IL_0070:
						c = text[1];
						goto IL_0044;
						IL_0044:
						switch (c)
						{
						case 'h':
							goto IL_03a0;
						case 'i':
							goto IL_03b5;
						case 'e':
							goto IL_046e;
						case 'f':
						case 'g':
							goto end_IL_0318;
						}
						num2 = ((int)num * -1158560381) ^ -896953945;
						goto IL_00a5;
						IL_05f8:
						return 2;
						IL_00a5:
						while (true)
						{
							switch ((num = (uint)num2 ^ 0xD759E553u) % 110u)
							{
							case 92u:
							{
								int num3;
								int num4;
								if (c == 'u')
								{
									num3 = 480651119;
									num4 = 480651119;
								}
								else
								{
									num3 = 1326864563;
									num4 = 1326864563;
								}
								num2 = num3 ^ ((int)num * -72113517);
								continue;
							}
							case 74u:
								break;
							case 71u:
								goto IL_0070;
							case 68u:
								num2 = ((int)num * -878447425) ^ 0x3F8A14CD;
								continue;
							case 67u:
								num2 = (int)((num * 1169447231) ^ 0x21755664);
								continue;
							case 8u:
								num2 = (int)((num * 673801095) ^ 0x3A78A2F9);
								continue;
							case 65u:
								goto IL_0272;
							case 104u:
								goto IL_0298;
							case 96u:
								goto IL_02a2;
							case 43u:
								goto IL_02ac;
							case 3u:
								goto IL_02c8;
							case 54u:
								goto end_IL_02c8;
							case 76u:
							case 80u:
								goto end_IL_030f;
							case 7u:
								goto IL_0320;
							case 9u:
								goto IL_0335;
							case 15u:
								goto IL_033f;
							case 27u:
								goto IL_0354;
							case 36u:
								goto IL_0369;
							case 38u:
								if (!(text == "Summoning Tower Mk I"))
								{
									goto end_IL_0318;
								}
								goto IL_058e;
							case 70u:
								goto IL_0393;
							case 24u:
								goto IL_03a0;
							case 62u:
								goto IL_03b5;
							case 75u:
								goto IL_03ca;
							case 77u:
								goto IL_03df;
							case 44u:
								goto IL_03ec;
							case 6u:
								goto IL_03f6;
							case 10u:
								goto IL_040b;
							case 83u:
								goto IL_0420;
							case 94u:
								goto IL_0435;
							case 58u:
								goto IL_043a;
							case 26u:
								goto IL_0444;
							case 47u:
								goto IL_0459;
							case 97u:
								goto IL_046e;
							case 102u:
								goto IL_0483;
							case 63u:
								goto IL_0488;
							case 88u:
								goto IL_049d;
							case 17u:
								goto IL_04a5;
							case 103u:
								goto IL_04ba;
							case 95u:
								goto IL_04bf;
							case 51u:
								goto IL_04c9;
							case 93u:
								goto IL_04db;
							case 105u:
								goto IL_04ed;
							case 61u:
								goto IL_04f5;
							case 98u:
								goto IL_04fa;
							case 87u:
								goto IL_050f;
							case 28u:
								goto IL_0514;
							case 35u:
								goto IL_0526;
							case 39u:
								goto IL_052e;
							case 106u:
								goto IL_0543;
							case 109u:
								goto IL_0545;
							case 46u:
								goto IL_0555;
							case 85u:
								goto IL_0557;
							case 40u:
								goto IL_056c;
							case 29u:
								goto IL_057e;
							case 64u:
								goto IL_058e;
							case 73u:
								goto IL_0590;
							case 30u:
								goto IL_05a5;
							case 37u:
								goto IL_05b4;
							case 12u:
								goto IL_05c1;
							case 55u:
								goto IL_05d0;
							case 84u:
								goto IL_05d5;
							case 108u:
								goto IL_05dc;
							case 57u:
								goto IL_05eb;
							case 72u:
								goto IL_05f8;
							case 34u:
								goto IL_05fa;
							case 2u:
								goto IL_0602;
							case 52u:
								goto IL_0607;
							case 59u:
								goto IL_0616;
							case 4u:
								goto IL_061d;
							case 16u:
								goto IL_062a;
							default:
								goto end_IL_0318;
							}
							break;
						}
						goto IL_0044;
						IL_05fa:
						c = text[0];
						goto IL_0602;
						IL_0602:
						if (c == 'E')
						{
							goto IL_0607;
						}
						goto IL_0616;
						IL_0607:
						if (!(text == "Empowering Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_0616:
						if (c != 'S')
						{
							goto end_IL_0318;
						}
						goto IL_061d;
						IL_061d:
						if (!(text == "Shock Nova Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_05b4:
						c = text[1];
						if (c == 'h')
						{
							goto IL_05c1;
						}
						goto IL_05d0;
						IL_05c1:
						if (!(text == "Shock Nova Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						IL_05d0:
						if (c != 'm')
						{
							goto IL_05d5;
						}
						goto IL_05eb;
						IL_05d5:
						if (c != 'u')
						{
							goto end_IL_0318;
						}
						goto IL_05dc;
						IL_05dc:
						if (!(text == "Summoning Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_05eb:
						if (!(text == "Empowering Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						IL_04ed:
						c = text[0];
						goto IL_04f5;
						IL_04f5:
						if (c == 'C')
						{
							goto IL_04fa;
						}
						goto IL_050f;
						IL_04fa:
						if (!(text == "Chilling Tower Mk I"))
						{
							goto end_IL_0318;
						}
						goto IL_058e;
						IL_050f:
						if (c == 'F')
						{
							goto IL_0514;
						}
						goto IL_0526;
						IL_0514:
						if (!(text == "Fireball Tower Mk I"))
						{
							goto end_IL_0318;
						}
						goto IL_058e;
						IL_0526:
						if (c != 'S')
						{
							goto end_IL_0318;
						}
						goto IL_052e;
						IL_052e:
						if (!(text == "Seismic Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						IL_046e:
						if (!(text == "Seismic Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_0420:
						if (!(text == "Scout Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_03df:
						c = text[0];
						if (c != 'S')
						{
							goto IL_03ec;
						}
						goto IL_040b;
						IL_03ec:
						if (c != 'T')
						{
							goto end_IL_0318;
						}
						goto IL_03f6;
						IL_03f6:
						if (!(text == "Temporal Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_040b:
						if (!(text == "Sentinel Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_03ca:
						if (!(text == "Arc Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_03b5:
						if (!(text == "Fireball Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						IL_03a0:
						if (!(text == "Chilling Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						IL_0369:
						c = text[0];
						if (c != 'F')
						{
							goto IL_0483;
						}
						goto IL_0545;
						IL_0483:
						if (c == 'G')
						{
							goto IL_0488;
						}
						goto IL_049d;
						IL_0488:
						if (!(text == "Glacial Cage Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_049d:
						if (c != 'S')
						{
							goto end_IL_0318;
						}
						goto IL_04a5;
						IL_04a5:
						if (!(text == "Seismic Tower Mk I"))
						{
							goto end_IL_0318;
						}
						goto IL_058e;
						IL_0545:
						if (!(text == "Flamethrower Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_033f:
						if (!(text == "Meteor Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_0335:
						c = text[1];
						goto IL_0393;
						IL_0393:
						if ((uint)c > 111u)
						{
							goto IL_0435;
						}
						goto IL_04ba;
						IL_0435:
						if (c != 'r')
						{
							goto IL_043a;
						}
						goto IL_0459;
						IL_043a:
						if (c != 't')
						{
							goto end_IL_0318;
						}
						goto IL_0444;
						IL_0444:
						if (!(text == "Stone Gaze Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_0459:
						if (!(text == "Freezebolt Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_04ba:
						if (c != 'm')
						{
							goto IL_04bf;
						}
						goto IL_04db;
						IL_04bf:
						if (c != 'o')
						{
							goto end_IL_0318;
						}
						goto IL_04c9;
						IL_04c9:
						if (!(text == "Tower Foundation"))
						{
							goto end_IL_0318;
						}
						goto IL_0543;
						IL_0543:
						return 0;
						IL_04db:
						if (!(text == "Smothering Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_0320:
						if (!(text == "Imbuing Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_02ac:
						c = text[2];
						goto IL_02a2;
						IL_02a2:
						if (c != 'g')
						{
							goto IL_0298;
						}
						goto IL_0354;
						IL_0354:
						if (!(text == "Lightning Storm Tower"))
						{
							goto end_IL_0318;
						}
						goto IL_0555;
						IL_0555:
						return 4;
						IL_0298:
						if (c != 'i')
						{
							goto IL_0272;
						}
						goto IL_05a5;
						IL_05a5:
						if (!(text == "Chilling Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_0272:
						switch (c)
						{
						case 'm':
							goto IL_0557;
						case 'o':
							goto IL_056c;
						case 'p':
							goto IL_057e;
						case 'r':
							goto IL_0590;
						case 'n':
						case 'q':
							goto end_IL_0318;
						}
						num2 = ((int)num * -2080777245) ^ 0x2813A18A;
						goto IL_00a5;
						IL_0590:
						if (!(text == "Fireball Tower Mk III"))
						{
							goto end_IL_0318;
						}
						goto IL_062a;
						IL_062a:
						return 3;
						IL_057e:
						if (!(text == "Empowering Tower Mk I"))
						{
							goto end_IL_0318;
						}
						goto IL_058e;
						IL_056c:
						if (!(text == "Shock Nova Tower Mk I"))
						{
							goto end_IL_0318;
						}
						goto IL_058e;
						IL_058e:
						return 1;
						IL_0557:
						if (!(text == "Summoning Tower Mk II"))
						{
							goto end_IL_0318;
						}
						goto IL_05f8;
						continue;
						end_IL_02c8:
						break;
					}
					continue;
					end_IL_030f:
					break;
				}
				continue;
				end_IL_0318:
				break;
			}
			return 0;
		}
	}

	public BlightTowerElement Ui
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (!(label == null))
			{
				return label.GetObjectAt<BlightTowerElement>(0);
			}
			return null;
		}
	}

	internal BlightDefensiveTower(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public bool Upgrade(string selectedId = "")
	{
		List<BlightTowerOption> menu = Ui.Menu;
		BlightTowerOption blightTowerOption = (string.IsNullOrEmpty(selectedId) ? menu.FirstOrDefault() : ((menu.Count > 1) ? Ui.Menu.FirstOrDefault((BlightTowerOption x) => x.Id == selectedId) : menu.FirstOrDefault()));
		if (!(blightTowerOption == null))
		{
			Vector2i elementClickLocation = blightTowerOption.ElementClickLocation;
			MouseManager.SetMousePosition(elementClickLocation, useRandomPos: false);
			Thread.Sleep(30);
			MouseManager.ClickLMB(elementClickLocation.X, elementClickLocation.Y);
			Thread.Sleep(30);
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Tower]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tTier: {Tier}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine($"\t[Upgrades]");
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine($"\t\tId: {item.Id}");
				stringBuilder.AppendLine($"\t\tName: {item.Name}");
				stringBuilder.AppendLine($"\t\tDescription: {item.Description}");
				stringBuilder.AppendLine($"\t\tIcon: {item.Icon}");
				stringBuilder.AppendLine($"\t\tCost: {item.Cost}");
				stringBuilder.AppendLine($"\t\tIsVisible: {item.IsVisible}");
				stringBuilder.AppendLine($"\t\tIsVisibleLocal: {item.IsVisibleLocal}");
			}
		}
		return stringBuilder.ToString();
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Tower]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tTier: {Tier}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine($"\t[Upgrades]");
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine($"\t\tId: {item.Id}");
				stringBuilder.AppendLine($"\t\tName: {item.Name}");
				stringBuilder.AppendLine($"\t\tDescription: {item.Description}");
				stringBuilder.AppendLine($"\t\tIcon: {item.Icon}");
				stringBuilder.AppendLine($"\t\tCost: {item.Cost}");
			}
		}
		return stringBuilder.ToString();
	}
}
