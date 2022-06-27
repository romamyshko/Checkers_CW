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
        Move CurrentMove { get; set; }
        string Winner { get; set; }
        string Turn { get; set; }
        void InitializeView(GameWithAIWindow view);
        void ClearBoard();
        void MakeBoard();
        void MakeButtons();
        UIElement GetGridElement(Panel g, int r, int c);
        void Button_Click(object sender, RoutedEventArgs e);
        bool CheckMove();
        bool CheckMoveWhite(IFrameworkInputElement button1, IFrameworkInputElement button2);
        bool CheckMoveBlack(IFrameworkInputElement button1, IFrameworkInputElement button2);
        void MakeMove();
        void AiMakeMove();
        CheckerBoard GetCurrentBoard();
        void CheckKing(Piece tmpPiece);
        void AddBlackButton(Piece middleMove);
        void CheckWin();
        void StartNewGame();
    }
}
