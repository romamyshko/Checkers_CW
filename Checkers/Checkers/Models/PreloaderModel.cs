using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Services.Logger;
using Checkers.Views;

namespace Checkers.Models
{
    public class PreloaderModel
    {
        private readonly IGameWithAIModel _gameWithAIModel;
        private readonly Logger _logger;

        public PreloaderModel(IGameWithAIModel gameWithAiModel)
        {
            _gameWithAIModel = gameWithAiModel;
            _logger = new Logger(new FileLog("D:\\fileLogs.txt"));
        }

        public void StartNewGameWithAI(InputForm inputForm, MainWindow mainWindow)
        {
            try
            {
                _gameWithAIModel.InitializeView(new GameWithAIWindow(mainWindow));
                _gameWithAIModel.Username = inputForm.TextBox.Text;
                _gameWithAIModel.View.Show();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
