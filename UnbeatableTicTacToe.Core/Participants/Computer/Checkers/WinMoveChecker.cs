using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    // Win: If the player has two in a row, they can place a third to get three in a row.
    public class WinMoveChecker : MoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.Win;

        public override Move? DeterminePossibleMove(Game game)
        {
            Move? CheckCellsForWinMove(ICollection<BoardCell> alignedCells)
            {
                // Number of cells occupied by current player's figure
                int occupiedCellsCount = alignedCells.Count(cell => cell.Figure == game.CurrentFigure);

                // Empty cells
                List<BoardCell> emptyCells = alignedCells.Where(cell => cell.Figure == Figure.Empty).ToList();

                // Winning position
                if (occupiedCellsCount == game.BoardSize - 1 && emptyCells.Count == 1)
                {
                    BoardCell emptyCell = emptyCells.First();
                    return new Move(emptyCell.Row, emptyCell.Column);
                }

                return null;
            }
            
            return GetAllAlignedCells(game).Select(CheckCellsForWinMove).FirstOrDefault(m => m.HasValue);
        }
    }
}
