using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;

namespace Checkers.ViewModels.Commands
{
    public class ExitToMenuCommand : ICommand
    {
        private IGameWithAIModel _gameWithAIModel;

        public ExitToMenuCommand(IGameWithAIModel gameWithAIModel)
        {
            _gameWithAIModel = gameWithAIModel;
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
            _gameWithAIModel.View.Close();
            MainWindow.Instance.Show();
        }
    }
}
