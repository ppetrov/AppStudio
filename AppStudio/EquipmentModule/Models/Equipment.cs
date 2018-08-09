using System;

namespace AppStudio.EquipmentModule.Models
{
	public sealed class Equipment
	{
		public long Id { get; }
		public string SerialNumber { get; }
		public decimal Power { get; }

		public Equipment(long id, string serialNumber, decimal power)
		{
			if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));

			this.Id = id;
			this.SerialNumber = serialNumber;
			this.Power = power;
		}
	}
}