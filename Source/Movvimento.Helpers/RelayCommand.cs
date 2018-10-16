using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControleDeAulas.Helpers
{
	public class RelayCommand : ICommand
	{
		#region Fields

		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;

		#endregion // Fields

		#region Constructors
		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="execute"></param>
		public RelayCommand(Action<object> execute) : this(execute, null) { }

		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		#region ICommand Members
		/// <summary>
		/// Aplica os commands
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		/// <summary>
		/// Aplica os commands
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		/// <summary>
		/// Aplica os commands
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
		#endregion // ICommand Members
	}
}
