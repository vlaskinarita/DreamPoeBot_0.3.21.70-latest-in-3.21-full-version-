using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Common;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Vector3 : IEquatable<Vector3>
{
	public float X;

	public float Y;

	public float Z;

	public static Vector3 Zero { get; private set; }

	public static Vector3 One { get; private set; }

	static Vector3()
	{
		Zero = new Vector3(0f, 0f, 0f);
		One = new Vector3(1f, 1f, 1f);
	}

	public Vector3(Vector2 v, float z)
		: this(v.X, v.Y, z)
	{
	}

	public Vector3(float v)
		: this(v, v, v)
	{
	}

	public Vector3(Vector2i v, float z)
		: this(v.X, v.Y, z)
	{
	}

	public Vector3(float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector2 ToVector2()
	{
		return new Vector2(X, Y);
	}

	public float Length()
	{
		return (float)Math.Sqrt(LengthSqr());
	}

	public float LengthSqr()
	{
		return X * X + Y * Y + Z * Z;
	}

	public void Normalize()
	{
		float divisor = Length();
		Divide(ref this, divisor, out this);
	}

	public float Distance(Vector3 v)
	{
		return Distance(ref this, ref v);
	}

	public float Distance(ref Vector3 v)
	{
		return Distance(ref this, ref v);
	}

	public float DistanceSqr(Vector3 v)
	{
		return DistanceSqr(ref this, ref v);
	}

	public float DistanceSqr(ref Vector3 v)
	{
		return DistanceSqr(ref this, ref v);
	}

	public unsafe void CopyTo(float* arr)
	{
		*arr = X;
		arr[4] = Y;
		arr[8] = Z;
	}

	public bool Equals(Vector3 other)
	{
		return Equals(ref this, ref other);
	}

	public bool Equals(ref Vector3 other)
	{
		return Equals(ref this, ref other);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		try
		{
			return Equals((Vector3)obj);
		}
		catch (InvalidCastException)
		{
			return false;
		}
	}

	public static bool operator ==(Vector3 ls, Vector3 rs)
	{
		return Equals(ref ls, ref rs);
	}

	public static bool operator !=(Vector3 ls, Vector3 rs)
	{
		return Equals(ref ls, ref rs);
	}

	public static bool Equals(Vector3 v1, Vector3 v2)
	{
		return Equals(ref v1, ref v2);
	}

	public static bool Equals(ref Vector3 v1, ref Vector3 v2)
	{
		if (v1.X == v2.X && v1.Y == v2.Y)
		{
			return v1.Z == v2.Z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((X.GetHashCode() * 397) ^ Y.GetHashCode()) * 397) ^ Z.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{{{0}, {1}, {2}}}", X, Y, Z);
	}

	public static Vector3 operator *(float left, Vector3 right)
	{
		right.X *= left;
		right.Y *= left;
		right.Z *= left;
		return right;
	}

	public static Vector3 operator +(Vector3 ls, Vector3 rs)
	{
		Add(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector3 operator -(Vector3 ls, Vector3 rs)
	{
		Subtract(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector3 operator *(Vector3 ls, Vector3 rs)
	{
		Multiply(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector3 operator *(Vector3 ls, float rs)
	{
		Multiply(ref ls, rs, out var result);
		return result;
	}

	public static Vector3 operator /(Vector3 ls, Vector3 rs)
	{
		Multiply(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector3 operator /(Vector3 ls, float rs)
	{
		Divide(ref ls, rs, out var result);
		return result;
	}

	public static void Add(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = v1.X + v2.X;
		result.Y = v1.Y + v2.Y;
		result.Z = v1.Z + v2.Z;
	}

	public static void Subtract(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = v1.X - v2.X;
		result.Y = v1.Y - v2.Y;
		result.Z = v1.Z - v2.Z;
	}

	public static void Multiply(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = v1.X * v2.X;
		result.Y = v1.Y * v2.Y;
		result.Z = v1.Z * v2.Z;
	}

	public static void Multiply(ref Vector3 v1, float scalar, out Vector3 result)
	{
		result.X = v1.X * scalar;
		result.Y = v1.Y * scalar;
		result.Z = v1.Z * scalar;
	}

	public static void Divide(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = v1.X / v2.X;
		result.Y = v1.Y / v2.Y;
		result.Z = v1.Z / v2.Z;
	}

	public static void Divide(ref Vector3 v1, float divisor, out Vector3 result)
	{
		result.X = v1.X / divisor;
		result.Y = v1.Y / divisor;
		result.Z = v1.Z / divisor;
	}

	public static void Negate(ref Vector3 v, out Vector3 result)
	{
		result.X = 0f - v.X;
		result.Y = 0f - v.Y;
		result.Z = 0f - v.Z;
	}

	public static float Distance(Vector3 v1, Vector3 v2)
	{
		return (float)Math.Sqrt(DistanceSqr(ref v1, ref v2));
	}

	public static float Distance(ref Vector3 v1, ref Vector3 v2)
	{
		return (float)Math.Sqrt(DistanceSqr(ref v1, ref v2));
	}

	public static float DistanceSqr(Vector3 v1, Vector3 v2)
	{
		return DistanceSqr(ref v1, ref v2);
	}

	public static float DistanceSqr(ref Vector3 v1, ref Vector3 v2)
	{
		float num = v1.Y - v2.Y;
		float num2 = v1.Z - v2.Z;
		float num3 = v1.X - v2.X;
		return num3 * num3 + num * num + num2 * num2;
	}

	public float Distance2D(Vector3 to)
	{
		return Distance2D(ref this, ref to);
	}

	public float Distance2DSqr(Vector3 to)
	{
		return Distance2DSqr(ref this, ref to);
	}

	public static float Distance2D(ref Vector3 v1, ref Vector3 v2)
	{
		float num = v1.Z - v2.Z;
		float num2 = v1.X - v2.X;
		return (float)Math.Sqrt(num2 * num2 + num * num);
	}

	public static float Distance2DSqr(ref Vector3 v1, ref Vector3 v2)
	{
		float num = v1.Z - v2.Z;
		float num2 = v1.X - v2.X;
		return num2 * num2 + num * num;
	}

	public static Vector3 GetDirection(Vector3 from, Vector3 to)
	{
		GetDirection(ref from, ref to, out var dir);
		return dir;
	}

	public static void GetDirection(ref Vector3 from, ref Vector3 to, out Vector3 dir)
	{
		Subtract(ref to, ref from, out dir);
		dir.Normalize();
	}

	public static Vector3 NormalizedDirection(Vector3 start, Vector3 end)
	{
		Vector3 result = end - start;
		result.Normalize();
		return result;
	}

	public static float Dot(Vector3 v1, Vector3 v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public static Vector3 Cross(Vector3 v1, Vector3 v2)
	{
		Cross(ref v1, ref v2, out var crossProduct);
		return crossProduct;
	}

	public static void Cross(ref Vector3 v1, ref Vector3 v2, out Vector3 crossProduct)
	{
		crossProduct.X = v1.Y * v2.Z - v1.Z * v2.Y;
		crossProduct.Y = v1.Z * v2.X - v1.X * v2.Z;
		crossProduct.Z = v1.X * v2.Y - v1.Y * v2.X;
	}

	public static void Transform(ref Vector3 v, ref Matrix m, out Vector3 result)
	{
		float x = v.X * m.M11 + v.Y * m.M21 + v.Z * m.M31 + m.M41;
		float y = v.X * m.M12 + v.Y * m.M22 + v.Z * m.M32 + m.M42;
		float z = v.X * m.M13 + v.Y * m.M23 + v.Z * m.M33 + m.M43;
		result.X = x;
		result.Y = y;
		result.Z = z;
	}

	public static Vector3 Transform(Vector3 v, ref Matrix m)
	{
		Transform(ref v, ref m, out v);
		return v;
	}

	public static void Min(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = Math.Min(v1.X, v2.X);
		result.Y = Math.Min(v1.Y, v2.Y);
		result.Z = Math.Min(v1.Z, v2.Z);
	}

	public static Vector3 Min(Vector3 v1, Vector3 v2)
	{
		Min(ref v1, ref v2, out var result);
		return result;
	}

	public static void Max(ref Vector3 v1, ref Vector3 v2, out Vector3 result)
	{
		result.X = Math.Max(v1.X, v2.X);
		result.Y = Math.Max(v1.Y, v2.Y);
		result.Z = Math.Max(v1.Z, v2.Z);
	}

	public static Vector3 Max(Vector3 v1, Vector3 v2)
	{
		Max(ref v1, ref v2, out var result);
		return result;
	}

	public static bool CalculateBarycentric(ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, ref Vector3 point, out Vector3 barycentric)
	{
		float num = p1.X * p2.Y - p1.X * p3.Y - p2.X * p1.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y;
		if (num != 0f)
		{
			float num2 = point.X * p2.Y - point.X * p3.Y - p2.X * point.Y + p2.X * p3.Y + p3.X * point.Y - p3.X * p2.Y;
			barycentric.X = num2 / num;
			float num3 = p1.X * point.Y - p1.X * p3.Y - point.X * p1.Y + point.X * p3.Y + p3.X * p1.Y - p3.X * point.Y;
			barycentric.Y = num3 / num;
			float num4 = p1.X * p2.Y - p1.X * point.Y - p2.X * p1.Y + p2.X * point.Y + point.X * p1.Y - point.X * p2.Y;
			barycentric.Z = num4 / num;
			return true;
		}
		barycentric = Zero;
		return false;
	}

	public static void CatmullRom(ref Vector3 beforeStart, ref Vector3 start, ref Vector3 end, ref Vector3 afterEnd, float amount, out Vector3 result)
	{
		Cardinal(ref beforeStart, ref start, ref end, ref afterEnd, 0.5f, 0.5f, amount, out result);
	}

	public static Vector3 CatmullRom(Vector3 beforeStart, Vector3 start, Vector3 end, Vector3 afterEnd, float amount)
	{
		Cardinal(ref beforeStart, ref start, ref end, ref afterEnd, 0.5f, 0.5f, amount, out var result);
		return result;
	}

	public static void Cardinal(ref Vector3 beforeStart, ref Vector3 start, ref Vector3 end, ref Vector3 afterEnd, float aStart, float aEnd, float amount, out Vector3 result)
	{
		Vector3 tangent = aStart * (end - beforeStart);
		Vector3 tangent2 = aEnd * (afterEnd - start);
		Hermite(ref start, ref tangent, ref end, ref tangent2, amount, out result);
	}

	public static Vector3 Cardinal(Vector3 beforeStart, Vector3 start, Vector3 end, Vector3 afterEnd, float aStart, float aEnd, float amount)
	{
		Cardinal(ref beforeStart, ref start, ref end, ref afterEnd, aStart, aEnd, amount, out var result);
		return result;
	}

	public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
	{
		float num = amount * amount;
		float num2 = num * amount;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + amount;
		float num6 = num2 - num;
		result = value1 * num3 + value2 * num4 + tangent1 * num5 + tangent2 * num6;
	}

	public static Vector3 CubiceHermiteCurve(Vector3 start, Vector3 end, Vector3 u, Vector3 v, float t)
	{
		if (t > 1f || t < 0f)
		{
			throw new ArgumentOutOfRangeException("t", "t needs to be between 0.0f and 1.0f.");
		}
		float num = 1f - t;
		float num2 = t * t;
		float num3 = num * num;
		return num3 * (1f + 2f * t) * start + num2 * (1f + 2f * num) * end + num3 * t * u - num2 * num * v;
	}

	public static Vector3 Blend(Vector3 firstPoint, Vector3 secondPoint, float t)
	{
		if (t > 1f || t < 0f)
		{
			throw new ArgumentOutOfRangeException("t", "t needs to be between 0.0f and 1.0f.");
		}
		float num = 1f - t;
		return firstPoint * num + secondPoint * t;
	}

	public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
	{
		Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out var result);
		return result;
	}
}
