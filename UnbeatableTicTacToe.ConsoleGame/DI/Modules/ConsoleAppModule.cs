using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;
using NLog.Extensions.Logging;
using UnbeatableTicTacToe.ConsoleGame.DI.Factories;
using UnbeatableTicTacToe.ConsoleGame.GameMode;
using UnbeatableTicTacToe.ConsoleGame.UI;
using UnbeatableTicTacToe.GameCore.GameMode;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace UnbeatableTicTacToe.ConsoleGame.DI.Modules
{
    public class ConsoleAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggerFactory>().To<LoggerFactory>().InSingletonScope()
                .OnActivation(f =>
                {
                    f.AddNLog(new NLogProviderOptions
                    {
                        CaptureMessageTemplates = true,
                        CaptureMessageProperties = true,
                    });
                });

            Bind<ILogger>().ToMethod(context => context.Kernel.Get<ILoggerFactory>().CreateLogger(context.Request.Target?.Type)).InSingletonScope();

            Bind<IConsoleUI>().To<ConsoleUI>().InSingletonScope();

            Bind<IHumanPlayer>().To<HumanPlayer>().InTransientScope();
            Bind<IHumanPlayerFactory>().To<HumanPlayerFactory>().InSingletonScope();

            Bind<IPlayableGameMode>().To<SinglePlayerMode>();
        }
    }
}
