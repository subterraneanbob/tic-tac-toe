namespace UnbeatableTicTacToe.Common.Utils
{
    public interface IRandomNumbersProvider
    {
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
    }
}
