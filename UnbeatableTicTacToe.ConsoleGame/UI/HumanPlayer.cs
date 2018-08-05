using UnbeatableTicTacToe.GameCore;

namespace UnbeatableTicTacToe.ConsoleGame.UI
{
    public class HumanPlayer : IHumanPlayer
    {
        private readonly IConsoleUI _consoleUI;

        public HumanPlayer(IConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public Move MakeNextMove(Game game)
        {
            for (;;)
            {
                Move move = _consoleUI.PromptForRowAndColumn(game);

                try
                {
                    if (move.Valid)
                    {
                        game.MakeMove(move);
                        return move;
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        public override string ToString()
        {
            return "Human player";
        }
    }
}
