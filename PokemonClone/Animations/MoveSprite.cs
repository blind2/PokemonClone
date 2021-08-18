using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Components;
using PokemonClone.Model;
using System;

namespace PokemonClone.Animations
{
    internal class MoveSprite : IAnimation
    {
        private Sprite sprite;
        private int speed;
        private int endPosition;
        private bool isDone;

        public bool IsDone => isDone;

        public MoveSprite(Sprite sprite, int speed, int endPosition)
        {
            this.sprite = sprite;
            this.speed = speed;
            this.endPosition = endPosition;
        }

        public void MoveRight(GameTime gameTime)
        {
            if (sprite.RectangleX < endPosition)
            {
                sprite.RectangleX += speed;
                isDone = false;
            }
            else
            {
                isDone = true;
            }
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            if (sprite.Rectangle.X > endPosition)
            {
                sprite.RectangleX -= speed;
                isDone = false;
            }
            else
            {
                isDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
