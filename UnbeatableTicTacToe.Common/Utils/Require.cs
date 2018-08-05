using System;
using System.Collections.Generic;

namespace UnbeatableTicTacToe.Common.Utils
{
    public static class Require
    {
        public static void NotNull(object value, string parameterName = "value")
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{parameterName} cannot be null.");
            }
        }

        public static void NotEmpty(string value, string parameterName = "value")
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{parameterName} cannot be empty.");
            }
        }

        public static void Equal<T>(T actualValue, T unExpectedValue, string parameterName = "value")
        {
            if (!EqualityComparer<T>.Default.Equals(actualValue, unExpectedValue))
            {
                throw new ArgumentException($"{actualValue} cannot be equal to {unExpectedValue}", parameterName);
            }
        }

        public static void NotEqual<T>(T actualValue, T unExpectedValue, string parameterName = "value")
        {
            if (EqualityComparer<T>.Default.Equals(actualValue, unExpectedValue))
            {
                throw new ArgumentException($"{actualValue} cannot be equal to {unExpectedValue}", parameterName);
            }
        }

        public static void InRange(int value, int low, int high, string parameterName = "value")
        {
            if (value < low || value > high)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"{value} is not in range [{low};{high}]");
            }
        }
    }
}
