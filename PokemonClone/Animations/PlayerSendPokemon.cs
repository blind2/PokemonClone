using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Components;
using PokemonClone.Model;
using System.Collections.Generic;

namespace PokemonClone.Animations
{
    public class PlayerSendPokemon : IAnimation
    {
        private int index;
        private float timer;
        private bool isDone;
        private Sprite pokemonSprite;
        private List<Sprite> spritetList = new List<Sprite>();
        private ThrowPokeball throwPokeball;

        public bool IsDone => isDone;

        public PlayerSendPokemon(Sprite pokemonSprite)
        {
            this.pokemonSprite = pokemonSprite;
            pokemonSprite.IsVisible = false;
        }

        public void LoadContent(ContentManager content)
        {
            throwPokeball = new ThrowPokeball(pokemonSprite);
            throwPokeball.LoadContent(content);

            spritetList.Add(new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_00"), new Rectangle(100, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize)) { IsVisible = false });
            spritetList.Add(new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_01"), new Rectangle(100, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize)) { IsVisible = false });
            spritetList.Add(new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_02"), new Rectangle(100, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize)) { IsVisible = false });
            spritetList.Add(new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_03"), new Rectangle(100, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize)) { IsVisible = false });
            spritetList.Add(new Sprite(content.Load<Texture2D>("Npc\\RedBattleSprites\\red_battle_sprite_04"), new Rectangle(100, 120, Setting.PokemonSpriteSize, Setting.PokemonSpriteSize)) { IsVisible = false });
        }

        public void SetVisibility(bool isVissible)
        {
            foreach (var sprite in spritetList)
            {
                sprite.IsVisible = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (index > 2)
            {
                throwPokeball.Update(gameTime);
            }

            if (timer > 100 && index < spritetList.Count - 1)
            {
                index++;
                timer = 0;
            }

            foreach (var sprite in spritetList)
            {
                new MoveSprite(sprite, 7, -300).Update(gameTime);

            }
            if (throwPokeball.IsDone)
            {
                pokemonSprite.IsVisible = true;
                isDone = true;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spritetList[index].Draw(spriteBatch);
            
            pokemonSprite.Draw(spriteBatch,0,new Vector2(pokemonSprite.Texture.Width/2, pokemonSprite.Texture.Height/2));
            if (index > 2)
            {
                throwPokeball.Draw(spriteBatch);
            }
        }
    }
}
