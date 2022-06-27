using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Checkers.Views;

namespace Checkers.Models
{
    public interface IGameWithAIModel
    {
        GameWithAIWindow View { get; set; }
        string Username { get; set; }
        void InitializeView(GameWithAIWindow view);
        void StartNewGame();
    }
}
