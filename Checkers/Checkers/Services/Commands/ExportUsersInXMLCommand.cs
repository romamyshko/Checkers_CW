using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers.Services.Commands
{
    public class ExportUsersInXMLCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public ExportUsersInXMLCommand()
        {

        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

        }
    }
}
