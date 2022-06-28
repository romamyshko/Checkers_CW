using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Checkers.Models;
using Checkers.Services.Logger;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Checkers.Services.Repository
{
    public abstract class DBRepository
    {
        protected readonly Logger.Logger _logger = new(new FileLog("D:\\fileLogs.txt"));

        public string FilePath { get; set; }
        public string ImportFilePath { get; set; } = String.Empty;

        protected DBRepository()
        {
            var dialog = new CommonOpenFileDialog();
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                ImportFilePath = dialog.FileName;
            }
        }

        protected DBRepository(string filePath)
        {
            FilePath = filePath;
        }

        public IEnumerable<User> GetData(bool xml = false)
        {
            try
            {
                var data = File.ReadAllText(FilePath);

                if (xml)
                {
                    var json = new Json(FilePath);
                    return json.DeserializeUsers(data);
                }

                return DeserializeUsers(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Enumerable.Empty<User>();
            }
        }

        public IEnumerable<User> GetImportData()
        {
            try
            {
                var data = File.ReadAllText(ImportFilePath);
                return DeserializeUsers(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Enumerable.Empty<User>();
            }
        }

        public void WriteUser(User user, bool isStatistics = false)
        {
            WriteUsers(new List<User>() {user}, isStatistics);
        }

        public void WriteUsers(List<User> users, bool isStatistics = false)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    UpdateAllUsers(users);
                    File.Delete(FilePath);
                }

                string serialized = String.Empty;

                if (isStatistics)
                {
                    var json = new Json(FilePath);
                    serialized = json.SerializeUsers(users);
                }
                else
                {
                    serialized = SerializeUsers(users);
                }

                File.WriteAllText(FilePath, serialized);
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
                var serialized = SerializeUsers(data);

                if (File.Exists(fileDestination))
                {
                    File.AppendAllText(fileDestination, serialized);
                }
                else
                {
                    File.WriteAllText(fileDestination, serialized);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
           
        }

        protected abstract string SerializeUsers(List<User> users);
        protected abstract List<User> DeserializeUsers(string serializedUsers);

        private void UpdateAllUsers(List<User> users)
        {
            var currentData = GetData(true);
            var usersToRemove = new List<User>();


            foreach (var user in currentData)
            {
                foreach (var newUser in users)
                {
                    if (newUser.Username == user.Username)
                    {
                        user.Loses += newUser.Loses;
                        user.Wins += newUser.Wins;
                        user.TotalTime =
                            (TimeSpan.Parse(user.TotalTime) + TimeSpan.Parse(newUser.TotalTime)).ToString();

                        usersToRemove.Add(newUser);
                    }
                }
            }

            foreach (var user in usersToRemove)
            {
                users.Remove(user);
            }
            
            users.AddRange(currentData);
        }
    }
}
