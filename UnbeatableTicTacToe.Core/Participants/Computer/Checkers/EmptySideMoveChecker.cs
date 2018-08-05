using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public class EmptySideMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.EmptySide;

        public override Move? DeterminePossibleMove(Game game)
        {
            var sideRows = GetRows(game).Where((row, i) => i == 0 || i == game.BoardSize - 1);
            var sideColumns = GetColumns(game).Where((column, i) => i == 0 || i == game.BoardSize - 1);

            var sides =
                from line in sideRows.Concat(sideColumns)
                select line.ElementAt(1);

            BoardCell emptySide = sides.FirstOrDefault(cell => cell.Figure == Figure.Empty);

            if (emptySide != null)
            {
                return new Move(emptySide.Row, emptySide.Column);
            }

            return null;
        }
    }
}