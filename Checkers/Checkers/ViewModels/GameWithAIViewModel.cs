using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Checkers.Models;
using Checkers.ViewModels.Commands;
using Checkers.Views;

namespace Checkers.ViewModels
{
    public class GameWithAIViewModel : ViewModelBase
    {
        private Visibility _infoPanelVisibility;
        private bool _isCheckInfoPanel;
        private string _statusText;
        private string _timePassed;
        public ICommand ExitCommand { get; set; }
        public ICommand ExitToMenuCommand { get; set; }
        public ICommand NewGameCommand { get; set; }

        public GameWithAIViewModel(IGameWithAIModel gameWithAIModel, MainWindow mainWindow)
        {
            InfoPanelVisibility = 0;
            IsCheckInfoPanel = true;

            StatusText = "";
            TimePassed = "00:00:00";

            ExitCommand = new ExitCommand();
            ExitToMenuCommand = new ExitToMenuCommand(gameWithAIModel.View){MainWindow = mainWindow};
            NewGameCommand = new NewGameCommand(gameWithAIModel, this);
        }

        public Visibility InfoPanelVisibility
        {
            get => _infoPanelVisibility;
            set
            {
                _infoPanelVisibility = value;
                OnPropertyChanged();
            }
        } 

        public bool IsCheckInfoPanel
        {
            get => _isCheckInfoPanel;
            set
            {
                _isCheckInfoPanel = value;
                OnPropertyChanged();
            } 
        }

        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                OnPropertyChanged();
            }
        } 

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
