using FluentAssertions;
using UnbeatableTicTacToe.ConsoleGame.DI;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;
using Xunit;

namespace UnbeatableTicTacToe.Tests.Participants
{
    public class FlawlessStrategyTests
    {
        private readonly FlawlessStrategy _strategy;
        private readonly Game _game = new Game();

        public FlawlessStrategyTests()
        {
            CompositionRoot root = new CompositionRoot();
            _strategy = root.GetInstance<FlawlessStrategy>();
        }

        [Fact]
        public void DetermineNextMove_WhenOpponentMoveHasToBeBlocker_ShouldReturnBlockMove()
        {
            // |X|O| |
            // | |X| |
            // | | |?|
            _game.MakeMove(new Move(0, 0));
            _game.MakeMove(new Move(0, 1));
            _game.MakeMove(new Move(1, 1));

            Move move = _strategy.DetermineNextMove(_game);

            move.Should().Be(new Move(2, 2));
        }
    }
}
