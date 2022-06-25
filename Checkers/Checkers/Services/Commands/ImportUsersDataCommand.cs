using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Models;
using Checkers.Services.Repository;

namespace Checkers.Services.Commands
{
    public class ImportUsersDataCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public ImportUsersDataCommand()
        {
            
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var import = new Json();
            import.FilePath = "D:\\users.json";
            import.WriteUsers(import.GetImportData().ToList());
            StatisticsModel.UpdateGrid();
        }
    }
}
