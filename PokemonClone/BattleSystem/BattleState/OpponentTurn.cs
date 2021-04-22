using Microsoft.Xna.Framework;
using PokemonClone.Engine;
using PokemonClone.Model;
using System;

namespace PokemonClone.BattleSystem.BattleState
{
    public class OpponentTurn : IState
    {
        private Battle battle;
        private bool canAttack = true;
        private Animation animation;

        public OpponentTurn(Battle battle)
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
                battle.opponentPokemon.Attack(battle.playerPokemon.listMove[0], battle.playerPokemon);
                animation = new Animation();
                canAttack = false;
            }

            battle.combatText.UseText("OpponentPokemonAttck");
            animation.TakeDommage(battle.playerPokemonSprite);

            if (animation.Isfinished())
            {
                if (battle.playerPokemon.isDead())
                {
                    battle.curentState = battle.end;
                }
                else if (battle.fastestPokemon == battle.opponentPokemon)
                {
                    battle.curentState = battle.playerTurn;
                }
                else
                {
                    battle.curentState = battle.selectAction;
                    canAttack = true;
                }
            }

        }

    }
}

