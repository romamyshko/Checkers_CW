using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Services.Logger;

namespace Checkers
{
    public class Program
    {
        private static readonly Logger _logger = new(new FileLog("D:\\fileLogs.txt"));

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
           
        }
    }
}
