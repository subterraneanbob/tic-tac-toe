using Microsoft.Extensions.Logging;
using UnbeatableTicTacToe.ConsoleGame.UI;
using UnbeatableTicTacToe.GameCore.GameMode;
using UnbeatableTicTacToe.GameCore.Participants;

// ReSharper disable InconsistentNaming

namespace UnbeatableTicTacToe.ConsoleGame.GameMode
{
    public abstract class ConsoleGameModeBase : PlayableGameModeBase
    {
        protected readonly ILogger _logger;
        protected readonly IConsoleUI _consoleUI;

        private PlayerNumber currentPlayer = PlayerNumber.Player1;

        protected ConsoleGameModeBase(IConsoleUI consoleUI, ILogger logger)
        {
            _consoleUI = consoleUI;
            _logger = logger;
        }

        protected override void BeforeMove()
        {
            currentPlayer = Game.CurrentPlayer;
        }

        protected override void AfterMove()
        {
            _logger.LogTrace($"{ Players[currentPlayer] } make a { LastMove } move");
        }

        protected override void AfterGameEnded()
        {
            _consoleUI.PrintWinner(Game);
        }
    }
}
