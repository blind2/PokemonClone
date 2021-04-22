using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokemonClone.Engine
{
    public class Label
    {
        private SpriteFont font;
        private Vector2 position;
        private Color color;
        private bool isVisible = true;
        private string textName;

        public Label(SpriteFont font, Vector2 position, Color color)
        {
            this.font = font;
            this.position = position;
            this.color = color;
        }

        public Label(SpriteFont font, Vector2 position, Color color, string textName)
        {
            this.font = font;
            this.position = position;
            this.color = color;
            this.textName = textName;
        }

        public bool SetVisibility(bool visible)
        {
            return isVisible = visible;
        }

        public void Draw(SpriteBatch spritebatch, float size)
        {
            if (isVisible)
            {
                spritebatch.DrawString(font, textName, position, color, 0, Vector2.Zero, size, SpriteEffects.None, 0);
            }
        }

        public void Draw(SpriteBatch spritebatch, string text, float size)
        {
            if (isVisible)
            {              
                spritebatch.DrawString(font, text, position, color, 0, Vector2.Zero, size, SpriteEffects.None, 0);              
            }
            
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public SpriteFont Font
        {
            get { return font; }
        }
    }
}
