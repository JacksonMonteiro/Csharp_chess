using board;
using chess;

namespace Chess.chess {
    internal class Pawn : Piece {
        private ChessMatch Match;
        public Pawn(ChessBoard Board, Color Color, ChessMatch match) : base(Board, Color) {
            Match = match;
        }

        public override string ToString() {
            return "P";
        }

        private bool existsEnemy(Position pos) {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool isFree(Position pos) {
            return Board.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White) {
                pos.defineValues(Position.Line - 1, Position.Column);
                if (Board.isValidPosition(pos) && isFree(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 2, Position.Column);
                pos.defineValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.isValidPosition(p2) && isFree(p2) && Board.isValidPosition(pos) && isFree(pos) && MovementQnt == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column - 1);
                if (Board.isValidPosition(pos) && existsEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column + 1);
                if (Board.isValidPosition(pos) && existsEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                if (Position.Line == 3) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.isValidPosition(left) && existsEnemy(left) && Board.piece(left) == Match.vulnerableToEnPassant) {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.isValidPosition(right) && existsEnemy(right) && Board.piece(right) == Match.vulnerableToEnPassant) {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else {
                pos.defineValues(Position.Line + 1, Position.Column);
                if (Board.isValidPosition(pos) && isFree(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.isValidPosition(p2) && isFree(p2) && Board.isValidPosition(pos) && isFree(pos) && MovementQnt == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column - 1);
                if (Board.isValidPosition(pos) && existsEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column + 1);
                if (Board.isValidPosition(pos) && existsEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }


                if (Position.Line == 4) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.isValidPosition(left) && existsEnemy(left) && Board.piece(left) == Match.vulnerableToEnPassant) {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.isValidPosition(right) && existsEnemy(right) && Board.piece(right) == Match.vulnerableToEnPassant) {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

    }
}
