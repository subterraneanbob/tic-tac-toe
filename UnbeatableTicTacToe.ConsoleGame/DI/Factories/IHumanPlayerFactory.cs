using UnbeatableTicTacToe.ConsoleGame.UI;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Factories
{
    public interface IHumanPlayerFactory
    {
        IHumanPlayer CreateHumanPlayer(IConsoleUI consoleUI);
    }
}
