using System;
using System.Linq;
using UnbeatableTicTacToe.Common.Utils;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies
{
    public class BelievableStrategy : IGameStrategy
    {
        public const int MistakeProbability = 25;

        private readonly IRandomNumbersProvider _randomNumbersProvider;

        private readonly IMoveChecker[] _moveCheckers;

        public GameStrategyType StrategyType => GameStrategyType.Believable;

        public BelievableStrategy(IMoveChecker[] moveCheckers, IRandomNumbersProvider randomNumbersProvider)
        {
            _moveCheckers = moveCheckers.OrderByDescending(c => (int)c.MoveType).ToArray();
            _randomNumbersProvider = randomNumbersProvider;
        }

        public virtual Move DetermineNextMove(Game game)
        {
            return DetermineNextMoveInternal(_moveCheckers, game, ShouldPlayOptimalMove()).SuggestedMove;
        }

        protected virtual bool ShouldPlayOptimalMove()
        {
            return _randomNumbersProvider.Next(0, 100) > MistakeProbability;
        }

        protected virtual MoveInfo DetermineNextMoveInternal(IMoveChecker[] moveCheckers, Game game, bool isOptimal = true)
        {
            if (!isOptimal)
            {
                moveCheckers = ShuffleCheckers(moveCheckers);
            }

            foreach (IMoveChecker checker in moveCheckers)
            {
                Move? possibleMove = checker.DeterminePossibleMove(game);

                if (possibleMove.HasValue)
                {
                    return new MoveInfo(possibleMove.Value, checker.MoveType, isOptimal);
                }
            }

            throw new Exception("No moves were suggested by computer adversary. It is likely a bug in the implementation.");
        }

        private IMoveChecker[] ShuffleCheckers(IMoveChecker[] checkers)
        {
            IMoveChecker[] shuffledMoveCheckers = new IMoveChecker[checkers.Length];
            Array.Copy(checkers, shuffledMoveCheckers, checkers.Length);

            _randomNumbersProvider.Shuffle(shuffledMoveCheckers);

            return shuffledMoveCheckers;
        }
    }
}