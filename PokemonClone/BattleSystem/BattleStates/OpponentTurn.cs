using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Animations;
using PokemonClone.Engine.Animations;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleStates
{
    public class OpponentTurn : IState
    {
        private Battle battle;
        private bool canAttack = true;

        private Pokemon playerPokemon;
        private Pokemon opponentPokemon;

        private TextAnimation textAnimation;
        private HealthBarAnimation healthBarAnimation;
        private bool isDone;

        public OpponentTurn(Battle battle)
        {
            this.battle = battle;

            playerPokemon = battle.battleView.PlayerPokemon;
            opponentPokemon = battle.battleView.OpponentPokemon;
            textAnimation = new TextAnimation(battle.battleView.combatDialogBox, 3);
            healthBarAnimation = new HealthBarAnimation(battle.battleView.playerHealthBar);
        }

        public void Draw(SpriteBatch spriteBtach)
        {
            throw new NotImplementedException();
        }

        public void GoToNextState()
        {
            battle.CurrentState = battle.SelectAction;
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            if (canAttack)
            {
                opponentPokemon.Attack(opponentPokemon.listMove[0], playerPokemon);
                canAttack = false;
            }

            AnimationPlayer.Play(() => textAnimation.Update(gameTime));
            if (textAnimation.IsDone)
            {
                AnimationPlayer.Play(() => healthBarAnimation.Update(gameTime));
            }


            if (healthBarAnimation.IsDone)
            {
                //new PlayerTurn(battle);
                //canAttack = true;
                //GoToNextState();
                battle.CurrentState = new PlayerTurn(battle);
            }
            //Execute(() => battleEvent.HealthBarAnimation(battleView.opponentHealthBar, gameTime), true);

        }
    }
}
