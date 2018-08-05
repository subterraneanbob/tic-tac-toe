using System;
using Ninject;
using UnbeatableTicTacToe.ConsoleGame.DI.Modules;

namespace UnbeatableTicTacToe.ConsoleGame.DI
{
    public class CompositionRoot : IDisposable
    {
        private readonly IKernel _kernel;

        public CompositionRoot()
        {
            _kernel = new StandardKernel();
            _kernel.Load<CommonModule>();
            _kernel.Load<GameModule>();
            _kernel.Load<ConsoleAppModule>();
        }

        public T GetInstance<T>()
        {
            return _kernel.Get<T>();
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
