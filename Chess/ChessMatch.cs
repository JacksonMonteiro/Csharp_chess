using board;

namespace chess {
    internal class ChessMatch {
        public ChessBoard Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool isEnded { get; private set; }

        public ChessMatch() {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            isEnded = false;
            insertPieces();
        }

        public void executeMovement(Position origin, Position destiny) {
            Piece p = Board.removePiece(origin);
            p.incrementMovementQnt();

            Piece capturedPiece = Board.removePiece(destiny);
            Board.insertPiece(p, destiny);
        }

        private void insertPieces() {
            Board.insertPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.insertPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).toPosition());
            Board.insertPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).toPosition());
            Board.insertPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).toPosition());
            Board.insertPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.insertPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());
            
            
            Board.insertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            Board.insertPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.insertPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            Board.insertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            Board.insertPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.insertPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}