using board;
using Chess.chess;
using System.Runtime.ConstrainedExecution;

namespace chess {
    internal class ChessMatch {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool isEnded { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;
        public bool Check { get; private set; }

        public ChessMatch() {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            isEnded = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Check = false;
            insertPieces();
        }

        public Piece executeMovement(Position origin, Position destiny) {
            Piece p = Board.removePiece(origin);
            p.incrementMovementQnt();

            Piece capturedPiece = Board.removePiece(destiny);
            Board.insertPiece(p, destiny);

            if (capturedPiece != null) {
                CapturedPieces.Add(capturedPiece);
            }

            // Short Castle
            if (p is King && destiny.Column == origin.Column + 2) {
                Position rookOrigin = new Position(origin.Line, origin.Column + 3);
                Position rookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece piece = Board.removePiece(rookOrigin);
                piece.incrementMovementQnt();
                Board.insertPiece(piece, rookDestiny);
            }

            // Long Castle
            if (p is King && destiny.Column == origin.Column - 2) {
                Position rookOrigin = new Position(origin.Line, origin.Column - 4);
                Position rookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece piece = Board.removePiece(rookOrigin);
                piece.incrementMovementQnt();
                Board.insertPiece(piece, rookDestiny);
            }

            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece) {
            Piece piece = Board.removePiece(destiny);
            piece.decreaseMovementQnt();
            if (capturedPiece != null) {
                Board.insertPiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.insertPiece(piece, origin);

            // Short Castle
            if (piece is King && destiny.Column == origin.Column + 2) {
                Position rookOrigin = new Position(origin.Line, origin.Column + 3);
                Position rookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece rookPiece = Board.removePiece(rookDestiny);
                rookPiece.decreaseMovementQnt();
                Board.insertPiece(rookPiece, rookOrigin);
            }

            // Short Castle
            if (piece is King && destiny.Column == origin.Column - 2) {
                Position rookOrigin = new Position(origin.Line, origin.Column - 4);
                Position rookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece rookPiece = Board.removePiece(rookDestiny);
                rookPiece.decreaseMovementQnt();
                Board.insertPiece(rookPiece, rookOrigin);
            }
        }

        public void executeChessMovement(Position origin, Position destiny) {
            Piece capturedPiece = executeMovement(origin, destiny);

            if (isItInCheck(CurrentPlayer)) {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check");
            }

            if (isItInCheck(adversary(CurrentPlayer))) {
                Check = true;
            }
            else {
                Check = false;
            }

            if (isItInMate(adversary(CurrentPlayer))) {
                isEnded = true;
            }
            else {
                Turn++;
                switchPlayer();
            }

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
            if (!Board.piece(origin).possibleMovement(destiny)) {
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
            foreach (Piece piece in Pieces) {
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
            insertNewPiece('a', 1, new Rook(Board, Color.White));
            insertNewPiece('b', 1, new Knight(Board, Color.White));
            insertNewPiece('c', 1, new Bishop(Board, Color.White));
            insertNewPiece('d', 1, new Queen(Board, Color.White));
            insertNewPiece('e', 1, new King(Board, Color.White, this));
            insertNewPiece('f', 1, new Bishop(Board, Color.White));
            insertNewPiece('g', 1, new Knight(Board, Color.White));
            insertNewPiece('h', 1, new Rook(Board, Color.White));
            insertNewPiece('a', 2, new Pawn(Board, Color.White));
            insertNewPiece('b', 2, new Pawn(Board, Color.White));
            insertNewPiece('c', 2, new Pawn(Board, Color.White));
            insertNewPiece('d', 2, new Pawn(Board, Color.White));
            insertNewPiece('e', 2, new Pawn(Board, Color.White));
            insertNewPiece('f', 2, new Pawn(Board, Color.White));
            insertNewPiece('g', 2, new Pawn(Board, Color.White));
            insertNewPiece('h', 2, new Pawn(Board, Color.White));

            insertNewPiece('a', 8, new Rook(Board, Color.Black));
            insertNewPiece('b', 8, new Knight(Board, Color.Black));
            insertNewPiece('c', 8, new Bishop(Board, Color.Black));
            insertNewPiece('d', 8, new Queen(Board, Color.Black));
            insertNewPiece('e', 8, new King(Board, Color.Black, this));
            insertNewPiece('f', 8, new Bishop(Board, Color.Black));
            insertNewPiece('g', 8, new Knight(Board, Color.Black));
            insertNewPiece('h', 8, new Rook(Board, Color.Black));
            insertNewPiece('a', 7, new Pawn(Board, Color.Black));
            insertNewPiece('b', 7, new Pawn(Board, Color.Black));
            insertNewPiece('c', 7, new Pawn(Board, Color.Black));
            insertNewPiece('d', 7, new Pawn(Board, Color.Black));
            insertNewPiece('e', 7, new Pawn(Board, Color.Black));
            insertNewPiece('f', 7, new Pawn(Board, Color.Black));
            insertNewPiece('g', 7, new Pawn(Board, Color.Black));
            insertNewPiece('h', 7, new Pawn(Board, Color.Black));
        }

        private Color adversary(Color color) {
            if (color == Color.White) {
                return Color.Black;
            }
            else {
                return Color.White;
            }
        }


        private Piece king(Color cor) {
            foreach (Piece piece in inGamePieces(cor)) {
                if (piece is King) {
                    return piece;
                }
            }
            return null;
        }


        public bool isItInCheck(Color cor) {
            Piece R = king(cor);
            if (R == null) {
                throw new BoardException("Doesn't exists a king of the color " + cor + " on the board!");
            }
            foreach (Piece x in inGamePieces(adversary(cor))) {
                bool[,] mat = x.possibleMovements();
                if (mat[R.Position.Line, R.Position.Column]) {
                    return true;
                }
            }
            return false;
        }

        public bool isItInMate(Color color) {
            if (!isItInCheck(color)) {
                return false;
            }

            foreach (Piece piece in inGamePieces(color)) {
                bool[,] mat = piece.possibleMovements();
                for (int i = 0; i < Board.Lines; i++) {
                    for (int j = 0; j < Board.Columns; j++) {
                        if (mat[i, j]) {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, destiny);

                            bool isInCheck = isItInCheck(color);
                            undoMovement(origin, destiny, capturedPiece);

                            if (!isInCheck) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}