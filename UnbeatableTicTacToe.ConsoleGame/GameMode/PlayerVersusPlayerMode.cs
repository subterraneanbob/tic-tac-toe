using Microsoft.Extensions.Logging;
using UnbeatableTicTacToe.ConsoleGame.DI.Factories;
using UnbeatableTicTacToe.ConsoleGame.UI;
using UnbeatableTicTacToe.GameCore.Participants;

namespace UnbeatableTicTacToe.ConsoleGame.GameMode
{
    public class PlayerVersusPlayerMode : ConsoleGameModeBase
    {
        public PlayerVersusPlayerMode(IConsoleUI consoleUI, IHumanPlayerFactory humanPlayerFactory, ILogger logger) : base(consoleUI, logger)
        {
            AddPlayer(PlayerNumber.Player1, humanPlayerFactory.CreateHumanPlayer(_consoleUI));
            AddPlayer(PlayerNumber.Player2, humanPlayerFactory.CreateHumanPlayer(_consoleUI));
        }
    }
}
