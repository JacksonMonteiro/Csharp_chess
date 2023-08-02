using board;

namespace chess     {
    internal class Rook : Piece {
        public Rook(ChessBoard board, Color color) : base(board, color) { }

        public override string ToString() {
            return "T";
        }

        private bool canMove(Position pos) {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);


            pos.defineValues(Position.Line - 1, Position.Column);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.Line = pos.Line - 1;
            }


            pos.defineValues(Position.Line + 1, Position.Column);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.Line = pos.Line + 1;
            }


            pos.defineValues(Position.Line, Position.Column + 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.Column = pos.Column + 1;
            }


            pos.defineValues(Position.Line, Position.Column - 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}
