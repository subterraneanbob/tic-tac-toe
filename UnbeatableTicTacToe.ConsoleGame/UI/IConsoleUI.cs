using UnbeatableTicTacToe.GameCore;

namespace UnbeatableTicTacToe.ConsoleGame.UI
{
    public interface IConsoleUI
    {
        void RedrawBoard(Game game);
        Move PromptForRowAndColumn(Game game);
        void PrintWinner(Game game);
    }
}
