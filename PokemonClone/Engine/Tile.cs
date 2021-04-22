using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.Engine
{
    public  class Tile
    {
        protected Vector2 position;
        protected bool solid;
        private int index;
        private float timer;

        public Tile(Vector2 position, int index, bool solid)
        {
            this.position = position;
            this.index = index;
            this.solid = solid;
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
        public  void Draw(SpriteBatch spriteBatch, TextureRegion textureRegion)
        {
            textureRegion.Draw(spriteBatch, position, index);
        }
        
        public Vector2 Position
        {
            get { return position; }
        }

        public bool Solid
        {
            get { return solid; }
        }
    }
}
