using Chess.Board;

namespace Chess {
    internal class Screen {
        public static void printBoard(ChessBoard board) {
            for (int i = 0; i < board.Lines; i++) {

                for (int j = 0; j < board.Columns; j++) {

                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(board.piece(i, j) + " ");
                    }

                }

                Console.WriteLine();

            }
        }
    }
}
