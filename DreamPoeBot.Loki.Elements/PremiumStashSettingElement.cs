using System.Collections.Generic;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class PremiumStashSettingElement : Element
{
	internal static long _checkBoxOffset = 994L;

	internal Element PublicButton => base.Children[0].Children[0].Children[2].Children[1];

	internal bool IsPublic => base.M.ReadByte(PublicButton.Address + _checkBoxOffset) == 1;

	internal Element OkButton => base.Children[0].Children[0].Children[9].Children[0];

	internal List<AffinitieCheckbox> Affinities => base.Children[0].Children[0].Children[8].Children[1].Children.Select((Element x) => GetObject<AffinitieCheckbox>(x.Address)).ToList();
}
