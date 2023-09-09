using System;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Common;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Quaternion
{
	public float X;

	public float Y;

	public float Z;

	public float W;

	public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
	{
		float num = roll * 0.5f;
		float num2 = (float)Math.Sin(num);
		float num3 = (float)Math.Cos(num);
		float num4 = pitch * 0.5f;
		float num5 = (float)Math.Sin(num4);
		float num6 = (float)Math.Cos(num4);
		float num7 = yaw * 0.5f;
		float num8 = (float)Math.Sin(num7);
		float num9 = (float)Math.Cos(num7);
		result.X = num9 * num5 * num3 + num8 * num6 * num2;
		result.Y = num8 * num6 * num3 - num9 * num5 * num2;
		result.Z = num9 * num6 * num2 - num8 * num5 * num3;
		result.W = num9 * num6 * num3 + num8 * num5 * num2;
	}
}
