using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Engine.MapEditor
{
    public class Tile
    {
        public Vector2 Position { get; protected set; }
        public bool Solid { get; protected set; }

        private int index;
        private float timer;

        public Tile(Vector2 position, int index, bool solid)
        {
            this.Position = position;
            this.index = index;
            this.Solid = solid;
        }


        public void Animate(int min, int max, float delay, GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > delay)
            {
                if (index >= max)
                {
                    index = min;
                }
                else
                {
                    index++;
                }

                timer = 0;
            }


        }
        public void Draw(SpriteBatch spriteBatch, TextureRegion textureRegion)
        {
            textureRegion.Draw(spriteBatch, Position, index);
        }
    }
}

