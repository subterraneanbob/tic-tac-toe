using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class ForkMoveCheckerTests : MoveCheckerTestsBase<ForkMoveChecker>
    {
        [Fact]
        public void MoveType_ForForkMoveChecker_ShouldReturnForkMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.Fork);
        }

        [Fact]
        public void DeterminePossibleMove_WhenForkMoveIsAvailable_ShouldReturnWinMove()
        {
            // X| |? 
            // O|?|O
            // X| |?  
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(2, 0));
            Game.MakeMove(new Move(1, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().Match<Move>(m => m == new Move(0, 2) ||
                                           m == new Move(1, 1) ||
                                           m == new Move(2, 2));
        }

        [Fact]
        public void DeterminePossibleMove_WhenForkMoveIsNotAvailable_ShouldReturnNull()
        {
            // X| | 
            //  | | 
            //  | |O   
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(2, 2));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeFalse();
        }
    }
}
