namespace UnbeatableTicTacToe.GameCore.Participants
{
    public interface IPlayer
    {
        Move MakeNextMove(Game game);
    }
}