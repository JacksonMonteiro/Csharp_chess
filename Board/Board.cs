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
    }
}
