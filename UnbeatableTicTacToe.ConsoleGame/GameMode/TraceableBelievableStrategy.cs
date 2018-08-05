using Microsoft.Extensions.Logging;
using UnbeatableTicTacToe.Common.Utils;
using UnbeatableTicTacToe.GameCore;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.ConsoleGame.GameMode
{
    public class TraceableBelievableStrategy : BelievableStrategy
    {
        protected readonly ILogger Logger;

        public TraceableBelievableStrategy(IMoveChecker[] moveCheckers, 
            IRandomNumbersProvider randomNumbersProvider, ILogger logger) : base(moveCheckers, randomNumbersProvider)
        {
            Logger = logger;
        }

        protected override bool ShouldPlayOptimalMove()
        {
            bool playOptimal = base.ShouldPlayOptimalMove();

            if (!playOptimal)
            {
                Logger?.LogTrace("Computer adversary proposed a non-optimal move");
            }

            return playOptimal;
        }

        protected override MoveInfo DetermineNextMoveInternal(IMoveChecker[] moveCheckers, Game game, bool isOptimal = true)
        {
            MoveInfo moveInfo = base.DetermineNextMoveInternal(moveCheckers, game, isOptimal);

            Logger?.LogTrace($"Move { moveInfo.SuggestedMove } type = { moveInfo.MoveType }");

            return moveInfo;
        }
    }
}
