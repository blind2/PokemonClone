using Microsoft.Xna.Framework;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleState
{
    public class ChangeTurn : IState
    {
        private Battle battle;


        public ChangeTurn(Battle battle)
        {
            this.battle = battle;
        }


        public void GoToNextState()
        {
          
        }

        public void Update(GameTime gameTime)
        {
            battle.selectionBoxMove.SetVisibility(false);

            if (battle.playerPokemon.PokemonStats.Speed > battle.opponentPokemon.PokemonStats.Speed)
            {
                battle.fastestPokemon = battle.playerPokemon;
                battle.curentState = battle.playerTurn;
            }

            else if (battle.opponentPokemon.PokemonStats.Speed > battle.playerPokemon.PokemonStats.Speed)
            {
                battle.fastestPokemon = battle.opponentPokemon;
                battle.curentState = battle.opponentTurn;
            }
            else
            {
                battle.fastestPokemon = battle.playerPokemon;
                battle.curentState = battle.playerTurn;

            }
        }
    }
}
