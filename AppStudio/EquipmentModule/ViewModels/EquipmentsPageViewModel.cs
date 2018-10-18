using System;
using System.Linq;
using System.Threading.Tasks;
using AppCore;
using AppCore.ViewModels;
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

			this.ViewModel = new EquipmentsViewModel(mainContext);
		}

		public override void LoadData(object parameter)
		{
			this.IsBusy = true;

			Task.Run(() =>
			{
				try
				{
					var viewModels = EquipmentDataProvider
						.GetEquipments(this.MainContext)
						.Select(v => new EquipmentViewModel(v, this.ViewModel.Captions));

					// TODO : !!! Marshal to the UI Thread
					try
					{
						this.ViewModel.LoadData(viewModels);
					}
					catch (Exception ex)
					{
						this.MainContext.Log(ex);
					}
					finally
					{
						this.IsBusy = false;
					}
				}
				catch (Exception ex)
				{
					this.MainContext.Log(ex);
				}
			});
		}
	}
}