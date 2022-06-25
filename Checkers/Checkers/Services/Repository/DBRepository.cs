using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Checkers.Models;
using Checkers.Services.Logger;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.Services.Repository
{
    public abstract class DBRepository
    {
        protected readonly string _filePath;
        protected readonly Logger.Logger _logger = new(new FileLog("D:\\fileLogs.txt"));

        protected DBRepository()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                _filePath = dialog.FileName;
            }
        }

        protected DBRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<User> GetData()
        {
            try
            {
                var data = File.ReadAllText(_filePath);
                return DeserializeUsers(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Enumerable.Empty<User>();
            }
        }

        public void WriteUser(User user)
        {
            WriteUsers(new List<User>() {user});
        }

        public void WriteUsers(List<User> users)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var currentData = GetData();
                    users.AddRange(currentData);
                    File.Delete(_filePath);
                }

                var serialized = SerializeUsers(users);
                File.WriteAllText(_filePath, serialized);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public int GetLastId()
        {
            var data = GetData().Select(a => a.Number);

            if (data.Any())
            {
                return data.Max();
            }

            return 0;
        }

        public void ExportAllData(string fileDestination, List<User> data)
        {

            try
            {
                File.WriteAllText(fileDestination, SerializeUsers(data));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
           
        }

        protected abstract string SerializeUsers(List<User> users);
        protected abstract List<User> DeserializeUsers(string serializedUsers);
    }
}
