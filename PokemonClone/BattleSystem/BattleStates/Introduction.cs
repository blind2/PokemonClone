using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Animations;
using PokemonClone.Engine.Components;
using PokemonClone.Model;

namespace PokemonClone.BattleSystem.BattleStates
{
    public class Introduction : IState
    {
        private Battle battle;
        private MoveSprite movePlayerSpriteLeft;
        private MoveSprite moveOpponentSpriteRight;
        private MoveSprite oppenentRetire;
        private TextAnimation textAnimation;
        private TrainerSendPokemon trainerSendPokemon;
        private PlayerSendPokemon playerSendPokemon;

        public Introduction(Battle battle)
        {
            this.battle = battle;
            movePlayerSpriteLeft = new MoveSprite(battle.battleView.PlayerSrpite, 8, 100);
            moveOpponentSpriteRight = new MoveSprite(battle.battleView.OpponentSprite, 8, 490);
            oppenentRetire = new MoveSprite(battle.battleView.OpponentSprite, 8, 800);
            textAnimation = new TextAnimation(battle.battleView.combatDialogBox, 0);        
        }


        public void GoToNextState()
        {
            battle.CurrentState = battle.SelectAction;
        }

        public void LoadContent(ContentManager content)
        {
            trainerSendPokemon = new TrainerSendPokemon(new Sprite(content.Load<Texture2D>("Pokemon\\Front\\charmander_front"),new Rectangle(590,130,25,25)), new Rectangle(570, 150, 30, 30));
            trainerSendPokemon.LoadContent(content);

            playerSendPokemon = new PlayerSendPokemon(new Sprite(content.Load<Texture2D>("Pokemon\\Back\\bulbasaur_back"), new Rectangle(200, 270, 25, 25)));
            playerSendPokemon.LoadContent(content);
        }

        bool keyPressed;
        public void Update(GameTime gameTime)
        {
            battle.battleView.PlayerBattleFrameVisibility(false);
            battle.battleView.OpponentBattleFrameVisibility(false);
           
            AnimationPlayer.Play(() => movePlayerSpriteLeft.Update(gameTime));
            AnimationPlayer.Play(() => moveOpponentSpriteRight.MoveRight(gameTime));
            AnimationPlayer.Play(() => textAnimation.Update(gameTime));


            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                keyPressed = true;
            }

            if (keyPressed)
            {
                AnimationPlayer.Play(() => oppenentRetire.MoveRight(gameTime));
                
            }
            if (oppenentRetire.IsDone)
            {              
                AnimationPlayer.Play(() => trainerSendPokemon.Update(gameTime));
                textAnimation = new TextAnimation(battle.battleView.combatDialogBox, 1);
                textAnimation.Update(gameTime);

            }
            if (movePlayerSpriteLeft.IsDone)
            {
              
                battle.battleView.PlayerSrpite.IsVisible = false;
                playerSendPokemon.SetVisibility(true);
            }
            if (trainerSendPokemon.IsDone)
            {
                battle.battleView.OpponentBattleFrameVisibility(true);
                playerSendPokemon.Update(gameTime);
                //AnimationPlayer.Play(() => playerRetire.Update(gameTime));
            }
            if (playerSendPokemon.IsDone)
            {
                battle.battleView.PlayerBattleFrameVisibility(true);
                //battle.CurrentState = new SelectAction(battle);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSendPokemon.Draw(spriteBatch);
            if (oppenentRetire.IsDone)
            {
                trainerSendPokemon.Draw(spriteBatch);
            }
           
        }
    }
}
