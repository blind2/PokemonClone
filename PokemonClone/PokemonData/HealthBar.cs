using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Engine.Components;
using PokemonClone.Model;

namespace PokemonClone.PokemonData
{
    public class HealthBar : IVisible
    {
        private Pokemon pokemon;
        private Sprite frontBar;
        private Sprite backBar;
        private int finalWidth = 0;
        public bool IsFinished { get; private set; } = false;

        public HealthBar(Pokemon pokemon, Sprite frontBar)
        {
            this.pokemon = pokemon;
            this.frontBar = frontBar;
        }

        public void LoadContent(ContentManager content)
        {
            backBar = new Sprite(content.Load<Texture2D>("Color\\black"),
                new Rectangle(frontBar.Rectangle.X, frontBar.RectangleY, frontBar.RectangleWidth, frontBar.RectangleHeight));
        }

        public void Update(GameTime gameTime)
        {
            IsFinished = false;
            //Update hp bar overtime
            int width = backBar.RectangleWidth * pokemon.PokemonStats.CurrentHp / pokemon.PokemonStats.Hp;

            if (frontBar.RectangleWidth != width)
            {
                frontBar.Rectangle = new Rectangle(frontBar.RectangleX, frontBar.RectangleY, frontBar.Rectangle.Width - 1, frontBar.Rectangle.Height);
            }
            else
            {
                IsFinished = true;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            backBar.Draw(spriteBatch);
            frontBar.Draw(spriteBatch);
        }

        public void SetVisibility(bool visible)
        {
            frontBar.IsVisible = visible;
            backBar.IsVisible = visible;
        }
    }
}
