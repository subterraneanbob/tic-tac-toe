using System;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using UnbeatableTicTacToe.ConsoleGame.DI.Factories;
using UnbeatableTicTacToe.ConsoleGame.GameMode;
using UnbeatableTicTacToe.GameCore.Participants.Computer;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Checkers;
using UnbeatableTicTacToe.GameCore.Participants.Computer.Strategies;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Modules
{
    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameStrategy>().To<FlawlessStrategy>();
            Bind<IGameStrategy>().To<TraceableBelievableStrategy>();
            Bind<IGameStrategy>().To<RandomStrategy>();

            Kernel.Bind(c => c.FromAssemblyContaining<IMoveChecker>()
                .SelectAllClasses().InheritedFrom<IMoveChecker>()
                .BindAllInterfaces()
                .Configure(b => b.InSingletonScope()));

            Bind<IComputerAdversary>().To<ComputerAdversary>();

            IComputerAdversary ComputerAdversaryCreator() => Kernel?.Get<IComputerAdversary>();
            Bind<IComputerAdversaryFactory>().To<ComputerAdversaryFactory>()
                .WithConstructorArgument((Func<IComputerAdversary>)ComputerAdversaryCreator);
        }
    }
}
