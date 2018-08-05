namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies
{
    public interface IGameStrategy
    {
        GameStrategyType StrategyType { get; }
        Move DetermineNextMove(Game game);
    }
}