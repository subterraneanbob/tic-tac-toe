using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnbeatableTicTacToe.GameCore.Participants;

namespace UnbeatableTicTacToe.GameCore
{
    public class Game
    {
        private static readonly Dictionary<PlayerNumber, Figure> PlayerFigureChoice = new Dictionary<PlayerNumber, Figure>
        {
            { PlayerNumber.Player1, Figure.Cross },
            { PlayerNumber.Player2, Figure.Nought },
        };

        private readonly List<List<byte>> _winningIndicesCombinations = new List<List<byte>>();

        private Board _board;

        public byte BoardSize => _board.Size;

        public PlayerNumber CurrentPlayer { get; private set; } = PlayerNumber.Player1;

        public Figure CurrentFigure => PlayerFigureChoice[CurrentPlayer];

        public PlayerNumber NextPlayer => CurrentPlayer == PlayerNumber.Player1 ? PlayerNumber.Player2 : PlayerNumber.Player1;

        public Figure OpponentFigure => CurrentFigure == Figure.Cross ? Figure.Nought : Figure.Cross;

        public GameState CurrentState { get; private set; } = GameState.SessionInProgress;

        public IReadOnlyCollection<BoardCell> CurrentPosition => new ReadOnlyCollection<BoardCell>(_board.GetCurrentPosition());

        public Game(byte boardSize = Board.DefaultBoardSize)
        {
            Init(boardSize);
        }

        public void MakeMove(Move move)
        {
            if (CurrentState != GameState.SessionInProgress)
            {
                throw new InvalidOperationException("Game over");
            }

            if (!_board.PutFigure(PlayerFigureChoice[CurrentPlayer], move))
            {
                throw new ArgumentOutOfRangeException(nameof(move), "Illegal move");
            }

            CurrentState = Advance();
            CurrentPlayer = NextPlayer;
        }

        private void Init(byte boardSize)
        {
            _board = new Board(boardSize);
            CurrentPlayer = PlayerNumber.Player1;
            GenerateWinningCombinations(boardSize);
        }

        private void GenerateWinningCombinations(byte boardSize)
        {
            // Generate winning combinations
            // Horizontal
            for (byte i = 0; i < boardSize * boardSize; i += boardSize)
            {
                _winningIndicesCombinations.Add(Enumerable.Range(i, boardSize).Select(e => (byte)e).ToList());
            }

            // Vertical
            var range = Enumerable.Range(0, boardSize).Select(e => e * boardSize).ToList();
            for (byte i = 0; i < boardSize; ++i)
            {
                _winningIndicesCombinations.Add(range.Select(e => (byte)(e + i)).ToList());
            }

            // Diagonal
            _winningIndicesCombinations.Add(Enumerable.Range(0, boardSize).Select(e => (byte)(e * (boardSize + 1))).ToList());
            _winningIndicesCombinations.Add(Enumerable.Range(1, boardSize).Select(e => (byte)(e * (boardSize - 1))).ToList());
        }

        private GameState Advance()
        {
            BoardCell[] position = _board.GetCurrentPosition();

            // Check for winning conditions
            foreach (var winningLine in _winningIndicesCombinations)
            {
                var line = new Figure[winningLine.Count];

                for (byte i = 0; i < winningLine.Count; ++i)
                {
                    line[i] = position[winningLine.ElementAt(i)].Figure;
                }

                if (line.All(figure => figure == Figure.Cross))
                {
                    return new GameState(PlayerFigureChoice.First(pair => pair.Value == Figure.Cross).Key, 
                        winningLine.ToArray());
                }

                if (line.All(figure => figure == Figure.Nought))
                {
                    return new GameState(PlayerFigureChoice.First(pair => pair.Value == Figure.Nought).Key, 
                        winningLine.ToArray());
                }
            }

            return position.Any(cell => cell.Figure == Figure.Empty) ? GameState.SessionInProgress : GameState.Tie;
        }

        public override string ToString()
        {
            return _board.ToString();
        }
    }
}
