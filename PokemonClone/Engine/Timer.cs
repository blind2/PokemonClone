using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.Engine
{
    public class Timer
    {
        private float timer;

        public  bool SetTimer(float interval, GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                timer = 0;
                return true;

            }
            return false;
        }
    }
}
