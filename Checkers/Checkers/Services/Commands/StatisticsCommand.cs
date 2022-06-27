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
        private readonly StatisticsWindow _statisticsWindow;
        private readonly MainWindow _mainWindow;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public StatisticsCommand(MainWindow mainWindow, StatisticsWindow statisticsWindow)
        {
            _statisticsWindow = statisticsWindow;
            _mainWindow = mainWindow;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _statisticsWindow.Show();
            _mainWindow.Hide();
        }
    }
}
