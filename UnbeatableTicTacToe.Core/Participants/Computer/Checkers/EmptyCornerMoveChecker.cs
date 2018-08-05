using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public class EmptyCornerMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.EmptyCorner;

        public override Move? DeterminePossibleMove(Game game)
        {
            var selectMany = GetDiagonals(game).SelectMany(diagonal => new List<BoardCell>
            {
                diagonal.First(),
                diagonal.Last()
            }).Where(cell => cell.Figure == Figure.Empty).ToList();

            if (selectMany.Any())
            {
                BoardCell emptyCorner = selectMany.First();

                return new Move(emptyCorner.Row, emptyCorner.Column);
            }

            return null;
        }
    }
}
