using System;
using UnbeatableTicTacToe.GameCore.Participants.Computer;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Factories
{
    public class ComputerAdversaryFactory : IComputerAdversaryFactory
    {
        private readonly Func<IComputerAdversary> _computerAdversaryCreator;

        public ComputerAdversaryFactory(Func<IComputerAdversary> computerAdversaryCreator)
        {
            _computerAdversaryCreator = computerAdversaryCreator;
        }

        public IComputerAdversary CreateComputerAdversary()
        {
            return _computerAdversaryCreator();
        }
    }
}
