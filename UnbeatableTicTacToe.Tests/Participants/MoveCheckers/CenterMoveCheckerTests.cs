using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class CenterMoveCheckerTests : MoveCheckerTestsBase<CenterMoveChecker>
    {
        [Fact]
        public void MoveType_ForForkMoveChecker_ShouldReturnForkMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.Center);
        }

        [Fact]
        public void DeterminePossibleMove_WhenCenterMoveIsAvailable_ShouldReturnCenterMove()
        {
            // X| |
            // O| |O
            //  | |X
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(2, 2));
            Game.MakeMove(new Move(1, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Be(new Move(1, 1));
        }

        [Fact]
        public void DeterminePossibleMove_WhenCenterIsOccupied_ShouldReturnNull()
        {
            // X| |
            // O|X|O
            //  | | 
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(1, 1));
            Game.MakeMove(new Move(1, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeFalse();
        }
    }
}
