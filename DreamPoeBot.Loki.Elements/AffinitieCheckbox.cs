using System;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class AffinitieCheckbox : Element
{
	public LokiPoe.StashTabAffinitiesEnum AffinitieEnum
	{
		get
		{
			string text = base.Children[0].Text;
			uint num = default(uint);
			char c = default(char);
			while (!string.IsNullOrEmpty(text))
			{
				while (true)
				{
					IL_0172:
					if (text != null)
					{
						while (true)
						{
							IL_0169:
							int length = text.Length;
							while (true)
							{
								switch (length)
								{
								case 3:
									goto IL_018d;
								case 5:
									goto IL_01c9;
								case 6:
									goto IL_0206;
								case 7:
									goto IL_0242;
								case 8:
									goto IL_0251;
								case 9:
									goto IL_02a3;
								case 15:
									goto IL_02b3;
								case 4:
								case 10:
								case 11:
								case 12:
								case 13:
								case 14:
									goto end_IL_0128;
								}
								int num2 = (int)(num * 1480237392) ^ -704138579;
								while (true)
								{
									switch ((num = (uint)num2 ^ 0xC35272CCu) % 56u)
									{
									case 1u:
										num2 = (int)(num * 1877256502) ^ -305293333;
										continue;
									case 53u:
										break;
									case 32u:
										goto IL_0169;
									case 7u:
										goto IL_0172;
									case 16u:
									case 18u:
										goto end_IL_0172;
									case 52u:
										goto end_IL_017a;
									case 44u:
										goto IL_018d;
									case 13u:
										goto IL_019a;
									case 35u:
										goto IL_01aa;
									case 45u:
										goto IL_01ad;
									case 54u:
										goto IL_01b7;
									case 55u:
										goto IL_01c7;
									case 39u:
										goto IL_01c9;
									case 22u:
										goto IL_01d6;
									case 30u:
										goto IL_01e6;
									case 17u:
										goto IL_01e9;
									case 42u:
										goto IL_01f3;
									case 40u:
										goto IL_0203;
									case 29u:
										goto IL_0206;
									case 24u:
										goto IL_020e;
									case 5u:
										goto IL_0213;
									case 19u:
										goto IL_0223;
									case 3u:
										goto IL_0226;
									case 2u:
										goto IL_0230;
									case 34u:
										goto IL_0240;
									case 4u:
										goto IL_0242;
									case 27u:
										goto IL_024f;
									case 38u:
										goto IL_0251;
									case 9u:
										goto IL_0274;
									case 21u:
										goto IL_0281;
									case 14u:
										goto IL_0283;
									case 8u:
										goto IL_0290;
									case 51u:
										goto IL_0293;
									case 46u:
										goto IL_02a0;
									case 37u:
										goto IL_02a3;
									case 10u:
										goto IL_02b0;
									case 41u:
										goto IL_02b3;
									default:
										goto end_IL_0128;
									case 43u:
										goto IL_02cb;
									}
									break;
								}
								continue;
								IL_01b7:
								if (!(text == "Map"))
								{
									break;
								}
								goto IL_01c7;
								IL_01c7:
								return LokiPoe.StashTabAffinitiesEnum.Map;
								IL_02b3:
								if (!(text == "Divination Card"))
								{
									break;
								}
								goto IL_02cb;
								IL_02cb:
								return LokiPoe.StashTabAffinitiesEnum.DivinationCards;
								IL_02a3:
								if (!(text == "Metamorph"))
								{
									break;
								}
								goto IL_02b0;
								IL_02b0:
								return LokiPoe.StashTabAffinitiesEnum.Metamorph;
								IL_0251:
								switch (text[0])
								{
								case 'C':
									break;
								case 'D':
									goto IL_0283;
								case 'F':
									goto IL_0293;
								default:
									goto end_IL_0128;
								}
								goto IL_0274;
								IL_0293:
								if (!(text == "Fragment"))
								{
									break;
								}
								goto IL_02a0;
								IL_02a0:
								return LokiPoe.StashTabAffinitiesEnum.Fragment;
								IL_0283:
								if (!(text == "Delirium"))
								{
									break;
								}
								goto IL_0290;
								IL_0290:
								return LokiPoe.StashTabAffinitiesEnum.Delirium;
								IL_0274:
								if (!(text == "Currency"))
								{
									break;
								}
								goto IL_0281;
								IL_0281:
								return LokiPoe.StashTabAffinitiesEnum.Corrency;
								IL_0242:
								if (!(text == "Essence"))
								{
									break;
								}
								goto IL_024f;
								IL_024f:
								return LokiPoe.StashTabAffinitiesEnum.Essence;
								IL_0206:
								c = text[0];
								goto IL_020e;
								IL_020e:
								if (c == 'B')
								{
									goto IL_0213;
								}
								goto IL_0226;
								IL_0213:
								if (!(text == "Blight"))
								{
									break;
								}
								goto IL_0223;
								IL_0223:
								return LokiPoe.StashTabAffinitiesEnum.Blight;
								IL_0226:
								if (c != 'U')
								{
									break;
								}
								goto IL_0230;
								IL_0230:
								if (!(text == "Unique"))
								{
									break;
								}
								goto IL_0240;
								IL_0240:
								return LokiPoe.StashTabAffinitiesEnum.Unique;
								IL_01c9:
								c = text[0];
								if (c == 'D')
								{
									goto IL_01d6;
								}
								goto IL_01e9;
								IL_01d6:
								if (!(text == "Delve"))
								{
									break;
								}
								goto IL_01e6;
								IL_01e6:
								return LokiPoe.StashTabAffinitiesEnum.Delve;
								IL_01e9:
								if (c != 'F')
								{
									break;
								}
								goto IL_01f3;
								IL_01f3:
								if (!(text == "Flask"))
								{
									break;
								}
								goto IL_0203;
								IL_0203:
								return LokiPoe.StashTabAffinitiesEnum.Flask;
								IL_018d:
								c = text[0];
								if (c == 'G')
								{
									goto IL_019a;
								}
								goto IL_01ad;
								IL_019a:
								if (!(text == "Gem"))
								{
									break;
								}
								goto IL_01aa;
								IL_01aa:
								return LokiPoe.StashTabAffinitiesEnum.Gem;
								IL_01ad:
								if (c != 'M')
								{
									break;
								}
								goto IL_01b7;
								continue;
								end_IL_0128:
								break;
							}
							break;
						}
					}
					throw new ArgumentNullException("AffinitieEnum");
					continue;
					end_IL_0172:
					break;
				}
				continue;
				end_IL_017a:
				break;
			}
			throw new ArgumentNullException("AffinitieEnum");
		}
	}

	public bool IsSelected => base.M.ReadByte(base.Children[1].Address + PremiumStashSettingElement._checkBoxOffset) == 1;

	public void ClickCheckBox()
	{
		Vector2i pos = base.Children[1].CenterClickLocation();
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(10);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(10);
	}
}
