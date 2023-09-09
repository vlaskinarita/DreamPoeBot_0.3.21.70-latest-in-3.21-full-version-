using System;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Common;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Matrix
{
	public float M11;

	public float M12;

	public float M13;

	public float M14;

	public float M21;

	public float M22;

	public float M23;

	public float M24;

	public float M31;

	public float M32;

	public float M33;

	public float M34;

	public float M41;

	public float M42;

	public float M43;

	public float M44;

	public static Matrix Identity { get; private set; }

	public Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
	{
		M11 = m11;
		M12 = m12;
		M13 = m13;
		M14 = m14;
		M21 = m21;
		M22 = m22;
		M23 = m23;
		M24 = m24;
		M31 = m31;
		M32 = m32;
		M33 = m33;
		M34 = m34;
		M41 = m41;
		M42 = m42;
		M43 = m43;
		M44 = m44;
	}

	public void GetUp(out Vector3 up)
	{
		up.X = M21;
		up.Y = M22;
		up.Z = M23;
	}

	public void GetDown(out Vector3 down)
	{
		GetUp(out down);
		Vector3.Negate(ref down, out down);
	}

	public void GetRight(out Vector3 right)
	{
		right.X = M11;
		right.Y = M12;
		right.Z = M13;
	}

	public void GetLeft(out Vector3 left)
	{
		GetRight(out left);
		Vector3.Negate(ref left, out left);
	}

	public void GetBackwards(out Vector3 backwards)
	{
		backwards.X = M31;
		backwards.Y = M32;
		backwards.Z = M33;
	}

	public void GetForward(out Vector3 forward)
	{
		GetBackwards(out forward);
		Vector3.Negate(ref forward, out forward);
	}

	public void GetTranslation(out Vector3 translation)
	{
		translation.X = M41;
		translation.Y = M42;
		translation.Z = M43;
	}

	public static void Multiply(ref Matrix m1, ref Matrix m2, out Matrix result)
	{
		float m3 = m1.M11 * m2.M11 + m1.M12 * m2.M21 + m1.M13 * m2.M31 + m1.M14 * m2.M41;
		float m4 = m1.M11 * m2.M12 + m1.M12 * m2.M22 + m1.M13 * m2.M32 + m1.M14 * m2.M42;
		float m5 = m1.M11 * m2.M13 + m1.M12 * m2.M23 + m1.M13 * m2.M33 + m1.M14 * m2.M43;
		float m6 = m1.M11 * m2.M14 + m1.M12 * m2.M24 + m1.M13 * m2.M34 + m1.M14 * m2.M44;
		float m7 = m1.M21 * m2.M11 + m1.M22 * m2.M21 + m1.M23 * m2.M31 + m1.M24 * m2.M41;
		float m8 = m1.M21 * m2.M12 + m1.M22 * m2.M22 + m1.M23 * m2.M32 + m1.M24 * m2.M42;
		float m9 = m1.M21 * m2.M13 + m1.M22 * m2.M23 + m1.M23 * m2.M33 + m1.M24 * m2.M43;
		float m10 = m1.M21 * m2.M14 + m1.M22 * m2.M24 + m1.M23 * m2.M34 + m1.M24 * m2.M44;
		float m11 = m1.M31 * m2.M11 + m1.M32 * m2.M21 + m1.M33 * m2.M31 + m1.M34 * m2.M41;
		float m12 = m1.M31 * m2.M12 + m1.M32 * m2.M22 + m1.M33 * m2.M32 + m1.M34 * m2.M42;
		float m13 = m1.M31 * m2.M13 + m1.M32 * m2.M23 + m1.M33 * m2.M33 + m1.M34 * m2.M43;
		float m14 = m1.M31 * m2.M14 + m1.M32 * m2.M24 + m1.M33 * m2.M34 + m1.M34 * m2.M44;
		float m15 = m1.M41 * m2.M11 + m1.M42 * m2.M21 + m1.M43 * m2.M31 + m1.M44 * m2.M41;
		float m16 = m1.M41 * m2.M12 + m1.M42 * m2.M22 + m1.M43 * m2.M32 + m1.M44 * m2.M42;
		float m17 = m1.M41 * m2.M13 + m1.M42 * m2.M23 + m1.M43 * m2.M33 + m1.M44 * m2.M43;
		float m18 = m1.M41 * m2.M14 + m1.M42 * m2.M24 + m1.M43 * m2.M34 + m1.M44 * m2.M44;
		result.M11 = m3;
		result.M12 = m4;
		result.M13 = m5;
		result.M14 = m6;
		result.M21 = m7;
		result.M22 = m8;
		result.M23 = m9;
		result.M24 = m10;
		result.M31 = m11;
		result.M32 = m12;
		result.M33 = m13;
		result.M34 = m14;
		result.M41 = m15;
		result.M42 = m16;
		result.M43 = m17;
		result.M44 = m18;
	}

	public static void CreateTranslation(ref Vector3 position, out Matrix result)
	{
		result.M11 = 1f;
		result.M12 = 0f;
		result.M13 = 0f;
		result.M14 = 0f;
		result.M21 = 0f;
		result.M22 = 1f;
		result.M23 = 0f;
		result.M24 = 0f;
		result.M31 = 0f;
		result.M32 = 0f;
		result.M33 = 1f;
		result.M34 = 0f;
		result.M41 = position.X;
		result.M42 = position.Y;
		result.M43 = position.Z;
		result.M44 = 1f;
	}

	public static Matrix CreateTranslation(Vector3 position)
	{
		CreateTranslation(ref position, out var result);
		return result;
	}

	public static void CreateScale(float xScale, float yScale, float zScale, out Matrix result)
	{
		result.M11 = xScale;
		result.M12 = 0f;
		result.M13 = 0f;
		result.M14 = 0f;
		result.M21 = 0f;
		result.M22 = yScale;
		result.M23 = 0f;
		result.M24 = 0f;
		result.M31 = 0f;
		result.M32 = 0f;
		result.M33 = zScale;
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateScale(float xScale, float yScale, float zScale)
	{
		CreateScale(xScale, yScale, zScale, out var result);
		return result;
	}

	public static void CreateScale(float scale, out Matrix result)
	{
		result.M11 = scale;
		result.M12 = 0f;
		result.M13 = 0f;
		result.M14 = 0f;
		result.M21 = 0f;
		result.M22 = scale;
		result.M23 = 0f;
		result.M24 = 0f;
		result.M31 = 0f;
		result.M32 = 0f;
		result.M33 = scale;
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateScale(float scale)
	{
		CreateScale(scale, out var result);
		return result;
	}

	public static void CreateRotationX(float radians, out Matrix result)
	{
		float num = (float)Math.Cos(radians);
		float num2 = (float)Math.Sin(radians);
		result.M11 = 1f;
		result.M12 = 0f;
		result.M13 = 0f;
		result.M14 = 0f;
		result.M21 = 0f;
		result.M22 = num;
		result.M23 = num2;
		result.M24 = 0f;
		result.M31 = 0f;
		result.M32 = 0f - num2;
		result.M33 = num;
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateRotationX(float radians)
	{
		CreateRotationX(radians, out var result);
		return result;
	}

	public static void CreateRotationY(float radians, out Matrix result)
	{
		float num = (float)Math.Cos(radians);
		float num2 = (float)Math.Sin(radians);
		result.M11 = num;
		result.M12 = 0f;
		result.M13 = 0f - num2;
		result.M14 = 0f;
		result.M21 = 0f;
		result.M22 = 1f;
		result.M23 = 0f;
		result.M24 = 0f;
		result.M31 = num2;
		result.M32 = 0f;
		result.M33 = num;
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateRotationY(float radians)
	{
		CreateRotationY(radians, out var result);
		return result;
	}

	public static void CreateRotationZ(float radians, out Matrix result)
	{
		float num = (float)Math.Cos(radians);
		float num2 = (float)Math.Sin(radians);
		result.M11 = num;
		result.M12 = num2;
		result.M13 = 0f;
		result.M14 = 0f;
		result.M21 = 0f - num2;
		result.M22 = num;
		result.M23 = 0f;
		result.M24 = 0f;
		result.M31 = 0f;
		result.M32 = 0f;
		result.M33 = 1f;
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateRotationZ(float radians)
	{
		CreateRotationZ(radians, out var result);
		return result;
	}

	public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
	{
		float num = quaternion.X * quaternion.X;
		float num2 = quaternion.Y * quaternion.Y;
		float num3 = quaternion.Z * quaternion.Z;
		float num4 = quaternion.X * quaternion.Y;
		float num5 = quaternion.Z * quaternion.W;
		float num6 = quaternion.Z * quaternion.X;
		float num7 = quaternion.Y * quaternion.W;
		float num8 = quaternion.Y * quaternion.Z;
		float num9 = quaternion.X * quaternion.W;
		result.M11 = 1f - 2f * (num2 + num3);
		result.M12 = 2f * (num4 + num5);
		result.M13 = 2f * (num6 - num7);
		result.M14 = 0f;
		result.M21 = 2f * (num4 - num5);
		result.M22 = 1f - 2f * (num3 + num);
		result.M23 = 2f * (num8 + num9);
		result.M24 = 0f;
		result.M31 = 2f * (num6 + num7);
		result.M32 = 2f * (num8 - num9);
		result.M33 = 1f - 2f * (num2 + num);
		result.M34 = 0f;
		result.M41 = 0f;
		result.M42 = 0f;
		result.M43 = 0f;
		result.M44 = 1f;
	}

	public static Matrix CreateFromQuaternion(Quaternion quaternion)
	{
		CreateFromQuaternion(ref quaternion, out var result);
		return result;
	}

	public static Matrix CreateFromYawPitchRoll(float yaw, float pitch, float roll)
	{
		Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out var result);
		CreateFromQuaternion(ref result, out var result2);
		return result2;
	}

	public static Matrix operator *(Matrix ls, Matrix rs)
	{
		Multiply(ref ls, ref rs, out var result);
		return result;
	}

	static Matrix()
	{
		Identity = new Matrix(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}
}
