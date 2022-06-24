using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Models;
using Checkers.Views;
using System.Windows;
using System.Windows.Input;
using Checkers.ViewModels.Commands;

namespace Checkers.ViewModels
{
    public class PreloaderViewModel : BaseViewModel
    {
        public ICommand ExitCommand { get; set; }
        public ICommand GameWithAICommand { get; set; }
        public ICommand ChangeStyleCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }

        private readonly PreloaderModel _gamePreloaderModel;
        
        public PreloaderViewModel(PreloaderModel gamePreloaderModel)
        {
            _gamePreloaderModel = gamePreloaderModel;

            ExitCommand = new ExitCommand();
            GameWithAICommand = new GameWithAICommand(_gamePreloaderModel);
            ChangeStyleCommand = new ChangeStyleCommand();
            StatisticsCommand = new StatisticsCommand();
        }
    }
}
