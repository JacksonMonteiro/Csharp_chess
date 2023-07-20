namespace Chess.Board {
    internal class ChessBoard {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public ChessBoard(int lines, int columns) {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column) {
            return pieces[line, column];
        }

        public Piece piece(Position pos) {
            return pieces[pos.Line, pos.Column];
        }

        public void insertPiece(Piece p, Position pos) {
            if (exists(pos)) {
                throw new BoardException("Already exists a piece on this position");
            }

            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool isValidPosition(Position pos) {
            if (pos.Line < 0 || pos.Line > Lines || pos.Column < 0 || pos.Column > Columns) {
                return false;
            }

            return true;
        }

        public void validatePosition(Position pos) {
            if (!isValidPosition(pos)) {
                throw new BoardException("Invalid position");
            }
        }

        public bool exists(Position pos) {
            validatePosition(pos); 
            return piece(pos) != null;
        }
    }
}
