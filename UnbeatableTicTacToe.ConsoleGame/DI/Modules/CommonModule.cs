using Ninject.Modules;
using UnbeatableTicTacToe.Common.Utils;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Modules
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRandomNumbersProvider>().To<RandomNumbersProvider>().InSingletonScope();
            Bind<IConsole>().To<ConsoleWrapper>().InSingletonScope();
        }
    }
}
