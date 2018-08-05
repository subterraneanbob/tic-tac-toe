using UnbeatableTicTacToe.GameCore.Participants.Computer;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Factories
{
    public interface IComputerAdversaryFactory
    {
        IComputerAdversary CreateComputerAdversary();
    }
}
