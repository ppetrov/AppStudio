using System;

namespace AppStudio.EquipmentModule.Models
{
	// TODO : Generate this
	public sealed class EquipmentCaptions
	{
		public string SerialNumber { get; }

		public EquipmentCaptions(string serialNumber)
		{
			if (serialNumber == null) throw new ArgumentNullException(nameof(serialNumber));

			this.SerialNumber = serialNumber;
		}
	}
}