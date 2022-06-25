using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Checkers.Models;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.Services.Repository
{
    public abstract class DBRepository
    {
        protected readonly string _filePath;

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

        public List<User> GetData()
        {
            var data = File.ReadAllText(_filePath);

            return DeserializeUsers(data);
        }

        public void WriteUser(User user)
        {
            WriteUsers(new List<User>() {user});
        }

        public void WriteUsers(List<User> users)
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

        public void ExportAllData(string fileDestination, List<User> data)
        {
            File.WriteAllText(fileDestination, SerializeUsers(data));
        }

        protected abstract string SerializeUsers(List<User> users);
        protected abstract List<User> DeserializeUsers(string serializedUsers);
    }
}
