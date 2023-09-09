using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class SentinelDrone : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DroneBaseTypeStruct
	{
		private long intptr_BaseItemTypeData;

		private long intptr_BaseItemTypeFile;

		private long intptr_DroneTypeData;

		private long intptr_DroneTypeFile;

		public int Charges;

		public int Duration;

		public int Empowers;

		private long intptr_BuffVisualData;

		private long intptr_BuffVisualFile;

		public int Empowerments;
	}

	private static int _droneBaseTypeStructSize = -1;

	private PerFrameCachedValue<DroneBaseTypeStruct> perFrameCachedValue_1;

	public int ChargesUsed => base.M.ReadByte(base.Address + 32L);

	public int BaseCharges => PCV_ArchnemesisWorldItemStruct.Charges;

	public int BaseDuration => PCV_ArchnemesisWorldItemStruct.Duration;

	public int BaseEmpowers => PCV_ArchnemesisWorldItemStruct.Empowers;

	public int BaseEmpowerments => PCV_ArchnemesisWorldItemStruct.Empowerments;

	internal DroneBaseTypeStruct PCV_ArchnemesisWorldItemStruct
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<DroneBaseTypeStruct>(() => GetDroneBaseTypeStruct);
			}
			return perFrameCachedValue_1.Value;
		}
	}

	internal DroneBaseTypeStruct GetDroneBaseTypeStruct
	{
		get
		{
			if (_droneBaseTypeStructSize == -1)
			{
				_droneBaseTypeStructSize = MarshalCache<DroneBaseTypeStruct>.Size;
			}
			return base.M.FastIntPtrToStruct<DroneBaseTypeStruct>(base.M.ReadLong(base.Address + 16L, 16L), _droneBaseTypeStructSize);
		}
	}
}
