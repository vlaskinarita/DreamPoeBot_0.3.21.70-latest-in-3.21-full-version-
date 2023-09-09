using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common.Math;

namespace DreamPoeBot.Loki.Common;

[Serializable]
public struct BoundingBox : IEquatable<BoundingBox>
{
	public const int CornerCount = 8;

	public Vector3 Min;

	public Vector3 Max;

	public Vector3[] GetCorners()
	{
		return new Vector3[8]
		{
			new Vector3(Min.X, Max.Y, Max.Z),
			new Vector3(Max.X, Max.Y, Max.Z),
			new Vector3(Max.X, Min.Y, Max.Z),
			new Vector3(Min.X, Min.Y, Max.Z),
			new Vector3(Min.X, Max.Y, Min.Z),
			new Vector3(Max.X, Max.Y, Min.Z),
			new Vector3(Max.X, Min.Y, Min.Z),
			new Vector3(Min.X, Min.Y, Min.Z)
		};
	}

	public void GetCorners(Vector3[] corners)
	{
		if (corners == null)
		{
			throw new ArgumentNullException("corners");
		}
		if (corners.Length < 8)
		{
			throw new ArgumentOutOfRangeException("corners");
		}
		corners[0].X = Min.X;
		corners[0].Y = Max.Y;
		corners[0].Z = Max.Z;
		corners[1].X = Max.X;
		corners[1].Y = Max.Y;
		corners[1].Z = Max.Z;
		corners[2].X = Max.X;
		corners[2].Y = Min.Y;
		corners[2].Z = Max.Z;
		corners[3].X = Min.X;
		corners[3].Y = Min.Y;
		corners[3].Z = Max.Z;
		corners[4].X = Min.X;
		corners[4].Y = Max.Y;
		corners[4].Z = Min.Z;
		corners[5].X = Max.X;
		corners[5].Y = Max.Y;
		corners[5].Z = Min.Z;
		corners[6].X = Max.X;
		corners[6].Y = Min.Y;
		corners[6].Z = Min.Z;
		corners[7].X = Min.X;
		corners[7].Y = Min.Y;
		corners[7].Z = Min.Z;
	}

	public BoundingBox(Vector3 min, Vector3 max)
	{
		Min = min;
		Max = max;
	}

	public bool Equals(BoundingBox other)
	{
		if (Min == other.Min)
		{
			return Max == other.Max;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		bool result = false;
		if (obj is BoundingBox)
		{
			result = Equals((BoundingBox)obj);
		}
		return result;
	}

	public override int GetHashCode()
	{
		return Min.GetHashCode() + Max.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{{Min:{0} Max:{1}}}", new object[2]
		{
			Min.ToString(),
			Max.ToString()
		});
	}

	public static BoundingBox CreateMerged(BoundingBox original, BoundingBox additional)
	{
		BoundingBox result = default(BoundingBox);
		Vector3.Min(ref original.Min, ref additional.Min, out result.Min);
		Vector3.Max(ref original.Max, ref additional.Max, out result.Max);
		return result;
	}

	public static void CreateMerged(ref BoundingBox original, ref BoundingBox additional, out BoundingBox result)
	{
		Vector3.Min(ref original.Min, ref additional.Min, out var result2);
		Vector3.Max(ref original.Max, ref additional.Max, out var result3);
		result.Min = result2;
		result.Max = result3;
	}

	public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points)
	{
		if (points == null)
		{
			throw new ArgumentNullException();
		}
		bool flag = false;
		Vector3 v = new Vector3(float.MaxValue);
		Vector3 v2 = new Vector3(float.MinValue);
		List<Vector3> list = points.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Vector3 v3 = list[i];
			Vector3.Min(ref v, ref v3, out v);
			Vector3.Max(ref v2, ref v3, out v2);
			flag = true;
		}
		if (!flag)
		{
			throw new ArgumentException();
		}
		return new BoundingBox(v, v2);
	}

	public bool Intersects(BoundingBox box)
	{
		if (Max.X >= box.Min.X && Min.X <= box.Max.X && Max.Y >= box.Min.Y && Min.Y <= box.Max.Y && Max.Z >= box.Min.Z)
		{
			return Min.Z <= box.Max.Z;
		}
		return false;
	}

	public void Intersects(ref BoundingBox box, out bool result)
	{
		result = false;
		if (Max.X >= box.Min.X && Min.X <= box.Max.X && Max.Y >= box.Min.Y && Min.Y <= box.Max.Y && Max.Z >= box.Min.Z && Min.Z <= box.Max.Z)
		{
			result = true;
		}
	}

	public ContainmentType Contains(BoundingBox box)
	{
		if (!(Max.X < box.Min.X) && Min.X <= box.Max.X)
		{
			if (!(Max.Y < box.Min.Y) && Min.Y <= box.Max.Y)
			{
				if (!(Max.Z < box.Min.Z) && Min.Z <= box.Max.Z)
				{
					if (Min.X <= box.Min.X && box.Max.X <= Max.X && Min.Y <= box.Min.Y && box.Max.Y <= Max.Y && Min.Z <= box.Min.Z && box.Max.Z <= Max.Z)
					{
						return ContainmentType.Contains;
					}
					return ContainmentType.Intersects;
				}
				return ContainmentType.Disjoint;
			}
			return ContainmentType.Disjoint;
		}
		return ContainmentType.Disjoint;
	}

	public void Contains(ref BoundingBox box, out ContainmentType result)
	{
		result = ContainmentType.Disjoint;
		if (Max.X >= box.Min.X && Min.X <= box.Max.X && Max.Y >= box.Min.Y && Min.Y <= box.Max.Y && Max.Z >= box.Min.Z && Min.Z <= box.Max.Z)
		{
			result = ((!(Min.X > box.Min.X) && !(box.Max.X > Max.X) && !(Min.Y > box.Min.Y) && !(box.Max.Y > Max.Y) && !(Min.Z > box.Min.Z) && !(box.Max.Z > Max.Z)) ? ContainmentType.Contains : ContainmentType.Intersects);
		}
	}

	public ContainmentType Contains(Vector3 point)
	{
		if (Min.X <= point.X && point.X <= Max.X && Min.Y <= point.Y && point.Y <= Max.Y && Min.Z <= point.Z && point.Z <= Max.Z)
		{
			return ContainmentType.Contains;
		}
		return ContainmentType.Disjoint;
	}

	public void Contains(ref Vector3 point, out ContainmentType result)
	{
		result = ((!(Min.X > point.X) && !(point.X > Max.X) && !(Min.Y > point.Y) && !(point.Y > Max.Y) && !(Min.Z > point.Z) && !(point.Z > Max.Z)) ? ContainmentType.Contains : ContainmentType.Disjoint);
	}

	internal void method_0(ref Vector3 vector3_0, out Vector3 vector3_1)
	{
		vector3_1 = default(Vector3);
		vector3_1.X = ((vector3_0.X >= 0f) ? Max.X : Min.X);
		vector3_1.Y = ((vector3_0.Y >= 0f) ? Max.Y : Min.Y);
		vector3_1.Z = ((vector3_0.Z >= 0f) ? Max.Z : Min.Z);
	}

	public static bool operator ==(BoundingBox a, BoundingBox b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(BoundingBox a, BoundingBox b)
	{
		if (!(a.Min != b.Min))
		{
			return a.Max != b.Max;
		}
		return true;
	}
}
