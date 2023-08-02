using board;


namespace chess {
    internal class Bishop : Piece {
        public Bishop(ChessBoard board, Color color) : base(board, color) {

        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece piece = Board.piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // NO
            pos.defineValues(Position.Line - 1, Position.Column - 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.defineValues(Position.Line - 1, Position.Column + 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.defineValues(Position.Line + 1, Position.Column + 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.defineValues(Position.Line + 1, Position.Column - 1);
            while (Board.isValidPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
