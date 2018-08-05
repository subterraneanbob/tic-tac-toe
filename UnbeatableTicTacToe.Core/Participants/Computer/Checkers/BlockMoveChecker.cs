using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    // Block: If the opponent has two in a row, the player must play the third themselves to block the opponent.
    public class BlockMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.Block;

        public override Move? DeterminePossibleMove(Game game)
        {
            Move? CheckCellsForBlockMove(ICollection<BoardCell> alignedCells)
            {
                // Number of cells occupied by opponent
                int occupiedCellsCount = alignedCells.Count(cell => cell.Figure == game.OpponentFigure);

                // Empty cells
                List<BoardCell> emptyCells = alignedCells.Where(cell => cell.Figure == Figure.Empty).ToList();

                if (occupiedCellsCount == game.BoardSize - 1 && emptyCells.Count == 1)
                {
                    BoardCell emptyCell = emptyCells.First();
                    return new Move(emptyCell.Row, emptyCell.Column);
                }

                return null;
            }

            return GetAllAlignedCells(game).Select(CheckCellsForBlockMove).FirstOrDefault(m => m.HasValue);
        }
    }
}
