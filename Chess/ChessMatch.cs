using board;

namespace chess {
    internal class ChessMatch {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void executeChessMovement(Position origin, Position destiny) {
            executeMovement(origin, destiny);
            Turn++;
            switchPlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (Board.piece(pos) == null) {
                throw new BoardException("Don't exists piece on selected origin");
            }

            if (CurrentPlayer != Board.piece(pos).Color) {
                throw new BoardException("The selected piece is not yours");
            }
            

            if (!Board.piece(pos).exitsPossibleMovement()) {
                throw new BoardException("Does not exists available movements for the selected piece");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) {
            if (!Board.piece(origin).canMoveTo(destiny)) {
                throw new BoardException("Invalid destiny position");
            }
        }

        public void switchPlayer() {
            if (CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            }
            else {
                CurrentPlayer = Color.White;
            }
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