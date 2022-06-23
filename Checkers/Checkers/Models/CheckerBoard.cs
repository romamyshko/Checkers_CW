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
