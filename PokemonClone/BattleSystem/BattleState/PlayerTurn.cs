using Microsoft.Xna.Framework;
using PokemonClone.Engine;
using PokemonClone.Model;
using System;

namespace PokemonClone.BattleSystem.BattleState
{
    public class PlayerTurn : IState
    {
        private Battle battle;
        private bool canAttack = true;
        private Animation animation;

        public PlayerTurn(Battle battle)
        {
            this.battle = battle;
        }

        public void GoToNextState()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            if (canAttack)
            {
                battle.playerPokemon.Attack(battle.playerPokemon.listMove[0], battle.opponentPokemon);
                animation = new Animation();
                canAttack = false;
            }
          
            battle.combatText.UseText("PlayerPokemonAttack");
            
            animation.TakeDommage(battle.opponentPokemonSprite);

            if (animation.Isfinished())
            {
                if (battle.opponentPokemon.isDead())
                {
                   battle.curentState = battle.end;
                }
                else if (battle.fastestPokemon == battle.playerPokemon)
                {
                    battle.curentState = battle.opponentTurn;
                    canAttack = true;
                }
            }

         




        }
    }
}
