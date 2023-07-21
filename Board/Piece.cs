namespace board {
    abstract class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQnt { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(ChessBoard board, Color color) {
            Position = null;
            Board = board;
            Color = color;
            MovementQnt = 0;
        }

        public void incrementMovementQnt() {
            MovementQnt++;
        }

        public abstract bool[,] possibleMovements();

        public bool exitsPossibleMovement() {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < Board.Lines; i++) {
                for (int j = 0; j < Board.Columns; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool canMoveTo(Position pos) {
            return possibleMovements()[pos.Line, pos.Column];
        }
    }
}
