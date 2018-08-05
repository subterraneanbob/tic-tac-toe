using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnbeatableTicTacToe.Common.Utils;

namespace UnbeatableTicTacToe.GameCore
{
    /// <summary>
    /// Represents a board for the game of tic-tac-toe.
    /// It allows to keep track of the current position and adjust it.
    /// </summary>
    internal class Board
    {
        private readonly BoardCell[] _position;
        
        /// <summary>
        /// Default size of the board for the game of tic-tac-toe
        /// </summary>
        public const byte DefaultBoardSize = 3;

        /// <summary>
        /// Size of the board
        /// </summary>
        public byte Size { get; }

        public Board(byte size = DefaultBoardSize)
        {
            Size = size;
            _position = new BoardCell[Size * Size];

            // Generate the initial position - every cell is empty
            for (byte i = 0, k = 0; i < Size; ++i)
            {
                for (byte j = 0; j < Size; ++j)
                {
                    _position[k++] = new BoardCell(i, j, Figure.Empty, Size);
                }
            }
        }

        /// <summary>
        /// Get current position on the board
        /// </summary>
        /// <returns>One-dimensional array containing either empty figure, nought or cross</returns>
        public BoardCell[] GetCurrentPosition()
        {
            return _position;
        }

        /// <summary>
        /// Put figure (X or O) to the board
        /// </summary>
        /// <param name="figure">Figure (nought or cross)</param>
        /// <param name="move">Possible move</param>
        /// <returns>True if the move was performed, false if the move is illegal</returns>
        public bool PutFigure(Figure figure, Move move)
        {
            // Nought or cross, remember?
            Require.NotEqual(figure, Figure.Empty, "figure");
            
            // Validate that coordinates are fit within the board
            Require.InRange(move.Row, 0, Size - 1, "row");
            Require.InRange(move.Column, 0, Size - 1, "column");

            // Add new cell to the board
            BoardCell newCell = new BoardCell(move.Row, move.Column, figure, Size);
            BoardCell existingCell = _position[newCell.Index];

            // The move is illegal if the cell is already occupied
            if (existingCell.Figure != Figure.Empty)
            {
                return false;
            }

            // Replace empty cell with some figure
            _position[newCell.Index] = newCell;
            return true;
        }

        public override string ToString()
        {
            StringBuilder repr = new StringBuilder();

            // Split into chunks of a one row's number of elements
            foreach (List<BoardCell> cell in _position.ChunkBy(Size))
            {
                repr.AppendLine(String.Join("", cell));
            }

            // Remove trailing carriage return and newline chars
            return repr.ToString().TrimEnd(Environment.NewLine.ToArray());
        }
    }
}
