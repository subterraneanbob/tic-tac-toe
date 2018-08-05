using UnbeatableTicTacToe.ConsoleGame.UI;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Factories
{
    public class HumanPlayerFactory : IHumanPlayerFactory
    {
        public IHumanPlayer CreateHumanPlayer(IConsoleUI consoleUI)
        {
            return new HumanPlayer(consoleUI);
        }
    }
}
