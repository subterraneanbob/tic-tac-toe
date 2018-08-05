using System;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;

namespace UnbeatableTicTacToe.Tests.Participants.MoveCheckers
{
    public class MoveCheckerTestsBase<T> : IDisposable where T: MoveCheckerBase, new()
    {
        protected readonly Game Game;
        protected readonly IMoveChecker Checker;

        public MoveCheckerTestsBase()
        {
            Game = new Game();
            Checker = new T();
        }

        public void Dispose()
        {
        }
    }
}