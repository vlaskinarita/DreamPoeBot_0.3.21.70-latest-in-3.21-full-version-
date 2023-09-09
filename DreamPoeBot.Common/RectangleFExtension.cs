using System.Drawing;

namespace DreamPoeBot.Common;

public static class RectangleFExtension
{
	public static Vector2 Center(this RectangleF rectangle)
	{
		return new Vector2(rectangle.X + rectangle.Width / 2f, rectangle.Y + rectangle.Height / 2f);
	}
}
