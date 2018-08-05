using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public class OppositeCornerMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.OppositeCorner;

        public override Move? DeterminePossibleMove(Game game)
        {
            var oppositeCornersPairs =
                from diagonal in GetDiagonals(game)
                select new List<BoardCell>
                {
                    diagonal.First(),
                    diagonal.Last()
                };

            var oppositeCornerMoves =
                (from oppositeCorners in oppositeCornersPairs
                 where oppositeCorners.Count(c => c.Figure == Figure.Empty) == 1 &&
                       oppositeCorners.Count(c => c.Figure == game.OpponentFigure) == 1
                 select oppositeCorners).ToList();

            if (oppositeCornerMoves.Any())
            {
                BoardCell emptyCell = oppositeCornerMoves.First().First(cell => cell.Figure == Figure.Empty);

                return new Move(emptyCell.Row, emptyCell.Column);
            }

            return null;
        }
    }
}
