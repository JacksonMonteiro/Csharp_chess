using board;
using chess;

namespace Chess {
    internal class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while (!match.isEnded) {
                    try {
                        Console.Clear();

                        Screen.printChessMatch(match);

                        Console.WriteLine();
                        Console.Write("Insert the origin of piece(example, c1): ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possibleMovements = match.Board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.Board, possibleMovements);

                        Console.WriteLine();
                        Console.Write("Insert the destiny of piece (example, e1): ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.executeChessMovement(origin, destiny);
                    }
                    catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}