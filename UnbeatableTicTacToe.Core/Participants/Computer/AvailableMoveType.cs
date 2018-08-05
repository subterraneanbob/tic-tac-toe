namespace UnbeatableTicTacToe.GameCore.Participants.Computer
{
    public enum AvailableMoveType
    {
        EmptySide = 1,
        EmptyCorner = 2,
        OppositeCorner = 4,
        Center = 8,
        BlockFork = 16,
        Fork = 32,
        Block = 64,
        Win = 128
    }
}
