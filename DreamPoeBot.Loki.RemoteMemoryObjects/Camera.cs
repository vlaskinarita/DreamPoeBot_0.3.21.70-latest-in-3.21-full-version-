using System.Numerics;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Camera : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	internal struct Struct_CameraStructure
	{
		[FieldOffset(664)]
		public int Width;

		[FieldOffset(668)]
		public int Height;

		[FieldOffset(320)]
		public Struct957 Cam1;

		[FieldOffset(996)]
		public Vector3 Position;

		[FieldOffset(984)]
		public float ZFar;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct957
	{
		public readonly float M11;

		public readonly float M12;

		public readonly float M13;

		public readonly float M14;

		public readonly float M21;

		public readonly float M22;

		public readonly float M23;

		public readonly float M24;

		public readonly float M31;

		public readonly float M32;

		public readonly float M33;

		public readonly float M34;

		public readonly float M41;

		public readonly float M42;

		public readonly float M43;

		public readonly float M44;
	}

	public int Width => CameraStructure.Width;

	public int Height => CameraStructure.Height;

	public float ZFar => CameraStructure.ZFar;

	internal Struct_CameraStructure CameraStructure => base.M.FastIntPtrToStruct<Struct_CameraStructure>(base.Address + 168L);
}
