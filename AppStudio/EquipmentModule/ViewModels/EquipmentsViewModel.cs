using System;
using System.Collections.Generic;
using System.Windows.Input;
using AppCore;
using AppCore.Features;
using AppCore.Localization;
using AppCore.Sort;
using AppCore.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// Type
	// Multiple of Type
	public sealed class EquipmentsViewModel : PageViewModel
	{
		private List<EquipmentViewModel> Equipments { get; } = new List<EquipmentViewModel>();

		public string SearchHint { get; }

		private string _searchText = string.Empty;
		public string SearchText
		{
			get { return _searchText; }
			set
			{
				if (this.SetProperty(ref _searchText, value))
				{
					var feature = new Feature(nameof(EquipmentsViewModel), nameof(this.ApplyTextSearch));
					try
					{
						// Log only the first usage of the search text,
						// the transition from empty to non-empty.
						if (string.IsNullOrWhiteSpace(_searchText) &&
							!string.IsNullOrWhiteSpace(value))
						{
							this.MainContext.Save(feature);
						}

						this.ApplyTextSearch();
					}
					catch (Exception ex)
					{
						this.MainContext.Save(feature, ex);
					}
				}
			}
		}

		public ICommand ClearSearchCommand { get; }

		private SortOption[] SortOptions
		{
			get
			{
				return new[]
				{
					this.SerialNumberOption,
					this.PowerOption,
					this.LastCheckedOption,
				};
			}
		}
		public SortOption SerialNumberOption { get; }
		public SortOption PowerOption { get; }
		public SortOption LastCheckedOption { get; }

		public ICommand SelectSortOptionCommand { get; }

		private List<EquipmentViewModel> _currentEquipments = new List<EquipmentViewModel>(0);
		public List<EquipmentViewModel> CurrentEquipments
		{
			get { return _currentEquipments; }
			set { this.SetProperty(ref _currentEquipments, value); }
		}

		public EquipmentCaptions Captions { get; }

		public EquipmentsViewModel(MainContext mainContext) : base(mainContext)
		{
			var localization = this.MainContext.GetService<LocalizationManager>();

			this.SearchHint = localization.GetMessage(string.Empty);

			// TODO : Generate this method
			//var captions = new EquipmentCaptions(serialNumberCaption, powerCaption, lastCheckedCaption);
			this.SerialNumberOption = new SortOption(localization.GetMessage(nameof(EquipmentProperty.SerialNumber)), EquipmentProperty.SerialNumber);
			this.PowerOption = new SortOption(localization.GetMessage(nameof(EquipmentProperty.Power)), EquipmentProperty.Power);
			this.LastCheckedOption = new SortOption(localization.GetMessage(nameof(EquipmentProperty.LastChecked)), EquipmentProperty.LastChecked);
			this.Captions = new EquipmentCaptions("", "", "");

			this.ClearSearchCommand = new Command(this.ClearSearch);

			this.SelectSortOptionCommand = new Command(this.SelectSortOption);
		}

		public override void LoadData(object parameter)
		{
			if (parameter == null) throw new ArgumentNullException(nameof(parameter));

			try
			{
				var viewModels = parameter as IEnumerable<EquipmentViewModel>;

				this.Equipments.Clear();
				this.Equipments.AddRange(viewModels);

				this.ApplyTextSearch();
			}
			catch (Exception ex)
			{
				this.MainContext.Log(ex);
			}
		}

		private void SelectSortOption()
		{
			var feature = new Feature(nameof(EquipmentsViewModel), nameof(this.SelectSortOption));
			try
			{
				this.MainContext.Save(feature);

				this.MainContext.SelectSortOption(this.SortOptions, this.ApplySort);
			}
			catch (Exception ex)
			{
				this.MainContext.Save(feature, ex);
			}
		}

		private void ClearSearch()
		{
			var feature = new Feature(nameof(EquipmentsViewModel), nameof(this.ClearSearch));
			try
			{
				this.MainContext.Save(feature);

				this.SearchText = string.Empty;
			}
			catch (Exception ex)
			{
				this.MainContext.Save(feature, ex);
			}
		}

		private void ApplyTextSearch()
		{
			var matches = new List<EquipmentViewModel>();

			var searchText = this.SearchText;
			foreach (var viewModel in this.Equipments)
			{
				if (IsTextMatch(viewModel, searchText))
				{
					matches.Add(viewModel);
				}
			}

			this.CurrentEquipments = matches;
		}

		private void ApplySort(SortOption sortOption)
		{
			foreach (var option in this.SortOptions)
			{
				if (option != sortOption)
				{
					option.SortDirection = null;
				}
			}

			var property = (EquipmentProperty)sortOption.Data;
			Sort(this.Equipments, default(SortOption), property);
			Sort(this.CurrentEquipments, default(SortOption), property);

			this.CurrentEquipments = new List<EquipmentViewModel>(this.CurrentEquipments);
		}

		private static void Sort(List<EquipmentViewModel> viewModels, SortOption sortOption, EquipmentProperty property)
		{
			switch (property)
			{
				case EquipmentProperty.SerialNumber:
					viewModels.Sort((x, y) => string.Compare(x.SerialNumber, y.SerialNumber, StringComparison.OrdinalIgnoreCase));
					break;
				case EquipmentProperty.Power:
					viewModels.Sort((x, y) =>
					{
						var cmp = x.Model.Power.CompareTo(y.Model.Power);
						if (cmp == 0)
						{
							cmp = x.Model.Id.CompareTo(y.Model.Id);
						}
						return cmp;
					});
					break;
				case EquipmentProperty.LastChecked:
					viewModels.Sort((x, y) =>
					{
						var cmp = (x.Model.LastChecked ?? DateTime.MinValue).CompareTo((y.Model.LastChecked ?? DateTime.MinValue));
						if (cmp == 0)
						{
							cmp = x.Model.Id.CompareTo(y.Model.Id);
						}
						return cmp;
					});
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			if ((sortOption.SortDirection ?? SortDirection.Asc) == SortDirection.Desc)
			{
				viewModels.Reverse();
			}
		}

		private static bool IsTextMatch(EquipmentViewModel viewModel, string searchText)
		{
			return
				viewModel.SerialNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
				viewModel.Power.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
				viewModel.LastChecked.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}
}