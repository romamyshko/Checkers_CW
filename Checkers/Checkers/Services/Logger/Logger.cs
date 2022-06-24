using System;

namespace Checkers.Services.Logger
{
    public  class Logger
    {
        private ILogType _logType;

        public Logger(ILogType logType)
        {
            _logType = logType;
        }

        public void LogError(string errorMessage)
        {
            _logType.LogError(errorMessage);
        }

        public void LogWarning(string warningMessage)
        {
            _logType.LogWarning(warningMessage);
        }

        public void LogInfo(string infoMessage)
        {
            _logType.LogInfo(infoMessage);
        }
    }
}