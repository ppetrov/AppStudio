using System;
using AppClient.Core.Core;
using AppClient.Core.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// TODO : Generate this
	public sealed class EquipmentsPageViewModel : PageViewModel
	{
		public EquipmentsViewModel ViewModel { get; }

		public EquipmentsPageViewModel(MainContext mainContext) : base(mainContext)
		{
			if (mainContext == null) throw new ArgumentNullException(nameof(mainContext));

			// Register = OK
			//this.MainContext.RegisterServiceCreator(() => new EquipmentManager(this.MainContext));

			this.ViewModel = new EquipmentsViewModel(mainContext);
		}

		public override void LoadData(object parameter)
		{
			try
			{
				this.ViewModel.LoadData(this.MainContext.GetService<EquipmentManager>());
			}
			catch (Exception ex)
			{
				this.MainContext.Log(ex);
			}
		}
	}
}