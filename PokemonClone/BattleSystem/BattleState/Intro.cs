using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Engine;
using PokemonClone.Model;

namespace PokemonClone.BattleSystem.BattleState
{
    public class Intro : IState
    { 
        private Battle battle;       

        public Intro(Battle battle)
        {
            this.battle = battle;
        }

        public void GoToNextState()
        {
            battle.curentState = battle.selectAction;
        }

        public void Introduction()
        {
            battle.combatText.UseText("intro");
            battle.animationManager.Invoke("MoveLeft");
            battle.animationManager.Invoke("MoveRight");
            battle.PlayerBattleFrame(false);
            battle.OpponentBattleFrame(false);
            battle.selectionBoxAction.SetVisibility(false);


            if (battle.isKeyPressed == true)
            {
                battle.combatText.UseText("intro");
                battle.animationManager.UseAnimation("OpponentSwitchPokemon");
                battle.animationManager.UseAnimation("OpponentSendPokemon");             
                battle.animationManager.UseAnimation("OpponentSendPokemon");
                battle.opponentPokemonSprite.SetVisibility(true);
                battle.animationManager.UseAnimation("ShowOpponentBattleFrame");
                battle.combatText.UseText("PlayerSendPokemon");
                battle.animationManager.UseAnimation("PlayerSwitchPokemon");
                battle.animationManager.UseAnimation("PlayerSendPokemon");
                battle.playerPokemonSprite.SetVisibility(true);
                battle.animationManager.UseAnimation("ShowPlayerBattleFrame");

                if (battle.animationManager.Animation.Isfinished())
                {
                    GoToNextState();
                }
            }
        }

  

        public void Update(GameTime gameTime)
        {
            battle.Input();
            Introduction();
        }
    }
}
