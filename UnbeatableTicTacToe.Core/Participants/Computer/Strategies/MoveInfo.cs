namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies
{
    public class MoveInfo
    {
        public Move SuggestedMove { get; }
        public AvailableMoveType MoveType { get; }
        public bool IsOptimal { get; }

        public MoveInfo(Move suggestedMove, AvailableMoveType moveType, bool isOptimal)
        {
            IsOptimal = isOptimal;
            SuggestedMove = suggestedMove;
            MoveType = moveType;
        }
    }
}