using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Checkers.Models;
using Checkers.Views;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.ViewModels.Commands
{
    public class ExitToMenuCommand : ICommand
    {
        private readonly Window _viewToClose;
        public MainWindow MainWindow { get; set; }

        public ExitToMenuCommand(Window viewToClose)
        {
            _viewToClose = viewToClose;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var statistics = new StatisticsWindow(MainWindow) {Style = MainWindow.Style};
            statistics.ApplyTheStyles();

            _viewToClose.Close();

            MainWindow.DataContext = new PreloaderViewModel(MainWindow, statistics);
            MainWindow.Show();
        }
    }
}
