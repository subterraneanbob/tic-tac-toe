using System;
using System.Collections.Generic;
using System.Linq;
using UnbeatableTicTacToe.GameCore;
using Xunit;

namespace UnbeatableTicTacToe.Tests
{
    public class BoardTests : IDisposable
    {
        private Board _board;

        public BoardTests()
        {
            _board = new Board();
        }

        public void Dispose()
        {
            _board = null;
        }

        [Fact]
        public void ConvertCoordinatesTest()
        {
            byte boardSize = 3;

            Assert.Equal(0, BoardCell.ToOneDimensionCoordinates(0, 0, boardSize));
            Assert.Equal(1, BoardCell.ToOneDimensionCoordinates(0, 1, boardSize));
            Assert.Equal(2, BoardCell.ToOneDimensionCoordinates(0, 2, boardSize));

            Assert.Equal(3, BoardCell.ToOneDimensionCoordinates(1, 0, boardSize));
            Assert.Equal(4, BoardCell.ToOneDimensionCoordinates(1, 1, boardSize));
            Assert.Equal(5, BoardCell.ToOneDimensionCoordinates(1, 2, boardSize));

            Assert.Equal(6, BoardCell.ToOneDimensionCoordinates(2, 0, boardSize));
            Assert.Equal(7, BoardCell.ToOneDimensionCoordinates(2, 1, boardSize));
            Assert.Equal(8, BoardCell.ToOneDimensionCoordinates(2, 2, boardSize));
        }

        [Fact]
        public void InitialPositionTest()
        {
            IEnumerable<BoardCell> position = _board.GetCurrentPosition();

            position.ToList().ForEach(e => Assert.Equal(Figure.Empty, e.Figure));
        }

        [Fact]
        public void SimplePutFigureTest()
        {
            List<BoardCell> expectedPosition = GenerateEmptyPosition();

            // X |   |   
            //   |   |  
            //   |   |  
            MakeMoveAndVerify(_board, Figure.Cross, 0, 0, expectedPosition);

            // X |   |  
            //   | O |  
            //   |   |  
            MakeMoveAndVerify(_board, Figure.Nought, 1, 1, expectedPosition);

            // X |   |  
            //   | O |  
            //   |   | X 
            MakeMoveAndVerify(_board, Figure.Cross, 2, 2, expectedPosition);
        }

        [Fact]
        public void InvalidPutFigureTest()
        {
            List<BoardCell> expectedPosition = GenerateEmptyPosition();

            // X |   |  
            //   |   |  
            //   |   |  
            MakeMoveAndVerify(_board, Figure.Cross, 0, 0, expectedPosition);

            // Try to put nought on top of cross that was put previously
            // O |   |  
            //   |   |  
            //   |   |  
            MakeMoveAndVerify(_board, Figure.Nought, 0, 0, expectedPosition, false);
        }

        [Fact]
        public void InvalidPutFigureTest2()
        {
            Assert.True(_board.PutFigure(Figure.Cross, new Move(0, 0)));
            Assert.False(_board.PutFigure(Figure.Nought, new Move(0, 0)));
        }

        [Fact]
        public void ToStringTest()
        {
            string expectedInitialRepr = $"| || || |{Environment.NewLine}| || || |{Environment.NewLine}| || || |";
            Assert.Equal(expectedInitialRepr, _board.ToString());

            // Play the game a little
            _board.PutFigure(Figure.Cross, new Move(0, 0));
            _board.PutFigure(Figure.Cross, new Move(0, 2));
            _board.PutFigure(Figure.Nought, new Move(1, 1));
            _board.PutFigure(Figure.Cross, new Move(2, 0));
            _board.PutFigure(Figure.Nought, new Move(2, 2));

            expectedInitialRepr = $"|X|| ||X|{Environment.NewLine}| ||O|| |{Environment.NewLine}|X|| ||O|";
            Assert.Equal(expectedInitialRepr, _board.ToString());
        }

        private List<BoardCell> GenerateEmptyPosition()
        {
            return new Board().GetCurrentPosition().ToList();
        }

        private void MakeMoveAndVerify(Board board, Figure figure, byte row, byte column, 
            List<BoardCell> expectedPosition, bool expectValidMove = true)
        {
            BoardCell cell = new BoardCell(row, column, figure, board.Size);

            bool validMove = board.PutFigure(figure, new Move(row, column));

            Assert.Equal(expectValidMove, validMove);

            if (expectValidMove)
            {
                expectedPosition[cell.Index] = cell;
            }

            Assert.Equal(expectedPosition, board.GetCurrentPosition());
        }
    }
}
