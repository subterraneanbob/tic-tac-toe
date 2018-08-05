using System;
using UnbeatableTicTacToe.ConsoleGame.DI;
using UnbeatableTicTacToe.GameCore.GameMode;

namespace UnbeatableTicTacToe.ConsoleGame
{
    class Program
    {
        static void Main()
        {
            using (CompositionRoot compositionRoot = new CompositionRoot())
            {
                IPlayableGameMode gameClient = compositionRoot.GetInstance<IPlayableGameMode>();
                gameClient.Loop();

                Console.ReadKey();
            }
        }
    }
}
