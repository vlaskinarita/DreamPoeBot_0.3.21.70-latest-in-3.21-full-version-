using System.Runtime.InteropServices;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Common;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LineSegment
{
	public Vector3 Start;

	public Vector3 End;

	public float DistanceSqr => Vector3.DistanceSqr(ref Start, ref End);

	public float Distance => Vector3.Distance(ref Start, ref End);

	public Vector3 Direction => End - Start;

	public Vector3 UnitDirection
	{
		get
		{
			Vector3 result = End - Start;
			result.Normalize();
			return result;
		}
	}

	public LineSegment(Vector3 start, Vector3 end)
	{
		Start = start;
		End = end;
	}

	public float ClosestT(Vector3 point)
	{
		return MathEx.Clamp(0f, 1f, Vector3.Dot(point - Start, Direction) / DistanceSqr);
	}

	public Vector3 ClosestPoint(Vector3 point)
	{
		return Start + ClosestT(point) * Direction;
	}
}
