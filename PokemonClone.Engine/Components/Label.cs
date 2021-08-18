using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Models;


namespace PokemonClone.Engine.Components
{
    public class Label : IComponent
    {
        public SpriteFont Font { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; } = new Color(48, 48, 48);
        public string Text { get; set; } = "no text found";
        public float Size { get; set; } = 1f;
        public bool IsVisible { get; set; } = true;

        
        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.DrawString(Font, Text, Position, Color, 0, Vector2.Zero, Size, SpriteEffects.None, 0);
            }
            
        }
    }
}
