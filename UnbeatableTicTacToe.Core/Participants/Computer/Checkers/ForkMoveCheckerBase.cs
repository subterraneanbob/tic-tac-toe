using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public abstract class ForkMoveCheckerBase : MoveCheckerBase
    {
        protected List<Move> GetAvailableForkMoves(Game game, Figure figure)
        {
            var candidateLines =
                (from cells in GetAllAlignedCells(game)
                    where cells.Count(cell => cell.Figure == figure) == 1 &&
                          cells.Count(cell => cell.Figure == Figure.Empty) == 2
                    select cells).ToList();

            // Determine available moves by finding intersection blanks between candidate lines
            var availableMoves =
                from line1 in candidateLines
                from line2 in candidateLines
                where !line1.SequenceEqual(line2) // eliminate comparison to the same line
                from c in line1.Intersect(line2)
                where c.Figure == Figure.Empty
                select new Move(c.Row, c.Column);

            return availableMoves.Distinct().ToList();
        }
    }
}