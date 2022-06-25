using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.ViewModels.Commands;
using Checkers.Views;

namespace Checkers.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        public ICommand ImportCommand { get; set; }
        public ICommand ExitToMenuCommand { get; set; }
        public ICommand ExportJSONCommand { get; set; }
        public ICommand ExportXMLCommand { get; set; }

        public StatisticsViewModel(StatisticsWindow view)
        {
            ExitToMenuCommand = new ExitToMenuCommand(view);
        }
    }
}
