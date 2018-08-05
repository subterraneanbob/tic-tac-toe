using System;
using System.Linq;
using UnbeatableTicTacToe.Common.Utils;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer
{
    public class ComputerAdversary : ComputerAdversaryBase
    {
        private readonly IGameStrategy[] _availableStrategies;
        private IGameStrategy _currentStrategy;

        public ComputerAdversary(IGameStrategy[] availableStrategies)
        {
            Require.NotNull(availableStrategies);

            if (availableStrategies.Length < 1)
            {
                throw new ArgumentException("No available game strategies for computer adversary", nameof(availableStrategies));
            }

            _availableStrategies = availableStrategies;
            _currentStrategy = availableStrategies[0];
        }

        public override void SetStrategy(GameStrategyType strategy)
        {
            _currentStrategy = _availableStrategies.First(s => s.StrategyType == strategy);
        }

        protected override Move GetNextMove(Game game)
        {
            return _currentStrategy.DetermineNextMove(game);
        }
    }
}
