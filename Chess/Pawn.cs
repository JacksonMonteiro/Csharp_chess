using board;
using chess;

namespace Chess.chess {
    internal class Pawn : Piece {
        public Pawn(ChessBoard Board, Color Color) : base(Board, Color) {
            
        }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Position pos) {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool livre(Position pos) {
            return Board.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White) {
                pos.defineValues(Position.Line - 1, Position.Column);
                if (Board.isValidPosition(pos) && livre(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.isValidPosition(p2) && livre(p2) && Board.isValidPosition(pos) && livre(pos) && MovementQnt == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column - 1);
                if (Board.isValidPosition(pos) && existeInimigo(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line - 1, Position.Column + 1);
                if (Board.isValidPosition(pos) && existeInimigo(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                /*if (Position.Line == 3) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.isValidPosition(left) && existeInimigo(left) && Board.piece(left) == Match.vulneravelEnPassant) {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Board.isValidPosition(direita) && existeInimigo(direita) && Board.piece(direita) == Match.vulneravelEnPassant) {
                        mat[direita.Line - 1, direita.Column] = true;
                    }
                }*/
            }
            else {
                pos.defineValues(Position.Line + 1, Position.Column);
                if (Board.isValidPosition(pos) && livre(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.isValidPosition(p2) && livre(p2) && Board.isValidPosition(pos) && livre(pos) && MovementQnt == 0) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column - 1);
                if (Board.isValidPosition(pos) && existeInimigo(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValues(Position.Line + 1, Position.Column + 1);
                if (Board.isValidPosition(pos) && existeInimigo(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                
                /*if (Position.Line == 4) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.isValidPosition(left) && existeInimigo(left) && Board.piece(left) == Match.vulneravelEnPassant) {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Board.isValidPosition(direita) && existeInimigo(direita) && Board.piece(direita) == Match.vulneravelEnPassant) {
                        mat[direita.Line + 1, direita.Column] = true;
                    }
                }*/
            }

            return mat;
        }

    }
}
