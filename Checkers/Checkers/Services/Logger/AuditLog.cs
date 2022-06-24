using System;

namespace Checkers.Services.Logger
{
    public class AuditLog : ILogType
    {
        private readonly ConsoleColor _defaultColor;

        public AuditLog()
        {
            _defaultColor = Console.ForegroundColor;
        }

        public void LogError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage} [{DateTime.Now}]");
            ResetForegroundColor();
        }

        public void LogWarning(string warningMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {warningMessage} [{DateTime.Now}]");
            ResetForegroundColor();
        }

        public void LogInfo(string infoMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Info: {infoMessage} [{DateTime.Now}]");
            ResetForegroundColor();
        }

        private void ResetForegroundColor()
        {
            Console.ForegroundColor = _defaultColor;
        }
    }
}