using System;
using System.Windows.Input;

namespace Bank.Command
{

	public class RelayCommand : ICommand
	{

		#region Fields

		private readonly Action<object> _action;
		private readonly Func<object, bool> _func;

		#endregion

		#region Events

		public event EventHandler? CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		#endregion

		#region Constructors

		public RelayCommand(Action<object> action, Func<object, bool> func = null)
		{
			_action = action;
			_func = func;
		}

		#endregion

		#region Methods

		public bool CanExecute(object? parameter) => parameter is null ? true : _func?.Invoke(parameter) ?? true;

		public void Execute(object? parameter) => _action?.Invoke(parameter);

		#endregion

	}

}