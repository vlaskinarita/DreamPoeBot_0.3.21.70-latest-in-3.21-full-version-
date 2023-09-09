namespace DreamPoeBot.Loki.Common.Controls;

public class MenuButton : SplitButton
{
	public MenuButton()
	{
		base.DefaultStyleKey = typeof(MenuButton);
	}

	protected override void OnClick()
	{
		OpenButtonMenu();
	}
}
