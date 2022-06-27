using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;
using Checkers.Views;

namespace Checkers.ViewModels.Commands
{
    public class GameWithAICommand : ICommand
    {
        public MainWindow MainWindow { get; set; }

        private PreloaderModel _gamePreloaderModel;
        private readonly InputForm _inputForm;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public GameWithAICommand(PreloaderModel preloaderModel, InputForm inputForm)
        {
            _gamePreloaderModel = preloaderModel;
            _inputForm = inputForm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _gamePreloaderModel.StartNewGameWithAI(_inputForm, MainWindow);
            _inputForm.Close();
        }
    }
}
