using Chess.Board;

namespace Chess {
    internal class Screen {
        public static void printBoard(ChessBoard board) {
            for (int i = 0; i < board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {

                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        PrintPiece(board.piece(i, j));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }

            Console.WriteLine("a b c d e f g h");
        }

        public static void PrintPiece(Piece piece) {
            if (piece.Color == Color.White) {
                Console.Write(piece);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
