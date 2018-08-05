using System;
using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    // Fork: Create an opportunity where the player has two threats to win (two non-blocked lines of 2).
    public class ForkMoveChecker : ForkMoveCheckerBase
    {
        public override AvailableMoveType MoveType => AvailableMoveType.Fork;

        public override Move? DeterminePossibleMove(Game game)
        {
            if (game.BoardSize != Board.DefaultBoardSize)
            {
                throw new NotImplementedException("Not implemented for board size > 3");
            }

            // Find lines with one of current figures and two blanks
            List<Move> availableMoves = GetAvailableForkMoves(game, game.CurrentFigure);

            return availableMoves.Count > 0 ? availableMoves.First() : default(Move?);
        }
    }
}
