using System;
using System.Linq;
using SharpDX;

namespace DreamPoeBot.Framework.Helpers;

public static class MathHepler
{
	private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	public static Random Randomizer { get; }

	static MathHepler()
	{
		Randomizer = new Random();
	}

	public static double GetPolarCoordinates(this Vector2 vector, out double phi)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		double num = ((Vector2)(ref vector)).Length();
		phi = Math.Acos((double)vector.X / num);
		if (vector.Y < 0f)
		{
			phi = 6.2831854820251465 - phi;
		}
		return num;
	}

	public static string GetRandomWord(int length)
	{
		char[] array = new char[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Randomizer.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)];
		}
		return new string(array);
	}

	public static float Max(params float[] values)
	{
		float num = values.First();
		for (int i = 1; i < values.Length; i++)
		{
			num = Math.Max(num, values[i]);
		}
		return num;
	}

	public static Vector2 Translate(this Vector2 vector, float dx, float dy)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return new Vector2(vector.X + dx, vector.Y + dy);
	}

	public static Vector3 Translate(this Vector3 vector, float dx, float dy, float dz)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(vector.X + dx, vector.Y + dy, vector.Z + dz);
	}
}
