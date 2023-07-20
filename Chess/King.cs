using Chess.Board;

namespace Chess.Chess {
    internal class King : Piece {
        public King(ChessBoard board, Color color) : base(board, color) { 
        }

        public override string ToString() {
            return "R";
        }
    }
}
