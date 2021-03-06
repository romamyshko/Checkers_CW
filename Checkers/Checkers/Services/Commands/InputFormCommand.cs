using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Views;

namespace Checkers.Services.Commands
{
    public class InputFormCommand : ICommand
    {
        public MainWindow MainWindow { get; set; }
        public StatisticsWindow StatisticsWindow { get; set; }

        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var inputForm = new InputForm(MainWindow);
            inputForm.Show();
            MainWindow.Hide();
        }
    }
}
