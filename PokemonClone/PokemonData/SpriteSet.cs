using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.PokemonData
{
    public class SpriteSet
    {
        private Texture2D frontSprite;
        private Texture2D backSprite;

        public SpriteSet(Texture2D frontSprite, Texture2D backSprite)
        {
            this.frontSprite = frontSprite;
            this.backSprite = backSprite;
        }

        public Texture2D FrontSprite
        {
            get { return frontSprite; }
        }

        public Texture2D BackSprite
        {
            get { return backSprite; }
        }
    }
}
