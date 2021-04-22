using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonClone.BattleSystem.BattleState;
using PokemonClone.Engine;
using PokemonClone.Model;
using PokemonClone.PokemonData;

namespace PokemonClone.BattleSystem
{
    public class Battle
    {
        public Pokemon playerPokemon;
        public Pokemon opponentPokemon;
        public Pokemon fastestPokemon;

        private Sprite background;
        public Sprite playerTextureRectangle;
        public Sprite opponentTextureRectangle;
        private Sprite playerBattleFrame;
        private Sprite opponentBattleFrame;
        public Sprite opponentPokemonSprite;
        public Sprite playerPokemonSprite;
      

        private Label opponentName;
        private Label playerName;
        private Label playerLevel;
        private Label opponentLevel;
        private Label playerPokemonHp;
        private Label playerPokemonMaxHp;

        public DialogBox dialogBox;
        public SelectionBox selectionBoxAction;
        public SelectionBox selectionBoxMove;

        private HealthBar opponentHealthBar;
        private HealthBar playerHealthBar;
        private SpriteFont font;

        public AnimationManager animationManager;
        public CombatTextManager combatText;
        
        public bool isKeyPressed = false;
        
        //State
        public Intro intro;
        public SelectAction selectAction;
        public SelectMove selectMove;
        public ChangeTurn changeAction;
        public End end;
        public PlayerTurn playerTurn;
        public OpponentTurn opponentTurn;
        public IState curentState;

        public Battle(Pokemon playerPokemon, Pokemon opponentPokemon)
        {
            this.playerPokemon = playerPokemon;
            this.opponentPokemon = opponentPokemon;

            combatText = new CombatTextManager(this);
            animationManager = new AnimationManager(this);
            intro = new Intro(this);
            selectAction = new SelectAction(this);
            selectMove = new SelectMove(this);
            changeAction = new ChangeTurn(this);
            end = new End(this);
            playerTurn = new PlayerTurn(this);
            opponentTurn = new OpponentTurn(this);
            curentState = intro;
        }

        public void Input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isKeyPressed = true;
            }
        }

        public void SelectionBoxAction()
        {
            selectionBoxAction.AddOption(new Label(font, new Vector2(540, 395), new Color(48, 48, 48), "FIGHT"));
            selectionBoxAction.AddOption(new Label(font, new Vector2(700, 395), new Color(48, 48, 48), "BAG"));
            selectionBoxAction.AddOption(new Label(font, new Vector2(540, 450), new Color(48, 48, 48), "POKEMON"));
            selectionBoxAction.AddOption(new Label(font, new Vector2(700, 450), new Color(48, 48, 48), "RUN"));
        }

        public void SelectionBoxMove()
        {
            selectionBoxMove.AddOption(new Label(font, new Vector2(60, 395), new Color(48, 48, 48), playerPokemon.GetMoveName(0).ToUpper()));
            selectionBoxMove.AddOption(new Label(font, new Vector2(250, 395), new Color(48, 48, 48), playerPokemon.GetMoveName(1).ToUpper()));
            selectionBoxMove.AddOption(new Label(font, new Vector2(60, 450), new Color(48, 48, 48), playerPokemon.GetMoveName(2)));
            selectionBoxMove.AddOption(new Label(font, new Vector2(250, 450), new Color(48, 48, 48), playerPokemon.GetMoveName(3)));
        }

      
        public void LoadContent(ContentManager content)
        {

            //Trainer sprite
            Texture2D opponentSprite = content.Load<Texture2D>("Npc\\gary_battle_sprite");
            Texture2D playerSprite = content.Load<Texture2D>("Npc\\red_battle_sprite");
            Texture2D selectionMoveSprite = content.Load<Texture2D>("selection_move_box");
            Texture2D selectionActionSprite = content.Load<Texture2D>("action_selection_box");
            font = content.Load<SpriteFont>("Font\\pokemon");
            background = new Sprite(content.Load<Texture2D>("Battle\\grass_background"), new Rectangle(0, 0, Setting.ScreenWidth, 350));
            playerBattleFrame = new Sprite(content.Load<Texture2D>("Battle\\player_battle_frame"), new Rectangle(425, 235, 350, 110));
            opponentBattleFrame = new Sprite(content.Load<Texture2D>("Battle\\opponent_battle_frame"), new Rectangle(40, 55, 345, 90));
            dialogBox = new DialogBox(content.Load<Texture2D>("Battle\\combat_dialogbox"), new Rectangle(0, 350, Setting.ScreenWidth, 175));
            playerTextureRectangle = new Sprite(playerSprite, new Rectangle(790, 175, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            opponentTextureRectangle = new Sprite(opponentSprite, new Rectangle(0, 45, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            opponentPokemonSprite = new Sprite(opponentPokemon.SpriteSet.FrontSprite, new Rectangle(900, 63, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            playerPokemonSprite = new Sprite(playerPokemon.SpriteSet.BackSprite, new Rectangle(-200, 219, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            dialogBox.LoadContent(content, 32, 33, Color.White);
            selectionBoxAction = new SelectionBox(new Sprite(selectionActionSprite, new Rectangle(500, 350, 300, 175)));
            selectionBoxAction.LoadContent(content, 19, 32, 20, 50);
            selectionBoxMove = new SelectionBox(new Sprite(selectionActionSprite, new Rectangle(0, 350, 450, 175)));
            selectionBoxMove.LoadContent(content, 19, 32, 40, 50);
            SelectionBoxAction();
            SelectionBoxMove();
            selectionBoxMove.SetVisibility(false);
            opponentName = new Label(font, new Vector2(60, 65), new Color(48, 48, 48));
            playerName = new Label(font, new Vector2(480, 245), new Color(48, 48, 48));
            playerLevel = new Label(font, new Vector2(732, 249), new Color(48, 48, 48));
            playerPokemonHp = new Label(font, new Vector2(665, 300), new Color(48, 48, 48));
            playerPokemonMaxHp = new Label(font, new Vector2(700, 300), new Color(48, 48, 48));
            opponentLevel = new Label(font, new Vector2(323, 70), new Color(48, 48, 48));
            opponentHealthBar = new HealthBar(opponentPokemon, new Sprite(content.Load<Texture2D>("Color\\green"), new Rectangle(175, 108, 165, 10)));
            opponentHealthBar.LoadContent(content);
            playerHealthBar = new HealthBar(playerPokemon, new Sprite(content.Load<Texture2D>("Color\\green"), new Rectangle(588, 285, 160, 10)));
            playerHealthBar.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            dialogBox.Update(gameTime);
            Animation.gameTime = gameTime;
            selectionBoxAction.Update(gameTime);
            selectionBoxMove.Update(gameTime);
            opponentHealthBar.Update(gameTime);
            playerHealthBar.Update(gameTime);
            curentState.Update(gameTime);

        }

        public void PlayerBattleFrame(bool visible)
        {
            playerBattleFrame.SetVisibility(visible);
            playerLevel.SetVisibility(visible);
            playerName.SetVisibility(visible);
            playerHealthBar.SetVisibility(visible);
            playerPokemonHp.SetVisibility(visible);
            playerPokemonMaxHp.SetVisibility(visible);
        }

        public void OpponentBattleFrame(bool visible)
        {
            opponentBattleFrame.SetVisibility(visible);
            opponentLevel.SetVisibility(visible);
            opponentName.SetVisibility(visible);
            opponentHealthBar.SetVisibility(visible);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
            background.Draw(spriteBatch);
            dialogBox.Draw(spriteBatch, 0, 2.5f);
            playerTextureRectangle.Draw(spriteBatch);
            opponentTextureRectangle.Draw(spriteBatch);
            opponentBattleFrame.Draw(spriteBatch);
            playerBattleFrame.Draw(spriteBatch);
            playerName.Draw(spriteBatch, playerPokemon.PokemonStats.Name.ToUpper(), 2f);
            playerLevel.Draw(spriteBatch, playerPokemon.PokemonStats.Level.ToString(), 2f);
            opponentName.Draw(spriteBatch, opponentPokemon.PokemonStats.Name.ToUpper(), 2f);
            opponentLevel.Draw(spriteBatch, opponentPokemon.PokemonStats.Level.ToString(), 2f);
            playerPokemonHp.Draw(spriteBatch, playerPokemon.PokemonStats.CurrentHp.ToString(), 2f);
            playerPokemonMaxHp.Draw(spriteBatch, "/" + playerPokemon.PokemonStats.Hp.ToString(), 2f);
            opponentPokemonSprite.Draw(spriteBatch);
            playerPokemonSprite.Draw(spriteBatch);
            selectionBoxAction.Draw(spriteBatch);
            selectionBoxMove.Draw(spriteBatch);
            opponentHealthBar.Draw(spriteBatch);
            playerHealthBar.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
