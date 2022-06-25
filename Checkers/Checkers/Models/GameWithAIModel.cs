using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Checkers.Services.Logger;
using Checkers.Services.Repository;
using Checkers.Views;

namespace Checkers.Models
{
    public class GameWithAIModel : IGameWithAIModel
    {
        public GameWithAIWindow View { get; set; }
        public Move CurrentMove { get; set; }
        public string Winner { get; set; }  
        public string Turn { get; set; }

        private readonly ObservableCollection<HistoryMove> _observableHistoryMove;
        private readonly Logger _logger;
        private int _numberMove;
        private readonly DispatcherTimer _timerMove;
        private DateTime _timeMove;
        private string _timePassed;
        private readonly DispatcherTimer _commonTimer;
        private DateTime _commonTime;

        public GameWithAIModel()
        {
            CurrentMove = new Move();
            Winner = null;
            _numberMove = 1;
            _observableHistoryMove = new ObservableCollection<HistoryMove>();

            _timerMove = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _commonTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timerMove.Tick += TimerMove_Tick;
            _commonTimer.Tick += CommonTimerTick;
            _timeMove = new DateTime();
            _commonTime = new DateTime();
            _timePassed = "00:00:00";
            _logger = new Logger(new AuditLog());
        }

        private void CommonTimerTick(object sender, EventArgs e)
        {
            _commonTime = _commonTime.AddSeconds(1);
            View.TextBlockTimePassed.Text = _commonTime.ToString("HH:mm:ss");
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            _timeMove = _timeMove.AddSeconds(1);
            _timePassed = _timeMove.ToString("HH:mm:ss");
        } 

        public void InitializeView(GameWithAIWindow view)
        {
            View = view;
            View.GridMain.Visibility = Visibility.Hidden;
            
            Turn = "Black";
            MakeBoard();
            View.GridMain.Visibility = Visibility.Visible;

            _commonTimer.Start();
            _timerMove.Start();
          
            View.StatusText.Text = "Black's turn";
            _logger.LogInfo(View.StatusText.Text);
            View.DataGridHistoryMove.ItemsSource = _observableHistoryMove;
            View.ScoreBlacksLeft.Text = "12";
            View.ScoreBlacksTaked.Text = "0";
            View.ScoreWhitesLeft.Text = "12";
            View.ScoreWhitesTaked.Text = "0";
        }

        public void ClearBoard()
        {
            for (var r = 1; r < 9; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, r, c);
                    View.CheckersGrid.Children.Remove(stackPanel);
                } 
            } 
        }

        public void MakeBoard()
        {
            for (var r = 1; r < 9; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var stackPanel = new StackPanel();

                    if (r % 2 == 1)
                    {
                        stackPanel.Background = c % 2 == 0 ? Brushes.White : Brushes.Black;
                    }
                    else
                    {
                        stackPanel.Background = c % 2 == 0 ? Brushes.Black : Brushes.White;
                    }

                    Grid.SetRow(stackPanel, r);
                    Grid.SetColumn(stackPanel, c);
                    View.CheckersGrid.Children.Add(stackPanel);
                }
            } 

            MakeButtons();
        }

        public void MakeButtons()
        {
            for (var r = 1; r < 9; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, r, c);
                    var button = new Button();
                    button.Click += Button_Click;
                    button.Height = 190;
                    button.Width = 190;
                    button.HorizontalAlignment = HorizontalAlignment.Stretch;
                    button.VerticalAlignment = VerticalAlignment.Stretch;

                    var whiteBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(@"C:\Users\romam\Desktop\Checkers_CW\Checkers\Checkers\Images\checkerWhite.png", UriKind.Absolute))
                    };
                    var blackBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(@"C:\Users\romam\Desktop\Checkers_CW\Checkers\Checkers\Images\checkerBlack.png", UriKind.Absolute))
                    };

                    switch (r)
                    {
                        case 1:
                            if (c % 2 == 1)
                            {
                                button.Background = whiteBrush;
                                button.Name = "buttonWhite" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 2:
                            if (c % 2 == 0)
                            {
                                button.Background = whiteBrush;
                                button.Name = "buttonWhite" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 3:
                            if (c % 2 == 1)
                            {
                                button.Background = whiteBrush;
                                button.Name = "buttonWhite" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 4:
                            if (c % 2 == 0)
                            {
                                button.Background = Brushes.Black;
                                button.Name = "button" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 5:
                            if (c % 2 == 1)
                            {
                                button.Background = Brushes.Black;
                                button.Name = "button" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 6:
                            if (c % 2 == 0)
                            {
                                button.Background = blackBrush;
                                button.Name = "buttonBlack" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 7:
                            if (c % 2 == 1)
                            {
                                button.Background = blackBrush;
                                button.Name = "buttonBlack" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;
                        case 8:
                            if (c % 2 == 0)
                            {
                                button.Background = blackBrush;
                                button.Name = "buttonBlack" + r + c;
                                stackPanel.Children.Add(button);
                            }
                            break;

                    }
                }
            }
        }

        public UIElement GetGridElement(Panel g, int r, int c)
        {
            for (var i = 0; i < g.Children.Count; i++)
            {
                var e = g.Children[i];
                if (Grid.GetRow(e) == r && Grid.GetColumn(e) == c)
                    return e;
            }
            return null!;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var stackPanel = (StackPanel)button.Parent;
            var row = Grid.GetRow(stackPanel);
            var col = Grid.GetColumn(stackPanel);

            _logger.LogInfo("Row: " + row + " Column: " + col);

            if (CurrentMove == null)
                CurrentMove = new Move();
            if (CurrentMove.Piece1 == null)
            {
                CurrentMove.Piece1 = new Piece(row, col);
                stackPanel.Background = Brushes.SlateBlue;
            }
            else
            {
                CurrentMove.Piece2 = new Piece(row, col);
                stackPanel.Background = Brushes.SlateBlue;
            }
            if (CurrentMove.Piece1 != null && CurrentMove.Piece2 != null)
                if (CheckMove())
                {
                    MakeMove();
                    AiMakeMove();
                }
        }

        public bool CheckMove()
        {
            var stackPanel1 = (StackPanel)GetGridElement(View.CheckersGrid, CurrentMove.Piece1.Row, CurrentMove.Piece1.Column);
            var stackPanel2 = (StackPanel)GetGridElement(View.CheckersGrid, CurrentMove.Piece2.Row, CurrentMove.Piece2.Column);
            var button1 = (Button)stackPanel1.Children[0];
            var button2 = (Button)stackPanel2.Children[0];
            stackPanel1.Background = Brushes.Black;
            stackPanel2.Background = Brushes.Black;

            switch (Turn)
            {
                case "Black" when button1.Name.Contains("White"):
                    CurrentMove.Piece1 = null;
                    CurrentMove.Piece2 = null;
                    _logger.LogInfo("Black's turn.");
                    return false;
                case "White" when button1.Name.Contains("Black"):
                    CurrentMove.Piece1 = null;
                    CurrentMove.Piece2 = null;
                    _logger.LogInfo("White's turn.");
                    return false;
            }

            if (button1.Equals(button2))
            {
                CurrentMove.Piece1 = null;
                CurrentMove.Piece2 = null;
                return false;
            }

            if (button1.Name.Contains("Black"))
                return CheckMoveBlack(button1, button2);
            if (button1.Name.Contains("White"))
                return CheckMoveWhite(button1, button2);
            CurrentMove.Piece1 = null;
            CurrentMove.Piece2 = null;

            _logger.LogWarning("CheckMove: False");

            return false;
        }

        public bool CheckMoveWhite(IFrameworkInputElement button1, IFrameworkInputElement button2)
        {
            var currentBoard = GetCurrentBoard();
            var jumpMoves = currentBoard.CheckJumps("White");

            if (jumpMoves.Count > 0)
            {
                var invalid = true;

                foreach (var move in jumpMoves)
                    if (CurrentMove.Equals(move))
                        invalid = false;

                if (invalid)
                {
                    _logger.LogWarning("You must beat the piece.");
                    CurrentMove.Piece1 = null;
                    CurrentMove.Piece2 = null;
                    _logger.LogWarning("CheckMoveWhite: False");
                    return false;
                }
            }

            if (button1.Name.Contains("White"))
                if (button1.Name.Contains("King"))
                {
                    if (CurrentMove.IsAdjacent("King") && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                        return true;

                    var middlePiece = CurrentMove.CheckJump("King");

                    if (!button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                    {
                        var middleStackPanel = (StackPanel)GetGridElement(View.CheckersGrid, middlePiece.Row, middlePiece.Column);
                        var middleButton = (Button)middleStackPanel.Children[0];

                        if (middleButton.Name.Contains("Black"))
                        {
                            View.CheckersGrid.Children.Remove(middleStackPanel);
                            AddBlackButton(middlePiece);
                            return true;
                        }
                    }
                }
                else
                {
                    if (CurrentMove.IsAdjacent("White") && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                        return true;

                    var middlePiece = CurrentMove.CheckJump("White");
                    if (!button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                    {
                        var middleStackPanel = (StackPanel)GetGridElement(View.CheckersGrid, middlePiece.Row, middlePiece.Column);
                        var middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains("Black"))
                        {
                            View.CheckersGrid.Children.Remove(middleStackPanel);
                            AddBlackButton(middlePiece);
                            return true;
                        }
                    }
                }

            CurrentMove = null;
            _logger.LogWarning("Unreachable turn. Repeat again.");
            return false;
        }

        public bool CheckMoveBlack(IFrameworkInputElement button1, IFrameworkInputElement button2)
        {
            var currentBoard = GetCurrentBoard();
            var jumpMoves = currentBoard.CheckJumps("Black");

            if (jumpMoves.Count > 0)
            {
                var invalid = true;

                foreach (var move in jumpMoves)
                    if (CurrentMove.Equals(move))
                        invalid = false;

                if (invalid)
                {
                    _logger.LogWarning("You must beat the piece.");
                    CurrentMove.Piece1 = null;
                    CurrentMove.Piece2 = null;
                    _logger.LogWarning("CheckerMoveBlack: False");
                    return false;
                }
            }

            if (button1.Name.Contains("Black"))
                if (button1.Name.Contains("King"))
                {
                    if (CurrentMove.IsAdjacent("King") && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                        return true;
                    var middlePiece = CurrentMove.CheckJump("King");

                    if (middlePiece != null && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                    {
                        var middleStackPanel = (StackPanel)GetGridElement(View.CheckersGrid, middlePiece.Row, middlePiece.Column);
                        var middleButton = (Button)middleStackPanel.Children[0];

                        if (middleButton.Name.Contains("White"))
                        {
                            View.CheckersGrid.Children.Remove(middleStackPanel);
                            AddBlackButton(middlePiece);
                            return true;
                        }
                    }
                }
                else
                {
                    if (CurrentMove.IsAdjacent("Black") && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                        return true;

                    var middlePiece = CurrentMove.CheckJump("Black");

                    if (middlePiece != null && !button2.Name.Contains("Black") && !button2.Name.Contains("White"))
                    {
                        var middleStackPanel = (StackPanel)GetGridElement(View.CheckersGrid, middlePiece.Row, middlePiece.Column);
                        var middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains("White"))
                        {
                            View.CheckersGrid.Children.Remove(middleStackPanel);
                            AddBlackButton(middlePiece);
                            return true;
                        }
                    }
                }
            CurrentMove = null;
            _logger.LogWarning("Unreachable turn. Try again.");
            return false;
        }

        public void MakeMove()
        {

            _logger.LogInfo("Piece1: row = " + CurrentMove.Piece1.Row +
                            ", col = " + CurrentMove.Piece1.Column);
            _logger.LogInfo("Piece2: row = " + CurrentMove.Piece2.Row +
                            ", col = " + CurrentMove.Piece2.Column);

            var stackPanel1 = (StackPanel)GetGridElement(View.CheckersGrid, CurrentMove.Piece1.Row, CurrentMove.Piece1.Column);
            var stackPanel2 = (StackPanel)GetGridElement(View.CheckersGrid, CurrentMove.Piece2.Row, CurrentMove.Piece2.Column);

            View.CheckersGrid.Children.Remove(stackPanel1);
            View.CheckersGrid.Children.Remove(stackPanel2);

            Grid.SetRow(stackPanel1, CurrentMove.Piece2.Row);
            Grid.SetColumn(stackPanel1, CurrentMove.Piece2.Column);

            View.CheckersGrid.Children.Add(stackPanel1);

            Grid.SetRow(stackPanel2, CurrentMove.Piece1.Row);
            Grid.SetColumn(stackPanel2, CurrentMove.Piece1.Column);

            View.CheckersGrid.Children.Add(stackPanel2);

            CheckKing(CurrentMove.Piece2);
                
            var tempCount = 0;
            _observableHistoryMove
                .ToList()
                .ForEach(move => {
                    if (move.Number == _numberMove)
                        tempCount++;
                });
            _timerMove.Stop();
            if (tempCount < 2)
            {
                _observableHistoryMove.Add(new HistoryMove(_numberMove, _timePassed,
                                                           $"{new BoardRowCol(CurrentMove.Piece1.Row, CurrentMove.Piece1.Column)}" +
                                                           $" -> {new BoardRowCol(CurrentMove.Piece2.Row, CurrentMove.Piece2.Column)}"));
            }
            else if (tempCount == 2)
            {
                _observableHistoryMove.Add(new HistoryMove(++_numberMove, _timePassed,
                                                           $"{new BoardRowCol(CurrentMove.Piece1.Row, CurrentMove.Piece1.Column)}" +
                                                           $" -> {new BoardRowCol(CurrentMove.Piece2.Row, CurrentMove.Piece2.Column)}"));
            }
           
            View.DataGridHistoryMove.ScrollIntoView(View.DataGridHistoryMove.Items[^1]);

            _timeMove = new DateTime();
            _timePassed = "00:00:00";
            _timerMove.Start();
            CurrentMove = null;

            switch (Turn)
            {
                case "Black":
                    View.StatusText.Text = "White's turn";
                    Turn = "White";
                    break;
                case "White":
                    View.StatusText.Text = "Black's turn";
                    Turn = "Black";
                    break;

            }

            _logger.LogInfo(View.StatusText.Text);

            CheckWin();
        }

        public void AiMakeMove()
        {
            CurrentMove = CheckerAI.GetMove(GetCurrentBoard());
            if (CurrentMove == null)
                return;
            if (CheckMove())
                MakeMove();
        }

        public CheckerBoard GetCurrentBoard()
        {
            var board = new CheckerBoard();

            for (var r = 1; r < 9; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, r, c);
                    if (stackPanel.Children.Count > 0)
                    {
                        var button = (Button)stackPanel.Children[0];
                        if (button.Name.Contains("White"))
                            board.SetState(r - 1, c, button.Name.Contains("King") ? 3 : 1);
                        else if (button.Name.Contains("Black"))
                            board.SetState(r - 1, c, button.Name.Contains("King") ? 4 : 2);
                        else
                            board.SetState(r - 1, c, 0);
                    }
                    else
                    {
                        board.SetState(r - 1, c, -1);
                    } 
                }
            } 
            return board;
        }

        public void CheckKing(Piece tmpPiece)
        {
            var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, tmpPiece.Row, tmpPiece.Column);

            if (stackPanel.Children.Count <= 0)
                return;

            var button = (Button)stackPanel.Children[0];
            var whiteBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"C:\Users\romam\Desktop\Checkers_CW\Checkers\Checkers\Images\checkerWhiteKingRed.png", UriKind.Absolute))
            };
            var blackBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"C:\Users\romam\Desktop\Checkers_CW\Checkers\Checkers\Images\checkerBlackKingRed.png", UriKind.Absolute))
            };

            if (button.Name.Contains("Black") && !button.Name.Contains("King"))
            {
                if (tmpPiece.Row == 1)
                {
                    button.Name = "button" + "Black" + "King" + tmpPiece.Row + tmpPiece.Column;
                    button.Background = blackBrush;
                }
            }
            else if (button.Name.Contains("White") && !button.Name.Contains("King"))
            {
                if (tmpPiece.Row == 8)
                {
                    button.Name = "button" + "White" + "King" + tmpPiece.Row + tmpPiece.Column;
                    button.Background = whiteBrush;
                }
            }
        }

        public void AddBlackButton(Piece middleMove)
        {
            var stackPanel = new StackPanel
            {
                Background = Brushes.Black
            };
            var button = new Button();
            button.Click += Button_Click;
            button.Height = 190;
            button.Width = 190;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.Background = Brushes.Black;
            button.Name = "button" + middleMove.Row + middleMove.Column;
            stackPanel.Children.Add(button);
            Grid.SetColumn(stackPanel, middleMove.Column);
            Grid.SetRow(stackPanel, middleMove.Row);
            View.CheckersGrid.Children.Add(stackPanel);
        }

        public void CheckWin()
        {
            int totalBlack = 0, totalWhite = 0;
            for (var r = 1; r < 9; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, r, c);
                    if (stackPanel.Children.Count > 0)
                    {
                        var button = (Button)stackPanel.Children[0];
                        if (button.Name.Contains("White"))
                            totalWhite++;
                        if (button.Name.Contains("Black"))
                            totalBlack++;
                    }
                }
            }

            View.ScoreBlacksLeft.Text = $"{totalBlack}";
            View.ScoreBlacksTaked.Text = $"{12 - totalWhite}";
            View.ScoreWhitesLeft.Text = $"{totalWhite}";
            View.ScoreWhitesTaked.Text = $"{12 - totalBlack}";

            if (totalBlack == 0)
                Winner = "White";
            if (totalWhite == 0)
                Winner = "Black";

            if (Winner != null)
            {
                for (var r = 1; r < 9; r++)
                {
                    for (var c = 0; c < 8; c++)
                    {
                        var stackPanel = (StackPanel)GetGridElement(View.CheckersGrid, r, c);
                        if (stackPanel.Children.Count > 0)
                        {
                            var button = (Button)stackPanel.Children[0];
                            button.Click -= Button_Click;
                        } 
                    } 
                }

                _timerMove.Tick -= TimerMove_Tick;
                _commonTimer.Tick -= CommonTimerTick;

                var json = new Json("D:\\users.json");
                var xml = new Xml("D:\\users.xml");

                var playerIsWinner = Winner.Equals("Black");

                var user = new User(json.GetLastId() + 1, "Roma", playerIsWinner ? 1 : 0, playerIsWinner ? 0 : 1,
                    View.TextBlockTimePassed.Text);

                json.WriteUser(user);
                xml.WriteUser(user);

                MessageBox.Show(View, $"{Winner} wins!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
        } 

        public void StartNewGame()
        {
            CurrentMove = null;
            Winner = null;
            Turn = "Black";
            ClearBoard();
            MakeBoard();
            View.ScoreBlacksLeft.Text = "12";
            View.ScoreBlacksTaked.Text = "0";
            View.ScoreWhitesLeft.Text = "12";
            View.ScoreWhitesTaked.Text = "0";

            _timerMove.Stop();
            _timeMove = new DateTime();
            _timePassed = "00:00:00";
            _timerMove.Start();

            
            _observableHistoryMove.Clear();
            _commonTimer.Stop();
            _commonTime = new DateTime();
            View.TextBlockTimePassed.Text = "00:00:00";
            _commonTimer.Start();

            _numberMove = 1;
        }
    }
}
