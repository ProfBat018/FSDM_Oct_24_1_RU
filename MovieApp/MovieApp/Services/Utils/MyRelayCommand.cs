using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieApp.Services.Utils;

class MyRelayCommand : ICommand
{
    private readonly Action _commandAction;
    private readonly Func<bool> _canExecute;

    public MyRelayCommand(Action commandAction, Func<bool> canExecute)
    {
        _commandAction = commandAction;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) => _canExecute(); 

    public void Execute(object parameter) => _commandAction();


    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
