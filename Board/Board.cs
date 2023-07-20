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

        public void insertPiece(Piece p, Position pos) {
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
    }
}
