using System;
using AppCore.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// Complete
	public sealed class EquipmentViewModel : ViewModel
	{
		public Equipment Model { get; }
		public string SerialNumber { get; }
		public string SerialNumberCaption { get; }
		public string Power { get; }
		public string PowerCaption { get; }
		public string LastChecked { get; }
		public string LastCheckedCaption { get; }

		public EquipmentViewModel(Equipment model, EquipmentCaptions captions)
		{
			if (model == null) throw new ArgumentNullException(nameof(model));
			if (captions == null) throw new ArgumentNullException(nameof(captions));

			this.Model = model;
			this.SerialNumber = model.SerialNumber;
			this.SerialNumberCaption = captions.SerialNumber;
			this.Power = model.Power.ToString(@"F2");
			this.PowerCaption = captions.Power;
			this.LastChecked = model.LastChecked.HasValue ? model.LastChecked.Value.ToString(@"dd MMM yyyy") : GetValue(string.Empty);;
			this.LastCheckedCaption = captions.LastChecked;
		}
	}
}