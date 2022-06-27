using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Models;
using Checkers.Views;
using System.Windows;
using System.Windows.Input;
using Checkers.Services.Commands;
using Checkers.ViewModels.Commands;

namespace Checkers.ViewModels
{
    public class PreloaderViewModel : ViewModelBase
    {
        public ICommand ExitCommand { get; set; }
        public ICommand InputFormCommand { get; set; }
        public ICommand ChangeStyleCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }

        public PreloaderViewModel(MainWindow mainWindow, StatisticsWindow statisticsWindow)
        {
            ExitCommand = new ExitCommand();
            InputFormCommand = new InputFormCommand() {MainWindow = mainWindow };
            ChangeStyleCommand = new ChangeStyleCommand() {MainWindow = mainWindow, StatisticsWindow = statisticsWindow };
            StatisticsCommand = new StatisticsCommand(mainWindow, statisticsWindow);
        }
    }
}
