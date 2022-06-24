using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Checkers.Models;
using Checkers.ViewModels.Commands;
using Checkers.Views;

namespace Checkers.ViewModels
{
    public class GameWithAIViewModel : BaseViewModel
    {
        private readonly IGameWithAIModel _gameWithAIModel;

        public GameWithAIViewModel(IGameWithAIModel gameWithAIModel)
        {
          
            _gameWithAIModel = gameWithAIModel;
            InfoPanelVisibility = 0;
            IsCheckInfoPanel = true;

            StatusText = "";
            TimePassed = "00:00:00";

            ExitCommand = new RelayCommand(Exit);
            ExitToMenuCommand = new RelayCommand(ExitToMenu);
            NewGameCommand = new RelayCommand(NewGame);
        }

        public RelayCommand ExitCommand { get; set; }
        private static void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        public RelayCommand ExitToMenuCommand { get; set; }
        private void ExitToMenu(object obj)
        {
            _gameWithAIModel.View.Close();
            MainWindow.Instance.Show();
        }

        public RelayCommand NewGameCommand { get; set; }
        private void NewGame(object obj)
        {
            StatusText = "Black's turn.";
            _gameWithAIModel.StartNewGame();
        }

        private Visibility _infoPanelVisibility;
        public Visibility InfoPanelVisibility
        {
            get => _infoPanelVisibility;
            set
            {
                _infoPanelVisibility = value;
                OnPropertyChanged();
            }
        } 

        private bool _isCheckInfoPanel;
        public bool IsCheckInfoPanel
        {
            get => _isCheckInfoPanel;
            set
            {
                _isCheckInfoPanel = value;
                OnPropertyChanged();
            } 
        }

        private string _statusText;
        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                OnPropertyChanged();
            }
        } 

        private string _timePassed;
        public string TimePassed
        {
            get => _timePassed;
            set
            {
                _timePassed = value;
                OnPropertyChanged();
            } 
        }
    }
}
