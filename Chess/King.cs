using board;

namespace chess {
    internal class King : Piece {
        private ChessMatch Match;
        public King(ChessBoard board, Color color, ChessMatch match) : base(board, color) {
            Match = match;
        }

        public override string ToString() {
            return "R";
        }

        private bool canMove(Position pos) {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] movements = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // UP
            pos.defineValues(Position.Line - 1, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // North East
            pos.defineValues(Position.Line - 1, Position.Column + 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // Right
            pos.defineValues(Position.Line, Position.Column + 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // South East
            pos.defineValues(Position.Line + 1, Position.Column + 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // South 
            pos.defineValues(Position.Line + 1, Position.Column);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // South West
            pos.defineValues(Position.Line + 1, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // West
            pos.defineValues(Position.Line, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // North West
            pos.defineValues(Position.Line - 1, Position.Column - 1);
            if (Board.isValidPosition(pos) && canMove(pos)) {
                movements[pos.Line, pos.Column] = true;
            }

            // castle
            if (MovementQnt == 0 && !Match.Check) {
                // Short castle
                Position rookPosition = new Position(Position.Line, Position.Column + 3);
                if (testRookToCastle(rookPosition)) {
                    Position one = new Position(Position.Line, Position.Column + 1);
                    Position two = new Position(Position.Line, Position.Column + 2  );

                    if (Board.piece(one) == null && Board.piece(two) == null) {
                        movements[Position.Line, Position.Column + 2] = true;
                    }
                }

                // Long Castle
                Position longRookPosition = new Position(Position.Line, Position.Column - 4);
                if (testRookToCastle(longRookPosition)) {
                    Position one = new Position(Position.Line, Position.Column - 1);
                    Position two = new Position(Position.Line, Position.Column -  2);
                    Position three = new Position(Position.Line, Position.Column -  3);

                    if (Board.piece(one) == null && Board.piece(two) == null && Board.piece(three) == null) {
                        movements[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return movements;

        }

        private bool testRookToCastle(Position pos) {
            Piece piece = Board.piece(pos);
            return piece != null && piece is Rook && piece.Color == Color && piece.MovementQnt == 0;

        }
    }
}
