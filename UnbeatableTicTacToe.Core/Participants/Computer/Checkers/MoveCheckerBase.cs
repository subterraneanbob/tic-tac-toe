using System.Collections.Generic;
using System.Linq;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers
{
    public abstract class MoveCheckerBase : IMoveChecker
    {
        public abstract AvailableMoveType MoveType { get; }

        public abstract Move? DeterminePossibleMove(Game game);

        protected IEnumerable<ICollection<BoardCell>> GetRows(Game game)
        {
            IReadOnlyCollection<BoardCell> position = game.CurrentPosition;

            return Enumerable.Range(0, game.BoardSize)
                .Select(row => position.Where(cell => cell.Row == row).ToList());
        }

        protected IEnumerable<ICollection<BoardCell>> GetColumns(Game game)
        {
            IReadOnlyCollection<BoardCell> position = game.CurrentPosition;

            return Enumerable.Range(0, game.BoardSize)
                .Select(column => position.Where(cell => cell.Column == column).ToList());
        }

        protected IEnumerable<ICollection<BoardCell>> GetDiagonals(Game game)
        {
            IReadOnlyCollection<BoardCell> position = game.CurrentPosition;

            return new List<ICollection<BoardCell>>
            {
                // left-to-right (row == column)
                position.Where(cell => cell.Row == cell.Column).ToList(),
                // right-to-left (2,4,6), (3,6,9,12) ...
                (from idx in Enumerable.Range(1, game.BoardSize)
                                       .Select(i => i * (game.BoardSize - 1))
                 join cell in position on idx equals cell.Index
                 select cell).ToList()
            };
        }

        // Generate all possible aligned cells triples (horizontal, vertical and diagonal)
        protected IEnumerable<ICollection<BoardCell>> GetAllAlignedCells(Game game)
        {
            List<ICollection<BoardCell>> combinations = new List<ICollection<BoardCell>>();

            combinations.AddRange(GetRows(game));
            combinations.AddRange(GetColumns(game));
            combinations.AddRange(GetDiagonals(game));

            return combinations;
        }
    }
}