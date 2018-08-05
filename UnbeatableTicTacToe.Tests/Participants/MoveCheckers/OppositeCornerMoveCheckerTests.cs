using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class OppositeCornerMoveCheckerTests : MoveCheckerTestsBase<OppositeCornerMoveChecker>
    {
        [Fact]
        public void MoveType_ForForkMoveChecker_ShouldReturnForkMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.OppositeCorner);
        }

        [Fact]
        public void DeterminePossibleMove_WhenOppositeCornerMoveIsAvailable_ShouldReturnOppositeCornerMove()
        {
            //X| |
            // | |
            // | |?
            Game.MakeMove(new Move(0, 0));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Be(new Move(2, 2));
        }

        [Fact]
        public void DeterminePossibleMove_WhenOppositeCornerMoveIsNotAvailable_ShouldReturnNull()
        {
            //X| |O
            // | | 
            //O| |X
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(2, 0));
            Game.MakeMove(new Move(2, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeFalse();
        }
    }
}