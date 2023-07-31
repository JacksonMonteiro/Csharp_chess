using board;

namespace chess {
    internal class ChessMatch {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool isEnded { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch() {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            isEnded = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            insertPieces();
        }

        public void executeMovement(Position origin, Position destiny) {
            Piece p = Board.removePiece(origin);
            p.incrementMovementQnt();

            Piece capturedPiece = Board.removePiece(destiny);
            Board.insertPiece(p, destiny);

            if (capturedPiece != null) {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces) {
                if (piece.Color == color) {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<Piece> inGamePieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces) {
                if (piece.Color == color) {
                    aux.Add(piece);
                }
            }

            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void insertNewPiece(char column, int line, Piece piece) {
            Board.insertPiece(piece, new ChessPosition(column, line).toPosition());
            Pieces.Add(piece);
        }

        private void insertPieces() {

            insertNewPiece('c', 1, new Tower(Board, Color.White));
            insertNewPiece('c', 2, new Tower(Board, Color.White));
            insertNewPiece('d', 2, new Tower(Board, Color.White));
            insertNewPiece('e', 2, new Tower(Board, Color.White));
            insertNewPiece('e', 1, new Tower(Board, Color.White));
            insertNewPiece('d', 1, new King(Board, Color.White));

            insertNewPiece('c', 7, new Tower(Board, Color.Black));
            insertNewPiece('c', 8, new Tower(Board, Color.Black));
            insertNewPiece('d', 7, new Tower(Board, Color.Black));
            insertNewPiece('e', 7, new Tower(Board, Color.Black));
            insertNewPiece('e', 8, new Tower(Board, Color.Black));
            insertNewPiece('d', 8, new King(Board, Color.Black));

        }
    }
}