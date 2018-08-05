namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public interface IMoveChecker
    {
        AvailableMoveType MoveType { get; }
        Move? DeterminePossibleMove(Game game);
    }
}
