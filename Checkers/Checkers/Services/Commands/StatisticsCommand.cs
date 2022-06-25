using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Checkers.Views;

namespace Checkers.ViewModels.Commands
{
    public class StatisticsCommand : ICommand
    {
        private readonly StatisticsWindow _view;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public StatisticsCommand(StatisticsWindow view)
        {
            _view = view;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _view.Show();
            MainWindow.Instance.Hide();
        }
    }
}
