using System;
using System.Windows.Input;

namespace AppStudio
{
	public sealed class ActionCommand : ICommand
	{
		private Action Action { get; }

		public ActionCommand(Action action)
		{
			if (action == null) throw new ArgumentNullException(nameof(action));

			this.Action = action;
		}

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}

		public event EventHandler CanExecuteChanged;
	}
}