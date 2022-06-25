using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services.Repository;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.Services.Commands
{
    public class ExportUsersInJSONCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public ExportUsersInJSONCommand()
        {
            
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var exporter = new Json("D:\\users.json");

            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            var result = dialog.ShowDialog();
            
            var filePath = "";
            if (result == CommonFileDialogResult.Ok)
            {
                filePath = dialog.FileName;
            }

            var data = exporter?.GetData();

            var date = DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');

            exporter.ExportAllData($"{filePath}EXPORT_IN_JSON_{date}.json", data.ToList());

        }
    }
}
