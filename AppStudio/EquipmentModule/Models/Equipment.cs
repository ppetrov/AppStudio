using System;

namespace AppStudio.EquipmentModule.Models
{
	// TODO : Generate this
	public sealed class Equipment
	{
		public string SerialNumber { get; }

		public Equipment(string serialNumber)
		{
			if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));

			this.SerialNumber = serialNumber;
		}
	}
}