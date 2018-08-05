using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class EmptyCornerMoveCheckerTests : MoveCheckerTestsBase<EmptyCornerMoveChecker>
    {
        [Fact]
        public void MoveType_ForForkMoveChecker_ShouldReturnForkMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.EmptyCorner);
        }

        [Fact]
        public void DeterminePossibleMove_WhenEmptyCornerMoveIsAvailable_ShouldReturnEmptyCornerMove()
        {
            //X| |O
            // | |
            //X| |?
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(2, 0));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Be(new Move(2, 2));
        }

        [Fact]
        public void DeterminePossibleMove_WhenEmptyCornerMoveIsNotAvailable_ShouldReturnNull()
        {
            // X| |X
            //  | |
            // O| |O
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(2, 0));
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(2, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeFalse();
        }
    }
}
