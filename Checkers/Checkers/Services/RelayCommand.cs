﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers.Services
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        private readonly Func<object, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter != null && (_canExecute == null || _canExecute(parameter));
        }

        public void Execute(object? parameter)
        {
            if (parameter != null) _execute(parameter);
        }
    }
}
