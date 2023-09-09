using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Common;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Ray
{
	public Vector3 Position;

	public Vector3 Direction;

	public Ray(Vector3 position, Vector3 direction)
	{
		Position = position;
		Direction = direction;
	}

	public float? Intersects(Sphere sphere)
	{
		float num = sphere.Center.X - Position.X;
		float num2 = sphere.Center.Y - Position.Y;
		float num3 = sphere.Center.Z - Position.Z;
		float num4 = num * num + num2 * num2 + num3 * num3;
		float num5 = sphere.Radius * sphere.Radius;
		if (num4 <= num5)
		{
			return 0f;
		}
		float num6 = num * Direction.X + num2 * Direction.Y + num3 * Direction.Z;
		if (num6 >= 0f)
		{
			float num7 = num4 - num6 * num6;
			if (num7 > num5)
			{
				return null;
			}
			float num8 = (float)System.Math.Sqrt(num5 - num7);
			return num6 - num8;
		}
		return null;
	}
}
