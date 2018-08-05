using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.GameCore.Participants.Computer
{
    public abstract class ComputerAdversaryBase : IComputerAdversary
    {
        public Move MakeNextMove(Game game)
        {
            int capacity = 1024;
            while (true)
            {
                try
                {
                    Move move = GetNextMove(game);

                    game.MakeMove(move);
                    return move;
                }
                catch
                {
                    if (capacity-- <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        public abstract void SetStrategy(GameStrategyType strategy);

        protected abstract Move GetNextMove(Game game);

        public override string ToString()
        {
            return "Computer adversary";
        }
    }
}
