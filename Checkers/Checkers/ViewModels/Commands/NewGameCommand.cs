using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;

namespace Checkers.ViewModels.Commands
{
    public class NewGameCommand : ICommand
    {
        private IGameWithAIModel _gameWithAIModel;
        private GameWithAIViewModel _gameWithAIViewModel;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        public NewGameCommand(IGameWithAIModel gameWithAIModel, GameWithAIViewModel gameWithAIViewModel)
        {
            _gameWithAIModel = gameWithAIModel;
            _gameWithAIViewModel = gameWithAIViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _gameWithAIViewModel.StatusText = "Black's turn.";
            _gameWithAIModel.StartNewGame();
        }
    }
}
