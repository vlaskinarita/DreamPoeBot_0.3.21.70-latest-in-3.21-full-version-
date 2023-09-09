using System;
using System.Diagnostics;
using System.Windows.Input;

namespace DreamPoeBot.Loki.Common.MVVM;

public class RelayCommand : ICommand
{
	private readonly Action<object> action_0;

	private readonly Predicate<object> predicate_0;

	public event EventHandler CanExecuteChanged
	{
		add
		{
			CommandManager.RequerySuggested += value;
		}
		remove
		{
			CommandManager.RequerySuggested -= value;
		}
	}

	public RelayCommand(Action<object> execute)
		: this(execute, null)
	{
	}

	public RelayCommand(Action<object> execute, Predicate<object> canExecute)
	{
		if (execute == null)
		{
			throw new ArgumentNullException("execute");
		}
		action_0 = execute;
		predicate_0 = canExecute;
	}

	[DebuggerStepThrough]
	public bool CanExecute(object parameter)
	{
		if (predicate_0 != null)
		{
			return predicate_0(parameter);
		}
		return true;
	}

	public void Execute(object parameter)
	{
		action_0(parameter);
	}
}
