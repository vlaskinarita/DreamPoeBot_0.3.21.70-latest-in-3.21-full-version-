using System;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Game;

public static class CoordinateExtensions
{
	public const float PositionScalar = 0.092f;

	public static Vector2 MapToWorld(this Vector2i v)
	{
		return new Vector2((float)v.X / 0.092f + 5.4347825f, (float)v.Y / 0.092f + 5.4347825f);
	}

	public static Vector2 MapToWorld(this Vector2 v)
	{
		return new Vector2(v.X / 0.092f + 5.4347825f, v.Y / 0.092f + 5.4347825f);
	}

	public static Vector3 MapToWorld3(this Vector2i v, bool checkZ = true)
	{
		Vector2 vector = v.MapToWorld();
		float z = 0f;
		if (checkZ)
		{
			z = LokiPoe.ClientFunctions.GetHeightAt(v.X, v.Y);
		}
		return new Vector3(vector.X, vector.Y, z);
	}

	public static Vector3 MapToWorld3(this Vector2 v, bool checkZ = true)
	{
		Vector2 vector = v.MapToWorld();
		float z = 0f;
		if (checkZ)
		{
			z = LokiPoe.ClientFunctions.GetHeightAt((int)v.X, (int)v.Y);
		}
		return new Vector3(vector.X, vector.Y, z);
	}

	public static Vector3 WorldToWorld3(this Vector2 v, bool checkZ = true)
	{
		float z = 0f;
		if (checkZ)
		{
			z = LokiPoe.ClientFunctions.GetHeightAt((int)v.X, (int)v.Y);
		}
		return new Vector3(v.X, v.Y, z);
	}

	public static Vector2i WorldToMap(this Vector2 v)
	{
		return new Vector2i((int)Math.Floor(v.X * 0.092f), (int)Math.Floor(v.Y * 0.092f));
	}

	public static Vector2i World3ToMap(this Vector3 v)
	{
		return new Vector2i((int)Math.Floor(v.X * 0.092f), (int)Math.Floor(v.Y * 0.092f));
	}

	public static Vector2 World3ToWorld(this Vector3 v)
	{
		return new Vector2(v.X, v.Y);
	}
}
