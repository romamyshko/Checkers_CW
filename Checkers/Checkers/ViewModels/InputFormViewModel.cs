using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;
using Checkers.Services.Commands;
using Checkers.ViewModels.Commands;
using Checkers.Views;

namespace Checkers.ViewModels
{
    public class InputFormViewModel : ViewModelBase
    {
        public ICommand GameWithAICommand { get; set; }
        public ICommand ExitToMenuCommand { get; set; }

        public InputFormViewModel(MainWindow mainWindow, InputForm inputForm)
        {
            GameWithAICommand = new GameWithAICommand(new PreloaderModel(new GameWithAIModel()), inputForm) {MainWindow = mainWindow};
            ExitToMenuCommand = new ExitToMenuCommand(inputForm) {MainWindow = mainWindow};
        }
    }
}
