using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Models;
using Checkers.Views;
using System.Windows;
using Checkers.ViewModels.Commands;

namespace Checkers.ViewModels
{
    public class PreloaderViewModel : BaseViewModel
    {
        private readonly PreloaderModel _gamePreloaderModel;

        public PreloaderViewModel(PreloaderModel gamePreloaderModel)
        {
            _gamePreloaderModel = gamePreloaderModel;

            ExitCommand = new RelayCommand(Exit);
            GameWithAICommand = new RelayCommand(GameWithComputer);
            //OnlineGameClientCommand = new RelayCommand(OnlineGameClient);
            //OnlineGameServerCommand = new RelayCommand(OnlineGameServer);
        }

        public RelayCommand GameWithAICommand { get; set; }
        private void GameWithComputer(object obj)
        {
            _gamePreloaderModel.StartNewGameWithAI();
            MainWindow.Instance.Hide();
        }

        public RelayCommand ExitCommand { get; set; }
        private static void Exit(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
