using System;
using UnbeatableTicTacToe.Common.Utils;
using UnbeatableTicTacToe.GameCore;

namespace UnbeatableTicTacToe.ConsoleGame.UI
{
    public class ConsoleUI : IConsoleUI
    {
        private readonly IConsole _console;

        public ConsoleUI(IConsole console)
        {
            _console = console;
        }

        public void RedrawBoard(Game game)
        {
            Require.NotNull(game);

            _console.Clear();
            _console.WriteLine(game.ToString());
            _console.WriteLine("==========");
        }

        public Move PromptForRowAndColumn(Game game)
        {
            RedrawBoard(game);
            Console.WriteLine($"{game.CurrentPlayer}'s turn");

            Console.Write("Row = ");
            if (!byte.TryParse(Console.ReadLine(), out byte row))
            {
                return Move.Invalid;
            }

            Console.Write("Column = ");
            if (!byte.TryParse(Console.ReadLine(), out byte column))
            {
                return Move.Invalid;
            }

            return new Move(row, column);
        }
        
        public void PrintWinner(Game game)
        {
            RedrawBoard(game);

            Console.WriteLine(game.CurrentState == GameState.Tie ? "Draw!" : $"{game.CurrentState.Winner} wins!");
        }
    }
}
