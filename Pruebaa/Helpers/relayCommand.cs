using System;
using System.Windows.Input;

namespace Pruebaa.Helpers;
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExcecute; 

    public RelayCommand(Action execute) : this(execute, null) { }

    public RelayCommand(Action execute, Func<bool>? canExecute)
    {
        _execute = execute;
        _canExcecute = canExecute;
    }

    public bool CanExecute(object? parameter)=> _canExcecute?.Invoke() ?? true; //returns true if canExecute is null

    public void Execute(object? parameter)=> _execute();

    public event EventHandler? CanExecuteChanged;
}