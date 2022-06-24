using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services.Logger
{
    public interface ILogType
    {
        void LogError(string errorMessage);
        void LogWarning(string warningMessage);
        void LogInfo(string infoMessage);
    }
}
