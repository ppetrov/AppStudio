using System;
using AppCore.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// Complete
	public sealed class EquipmentViewModel : ViewModel
	{
		public Equipment Equipment { get; }
		public string SerialNumber { get; }
		public string SerialNumberCaption { get; }
		public string Power { get; }
		public string PowerCaption { get; }
		public string LastChecked { get; }
		public string LastCheckedCaption { get; }

		public EquipmentViewModel(Equipment equipment, EquipmentCaptions captions)
		{
			if (equipment == null) throw new ArgumentNullException(nameof(equipment));
			if (captions == null) throw new ArgumentNullException(nameof(captions));

			this.Equipment = equipment;
			this.SerialNumber = equipment.SerialNumber;
			this.SerialNumberCaption = captions.SerialNumber;
			this.Power = equipment.Power.ToString(@"F2");
			this.PowerCaption = captions.Power;
			this.LastChecked = equipment.LastChecked.ToString(@"dd MMM yyyy");
			this.LastCheckedCaption = captions.LastChecked;
		}
	}
}