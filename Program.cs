using board;
using chess;

namespace Chess {
    internal class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while (!match.isEnded) {
                    Console.Clear();
                    Screen.printBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Digite a posição de origem da peça (c1, por exemplo): ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possibleMovements = match.Board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(match.Board, possibleMovements);

                    Console.WriteLine();
                    Console.Write("Digite a posição de destino da peça (e1, por exemplo): ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMovement(origin, destiny);
                }

            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}