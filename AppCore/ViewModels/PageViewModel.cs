using System;

namespace AppCore.ViewModels
{
	public abstract class PageViewModel : ViewModel
	{
		public MainContext MainContext { get; }

		private string _title = string.Empty;
		public string Title
		{
			get { return _title; }
			set { this.SetProperty(ref _title, value); }
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set { this.SetProperty(ref _isBusy, value); }
		}

		protected PageViewModel(MainContext mainContext)
		{
			if (mainContext == null) throw new ArgumentNullException(nameof(mainContext));

			this.MainContext = mainContext;
		}

		public virtual void LoadData(object parameter)
		{
		}
	}
}