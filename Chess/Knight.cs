using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.chess {
    internal class Knight : Piece {
        public Knight(ChessBoard board, Color color) : base(board, color) { }

        public override string ToString() {
            return "C";
        }

        private bool canMove(Position pos) {
            Piece piece = Board.piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            pos.defineValues(Position.Line - 1, Position.Column - 2);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line - 2, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line - 2, Position.Column + 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line - 1, Position.Column + 2);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line + 1, Position.Column + 2);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line + 2, Position.Column + 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line + 2, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }
            pos.defineValues(Position.Line + 1, Position.Column - 2);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
