using board;
using chess;

namespace Chess {
    internal class Screen {
        public static void printBoard(ChessBoard board) {
            for (int i = 0; i < board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(ChessBoard board, bool[,] possibleMovements) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {
                    if (possibleMovements[i, j]) {
                        Console.BackgroundColor = changedBackground;
                    }
                    else {
                        Console.BackgroundColor = originalBackground;
                    }

                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void printPiece(Piece piece) {
            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(column, line);
        }

        public static void printChessMatch(ChessMatch match) {
            printBoard(match.Board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);


            if (!match.isEnded) {
                Console.WriteLine("Waiting move: " + match.CurrentPlayer);
                if (match.Check) {
                    Console.WriteLine("Check!");
                }
            }
            else {
                Console.WriteLine("Mate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
        }

        public static void printCapturedPieces(ChessMatch match) {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece piece in set) {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
    }
}
