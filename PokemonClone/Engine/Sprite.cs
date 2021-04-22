using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Engine
{
    public class Sprite
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private bool isVisible = true;


        public Sprite(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;       
        }


        public bool SetVisibility(bool visible)
        {
            return isVisible = visible;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, rectangle, Color.White);
            }
            
        }

        public void Draw(SpriteBatch spritebtach, int border)
        {
            spritebtach.DrawRoundedRect(rectangle, texture, border, Color.White);
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public int RectangleX
        {
            get { return rectangle.X; }
            set { rectangle.X = value; }
        }
        public int RectangleY
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }
    }
}
