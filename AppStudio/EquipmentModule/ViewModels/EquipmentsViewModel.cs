﻿using System;
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
	// TODO : Generate this
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
					this.ApplyTextSearch();
				}
			}
		}

		public ICommand ClearSearchCommand { get; }

		public SortOption[] SortOptions { get; }
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
			var localization = this.MainContext.GetService<ILocalization>();

			// TODO : Generate this method
			var serialNumberCaption = localization.GetValue(string.Empty);
			this.Captions = new EquipmentCaptions(serialNumberCaption);

			this.SearchHint = localization.GetValue(string.Empty);
			this.ClearSearchCommand = new ActionCommand(this.ClearSearch);

			// TODO : Generate this method
			this.SortOptions = new[]
			{
				new SortOption(serialNumberCaption, EquipmentProperty.SerialNumber),
			};
			this.SelectSortOptionCommand = new ActionCommand(this.SelectSortOption);
		}

		public void LoadData(IEnumerable<EquipmentViewModel> viewModels)
		{
			if (viewModels == null) throw new ArgumentNullException(nameof(viewModels));

			this.Equipments.Clear();
			this.Equipments.AddRange(viewModels);

			this.ApplyTextSearch();
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
			var searchText = this.SearchText;

			var capacity = 0;
			if (string.IsNullOrEmpty(searchText))
			{
				capacity = this.Equipments.Count;
			}
			var results = new List<EquipmentViewModel>(capacity);

			foreach (var viewModel in this.Equipments)
			{
				//
				// TODO : Define search method
				// 
				if (viewModel.SerialNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					results.Add(viewModel);
				}
			}

			this.CurrentEquipments = results;
		}

		// TODO : Generate this method
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

		// TODO : Generate this method
		private static void Sort(List<EquipmentViewModel> equipments, SortOption sortOption, EquipmentProperty property)
		{
			switch (property)
			{
				case EquipmentProperty.SerialNumber:
					equipments.Sort((x, y) => string.Compare(x.SerialNumber, y.SerialNumber, StringComparison.OrdinalIgnoreCase));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			if ((sortOption.SortDirection ?? SortDirection.Asc) == SortDirection.Desc)
			{
				equipments.Reverse();
			}
		}
	}
}