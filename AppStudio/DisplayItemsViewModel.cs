using System;
using System.Collections.Generic;
using System.Windows.Input;
using AppCore;
using AppCore.ViewModels;

namespace AppStudio
{
	public sealed class ArticlesPageViewModel : PageViewModel
	{
		public ArticlesViewModel ViewModel { get; } = new ArticlesViewModel();

		public ArticlesPageViewModel(MainContext mainContext) : base(mainContext)
		{
		}

		public override void LoadData(object parameter)
		{
			
		}
	}

	public sealed class ArticlesViewModel : ViewModel
	{
		private List<string> AllArticles { get; } = new List<string>();

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

		private List<string> _articles;
		public List<string> Articles
		{
			get { return _articles; }
			set { this.SetProperty(ref _articles, value); }
		}

		public ArticlesViewModel()
		{
			this.SearchHint = @"TODO : !!!";

			this.ClearSearchCommand = null;
		}

		private void ApplyTextSearch()
		{
			// TODO : Define Items
			//throw new System.NotImplementedException();
		}
	}
}