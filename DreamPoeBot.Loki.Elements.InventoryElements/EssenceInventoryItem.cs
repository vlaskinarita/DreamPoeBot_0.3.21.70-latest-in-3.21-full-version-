using SharpDX;

namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class EssenceInventoryItem : NormalInventoryItem
{
	public override int InventPosX => 0;

	public override int InventPosY => 0;

	public override RectangleF GetClientRect()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return base.Parent.GetClientRect();
	}
}
