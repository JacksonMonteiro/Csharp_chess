using Chess.Board;

namespace Chess {
    internal class Program {
        static void Main(string[] args) {
            ChessBoard board = new ChessBoard(8, 8); 
            Screen.printBoard(board);
        }
    }
}