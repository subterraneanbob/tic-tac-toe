using UnbeatableTicTacToe.GameCore.Participants;

namespace UnbeatableTicTacToe.GameCore
{
    public class GameState
    {
        public static readonly GameState SessionInProgress = new GameState();
        public static readonly GameState Tie = new GameState();

        public PlayerNumber? Winner { get; }
        public byte[] WinningLine { get; }

        public GameState()
        {
        }

        public GameState(PlayerNumber winner, byte[] winningLine)
        {
            Winner = winner;
            WinningLine = winningLine;
        }
    }
}
