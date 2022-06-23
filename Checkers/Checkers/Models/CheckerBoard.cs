using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class CheckerBoard
    {
        public int[,] Board { get; } = new int[8, 8];

        public CheckerBoard()
        {
            InitialiseBoard();
        }

        public List<Move> CheckJumps(string color)
        {
            var jumps = new List<Move>();

            for (var r = 0; r < 8; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    switch (color)
                    {
                        case "White":
                            switch (GetState(r, c))
                            {
                                case 3:
                                    if (GetState(r - 2, c - 2) == 0 && (GetState(r - 1, c - 1) == 2 || GetState(r - 1, c - 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c - 2)));
                                    if (GetState(r - 2, c + 2) == 0 && (GetState(r - 1, c + 1) == 2 || GetState(r - 1, c + 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c + 2)));
                                    if (GetState(r + 2, c - 2) == 0 && (GetState(r + 1, c - 1) == 2 || GetState(r + 1, c - 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c - 2)));
                                    if (GetState(r + 2, c + 2) == 0 && (GetState(r + 1, c + 1) == 2 || GetState(r + 1, c + 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c + 2)));
                                    break;
                                case 1:
                                    if (GetState(r + 2, c - 2) == 0 && (GetState(r + 1, c - 1) == 2 || GetState(r + 1, c - 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c - 2)));
                                    if (GetState(r + 2, c + 2) == 0 && (GetState(r + 1, c + 1) == 2 || GetState(r + 1, c + 1) == 4))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c + 2)));
                                    break;
                            }
                            break;
                        case "Black":
                            switch (GetState(r, c))
                            {
                                case 4:
                                    if (GetState(r - 2, c - 2) == 0 && (GetState(r - 1, c - 1) == 1 || GetState(r - 1, c - 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c - 2)));
                                    if (GetState(r - 2, c + 2) == 0 && (GetState(r - 1, c + 1) == 1 || GetState(r - 1, c + 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c + 2)));
                                    if (GetState(r + 2, c - 2) == 0 && (GetState(r + 1, c - 1) == 1 || GetState(r + 1, c - 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c - 2)));
                                    if (GetState(r + 2, c + 2) == 0 && (GetState(r + 1, c + 1) == 1 || GetState(r + 1, c + 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r + 3, c + 2)));
                                    break;
                                case 2:
                                    if (GetState(r - 2, c - 2) == 0 && (GetState(r - 1, c - 1) == 1 || GetState(r - 1, c - 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c - 2)));
                                    if (GetState(r - 2, c + 2) == 0 && (GetState(r - 1, c + 1) == 1 || GetState(r - 1, c + 1) == 3))
                                        jumps.Add(new Move(new Piece(r + 1, c), new Piece(r - 1, c + 2)));
                                    break;
                            } 
                            break;
                    }
                }
            }

            return jumps;
        }

        public bool SetState(int r, int c, int state)
        {
            if (state is > 4 or < -1)
                return false;

            Board[r, c] = state;
            return true;
        }

        public int GetState(int r, int c)
        {
            if (r is > 7 or < 0 || c is > 7 or < 0)
                return -1;

            return Board[r, c];
        }

        private void InitialiseBoard()
        {
            for (var r = 0; r < 8; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    Board[r, c] = -1;
                }
            }
        }
    }
}
