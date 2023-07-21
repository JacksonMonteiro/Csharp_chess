using board;

namespace chess {
    internal class King : Piece {
        private ChessBoard Board;
        private Color Color;
        public King(ChessBoard board, Color color) : base(board, color) {
            Board = board;
            Color = color;
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
             
            return movements;
            
        }
    }
}
