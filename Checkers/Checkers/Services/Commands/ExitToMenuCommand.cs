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
        private readonly Window _view;

        public ExitToMenuCommand(Window view)
        {
            _view = view;
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
          _view.Close();

            MainWindow.Instance.DataContext = new PreloaderViewModel();
            MainWindow.Instance.Show();
        }
    }
}
