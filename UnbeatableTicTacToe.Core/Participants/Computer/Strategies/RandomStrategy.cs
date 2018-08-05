using System.Collections.Generic;
using System.Linq;
using UnbeatableTicTacToe.Common.Utils;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies
{
    public class RandomStrategy : IGameStrategy
    {
        private readonly IRandomNumbersProvider _randomNumbersProvider;

        public GameStrategyType StrategyType => GameStrategyType.Random;

        public RandomStrategy(IRandomNumbersProvider randomNumbersProvider)
        {
            _randomNumbersProvider = randomNumbersProvider;
        }

        public Move DetermineNextMove(Game game)
        {
            List<Move> availableMoves = GetAvailableMoves(game);
            return availableMoves.ElementAt(_randomNumbersProvider.Next(0, availableMoves.Count));
        }

        protected List<Move> GetAvailableMoves(Game game)
        {
            return game.CurrentPosition
                .Where(cell => cell.Figure == Figure.Empty)
                .Select(cell => new Move(cell.Row, cell.Column))
                .ToList();
        }
    }
}