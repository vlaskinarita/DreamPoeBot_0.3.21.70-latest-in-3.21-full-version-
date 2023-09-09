using System;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Common;

public static class MathEx
{
	private static readonly Random random_0 = new Random();

	public static double Random(double min, double max)
	{
		return min + random_0.NextDouble() * (max - min);
	}

	public static float Lerp(float min, float max, float amount)
	{
		return min + (max - min) * amount;
	}

	public static float InverseLerp(float min, float max, float amount)
	{
		return (amount - min) / (max - min);
	}

	public static float GetPercentage(float current, float max, bool isHundredHigh = true)
	{
		float amount = GetAmount(0f, max, current);
		if (isHundredHigh)
		{
			return amount * 100f;
		}
		return amount;
	}

	public static float GetAmount(float min, float max, float value)
	{
		return (value - min) / (max - min);
	}

	public static float ToRadians(float degrees)
	{
		return (float)((double)degrees * (System.Math.PI / 180.0));
	}

	public static float ToDegrees(float radians)
	{
		return (float)((double)radians * (180.0 / System.Math.PI));
	}

	public static float DistanceSqr(ref Vector3 point, ref LineSegment line)
	{
		if (line.Start == line.End)
		{
			return Vector3.DistanceSqr(ref point, ref line.Start);
		}
		Vector3 v = line.End - line.Start;
		if (Vector3.Dot(v, point - line.Start) < 0f)
		{
			return Vector3.DistanceSqr(ref point, ref line.Start);
		}
		v *= new Vector3(-1f);
		if (Vector3.Dot(v, point - line.End) >= 0f)
		{
			return Vector3.Cross(point - line.Start, point - line.End).LengthSqr() / (line.End - line.Start).LengthSqr();
		}
		return Vector3.DistanceSqr(ref point, ref line.End);
	}

	public static float DistanceSqr(Vector3 point, LineSegment line)
	{
		return DistanceSqr(ref point, ref line);
	}

	public static float Distance(ref Vector3 point, ref LineSegment line)
	{
		return (float)System.Math.Sqrt(DistanceSqr(ref point, ref line));
	}

	public static float Distance(Vector3 point, LineSegment line)
	{
		return (float)System.Math.Sqrt(DistanceSqr(ref point, ref line));
	}

	public static float WrapAngle(float radian)
	{
		double num = System.Math.IEEERemainder(radian, System.Math.PI * 2.0);
		if (num > -System.Math.PI)
		{
			if (num > System.Math.PI)
			{
				num -= System.Math.PI * 2.0;
			}
		}
		else
		{
			num += System.Math.PI * 2.0;
		}
		return (float)num;
	}

	public static Vector3 CalculatePointFrom(Vector3 myLoc, Vector3 targetLoc, float pointDistanceToTarget)
	{
		Vector3 vector = targetLoc - myLoc;
		vector.Normalize();
		return targetLoc - vector * pointDistanceToTarget;
	}

	public static Vector3 GetPointAt(Vector3 from, float distance, float rotationRadians)
	{
		float x = (float)(System.Math.Cos(rotationRadians) * (double)distance);
		float y = (float)(System.Math.Sin(rotationRadians) * (double)distance);
		return from + new Vector3(x, y, 0f);
	}

	public static bool IntersectsPath(Vector3 target, float radius, Vector3 start, Vector3 destination)
	{
		Ray ray = new Ray(start, Vector3.NormalizedDirection(start, destination));
		Sphere sphere = new Sphere(target, radius);
		float? num = ray.Intersects(sphere);
		if (num.HasValue)
		{
			return num.Value <= start.Distance(destination);
		}
		return false;
	}

	public static bool IntersectsPath(Vector2i target, float radius, Vector2i start, Vector2i destination)
	{
		return IntersectsPath(new Vector3(target.X, target.Y, 0f), radius, new Vector3(start.X, start.Y, 0f), new Vector3(destination.X, destination.Y, 0f));
	}

	public static float Clamp(float min, float max, float value)
	{
		if (value <= min)
		{
			return min;
		}
		if (value >= max)
		{
			return max;
		}
		return value;
	}
}
