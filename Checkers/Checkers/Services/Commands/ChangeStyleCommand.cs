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
        public MainWindow MainWindow { get; set; }
        public  StatisticsWindow StatisticsWindow { get; set; }

        private readonly Logger _logger;

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
                switch (MainWindow.Style.Style)
                {
                    case Style.Green:
                        MainWindow.Style = new PacificPaletteStyle();
                        StatisticsWindow.Style = new PacificPaletteStyle();
                        break;
                    case Style.Pacific:
                        MainWindow.Style = new BasePaletteStyle();
                        StatisticsWindow.Style = new BasePaletteStyle();
                        break;
                    case Style.Base:
                        MainWindow.Style = new GreenPaletteStyle();
                        StatisticsWindow.Style = new GreenPaletteStyle();
                        break;
                    default:
                        return;
                }

                MainWindow.Style.ChangeButtonStyle(MainWindow.Play);
                MainWindow.Style.ChangeButtonStyle(MainWindow.Stats);
                MainWindow.Style.ChangeButtonStyle(MainWindow.Styles);
                MainWindow.Style.ChangeButtonStyle(MainWindow.Exit);
                MainWindow.Style.ChangeGridStyle(MainWindow.Grid);
                MainWindow.Style.ChangeNameStyle(MainWindow.Name);
                MainWindow.Style.ChangeSubNameStyle(MainWindow.SubName);

                StatisticsWindow.ApplyTheStyles();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
