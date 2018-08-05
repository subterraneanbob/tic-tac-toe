using System;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants;
using Xunit;

namespace UnbeatableTicTacToe.Tests
{
    public class GameTests : IDisposable
    {
        private Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        public void Dispose()
        {
            _game = null;
        }

        [Fact]
        public void SimpleGameTest()
        {
            Assert.Equal(GameState.SessionInProgress, _game.CurrentState);

            _game.MakeMove(new Move(0, 0));
            _game.MakeMove(new Move(0, 1));

            Assert.Equal(GameState.SessionInProgress, _game.CurrentState);

            _game.MakeMove(new Move(1, 1));
            _game.MakeMove(new Move(1, 0));
            _game.MakeMove(new Move(2, 2));

            Assert.True(_game.CurrentState.Winner == PlayerNumber.Player1);
        }

        [Fact]
        public void TieTest()
        {
            _game.MakeMove(new Move(0, 0));
            _game.MakeMove(new Move(0, 2));
            _game.MakeMove(new Move(0, 1));
            _game.MakeMove(new Move(1, 0));
            _game.MakeMove(new Move(1, 2));
            _game.MakeMove(new Move(1, 1));
            _game.MakeMove(new Move(2, 0));
            _game.MakeMove(new Move(2, 2));
            _game.MakeMove(new Move(2, 1));

            Assert.Equal(GameState.Tie, _game.CurrentState);
        }
    }
}
