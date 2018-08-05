using System.Collections.Generic;

namespace UnbeatableTicTacToe.GameCore
{
    public class BoardCell
    {
        private static readonly Dictionary<Figure, string> TextRepresentation = new Dictionary<Figure, string>
        {
            { Figure.Empty,  "| |" },
            { Figure.Cross,  "|X|" },
            { Figure.Nought, "|O|" }
        };

        private readonly byte _boardSize;

        public byte Row { get; }
        public byte Column { get; }
        public Figure Figure { get; }
        
        public byte Index => ToOneDimensionCoordinates(Row, Column, _boardSize);

        public string Description => $"{Figure} at ({Row},{Column})";

        public BoardCell(byte row, byte column, Figure figure, byte boardSize)
        {
            Row = row;
            Column = column;
            Figure = figure;
            _boardSize = boardSize;
        }

        public override bool Equals(object obj)
        {
            BoardCell other = (BoardCell)obj;

            return other != null &&
                   other.Row == Row && 
                   other.Column == Column &&
                   other.Figure == Figure;
        }

        public override int GetHashCode()
        {
            return Index;
        }

        public override string ToString()
        {
            return TextRepresentation[Figure];
        }

        /// <summary>
        /// Convert 2-dimensional coordinates (x,y) to 1-dimensional ones as follows:
        /// 0 | 1 | 2
        /// 3 | 4 | 5
        /// 6 | 7 | 8
        /// </summary>
        /// <returns></returns>
        public static byte ToOneDimensionCoordinates(byte row, byte column, byte boardSize)
        {
            return (byte)(column + (boardSize * row));
        }
    }
}
