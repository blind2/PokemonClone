using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Components;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.Animations
{
    public class ThrowPokeball : IAnimation
    {
        private Sprite pokemonSprite;
        private Sprite pokeball;
        private Vector2 velocity = Vector2.Zero;
        private Vector2 position;
        private float gravity = 20f;
        private float speed = 150;
        private  float timer;
        private float rotation;

        private bool isDone;
        private bool applyForce = true;
        private const int scaleSpeed = 3;

        public bool IsDone => isDone;

        public ThrowPokeball(Sprite pokemonSprite)
        {
            this.pokemonSprite = pokemonSprite;
        }

        public void LoadContent(ContentManager content)
        {
            pokeball = new Sprite(content.Load<Texture2D>("pokeball"), new Rectangle(150, 200, 30, 30));
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            //Rotation
            if (timer > 20)
            {
                rotation++;
                timer = 0;

            }

            if (pokeball.RectangleY < 175)
            {
                applyForce = false;
            }

            if (applyForce == true)
            {
                velocity.Y = -speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            velocity.X = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position = new Vector2(pokeball.RectangleX, pokeball.RectangleY);
            position += velocity;
            pokeball.RectangleX = (int)position.X;
            pokeball.RectangleY = (int)position.Y;

            if (pokeball.RectangleY>310)
            {
                pokeball.IsVisible = false;
                isDone = true;
            }

            if (pokemonSprite.Rectangle.Width < Setting.PokemonSpriteSize)
            {
                pokemonSprite.RectangleWidth += scaleSpeed;
                pokemonSprite.RectangleHeight += scaleSpeed;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeball.Draw(spriteBatch, rotation, new Vector2(pokeball.Texture.Width/2, pokeball.Texture.Height/2));
            
        }
    }
}
