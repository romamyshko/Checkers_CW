using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Views;

namespace Checkers.Models
{
    public class PreloaderModel
    {
        private readonly IGameWithAIModel _gameWithAIModel;

        public PreloaderModel(IGameWithAIModel gameWithAiModel)
        {
            _gameWithAIModel = gameWithAiModel;
        }

        public void StartNewGameWithAI()
        {
            _gameWithAIModel.InitializeView(new GameWithAIWindow());
            _gameWithAIModel.View.Show();
        }
    }
}
