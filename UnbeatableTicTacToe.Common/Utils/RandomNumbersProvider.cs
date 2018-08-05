using System;

namespace UnbeatableTicTacToe.Common.Utils
{
    public class RandomNumbersProvider : IRandomNumbersProvider
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}