using System;
using System.Collections.Generic;
using UnbeatableTicTacToe.GameCore.Participants;

namespace UnbeatableTicTacToe.GameCore.GameMode
{
    public abstract class PlayableGameModeBase : IPlayableGameMode
    {
        protected readonly Game Game;
        protected Move LastMove;

        protected readonly Dictionary<PlayerNumber, IPlayer> Players = new Dictionary<PlayerNumber, IPlayer>();

        protected PlayableGameModeBase()
        {
            Game = new Game();
        }

        public void Loop()
        {
            if (Players.Count < 2)
            {
                throw new InvalidOperationException("Not enough players to start playing the game");
            }

            while (Game.CurrentState == GameState.SessionInProgress)
            {
                // before move
                BeforeMove();

                LastMove = Players[Game.CurrentPlayer].MakeNextMove(Game);

                // after move
                AfterMove();
            }

            // On game end
            AfterGameEnded();
        }

        protected void AddPlayer(PlayerNumber playerNumber, IPlayer player)
        {
            Players[playerNumber] = player;
        }

        protected virtual void BeforeMove()
        {
        }

        protected virtual void AfterMove()
        {
        }

        protected virtual void AfterGameEnded()
        {
        }
    }
}