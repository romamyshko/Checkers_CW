using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services.Styles;

namespace Checkers.ViewModels.Commands
{
    public class ChangeStyleCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public ChangeStyleCommand()
        {
           
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var mainWindow = MainWindow.Instance;

            if (mainWindow.Style.Style == Style.Green)
            {
                mainWindow.Style = new PacificPaletteStyle();
            }
            else if (mainWindow.Style.Style == Style.Pacific)
            {
                mainWindow.Style = new BasePaletteStyle();
            }
            else if (mainWindow.Style.Style == Style.Base)
            {
                mainWindow.Style = new GreenPaletteStyle();
            }
            else
            {
                return;
            }

            mainWindow.Style.ChangeButtonStyle(mainWindow.Play);
            mainWindow.Style.ChangeButtonStyle(mainWindow.Stats);
            mainWindow.Style.ChangeButtonStyle(mainWindow.Styles);
            mainWindow.Style.ChangeButtonStyle(mainWindow.Exit);

            mainWindow.Style.ChangeGridStyle(mainWindow.Grid);

            mainWindow.Style.ChangeNameStyle(mainWindow.Name);
            mainWindow.Style.ChangeSubNameStyle(mainWindow.SubName);
        }
    }
}
