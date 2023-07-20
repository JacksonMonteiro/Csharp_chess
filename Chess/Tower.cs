using Chess.Board;

namespace Chess.Chess {
    internal class Tower : Piece {
        public Tower(ChessBoard board, Color color) : base(board, color) { }

        public override string ToString() {
            return "T";
        }
    }
}
