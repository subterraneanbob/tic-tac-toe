using System;
using System.Linq;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies
{
    public class FlawlessStrategy : IGameStrategy
    {
        private readonly IMoveChecker[] _moveCheckers;

        public GameStrategyType StrategyType => GameStrategyType.Flawless;

        public FlawlessStrategy(IMoveChecker[] moveCheckers)
        {
            _moveCheckers = moveCheckers.OrderByDescending(c => (int)c.MoveType).ToArray();
        }

        public Move DetermineNextMove(Game game)
        {
            foreach (IMoveChecker checker in _moveCheckers)
            {
                Move? preferableMove = checker.DeterminePossibleMove(game);

                if (preferableMove.HasValue)
                {
                    return preferableMove.Value;
                }
            }

            throw new Exception("No moves were suggested by computer adversary. It is likely a bug in the implementation.");
        }
    }
}