using System;
using AppCore.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// TODO : Generate this
	public sealed class EquipmentViewModel : ViewModel
	{
		public Equipment Equipment { get; }

		public string SerialNumberCaption { get; }
		public string SerialNumber { get; }

		public EquipmentViewModel(Equipment equipment, EquipmentCaptions captions)
		{
			if (equipment == null) throw new ArgumentNullException(nameof(equipment));
			if (captions == null) throw new ArgumentNullException(nameof(captions));

			this.Equipment = equipment;

			this.SerialNumber = equipment.SerialNumber;
			this.SerialNumberCaption = captions.SerialNumber;
		}
	}
}