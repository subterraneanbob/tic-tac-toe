using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class BlockForkMoveCheckerTests : MoveCheckerTestsBase<BlockForkMoveChecker>
    {
        [Fact]
        public void MoveType_ForForkMoveChecker_ShouldReturnForkMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.BlockFork);
        }

        [Fact]
        public void DeterminePossibleMove_WhenOpponentForkIsAvailable_ShouldReturnTwoInARowMove()
        {
            // X|?| 
            // O|O|X
            // X|?| 
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 1));
            Game.MakeMove(new Move(2, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(1, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Match<Move>(m => m == new Move(0, 1) ||
                                           m == new Move(2, 1));
        }

        [Fact]
        public void DeterminePossibleMove_WhenOpponentForkIsAvailable_ShouldReturnBlockForkMove()
        {
            //  |X|O
            // O| |X
            // X|?| 
            Game.MakeMove(new Move(0, 1));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(1, 2));
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(2, 0));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Be(new Move(2,1));
        }

        [Fact]
        public void DeterminePossibleMove_WhenOpponentForkIsNotAvailable_ShouldReturnNull()
        {
            // O| |X
            // X| |O
            //  | | 
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(1, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeFalse();
        }
    }
}
