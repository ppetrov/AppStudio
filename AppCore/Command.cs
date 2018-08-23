using System;
using System.Windows.Input;

namespace AppCore
{
	public sealed class Command : ICommand
	{
		public Command(Action action)
		{
			
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