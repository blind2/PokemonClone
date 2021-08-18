using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Engine.Components;
using PokemonClone.Model;
using System;

namespace PokemonClone.Animations
{
    public class TrainerSendPokemon : IAnimation
    {
        private Sprite pokeball;
        private Sprite pokemonSprite;
        private Rectangle position;
        private bool isDone;
        private float timer;
 
        private const int scaleSpeed = 3;

        public bool IsDone => isDone;

        public TrainerSendPokemon(Sprite pokemonSprite, Rectangle position)
        { 
            this.pokemonSprite = pokemonSprite;
            this.position = position;
        }

        public void LoadContent(ContentManager content)
        {

            pokeball = new Sprite(content.Load<Texture2D>("pokeball"), position);
            pokemonSprite.IsVisible = false;
        }

        public void Update(GameTime gameTime)
        {
           

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer < 500)
            {
                return;
            }

            pokemonSprite.IsVisible = true;
            if (pokemonSprite.Rectangle.Width < Setting.PokemonSpriteSize)
            {
                pokemonSprite.RectangleWidth += scaleSpeed;
                pokemonSprite.RectangleHeight += scaleSpeed;
            }
            else
            {
                isDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeball.Draw(spriteBatch);
            pokemonSprite.Draw(spriteBatch,0, new Vector2(pokemonSprite.Texture.Width/2, pokemonSprite.Texture.Height/2));
        }
    }
}
