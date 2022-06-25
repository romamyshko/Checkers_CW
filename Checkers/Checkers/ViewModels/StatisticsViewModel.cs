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
    public class StatisticsViewModel : ViewModelBase
    {
        public ICommand ImportUsersDataCommand { get; set; }
        public ICommand ExitToMenuCommand { get; set; }
        public ICommand ExportUsersInJSONCommand { get; set; }
        public ICommand ExportUsersInXMLCommand { get; set; }

        public StatisticsViewModel()
        {
            ExitToMenuCommand = new ExitToMenuCommand(StatisticsModel.View);
            ImportUsersDataCommand = new ImportUsersDataCommand();
            ExportUsersInJSONCommand = new ExportUsersInJSONCommand();
            ExportUsersInXMLCommand = new ExportUsersInXMLCommand();
        }
    }
}
