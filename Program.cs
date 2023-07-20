using Chess.Board;
using Chess.Chess;

namespace Chess {
    internal class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while(!match.isEnded) {
                    Console.Clear();
                    Screen.printBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Digite a posição de origem da peça (c1, por exemplo): ");
                    Position origin = Screen.readChessPosition().toPosition();

                    Console.Write("Digite a posição de destino da peça (e1, por exemplo): ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMovement(origin, destiny);
                }

            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
} 