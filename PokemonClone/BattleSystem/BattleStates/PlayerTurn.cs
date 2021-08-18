using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Animations;
using PokemonClone.Engine.Animations;
using PokemonClone.Enums;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleStates
{
    public  class PlayerTurn : IState
    {
        private Battle battle;
        private bool canAttack = true;

        private Pokemon playerPokemon;
        private Pokemon opponentPokemon;

        private TextAnimation textAnimation;
        private HealthBarAnimation healthBarAnimation;
        private bool isDone;

        public PlayerTurn(Battle battle)
        {
            this.battle = battle;

            playerPokemon = battle.battleView.PlayerPokemon;
            opponentPokemon = battle.battleView.OpponentPokemon;
            textAnimation = new TextAnimation(battle.battleView.combatDialogBox, 2);
            healthBarAnimation = new HealthBarAnimation(battle.battleView.opponentHealthBar);
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

        }

        public void Update(GameTime gameTime)
        {
            if (canAttack)
            {
                playerPokemon.Attack(playerPokemon.listMove[0], opponentPokemon);
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
                battle.CurrentState = new OpponentTurn(battle);
            }
            //Execute(() => battleEvent.HealthBarAnimation(battleView.opponentHealthBar, gameTime), true);

        }
    }
}
