using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Components;
using PokemonClone.Engine.Animations;
using PokemonClone.Engine.Components;
using PokemonClone.PokemonData;

namespace PokemonClone.BattleSystem
{
    public class BattleView
    {
        public Pokemon PlayerPokemon { get; }
        public Pokemon OpponentPokemon { get; }
        public Pokemon fastestPokemon;

        private Sprite background;
        private Sprite playerBattleFrame;
        private Sprite opponentBattleFrame;


        public Sprite OpponentPokemonSprite { get; private set; }
        public Sprite PlayerPokemonSprite { get; private set; }

        public Sprite PlayerSrpite { get; private set; }
        public Sprite OpponentSprite { get; private set; }

        private Label opponentName;
        private Label playerName;
        private Label playerLevel;
        private Label opponentLevel;
        private Label playerPokemonHp;
        private Label playerPokemonMaxHp;

        //public DialogBox dialogBox;
        public DialogBox combatDialogBox { get; private set; }
        public SelectionBox selectionBoxAction { get; private set; }
        public SelectionBox selectionBoxMove { get; private set; }

        public HealthBar opponentHealthBar { get; private set; }
        public HealthBar playerHealthBar { get; private set; }
        private SpriteFont font;

        private AnimationManager animationManager;
        private CombatTextManager combatText;

        public bool isKeyPressed = false;

        public BattleView(Pokemon playerPokemon, Pokemon opponentPokemon)
        {
            this.PlayerPokemon = playerPokemon;
            this.OpponentPokemon = opponentPokemon;
        }
        public BattleView()
        {

        }


        private void SelectionBoxAction(ContentManager content)
        {
            var selectionActionSprite = content.Load<Texture2D>("action_selection_box");
            selectionBoxAction = new SelectionBox(new Sprite(selectionActionSprite, new Rectangle(530, 320, 270, 160)));

            selectionBoxAction.AddOption(new Label() { Font = font, Position = new Vector2(570, 360), Text = "FIGHT", Size = 2f });
            selectionBoxAction.AddOption(new Label() { Font = font, Position = new Vector2(700, 360), Text = "BAG", Size = 2f });
            selectionBoxAction.AddOption(new Label() { Font = font, Position = new Vector2(570, 415), Text = "POKEMON", Size = 2f });
            selectionBoxAction.AddOption(new Label() { Font = font, Position = new Vector2(700, 415), Text = "RUN", Size = 2f });

            selectionBoxAction.LoadContent(content);
            selectionBoxAction.SetVisibility(false);
        }


        private void SelectionBoxMove(ContentManager content)
        {
            var selectionActionSprite = content.Load<Texture2D>("action_selection_box");
            selectionBoxMove = new SelectionBox(new Sprite(selectionActionSprite, new Rectangle(0, 320, 350, 160)));

            selectionBoxMove.AddOption(new Label() { Font = font, Position = new Vector2(40, 360), Text = PlayerPokemon.GetMoveName(0).ToUpper(), Size = 2f });
            selectionBoxMove.AddOption(new Label() { Font = font, Position = new Vector2(180, 360), Text = PlayerPokemon.GetMoveName(1).ToUpper(), Size = 2f });
            selectionBoxMove.AddOption(new Label() { Font = font, Position = new Vector2(40, 415), Text = PlayerPokemon.GetMoveName(2).ToUpper(), Size = 2f });
            selectionBoxMove.AddOption(new Label() { Font = font, Position = new Vector2(180, 415), Text = PlayerPokemon.GetMoveName(3).ToUpper(), Size = 2f });

            selectionBoxMove.LoadContent(content);
            selectionBoxMove.SetVisibility(false);
        }

        private void PlayerBattleFrame(ContentManager content)
        {
            playerName = new Label() { Font = font, Position = new Vector2(500, 215), Text = PlayerPokemon.PokemonStats.Name.ToUpper(), Size = 2f };
            playerLevel = new Label() { Font = font, Position = new Vector2(715, 219), Text = PlayerPokemon.PokemonStats.Level.ToString(), Size = 2f };
            playerPokemonHp = new Label() { Font = font, Position = new Vector2(655, 270), Text = PlayerPokemon.PokemonStats.CurrentHp.ToString(), Size = 2f };
            playerPokemonMaxHp = new Label() { Font = font, Position = new Vector2(670, 270), Text = "  /" + PlayerPokemon.PokemonStats.Hp.ToString(), Size = 2f };

            playerBattleFrame = new Sprite(content.Load<Texture2D>("Battle\\player_battle_frame"), new Rectangle(450, 205, 300, 110));
            playerHealthBar = new HealthBar(PlayerPokemon, new Sprite(content.Load<Texture2D>("Color\\green"), new Rectangle(590, 255, 137, 10)));
            playerHealthBar.LoadContent(content);
        }

        private void OpponentBattleFrame(ContentManager content)
        {
            opponentName = new Label() { Font = font, Position = new Vector2(60, 45), Text = OpponentPokemon.PokemonStats.Name.ToUpper(), Size = 2f };
            opponentLevel = new Label() { Font = font, Position = new Vector2(290, 50), Text = OpponentPokemon.PokemonStats.Level.ToString(), Size = 2f };

            opponentBattleFrame = new Sprite(content.Load<Texture2D>("Battle\\opponent_battle_frame"), new Rectangle(40, 35, 300, 90));
            opponentHealthBar = new HealthBar(OpponentPokemon, new Sprite(content.Load<Texture2D>("Color\\green"), new Rectangle(156, 87, 145, 10)));
            opponentHealthBar.LoadContent(content);
        }


        private void PlayerBattleFrameDraw(SpriteBatch spriteBatch)
        {
            playerBattleFrame.Draw(spriteBatch);
            playerName.Draw(spriteBatch);
            playerLevel.Draw(spriteBatch);
            playerPokemonHp.Draw(spriteBatch);
            playerPokemonMaxHp.Draw(spriteBatch);
            playerHealthBar.Draw(spriteBatch);
        }

        private void OpponentBattleFrameDraw(SpriteBatch spriteBatch)
        {
            opponentBattleFrame.Draw(spriteBatch);
            opponentName.Draw(spriteBatch);
            opponentLevel.Draw(spriteBatch);
            opponentHealthBar.Draw(spriteBatch);
        }

        public void PlayerBattleFrameVisibility(bool isVisible)
        {
            playerBattleFrame.IsVisible = isVisible;
            playerName.IsVisible = isVisible;
            playerLevel.IsVisible = isVisible;
            playerPokemonHp.IsVisible = isVisible;
            playerPokemonMaxHp.IsVisible = isVisible;
            playerHealthBar.SetVisibility(isVisible);

        }
        public void OpponentBattleFrameVisibility(bool isVisible)
        {
            opponentBattleFrame.IsVisible = isVisible;
            opponentName.IsVisible = isVisible;
            opponentLevel.IsVisible = isVisible;
            opponentHealthBar.SetVisibility(isVisible);
        }


        public void LoadContent(ContentManager content)
        {
            OpponentPokemonSprite = new Sprite(OpponentPokemon.SpriteSet.FrontSprite, new Rectangle(-200, 35, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            PlayerPokemonSprite = new Sprite(PlayerPokemon.SpriteSet.BackSprite, new Rectangle(100, 170, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            PlayerPokemonSprite.IsVisible = false;
            PlayerSrpite = new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_00"), new Rectangle(800, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));
            OpponentSprite = new Sprite(content.Load<Texture2D>("Npc\\bug_battle_sprite"), new Rectangle(-200, 0, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize));

            font = content.Load<SpriteFont>("Font\\pokemon");
            background = new Sprite(content.Load<Texture2D>("Battle\\grass_background"), new Rectangle(0, 0, Setting.ScreenWidth, 320));
            combatDialogBox = new DialogBox(content.Load<Texture2D>("Battle\\combat_dialogbox"), new Rectangle(0, 320, Setting.ScreenWidth, 160), new Label() { Font = font, Position = new Vector2(40, 350), Color = Color.White, Size = 2.5f }) { BorderSize = 0 };
            //combatDialogBox.LoadContent(content, 32, 33, Color.White);

            SelectionBoxAction(content);
            SelectionBoxMove(content);
            PlayerBattleFrame(content);
            OpponentBattleFrame(content);
        }

        public void Update(GameTime gameTime)
        {
            //combatDialogBox.Update(gameTime);
            Animation.gameTime = gameTime;
            //selectionBoxAction.Update(gameTime);
            //selectionBoxMove.Update(gameTime);
            //opponentHealthBar.Update(gameTime);
            //playerHealthBar.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, null);

            background.Draw(spriteBatch);
            combatDialogBox.Draw(spriteBatch);

            PlayerPokemonSprite.Draw(spriteBatch);
            OpponentPokemonSprite.Draw(spriteBatch);

            selectionBoxAction.Draw(spriteBatch);
            selectionBoxMove.Draw(spriteBatch);
            PlayerBattleFrameDraw(spriteBatch);
            OpponentBattleFrameDraw(spriteBatch);
            PlayerSrpite.Draw(spriteBatch);
            OpponentSprite.Draw(spriteBatch);

            //spriteBatch.End();
        }


    }
}


