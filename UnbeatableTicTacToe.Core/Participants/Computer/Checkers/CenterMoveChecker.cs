using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public class CenterMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.Center;

        public override Move? DeterminePossibleMove(Game game)
        {
            var diagonals = GetDiagonals(game).ToList();

            var diagonal1 = diagonals.ElementAt(0);
            var diagonal2 = diagonals.ElementAt(1);

            BoardCell centerCell = diagonal1.Intersect(diagonal2).First();

            Move? move = null;

            if (centerCell.Figure == Figure.Empty)
            {
                move = new Move(centerCell.Row, centerCell.Column);
            }

            return move;
        }
    }
}