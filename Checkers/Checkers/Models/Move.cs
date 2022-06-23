using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Move
    {
        public Piece Piece1 { get; }
        public Piece Piece2 { get; }

        public Move(Piece p1, Piece p2)
        {
            Piece1 = p1;
            Piece2 = p2;
        }

        public bool IsAdjacent(string color)
        {
            switch (color)
            {
                case "Black":
                    if (Piece1.Row - 1 == Piece2.Row && Piece1.Column - 1 == Piece2.Column)
                        return true;
                    if (Piece1.Row - 1 == Piece2.Row && Piece1.Column + 1 == Piece2.Column)
                        return true;
                    break;
                case "White":
                    if (Piece1.Row + 1 == Piece2.Row && Piece1.Column - 1 == Piece2.Column)
                        return true;
                    if (Piece1.Row + 1 == Piece2.Row && Piece1.Column + 1 == Piece2.Column)
                        return true;
                    break;
                case "King":
                    if (Piece1.Row - 1 == Piece2.Row && Piece1.Column - 1 == Piece2.Column)
                        return true;
                    if (Piece1.Row - 1 == Piece2.Row && Piece1.Column + 1 == Piece2.Column)
                        return true;
                    if (Piece1.Row + 1 == Piece2.Row && Piece1.Column - 1 == Piece2.Column)
                        return true;
                    if (Piece1.Row + 1 == Piece2.Row && Piece1.Column + 1 == Piece2.Column)
                        return true;
                    break;
            }

            return false;
        }

        public Piece CheckJump(string color)
        {
            switch (color)
            {
                case "Black":
                    if (Piece1.Row - 2 == Piece2.Row && Piece1.Column - 2 == Piece2.Column)
                        return new Piece(Piece1.Row - 1, Piece1.Column - 1);
                    if (Piece1.Row - 2 == Piece2.Row && Piece1.Column + 2 == Piece2.Column)
                        return new Piece(Piece1.Row - 1, Piece1.Column + 1);
                    break;
                case "White":
                    if (Piece1.Row + 2 == Piece2.Row && Piece1.Column - 2 == Piece2.Column)
                        return new Piece(Piece1.Row + 1, Piece1.Column - 1);
                    if (Piece1.Row + 2 == Piece2.Row && Piece1.Column + 2 == Piece2.Column)
                        return new Piece(Piece1.Row + 1, Piece1.Column + 1);
                    break;
                case "King":
                    if (Piece1.Row - 2 == Piece2.Row && Piece1.Column - 2 == Piece2.Column)
                        return new Piece(Piece1.Row - 1, Piece1.Column - 1);
                    if (Piece1.Row - 2 == Piece2.Row && Piece1.Column + 2 == Piece2.Column)
                        return new Piece(Piece1.Row - 1, Piece1.Column + 1);
                    if (Piece1.Row + 2 == Piece2.Row && Piece1.Column - 2 == Piece2.Column)
                        return new Piece(Piece1.Row + 1, Piece1.Column - 1);
                    if (Piece1.Row + 2 == Piece2.Row && Piece1.Column + 2 == Piece2.Column)
                        return new Piece(Piece1.Row + 1, Piece1.Column + 1);
                    break;
            } 

            return null!;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Move m)
            {
                return Piece1.Equals(m.Piece1) && Piece2.Equals(m.Piece2);
            }

            return false;
        }

        protected bool Equals(Move other)
        {
            return Piece1.Equals(other.Piece1) && Piece2.Equals(other.Piece2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Piece1, Piece2);
        }
    }
}
