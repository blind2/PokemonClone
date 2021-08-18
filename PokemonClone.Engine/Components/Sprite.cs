using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Extensions;
using PokemonClone.Engine.Models;
using System;

namespace PokemonClone.Engine.Components
{
    public class Sprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public bool IsVisible { get; set; } = true;

        private Rectangle rectangle;

        public Sprite(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.rectangle = rectangle;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(Texture, rectangle, Color.White);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int border)
        {
            if (IsVisible)
            {
                spriteBatch.DrawNinePatchRect(rectangle, Texture, border, Color.White);
            }
        }

        public void Draw(SpriteBatch spriteBatch, float rotation, Vector2 origin)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(Texture, rectangle, null, Color.White, rotation, origin, SpriteEffects.None, 0);
            }        
        }


        public Rectangle Rectangle
        {
            get => rectangle;
            set => rectangle = value;
        }

        public int RectangleX
        {
            get => rectangle.X;
            set => rectangle.X = value;
        }

        public int RectangleY
        {
            get => rectangle.Y;
            set => rectangle.Y = value;
        }

        public int RectangleWidth
        {
            get => rectangle.Width;
            set => rectangle.Width = value;
        }

        public int RectangleHeight
        {
            get => rectangle.Height;
            set => rectangle.Height = value;
        }
    }
}
