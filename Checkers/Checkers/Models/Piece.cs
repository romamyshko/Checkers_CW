using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Piece
    {
        public int Row { get; }
        public int Column { get; }

        public Piece(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Piece p)
            {
                return Row == p.Row && Column == p.Column;
            }

            return false;
        }

        protected bool Equals(Piece other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
