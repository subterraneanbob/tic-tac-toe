using System;
using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public class BlockForkMoveChecker : ForkMoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.BlockFork;

        public override Move? DeterminePossibleMove(Game game)
        {
            Move? CheckCellsForTwoInARowMove(ICollection<BoardCell> alignedCells)
            {
                // Number of cells occupied by current player's figure
                int occupiedCellsCount = alignedCells.Count(cell => cell.Figure == game.CurrentFigure);

                // Empty cells
                List<BoardCell> emptyCells = alignedCells.Where(cell => cell.Figure == Figure.Empty).ToList();

                // Winning position
                if (occupiedCellsCount == game.BoardSize - 2 && emptyCells.Count == 2)
                {
                    BoardCell emptyCell = emptyCells.First();
                    return new Move(emptyCell.Row, emptyCell.Column);
                }

                return null;
            }

            if (game.BoardSize != Board.DefaultBoardSize)
            {
                throw new NotImplementedException("Not implemented for board size > 3");
            }

            // Find lines with one of opponent's figures and two blanks
            List<Move> availableMoves = GetAvailableForkMoves(game, game.OpponentFigure);

            // Opponent can make a fork move
            if (availableMoves.Count > 0)
            {
                // Find opportunity to force opponent to block rather than fork
                // by creating two-in-a-row
                Move? opportunity = GetAllAlignedCells(game)
                    .Select(CheckCellsForTwoInARowMove)
                    .FirstOrDefault(m => m.HasValue);

                if (opportunity.HasValue)
                {
                    return opportunity;
                }

                // Block opponent's fork move
                return availableMoves.First();
            }

            return null;
        }
    }
}