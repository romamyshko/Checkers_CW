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

        public void StartNewGameWithAI()
        {
            try
            {
                _gameWithAIModel.InitializeView(new GameWithAIWindow());
                _gameWithAIModel.View.Show();
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
