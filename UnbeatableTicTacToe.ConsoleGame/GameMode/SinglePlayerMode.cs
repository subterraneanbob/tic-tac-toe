using Microsoft.Extensions.Logging;
using UnbeatableTicTacToe.ConsoleGame.DI.Factories;
using UnbeatableTicTacToe.ConsoleGame.UI;
using UnbeatableTicTacToe.GameCore.Participants;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.ConsoleGame.GameMode
{
    public class SinglePlayerMode : ConsoleGameModeBase
    {
        public SinglePlayerMode(IConsoleUI consoleUI, IHumanPlayerFactory humanPlayerFactory, 
            IComputerAdversaryFactory computerAdversaryFactory, ILogger logger) : base(consoleUI, logger)
        {
            AddPlayer(PlayerNumber.Player1, humanPlayerFactory.CreateHumanPlayer(_consoleUI));

            // Setup computer opponent
            IComputerAdversary adversary = computerAdversaryFactory.CreateComputerAdversary();
            adversary.SetStrategy(GameStrategyType.Believable);

            AddPlayer(PlayerNumber.Player2, adversary);
        }
    }
}
