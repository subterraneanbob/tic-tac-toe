using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer
{
    public interface IComputerAdversary : IPlayer
    {
        void SetStrategy(GameStrategyType strategy);
    }
}
