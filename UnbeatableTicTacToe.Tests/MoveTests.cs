using UnbeatableTicTacToe.GameCore;
using Xunit;

namespace UnbeatableTicTacToe.Tests
{
    public class MoveTests
    {
        [Fact]
        public void InvalidMoveTest()
        {
            Move move = Move.Invalid;

            Assert.False(move.Valid);
            Assert.Equal(0, move.Row);
            Assert.Equal(0, move.Column);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 0)]
        [InlineData(2, 2)]
        public void EqualsTest(byte row, byte column)
        {
            Move move = new Move(row, column);
            Move expectedEqualMove = new Move(row, column);

            Assert.Equal(expectedEqualMove, move);
            Assert.True(move.Equals(expectedEqualMove));
            Assert.True(expectedEqualMove.Equals(move));

            Assert.Equal(move, move);
            Assert.Equal(expectedEqualMove, expectedEqualMove);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void NotEqualsTest(byte row, byte column)
        {
            Move move = new Move(0, 0);
            Move differentMove = new Move(row, column);

            Assert.NotEqual(move, differentMove);
            Assert.False(move.Equals(differentMove));
            Assert.False(differentMove.Equals(move));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void GetHashCodeTest(byte row, byte column)
        {
            Move move = new Move(0, 0);
            Move differentMove = new Move(row, column);

            Assert.NotEqual(differentMove.GetHashCode(), move.GetHashCode());
            Assert.Equal(differentMove.GetHashCode(), new Move(row, column).GetHashCode());
        }
    }
}
