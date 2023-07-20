using Chess.Board;
using Chess.Chess;

namespace Chess {
    internal class Program {
        static void Main(string[] args) {
            ChessPosition pos = new ChessPosition('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
        }
    }
} 