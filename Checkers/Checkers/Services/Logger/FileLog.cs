using System;
using System.IO;

namespace Checkers.Services.Logger
{
    public class FileLog : ILogType
    {
        private readonly string _filePath;

        public FileLog(string filePath)
        {
            _filePath = filePath;
        }

        public void LogError(string errorMessage)
        {
            var messageLog = $"Error: {errorMessage} [{DateTime.Now}]";

            AppendOrWriteMessage(messageLog);
        }

        public void LogWarning(string warningMessage)
        {
            var messageLog = $"Warning: {warningMessage} [{DateTime.Now}]";

            AppendOrWriteMessage(messageLog);
        }

        public void LogInfo(string infoMessage)
        {
            var messageLog = $"Info: {infoMessage} [{DateTime.Now}]";

            AppendOrWriteMessage(messageLog);
        }

        private void AppendOrWriteMessage(string message)
        {
            if (File.Exists(_filePath))
            {
                File.AppendAllText(_filePath, message + "\r\n");
            }
            else
            {
                File.WriteAllText(_filePath, message + "\r\n");
            }
        }
    }
}