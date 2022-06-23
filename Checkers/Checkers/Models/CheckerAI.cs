using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class CheckerAI
    {
        public static Move GetMove(CheckerBoard currentBoard)
        {
            var availableMoves = GetAvailableMoves(currentBoard);
            availableMoves.Shuffle();
            return (availableMoves.Count < 1 ? null : availableMoves[0])!;
        }

        private static List<Move> GetAvailableMoves(CheckerBoard currentBoard)
        {
            var currentPieces = new List<Piece>();
            var availableMoves = new List<Move>();
            var jumpMoves = currentBoard.CheckJumps("White");

            if (jumpMoves.Count > 0)
            {
                return jumpMoves;
            }

            for (var r = 0; r < 8; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    if (currentBoard.GetState(r, c) == 1 || currentBoard.GetState(r, c) == 3)
                    {
                        currentPieces.Add(new Piece(r, c));
                    }
                } 
            }

            foreach (var p in currentPieces)
            {
                availableMoves.AddRange(CheckForMoves(p, currentBoard));
            }

            return availableMoves;
        }

        private static IEnumerable<Move> CheckForMoves(Piece piece, CheckerBoard currentBoard)
        {
            var moves = new List<Move>();

            switch (currentBoard.GetState(piece.Row, piece.Column))
            {
                case 3:
                    if (currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 2 || currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 4)
                        if (currentBoard.GetState(piece.Row - 2, piece.Column - 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row - 1, piece.Column - 2)));
                    if (currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 2 || currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 4)
                        if (currentBoard.GetState(piece.Row - 2, piece.Column + 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row - 1, piece.Column + 2)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 2 || currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 4)
                        if (currentBoard.GetState(piece.Row + 2, piece.Column - 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column - 2)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 2 || currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 4)
                        if (currentBoard.GetState(piece.Row + 2, piece.Column + 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column + 2)));
                    if (currentBoard.GetState(piece.Row - 1, piece.Column - 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row, piece.Column - 1)));
                    if (currentBoard.GetState(piece.Row - 1, piece.Column + 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row, piece.Column + 1)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column - 1)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column + 1)));
                    break;
                case 1:
                    if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 2 || currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 4)
                        if (currentBoard.GetState(piece.Row + 2, piece.Column - 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column - 2)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 2 || currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 4)
                        if (currentBoard.GetState(piece.Row + 2, piece.Column + 2) == 0)
                            moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 3, piece.Column + 2)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column - 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column - 1)));
                    if (currentBoard.GetState(piece.Row + 1, piece.Column + 1) == 0)
                        moves.Add(new Move(new Piece(piece.Row + 1, piece.Column), new Piece(piece.Row + 2, piece.Column + 1)));
                    break;
            }
            return moves;
        }
    }
}
