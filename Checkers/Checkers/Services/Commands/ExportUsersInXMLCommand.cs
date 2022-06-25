using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services.Repository;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.Services.Commands
{
    public class ExportUsersInXMLCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var exporter = new Xml("D:\\users.json");

            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                var filePath = dialog.FileName;

                var data = exporter?.GetData(true);
                var date = DateTime.Now.ToString().Replace('.', '_').Replace(':', '_');

                exporter.ExportAllData($"{filePath}EXPORT_IN_XML_{date}.xml", data.ToList());
            }
        }
    }
}
