using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.Engine
{
    public class Utility
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            int rng = random.Next(min, max);
            return rng;
        }
    }
}
