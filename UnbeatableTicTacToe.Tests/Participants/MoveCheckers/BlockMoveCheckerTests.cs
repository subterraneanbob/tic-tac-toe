using FluentAssertions;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class BlockMoveCheckerTests : MoveCheckerTestsBase<BlockMoveChecker>
    {
        [Fact]
        public void MoveType_ForWinMoveChecker_ShouldReturnWinMove()
        {
            Checker.MoveType.Should().Be(AvailableMoveType.Block);
        }

        [Fact]
        public void DeterminePossibleMove_WhenBlockMoveIsAvailable_ShouldReturnBlockMove()
        {
            // X|O| 
            //  |X| 
            //  | |?
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(0, 1));
            Game.MakeMove(new Move(1, 1));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.HasValue.Should().BeTrue();
            move.Should().BeEquivalentTo(new Move(2, 2));
        }

        [Fact]
        public void DeterminePossibleMove_WhenBlockMoveIsNotAvailable_ShouldReturnNull()
        {
            // X|?|X
            // O| | 
            //  |O| 
            Game.MakeMove(new Move(0, 0));
            Game.MakeMove(new Move(1, 0));
            Game.MakeMove(new Move(0, 2));
            Game.MakeMove(new Move(2, 1));

            Move? move = Checker.DeterminePossibleMove(Game);

            move.Should().BeNull();
        }
    }
}
