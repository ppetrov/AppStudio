﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppClient.Core.Core;
using AppClient.Core.Dialog;
using AppClient.Core.Features;
using AppClient.Core.Sort;
using AppClient.Core.ViewModels;
using AppStudio.EquipmentModule.Models;

namespace AppStudio.EquipmentModule.ViewModels
{
	// Type
	// Multiple of Type
	public sealed class EquipmentsViewModel : PageViewModel
	{
		private EquipmentManager Manager { get; set; }
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

		private EquipmentCaptions Captions { get; }

		public EquipmentsViewModel(MainContext mainContext) : base(mainContext)
		{
			this.SearchHint = this.MainContext.GetLocal(string.Empty);

			// TODO : Generate this method
			//var captions = new EquipmentCaptions(serialNumberCaption, powerCaption, lastCheckedCaption);
			this.SerialNumberOption = new SortOption(this.MainContext.GetLocal(nameof(EquipmentProperty.SerialNumber)), EquipmentProperty.SerialNumber);
			this.PowerOption = new SortOption(this.MainContext.GetLocal(nameof(EquipmentProperty.Power)), EquipmentProperty.Power);
			this.LastCheckedOption = new SortOption(this.MainContext.GetLocal(nameof(EquipmentProperty.LastChecked)), EquipmentProperty.LastChecked);
			this.Captions = new EquipmentCaptions("", "", "");

			//this.ClearSearchCommand = new Command(this.ClearSearch);

			//this.SelectSortOptionCommand = new Command(this.SelectSortOption);
		}

		public override void LoadData(object parameter)
		{
			if (parameter == null) throw new ArgumentNullException(nameof(parameter));

			this.IsBusy = true;
			try
			{
				this.Manager = parameter as EquipmentManager;

				Task.Run(() =>
				{
					try
					{
						this.Equipments.Clear();
						foreach (var equipment in this.Manager.GetEquipments())
						{
							this.Equipments.Add(new EquipmentViewModel(equipment, this.Captions));
						}
					}
					catch (Exception ex)
					{
						this.MainContext.Log(ex);
					}
					finally
					{
						// TODO : !!!!
						// Invoke on the main thread
						{
							this.IsBusy = false;
							this.DisplayData();
						};
					}
				});
			}
			catch (Exception ex)
			{
				this.MainContext.Log(ex);
			}
		}

		public async void Add()
		{
			try
			{
				var equipment = await this.Manager.AddAsync(default(Equipment));
				if (equipment != null)
				{
					this.Equipments.Add(new EquipmentViewModel(equipment, this.Captions));

					this.DisplayData();
				}
			}
			catch (Exception ex)
			{
				this.MainContext.Log(ex);
			}
		}

		private async Task Delete()
		{
			var feature = new Feature(nameof(EquipmentsViewModel), nameof(this.Delete));
			try
			{
				this.MainContext.Save(feature);

				// TODO : !!!
				var viewModel = this.Equipments[0];

				var confirmation = await this.MainContext.ConfirmAsync(@"Confirm delete equipment?", ConfirmationType.YesNo);
				if (confirmation == ConfirmationResult.Accept)
				{
					if (await this.Manager.DeleteAsync(viewModel.Model))
					{
						this.Equipments.Remove(viewModel);

						this.DisplayData(false);
					}
				}
			}
			catch (Exception ex)
			{
				this.MainContext.Save(feature, ex);
			}
		}

		private void DisplayData(bool sort = true)
		{
			if (sort)
			{
				this.Sort();
			}
			this.ApplyTextSearch();
		}

		private void SelectSortOption()
		{
			var feature = new Feature(nameof(EquipmentsViewModel), nameof(this.SelectSortOption));
			try
			{
				this.MainContext.Save(feature);

				//this.MainContext.SelectSortOption(this.SortOptions, this.ApplySort);
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

		private void Sort()
		{
			var sortOption = this.SortOptions.FirstOrDefault(s => s.SortDirection.HasValue) ??
							 this.SortOptions.FirstOrDefault();
			if (sortOption != null)
			{
				this.Sort(sortOption);
			}
		}

		private void Sort(SortOption sortOption)
		{
			var property = (EquipmentProperty)sortOption.Property;
			Sort(this.Equipments, default(SortOption), property);
			Sort(this.CurrentEquipments, default(SortOption), property);
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

			this.Sort(sortOption);

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