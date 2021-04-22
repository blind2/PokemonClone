using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Model;

namespace PokemonClone.PokemonData
{
    public class HealthBar : IVisible
    {
        private Pokemon pokemon;
        private Sprite frontBar;
        private Sprite backBar;

        public HealthBar(Pokemon pokemon, Sprite frontBar)
        {
            this.pokemon = pokemon;
            this.frontBar = frontBar;
        }

        public void LoadContent(ContentManager content)
        {
            backBar = new Sprite(content.Load<Texture2D>("Color\\black"),
                new Rectangle(frontBar.Rectangle.X, frontBar.Rectangle.Y, frontBar.Rectangle.Width, frontBar.Rectangle.Height));
        }

        public void Update(GameTime gameTime)
        {
            int width = backBar.Rectangle.Width * pokemon.PokemonStats.CurrentHp / pokemon.PokemonStats.Hp;

            frontBar.Rectangle = new Rectangle(frontBar.RectangleX, frontBar.RectangleY, width, frontBar.Rectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            backBar.Draw(spriteBatch);
            frontBar.Draw(spriteBatch);
        }

        public void SetVisibility(bool visible)
        {
            frontBar.SetVisibility(visible);
            backBar.SetVisibility(visible);
        }
    }
}
