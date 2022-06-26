using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services.Logger;
using Checkers.Services.Styles;
using Checkers.Views;

namespace Checkers.ViewModels.Commands
{
    public class ChangeStyleCommand : ICommand
    {
        private Logger _logger;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public ChangeStyleCommand()
        {
            _logger = new Logger(new FileLog("D:\\fileLogs.txt"));
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            TryChangeStyles();
        }

        private void TryChangeStyles()
        {
            try
            {
                var mainWindow = MainWindow.Instance;
               
                var statisticsWindow = StatisticsWindow.Instance;

                switch (mainWindow.Style.Style)
                {
                    case Style.Green:
                        mainWindow.Style = new PacificPaletteStyle();
                        statisticsWindow.Style = new PacificPaletteStyle();
                        break;
                    case Style.Pacific:
                        mainWindow.Style = new BasePaletteStyle();
                        statisticsWindow.Style = new BasePaletteStyle();
                        break;
                    case Style.Base:
                        mainWindow.Style = new GreenPaletteStyle();
                        statisticsWindow.Style = new GreenPaletteStyle();
                        break;
                    default:
                        return;
                }

                mainWindow.Style.ChangeButtonStyle(mainWindow.Play);
                mainWindow.Style.ChangeButtonStyle(mainWindow.Stats);
                mainWindow.Style.ChangeButtonStyle(mainWindow.Styles);
                mainWindow.Style.ChangeButtonStyle(mainWindow.Exit);
                mainWindow.Style.ChangeGridStyle(mainWindow.Grid);
                mainWindow.Style.ChangeNameStyle(mainWindow.Name);
                mainWindow.Style.ChangeSubNameStyle(mainWindow.SubName);

                statisticsWindow.Style.ChangeGridStyle(statisticsWindow.Grid);
                statisticsWindow.Style.ChangeButtonStyle(statisticsWindow.MainMenu);
                statisticsWindow.Style.ChangeButtonStyle(statisticsWindow.Import);
                statisticsWindow.Style.ChangeButtonStyle(statisticsWindow.Json);
                statisticsWindow.Style.ChangeButtonStyle(statisticsWindow.Xml);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
