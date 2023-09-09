using SharpDX;

namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class DivinationInventoryItem : NormalInventoryItem
{
	public override int InventPosX => 0;

	public override int InventPosY => 0;

	public override RectangleF GetClientRect()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		RectangleF clientRect = base.Parent.GetClientRect();
		long addr = base.Parent.Parent.Parent.Parent.Children[2].Address + 2660L;
		float num = (float)base.M.ReadInt(addr) * 107.5f;
		((RectangleF)(ref clientRect)).Y = ((RectangleF)(ref clientRect)).Y - num;
		return clientRect;
	}
}
