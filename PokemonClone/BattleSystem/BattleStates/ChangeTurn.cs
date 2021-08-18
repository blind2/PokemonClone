using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleStates
{
    internal class ChangeTurn : IState
    {
        private Battle battle;
        private Pokemon playerPokemon;
        private Pokemon opponentPokemon;
        private bool canAttack;
        private int turn;


        public ChangeTurn(Battle battle)
        {
            this.battle = battle;
            playerPokemon = battle.battleView.PlayerPokemon;
            opponentPokemon = battle.battleView.OpponentPokemon;
        }

        public void GoToNextState()
        {
            throw new NotImplementedException();
        }

        private Pokemon RandomPokemon()
        {
            var number = Utility.GenerateRandomNumber(1, 2);

            if (number == 1) return playerPokemon;

            return opponentPokemon;
        }

        private Pokemon GetFastestPokemon()
        {
            if (playerPokemon.PokemonStats.Speed > opponentPokemon.PokemonStats.Speed) return playerPokemon;

            if (opponentPokemon.PokemonStats.Speed > playerPokemon.PokemonStats.Speed) return opponentPokemon;

            return RandomPokemon();
        }

        


        public void Update(GameTime gameTime)
        {
            if (turn==0)
            {
                if (GetFastestPokemon() == playerPokemon)
                {
                    battle.CurrentState = new PlayerTurn(battle);
                }
                else
                {
                    battle.CurrentState =new OpponentTurn(battle);
                }
            }
            if (turn == 1)
            {
                if (GetFastestPokemon() == playerPokemon)
                {
                    battle.CurrentState = new OpponentTurn(battle);
                }
                else
                {
                    battle.CurrentState = new PlayerTurn(battle);
                }
            }
            if (turn == 2)
            {
                turn = 0;
                battle.CurrentState = new SelectAction(battle);
            }
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBtach)
        {
            throw new NotImplementedException();
        }
    }
}
