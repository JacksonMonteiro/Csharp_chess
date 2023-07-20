namespace Chess.Board {
    internal class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQnt { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(ChessBoard board, Color color) {
            Position = null;
            Board = board;
            Color = color;
            MovementQnt = 0;
        }
    }
}
