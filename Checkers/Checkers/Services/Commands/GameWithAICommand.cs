using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;

namespace Checkers.ViewModels.Commands
{
    public class GameWithAICommand : ICommand
    {
        private PreloaderModel _gamePreloaderModel;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public GameWithAICommand(PreloaderModel preloaderModel)
        {
            _gamePreloaderModel = preloaderModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _gamePreloaderModel.StartNewGameWithAI();
            MainWindow.Instance.Hide();
        }
    }
}
